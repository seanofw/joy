using System;
using System.Threading;
using Joy.Config;
using Joy.Forms;

namespace Joy.SyntaxHighlighting
{
	public class FullRestylerManager
	{
		private readonly TextEditorControl _owner;
		private readonly Configurator _configurator;
		private readonly ScintillaNET.Scintilla _editor;
		private Thread _workerThread;

		private ManualResetEventSlim _run = new ManualResetEventSlim();
		private bool _shouldCancel;
		private bool _abortAfterCancel;
		private bool _retryAfterCancel;
		private bool _isRunning;
		private object _stateLock = new object();

		public event EventHandler<RestyleStartedEventArgs> Started
		{
			add { _started.Add(value); }
			remove { _started.Remove(value); }
		}
		private ThreadSafeEventHandler<RestyleStartedEventArgs> _started = new ThreadSafeEventHandler<RestyleStartedEventArgs>();

		public event EventHandler<RestyleFinishedEventArgs> Finished
		{
			add { _finished.Add(value); }
			remove { _finished.Remove(value); }
		}
		private ThreadSafeEventHandler<RestyleFinishedEventArgs> _finished = new ThreadSafeEventHandler<RestyleFinishedEventArgs>();

		public FullRestylerManager(TextEditorControl owner, ScintillaNET.Scintilla editor, Configurator configurator)
		{
			_owner = owner;
			_editor = editor;
			_configurator = configurator;

			_workerThread = new Thread(WorkerThreadStart);
			_workerThread.Start();
		}

		public void EnqueueFullRestyle()
		{
			lock (_stateLock)
			{
				if (_isRunning)
				{
					_shouldCancel = true;
					_retryAfterCancel = !_abortAfterCancel;
				}
				_run.Set();
			}
		}

		public void CancelAndAbort()
		{
			lock (_stateLock)
			{
				_retryAfterCancel = false;
				_abortAfterCancel = true;
				_shouldCancel = true;
				_run.Set();
			}
		}

		private void WorkerThreadStart()
		{
			using (var backgroundThread = new SmileLibInterop.BackgroundThread())
			{
				System.Diagnostics.Debug.WriteLine("Worker thread started.");

				bool doRestart, abort = false;

				while (!abort)
				{
					System.Diagnostics.Debug.WriteLine("Worker thread is waiting.");
					_run.Wait();
					System.Diagnostics.Debug.WriteLine("Worker thread is running.");

					_started.Raise(new RestyleStartedEventArgs(false));

				retry:
					lock (_stateLock)
					{
						_isRunning = true;
					}

					try
					{
						FullRestyler fullRestyler = new FullRestyler(_owner, _editor, () => _shouldCancel, _configurator);
						fullRestyler.Restyle();
					}
					catch (Exception e)
					{
						// Should never get here, but just in case, we swallow errors
						// and hope a later pass will restyle the content better.
						System.Diagnostics.Debug.WriteLine("Warning: FullRestyler.Restyle() crashed: " + e.Message);
					}

					lock (_stateLock)
					{
						abort = _abortAfterCancel;
						doRestart = _retryAfterCancel;

						_isRunning = false;
						_shouldCancel = false;
						_abortAfterCancel = false;
						_retryAfterCancel = false;

						_run.Reset();
					}

					if (doRestart)
					{
						_started.Raise(new RestyleStartedEventArgs(true));
						goto retry;
					}

					_finished.Raise(new RestyleFinishedEventArgs(!abort));
				}

				System.Diagnostics.Debug.WriteLine("Worker thread is exiting.");
			}
		}
	}
}

using System;
using System.Collections.Immutable;

namespace Joy.SyntaxHighlighting
{
	/// <summary>
	/// This helper class makes writing thread-safe multiple-subscription event handlers easier
	/// by implementing all of the thread-safe mechanics.
	/// </summary>
	/// <typeparam name="T">The type of event arguments to raise.</typeparam>
	public class ThreadSafeEventHandler<T>
		where T : EventArgs
	{
		private ImmutableList<EventHandler<T>> _handlers = ImmutableList<EventHandler<T>>.Empty;

		public void Add(EventHandler<T> eventHandler)
			=> _handlers = _handlers.Add(eventHandler);

		public void Remove(EventHandler<T> eventHandler)
			=> _handlers = _handlers.RemoveAll(d => d == eventHandler);

		public void Raise(T args)
		{
			ImmutableList<EventHandler<T>> handlers = _handlers;	// Not actually needed, but we're proving a point.

			foreach (EventHandler<T> handler in handlers)
			{
				handler.Invoke(this, args);
			}
		}
	}
}

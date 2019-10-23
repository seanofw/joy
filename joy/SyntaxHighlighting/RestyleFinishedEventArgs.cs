using System;

namespace Joy.SyntaxHighlighting
{
	public class RestyleFinishedEventArgs : EventArgs
	{
		public bool FinishedSuccessfully { get; }

		internal RestyleFinishedEventArgs(bool finishedSuccessfully)
		{
			FinishedSuccessfully = finishedSuccessfully;
		}
	}
}

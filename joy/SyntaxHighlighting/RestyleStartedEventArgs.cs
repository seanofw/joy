using System;

namespace Joy.SyntaxHighlighting
{
	public class RestyleStartedEventArgs : EventArgs
	{
		public bool Restarting { get; }

		internal RestyleStartedEventArgs(bool restarting)
		{
			Restarting = restarting;
		}
	}
}

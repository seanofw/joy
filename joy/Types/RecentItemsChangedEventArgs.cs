using System;

namespace Joy.Types
{
	public class RecentItemsChangedEventArgs : EventArgs
	{
		public readonly RecentItemsChangeAction Action;

		public RecentItemsChangedEventArgs(RecentItemsChangeAction action)
		{
			Action = action;
		}
	}
}
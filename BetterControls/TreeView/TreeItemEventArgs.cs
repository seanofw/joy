using System;

namespace BetterControls.TreeView
{
	public class TreeItemEventArgs : EventArgs
	{
		public ITreeItem TreeItem { get; }

		public TreeItemEventArgs(ITreeItem treeItem)
		{
			TreeItem = treeItem;
		}
	}
}

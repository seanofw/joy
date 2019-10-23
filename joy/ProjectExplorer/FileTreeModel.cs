using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Joy.ProjectExplorer
{
	/*
	public class FileTreeModel : ITreeModel
	{
		private BackgroundWorker _worker;
		private List<ItemBase> _itemsToRead;
		private Dictionary<string, List<ItemBase>> _cache = new Dictionary<string, List<ItemBase>>();

		public FileTreeModel()
		{
			_itemsToRead = new List<ItemBase>();

			_worker = new BackgroundWorker();
			_worker.WorkerReportsProgress = true;
			_worker.DoWork += ReadFilesProperties;
			_worker.ProgressChanged += ProgressChanged;
		}

		private void ReadFilesProperties(object sender, DoWorkEventArgs e)
		{
			while (_itemsToRead.Count > 0)
			{
				ItemBase item = _itemsToRead[0];
				_itemsToRead.RemoveAt(0);

				if (item is FolderItem)
				{
					DirectoryInfo info = new DirectoryInfo(item.ItemPath);
					item.Date = info.CreationTime;
				}
				else if (item is FileItem)
				{
					FileInfo info = new FileInfo(item.ItemPath);
					item.Size = info.Length;
					item.Date = info.CreationTime;
				}
				_worker.ReportProgress(0, item);
			}
		}

		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			OnNodesChanged(e.UserState as ItemBase);
		}

		private TreePath GetPath(ItemBase item)
		{
			if (item == null)
				return TreePath.Empty;
			else
			{
				Stack<object> stack = new Stack<object>();
				while (item != null)
				{
					stack.Push(item);
					item = item.Parent;
				}
				return new TreePath(stack.ToArray());
			}
		}

		public System.Collections.IEnumerable GetChildren(TreePath treePath)
		{
			List<ItemBase> items = null;
			if (treePath.IsEmpty())
			{
				items = new List<ItemBase>();
				items.Add(new RootItem("Z:\\Dropbox\\prog\\smile", this));
				return items;
			}

			ItemBase parent = treePath.LastNode as ItemBase;
			if (parent != null)
			{
				if (_cache.ContainsKey(parent.ItemPath))
					items = _cache[parent.ItemPath];
				else
				{
					items = new List<ItemBase>();
					try
					{
						foreach (string str in Directory.GetDirectories(parent.ItemPath))
							items.Add(new FolderItem(str, parent, this));
						foreach (string str in Directory.GetFiles(parent.ItemPath))
						{
							FileItem item = new FileItem(str, parent, this);
							items.Add(item);
						}
					}
					catch (IOException)
					{
						return null;
					}
					_cache.Add(parent.ItemPath, items);
					_itemsToRead.AddRange(items);
					if (!_worker.IsBusy)
						_worker.RunWorkerAsync();
				}
			}

			return items;
		}

		public bool IsLeaf(TreePath treePath)
		{
			return treePath.LastNode is FileItem;
		}

		public event EventHandler<TreeModelEventArgs> NodesChanged;
		internal void OnNodesChanged(ItemBase item)
		{
			if (NodesChanged != null)
			{
				TreePath path = GetPath(item.Parent);
				NodesChanged(this, new TreeModelEventArgs(path, new object[] { item }));
			}
		}

		public event EventHandler<TreeModelEventArgs> NodesInserted;
		public event EventHandler<TreeModelEventArgs> NodesRemoved;
		public event EventHandler<TreePathEventArgs> StructureChanged;

		internal void OnStructureChanged()
		{
			StructureChanged?.Invoke(this, new TreePathEventArgs());
		}
	}
	*/
}

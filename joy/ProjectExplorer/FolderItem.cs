using System.IO;

namespace Joy.ProjectExplorer
{
	/*
	public class FolderItem : ItemBase
	{
		public override string Name
		{
			get => Path.GetFileName(ItemPath);
			set
			{
				string dir = Path.GetDirectoryName(ItemPath);
				string destination = Path.Combine(dir, value);
				Directory.Move(ItemPath, destination);
				ItemPath = destination;
			}
		}

		public FolderItem(string name, ItemBase parent, FileTreeModel owner)
		{
			ItemPath = name;
			Parent = parent;
			Owner = owner;
		}
	}
	*/
}

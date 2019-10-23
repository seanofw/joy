using System.IO;

namespace Joy.ProjectExplorer
{
	/*
	public class FileItem : ItemBase
	{
		public override string Name
		{
			get => Path.GetFileName(ItemPath);
			set
			{
				string dir = Path.GetDirectoryName(ItemPath);
				string destination = Path.Combine(dir, value);
				File.Move(ItemPath, destination);
				ItemPath = destination;
			}
		}

		public FileItem(string name, ItemBase parent, FileTreeModel owner)
		{
			ItemPath = name;
			Parent = parent;
			Owner = owner;
		}
	}
	*/
}

using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Joy.ProjectExplorer;
using BetterControls.TreeView;

namespace Joy.Forms
{
	public partial class ProjectExplorerControl : DockContent
	{
		public MainForm MainForm { get; }

		public ProjectExplorerControl(MainForm mainForm)
		{
			MainForm = mainForm;

			InitializeComponent();

			Text = "Project Explorer";

			DockAreas = DockAreas.Float
				| DockAreas.DockLeft | DockAreas.DockRight
				| DockAreas.DockTop | DockAreas.DockBottom;

			MainForm.ExtendThemeToToolStrip(ButtonToolStrip);

			FileTreeView.DataSource = new SimpleTreeItemDataSource
			{
				new SimpleTreeItem("C:\\", SilkIcons.Drive)
				{
					new SimpleTreeItem("Windows", SilkIcons.Folder),
					new SimpleTreeItem("Program Files", SilkIcons.Folder),
					new SimpleTreeItem("Users", SilkIcons.Folder),
				},
				new SimpleTreeItem("D:\\", SilkIcons.Drive)
				{
					new SimpleTreeItem("My Documents", SilkIcons.Folder),
					new SimpleTreeItem("Dropbox", SilkIcons.Folder),
				},
				new SimpleTreeItem("E:\\", SilkIcons.Drive)
				{
					new SimpleTreeItem("Install", SilkIcons.Folder),
					new SimpleTreeItem("TaxProFiles", SilkIcons.Folder),
				}
			};
			FileTreeView.IndentSize = 8;
		}
	}
}

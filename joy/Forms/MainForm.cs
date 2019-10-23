using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Joy.Config;
using Joy.Types;
using System.Linq;
using System.Collections.Generic;
using BetterControls.MessageBox;
using BetterControls.Themes;

namespace Joy.Forms
{
	public partial class MainForm : Form
	{
		#region Properties and fields

		private readonly VS2015LightTheme _vs2015LightTheme = new VS2015LightTheme();
		private readonly VS2015DarkTheme _vs2015DarkTheme = new VS2015DarkTheme();
		private readonly VS2015BlueTheme _vs2015BlueTheme = new VS2015BlueTheme();

		private FindControl _findControl;
		private ReplaceControl _replaceControl;

		public FindInfo FindInfo { get; set; }
		public ReplaceInfo ReplaceInfo { get; set; }

		public string ProjectFolder { get; set; }

		public readonly Configurator Configurator;
		public readonly Dispatcher Dispatcher;

		public TextEditorControl ActiveTextEditor =>
			(DockPanel.ActiveDocument is TextEditorControl textEditorControl) ? textEditorControl : null;

		#endregion

		#region Construction

		public MainForm()
		{
			InitializeComponent();

			Configurator = new Configurator();
			Dispatcher = new Dispatcher(this, Configurator);

			Configurator.LoadConfigFromRegistry();
			Configurator.IndicatorConfig = new IndicatorConfig(DefaultStyles.LightThemeIndicators);
			Configurator.TextEditorConfigChanged += Configurator_TextEditorConfigChanged;
			Configurator.StyleConfigChanged += Configurator_StyleConfigChanged;
			Configurator.IndicatorConfigChanged += Configurator_IndicatorConfigChanged;
			Configurator.AppConfigChanged += Configurator_AppConfigChanged;

			ApplyTheme();

			DockPanel.Dock = DockStyle.Fill;

			ProjectExplorerControl projectExplorerControl = new ProjectExplorerControl(this);
			projectExplorerControl.Show(DockPanel, DockState.DockRight);

			DockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;

			UpdateUIToMatchConfig();
			Dispatcher.NewCommand();
		}

		#endregion

		#region Theming support

		private readonly VisualStudioToolStripExtender _toolStripExtender = new VisualStudioToolStripExtender
		{
			DefaultRenderer = new ToolStripProfessionalRenderer()
		};

		public void ExtendThemeToToolStrip(ToolStrip toolStrip)
		{
			ThemeBase themeBase = GetCurrentThemeBase();
			_toolStripExtender.SetStyle(toolStrip, VisualStudioToolStripExtender.VsVersion.Vs2015, themeBase);
		}

		private ThemeBase GetCurrentThemeBase()
		{
			ThemeKind theme = Configurator.AppConfig.Theme;

			ThemeBase themeBase =
				(theme == ThemeKind.Blue ? (ThemeBase)_vs2015BlueTheme
				: theme == ThemeKind.Dark ? (ThemeBase)_vs2015DarkTheme
				: (ThemeBase)_vs2015LightTheme);

			return themeBase;
		}

		private void ApplyTheme()
		{
			ThemeBase themeBase = GetCurrentThemeBase();
			DockPanel.Theme = themeBase;

			ExtendThemeToToolStrip(MainMenu);
			ExtendThemeToToolStrip(MainStatusStrip);

			switch (Configurator.AppConfig.Theme)
			{
				case ThemeKind.Light:
					BetterControlsTheme.Current = BetterControlsLightTheme.Instance;
					break;
				case ThemeKind.Dark:
					BetterControlsTheme.Current = BetterControlsDarkTheme.Instance;
					break;
				case ThemeKind.Blue:
					BetterControlsTheme.Current = BetterControlsBlueTheme.Instance;
					break;
				default:
					BetterControlsTheme.Current = BetterControlsDefaultTheme.Instance;
					break;
			}
		}

		#endregion

		#region Miscellaneous internals

		private void UpdateUIToMatchConfig()
		{
			TextEditorConfig textEditorConfig = Configurator.TextEditorConfig;

			Text_EnableSmartIndent.Checked = textEditorConfig.SmartIndent;
			View_ShowWhitespace.Checked = textEditorConfig.ShowWhitespace;
			View_ShowLineNumbers.Checked = textEditorConfig.ShowLineNumbers;
			View_WordWrap.Checked = textEditorConfig.WordWrap;

			double fontSize = textEditorConfig.MainFontSize;
			double zoomedFontSize = fontSize + textEditorConfig.Zoom;
			if (zoomedFontSize < 2) zoomedFontSize = 2;
			long zoomPercentage = (long)(zoomedFontSize / fontSize * 100 + 0.5);
			ZoomStatusLabel.Text = "Zoom: " + zoomPercentage + "%";
		}

		private void RestyleAllTextEditors()
		{
			foreach (IDockContent dockContent in DockPanel.Documents)
			{
				if (dockContent is TextEditorControl textEditorControl)
				{
					textEditorControl.ApplyStyles(Configurator.StyleConfig, Configurator.TextEditorConfig);
					textEditorControl.ApplyIndicatorStyles(Configurator.IndicatorConfig);
				}
			}
		}

		#endregion

		#region Miscellaneous event handlers

		private void Configurator_AppConfigChanged(object sender, EventArgs e)
			=> UpdateUIToMatchConfig();
		private void Configurator_TextEditorConfigChanged(object sender, EventArgs e)
			=> UpdateUIToMatchConfig();
		private void Configurator_StyleConfigChanged(object sender, EventArgs e)
			=> RestyleAllTextEditors();
		private void Configurator_IndicatorConfigChanged(object sender, EventArgs e)
			=> RestyleAllTextEditors();

		private void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
			=> ActiveTextEditor?.NeedStatusUpdate();

		private void TextEditorControl_StatusUpdate(object sender, StatusEventArgs e)
		{
			if (!ReferenceEquals(sender, DockPanel.ActiveDocument))
				return;

			LineAndColumnStatusLabel.Text = $"Line {e.Line + 1}, Col {e.Column + 1}, Char {e.CharOfLine + 1}";
			LengthStatusLabel.Text = $"Length: {e.Chars}";
			LinesStatusLabel.Text = $"Lines: {e.Lines}";
		}

		#endregion

		#region Menu event handlers

		private void File_OpenProjectFolder_Click(object sender, EventArgs e) => Dispatcher.OpenProjectFolderCommand();
		private void File_CloseProjectFolder_Click(object sender, EventArgs e) => Dispatcher.CloseProjectFolderCommand();
		private void File_New_Click(object sender, EventArgs e) => Dispatcher.NewCommand();
		private void File_Open_Click(object sender, EventArgs e) => Dispatcher.OpenCommand();
		private void File_Save_Click(object sender, EventArgs e) => Dispatcher.SaveCommand();
		private void File_SaveAs_Click(object sender, EventArgs e) => Dispatcher.SaveAsCommand();
		private void File_Close_Click(object sender, EventArgs e) => Dispatcher.CloseCommand();
		private void File_Exit_Click(object sender, EventArgs e) => Dispatcher.ExitCommand();

		private void Edit_Undo_Click(object sender, EventArgs e) => Dispatcher.UndoCommand();
		private void Edit_Redo_Click(object sender, EventArgs e) => Dispatcher.RedoCommand();
		private void Edit_Cut_Click(object sender, EventArgs e) => Dispatcher.CutCommand();
		private void Edit_Copy_Click(object sender, EventArgs e) => Dispatcher.CopyCommand();
		private void Edit_Paste_Click(object sender, EventArgs e) => Dispatcher.PasteCommand();
		private void Edit_Delete_Click(object sender, EventArgs e) => Dispatcher.DeleteCommand();
		private void Edit_SelectAll_Click(object sender, EventArgs e) => Dispatcher.SelectAllCommand();

		private void Edit_Find_Click(object sender, EventArgs e) => Dispatcher.FindCommand();
		private void Edit_FindNext_Click(object sender, EventArgs e) => Dispatcher.FindNextCommand();
		private void Edit_FindPrevious_Click(object sender, EventArgs e) => Dispatcher.FindPreviousCommand();
		private void Edit_FindAndReplace_Click(object sender, EventArgs e) => Dispatcher.ReplaceCommand();

		private void Text_MakeUppercase_Click(object sender, EventArgs e) => Dispatcher.MakeUppercaseCommand();
		private void Text_MakeLowercase_Click(object sender, EventArgs e) => Dispatcher.MakeLowercaseCommand();
		private void Text_Indent_Click(object sender, EventArgs e) => Dispatcher.IndentCommand();
		private void Text_Unindent_Click(object sender, EventArgs e) => Dispatcher.UnindentCommand();
		private void Text_EnableSmartIndent_Click(object sender, EventArgs e)
			=> Dispatcher.SmartIndentCommand(!Configurator.TextEditorConfig.SmartIndent);
		private void Text_CommentOut_Click(object sender, EventArgs e) => Dispatcher.CommentOutCommand();
		private void Text_UncommentBackIn_Click(object sender, EventArgs e) => Dispatcher.UncommentBackInCommand();

		private void View_ShowWhitespace_Click(object sender, EventArgs e)
			=> Dispatcher.WhitespaceCommand(!Configurator.TextEditorConfig.ShowWhitespace);
		private void View_ShowLineNumbers_Click(object sender, EventArgs e)
			=> Dispatcher.LineNumbersCommand(!Configurator.TextEditorConfig.ShowLineNumbers);
		private void View_WordWrap_Click(object sender, EventArgs e)
			=> Dispatcher.WordWrapCommand(!Configurator.TextEditorConfig.WordWrap);
		private void View_ZoomIn_Click(object sender, EventArgs e) => Dispatcher.ZoomInCommand();
		private void View_ZoomOut_Click(object sender, EventArgs e) => Dispatcher.ZoomOutCommand();
		private void View_ZoomReset_Click(object sender, EventArgs e) => Dispatcher.ZoomResetCommand();

		private void Run_RunWithDebugger_Click(object sender, EventArgs e) => Dispatcher.RunWithDebuggerCommand();
		private void Run_Run_Click(object sender, EventArgs e) => Dispatcher.RunCommand();

		private void Tools_Options_Click(object sender, EventArgs e) => Dispatcher.OptionsCommand();

		private void Window_CloseAllDocuments_Click(object sender, EventArgs e)
			=> Dispatcher.CloseAllCommand();
		private void Window_CloseAllButThis_Click(object sender, EventArgs e)
			=> Dispatcher.CloseAllButThisCommand();

		private void Help_AboutJoy_Click(object sender, EventArgs e) => Dispatcher.AboutCommand();

		#endregion

		#region Public methods

		public bool CloseAllDocuments()
		{
			return CloseManyDocuments(d => true);
		}

		public bool CloseAllButThisDocument()
		{
			IDockContent activeDocument = DockPanel.ActiveDocument;
			return CloseManyDocuments(d => d != activeDocument);
		}

		private bool CloseManyDocuments(Func<IDockContent, bool> filter)
		{
			// Harden the initial set, since we're going to be modifying it.
			IDockContent[] documents = DockPanel.Documents.ToArray();

			foreach (IDockContent dockContent in documents)
			{
				if (!(dockContent is TextEditorControl textEditorControl))
					continue;
				if (!filter(dockContent))
					continue;

				if (textEditorControl.IsModified)
				{
					DialogResult result = BetterMessageBox
						.Owner(this)
						.Message($"\"{textEditorControl.Filename}\" has not yet been saved.\r\nWhat do you want to do with it?")
						.Caption("Warning")
						.Button("Save changes", DialogResult.OK, true)
						.Button("Discard changes", DialogResult.Ignore)
						.Button("Cancel", DialogResult.Cancel)
						.StandardImage(StandardImageKind.Warning)
						.Show();
					switch (result)
					{
						case DialogResult.OK:
							if (!textEditorControl.Save())
								return false;
							textEditorControl.Close();
							break;
						case DialogResult.Cancel:
							return false;
						case DialogResult.Ignore:
							textEditorControl.IsModified = false;
							textEditorControl.Close();
							return false;
					}
				}
				else
				{
					textEditorControl.Close();
				}
			}

			return true;
		}

		public bool EnsureAllDocumentsAreSavedBeforeRestart()
		{
			foreach (IDockContent dockContent in DockPanel.Documents)
			{
				if (!(dockContent is TextEditorControl textEditorControl))
					continue;

				if (textEditorControl.IsModified)
				{
					DialogResult result = BetterMessageBox
						.Owner(this)
						.Message($"\"{textEditorControl.Filename}\" has not yet been saved.\r\nWhat do you want to do with it?")
						.Caption("Warning")
						.Button("Save changes", DialogResult.OK, true)
						.Button("Discard changes", DialogResult.Ignore)
						.Button("Cancel", DialogResult.Cancel)
						.StandardImage(StandardImageKind.Warning)
						.Show();
					switch (result)
					{
						case DialogResult.OK:
							if (!textEditorControl.Save())
								return false;
							break;
						case DialogResult.Cancel:
							return false;
						default:
							break;
					}
				}
			}

			foreach (IDockContent dockContent in DockPanel.Documents)
			{
				if (!(dockContent is TextEditorControl textEditorControl))
					continue;
				textEditorControl.IsModified = false;
			}

			return true;
		}

		public void ShowFindPanel()
		{
			if (_findControl == null)
			{
				_findControl = new FindControl(FindInfo, Configurator, Dispatcher);
				_findControl.Show(this);
				_findControl.Location = new Point(Location.X + Width - _findControl.Width - 32, Location.Y + 32);
				_findControl.FormClosed += (sender, e) =>
				{
					_findControl = null;
				};
				_findControl.Changed += (sender, args) =>
				{
					FindInfo = args.FindInfo;
				};
			}

			_findControl.Activate();
		}

		public void ShowReplacePanel()
		{
			if (_replaceControl == null)
			{
				_replaceControl = new ReplaceControl(ReplaceInfo, Configurator, Dispatcher);
				_replaceControl.Show(this);
				_replaceControl.Location = new Point(Location.X + Width - _replaceControl.Width - 32, Location.Y + 32);
				_replaceControl.FormClosed += (sender, e) =>
				{
					_replaceControl = null;
				};
				_replaceControl.Changed += (sender, args) =>
				{
					ReplaceInfo = args.ReplaceInfo;
				};
			}

			_replaceControl.Activate();
		}

		public void NewFile()
		{
			AttachTextEditorControl(new TextEditorControl(Configurator));
		}

		public bool OpenFile(string filePath)
		{
			filePath = Path.GetFullPath(filePath);

			TextEditorControl lastEmptyDocument = null;
			foreach (IDockContent document in DockPanel.Documents)
			{
				if (!(document is TextEditorControl textEditorControl))
					continue;

				if (!textEditorControl.IsModified && textEditorControl.IsNew)
				{
					lastEmptyDocument = textEditorControl;
				}
				else if (string.Equals(textEditorControl.FullPathname, filePath, StringComparison.InvariantCultureIgnoreCase))
				{
					textEditorControl.Activate();
					return true;
				}
			}
			if (lastEmptyDocument != null)
				lastEmptyDocument.Close();

			TextEditorControl newTextEditorControl = TextEditorControl.FromFile(filePath, Configurator);
			if (newTextEditorControl == null)
				return false;

			AttachTextEditorControl(newTextEditorControl);
			return true;
		}

		private void AttachTextEditorControl(TextEditorControl textEditorControl)
		{
			textEditorControl.Show(DockPanel, DockState.Document);
			textEditorControl.StatusUpdate += TextEditorControl_StatusUpdate;
		}

		#endregion

		private void FileMenu_DropDownOpening(object sender, EventArgs e)
		{
			// This code is somewhat complicated, but is designed to ensure that no
			// matter how many items are added or removed from the file menu, it all
			// runs in O(n) time.

			// Temporarily remove the "File_Exit" item from the file menu.
			ToolStripItem fileExit = File_Exit;
			FileMenu.DropDownItems.Remove(fileExit);

			// Now find the indexes of any existing "Recent_*" items in the file menu.
			List<int> indexesToRemove = new List<int>();
			for (int i = 0; i < FileMenu.DropDownItems.Count; i++)
			{
				if (FileMenu.DropDownItems[i].Name.StartsWith("File_Recent_"))
					indexesToRemove.Add(i);
			}

			// Remove all of those items that start with "File_Recent_*" in *reverse*
			// order, which should hopefully ensure that each Remove() call runs in O(1)
			// time, since they should now be the last items in the menu.  That said,
			// even if they don't, this runs in at worst O(n) time relative to the total
			// size of the file menu.
			for (int i = indexesToRemove.Count - 1; i >= 0; i--)
			{
				FileMenu.DropDownItems.RemoveAt(indexesToRemove[i]);
			}

			// Remove any leftover separator bars from the end of the file menu that
			// could have appeared above or below the recent list.
			while (true)
			{
				ToolStripItem lastItem = FileMenu.DropDownItems[FileMenu.DropDownItems.Count - 1];
				if (lastItem is ToolStripSeparator)
					FileMenu.DropDownItems.RemoveAt(FileMenu.DropDownItems.Count - 1);
				else break;
			}

			if (Configurator.RecentFiles.Any())
			{
				// Now add a new separator bar.
				FileMenu.DropDownItems.Add(new ToolStripSeparator() { Size = new Size(221, 6) });

				// Add each of the recent files, in order.
				int index = 1;
				foreach (string recentFile in Configurator.RecentFiles.Take(10))
				{
					int proxyIndex = index++;
					string proxyRecentFile = recentFile;
					ToolStripMenuItem menuItem = new ToolStripMenuItem();
					menuItem.Name = "File_Recent_" + proxyIndex;
					menuItem.Size = new Size(224, 22);
					menuItem.Text = "&" + proxyIndex + ": " + Path.GetFileName(recentFile);
					menuItem.Click += ((object sender2, EventArgs e2) => Dispatcher.OpenCommand(proxyRecentFile));
					FileMenu.DropDownItems.Add(menuItem);
				}
			}

			// Now add a final separator bar.
			FileMenu.DropDownItems.Add(new ToolStripSeparator() { Size = new Size(221, 6) });

			// And re-add the Exit menu item.
			FileMenu.DropDownItems.Add(fileExit);
		}
	}
}

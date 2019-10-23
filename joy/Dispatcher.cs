using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BetterControls.MessageBox;
using Joy.Config;
using Joy.Extensions;
using Joy.Forms;

namespace Joy
{
	public class Dispatcher
	{
		#region Properties

		public MainForm MainForm { get; }

		public TextEditorControl ActiveTextEditor => MainForm.ActiveTextEditor;

		public Configurator Configurator { get; }

		#endregion

		#region Constructor

		public Dispatcher(MainForm mainForm, Configurator configurator)
		{
			MainForm = mainForm;
			Configurator = configurator;
		}

		#endregion

		#region File commands

		public void OpenProjectFolderCommand()
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

			folderBrowserDialog.Description = "Choose a project folder to open.";
			folderBrowserDialog.SelectedPath = MainForm.ProjectFolder;
			folderBrowserDialog.ShowNewFolderButton = true;

			if (folderBrowserDialog.ShowDialog(MainForm) == DialogResult.OK)
			{
				MainForm.ProjectFolder = folderBrowserDialog.SelectedPath;
			}
		}

		public void CloseProjectFolderCommand()
		{
			MainForm.ProjectFolder = null;
		}

		public void NewCommand() => MainForm.NewFile();

		public void OpenCommand()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.DefaultExt = ".sm";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.AutoUpgradeEnabled = true;
			openFileDialog.AddExtension = true;
			openFileDialog.DereferenceLinks = true;
			openFileDialog.FileName = string.Empty;
			openFileDialog.Filter = "Smile scripts (*.sm)|*.sm"
				+ "|JSON documents (*.json)|*.json"
				+ "|XML documents (*.xml)|*.xml"
				+ "|Text files (*.txt)|*.txt"
				+ "|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Multiselect = true;
			openFileDialog.Title = "Open File";
			openFileDialog.ValidateNames = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string filePath in openFileDialog.FileNames)
				{
					MainForm.OpenFile(filePath);
				}
			}
		}

		public void OpenCommand(string filePath)
			=> MainForm.OpenFile(filePath);

		public void SaveCommand() => ActiveTextEditor?.Save();

		public void SaveAsCommand() => ActiveTextEditor?.SaveAs();

		public void CloseCommand() => ActiveTextEditor?.Close();

		public void ExitCommand() => MainForm.Close();

		public void Restart()
		{
			if (MainForm.EnsureAllDocumentsAreSavedBeforeRestart())
			{
				Program.ShouldRestart = true;
				MainForm.Close();
			}
		}

		#endregion

		#region Edit commands

		public void UndoCommand() => ActiveTextEditor?.Undo();

		public void RedoCommand() => ActiveTextEditor?.Redo();

		public void CutCommand() => ActiveTextEditor?.Cut();

		public void CopyCommand() => ActiveTextEditor?.Copy();

		public void PasteCommand() => ActiveTextEditor?.Paste();

		public void DeleteCommand() => ActiveTextEditor?.Delete();

		public void SelectAllCommand() => ActiveTextEditor?.SelectAll();

		public void FindCommand() => MainForm.ShowFindPanel();

		public void FindNextCommand()
		{
			if (ActiveTextEditor == null) return;

			ActiveTextEditor.FindNext(MainForm.FindInfo);
			Configurator.RecentFindPatterns.Add(MainForm.FindInfo.Pattern);
		}

		public void FindPreviousCommand()
		{
			if (ActiveTextEditor == null) return;

			ActiveTextEditor.FindPrevious(MainForm.FindInfo);
			Configurator.RecentFindPatterns.Add(MainForm.FindInfo.Pattern);
		}

		public void ReplaceCommand() => MainForm.ShowReplacePanel();

		public void ReplaceNextCommand()
		{
			if (ActiveTextEditor == null) return;

			ActiveTextEditor.ReplaceNext(MainForm.ReplaceInfo);
			Configurator.RecentReplacePatterns.Add(MainForm.ReplaceInfo.Pattern);
			Configurator.RecentReplacements.Add(MainForm.ReplaceInfo.Replacement);
		}

		public void ReplaceAllCommand()
		{
			if (ActiveTextEditor == null) return;

			ActiveTextEditor.ReplaceAll(MainForm.ReplaceInfo);
			Configurator.RecentReplacePatterns.Add(MainForm.ReplaceInfo.Pattern);
			Configurator.RecentReplacements.Add(MainForm.ReplaceInfo.Replacement);
		}

		#endregion

		#region Text Commands

		public void MakeUppercaseCommand() => ActiveTextEditor?.MakeUppercase();

		public void MakeLowercaseCommand() => ActiveTextEditor?.MakeLowercase();

		public void IndentCommand() => ActiveTextEditor?.Indent();

		public void UnindentCommand() => ActiveTextEditor?.Unindent();

		public void SmartIndentCommand(bool smartIndent)
			=> Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithSmartIndent(smartIndent);

		public void CommentOutCommand() => ActiveTextEditor?.CommentOut();

		public void UncommentBackInCommand() => ActiveTextEditor?.UncommentBackIn();

		#endregion

		#region View commands

		public void WhitespaceCommand(bool show)
			=> Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithShowWhitespace(show);

		public void LineNumbersCommand(bool show)
			=> Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithShowLineNumbers(show);

		public void WordWrapCommand(bool wordWrap)
			=> Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithWordWrap(wordWrap);

		public void ZoomInCommand()
		{
			int zoom = Configurator.TextEditorConfig.Zoom;
			if (zoom < 20)
			{
				zoom++;
				Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithZoom(zoom);
			}
		}

		public void ZoomOutCommand()
		{
			int zoom = Configurator.TextEditorConfig.Zoom;
			if (zoom > -10)
			{
				zoom--;
				Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithZoom(zoom);
			}
		}

		public void ZoomResetCommand()
		{
			Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithZoom(0);
		}

		#endregion

		#region Run commands

		public void RunWithDebuggerCommand()
		{
		}

		public void RunCommand()
		{
		}

		#endregion

		#region Tools commands

		public void OptionsCommand()
		{
			OptionsDialog optionsDialog = new OptionsDialog(Configurator, this);
			optionsDialog.StartPosition = FormStartPosition.CenterParent;
			optionsDialog.ShowDialog(MainForm);
		}

		#endregion

		#region Window commands

		public void CloseAllCommand()
			=> MainForm.CloseAllDocuments();

		public void CloseAllButThisCommand()
			=> MainForm.CloseAllButThisDocument();

		#endregion

		#region Help commands

		private static Image _joyIcon =>
			Assembly.GetExecutingAssembly().LoadEmbeddedImage(@"Resources\joy.ico");

		public void AboutCommand()
		{
			BetterMessageBox.Caption("About Joy")
				.Message(@"Joy v1.0

An Integrated Development Environment (IDE) for the Smile Programming Language.

Copyright (c) 2019 by Sean Werkema.  All rights reserved.

Licenses:
- The Smile runtime is licensed under the Apache 2.0 license.
- Sean's Dialog Icons are in the public domain.
- Joy and all other components below are licensed under the MIT license.

Libraries and tools used by Joy:
- C# and .NET 4.5 (by Microsoft)
- Windows Forms (by Microsoft)
- System.Collections.Immutable (by Microsoft)
- Scintilla.NET: https://github.com/jacobslusser/ScintillaNET (by Jacob Slusser)
- DockPanel Suite: http://dockpanelsuite.com (by Weifen Luo)
- Cyotek ColorPicker control:
   https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker (by Richard Moss)
- Json.NET: https://www.newtonsoft.com/json (by Newtonsoft)
- BetterControls: https://github.com/seanofw/better-controls (by Sean Werkema)
- Sean's Dialog Icons: https://github.com/seanofw/icons (by Sean Werkema)
- Smile: https://smile.dev (by Sean Werkema)

For help with Smile, please visit https://smile.dev ; for help with Joy, please
visit https://github.com/seanofw/joy .")
				.Button("Joy!", DialogResult.OK, true)
				.Owner(MainForm)
				.Image(_joyIcon)
				.Show();
		}

		#endregion
	}
}

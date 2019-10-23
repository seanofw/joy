namespace Joy.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.File_OpenProjectFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.File_CloseProjectFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.File_New = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.Edit_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.Edit_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.Edit_Find = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_FindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_FindPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_FindAndReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_MakeUppercase = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_MakeLowercase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.Text_Indent = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_Unindent = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_EnableSmartIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.Text_CommentOut = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_UncommentBackIn = new System.Windows.Forms.ToolStripMenuItem();
            this.View_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.View_GoToLine = new System.Windows.Forms.ToolStripMenuItem();
            this.View_GoToDefinition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.View_ShowWhitespace = new System.Windows.Forms.ToolStripMenuItem();
            this.View_ShowLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.View_WordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.View_CollapseFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.View_CollapseRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.View_CollapseLiterateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.View_CollapseLiterateText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.View_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.View_ExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.View_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.View_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.View_ZoomReset = new System.Windows.Forms.ToolStripMenuItem();
            this.Run_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Run_RunWithDebugger = new System.Windows.Forms.ToolStripMenuItem();
            this.Run_Run = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.Run_SetPrimaryScript = new System.Windows.Forms.ToolStripMenuItem();
            this.Run_NoPrimaryScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.Tools_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_CloseAllDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_CloseAllButThis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Help_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_AboutJoy = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CodeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LineAndColumnStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LengthStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LinesStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.ZoomStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.Text_Menu,
            this.View_Menu,
            this.Run_Menu,
            this.Tools_Menu,
            this.Window_Menu,
            this.Help_Menu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.MdiWindowListItem = this.Window_Menu;
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(984, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_OpenProjectFolder,
            this.File_CloseProjectFolder,
            this.toolStripMenuItem12,
            this.File_New,
            this.File_Open,
            this.File_Save,
            this.File_SaveAs,
            this.File_Close,
            this.toolStripMenuItem5,
            this.File_Exit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            this.FileMenu.DropDownOpening += new System.EventHandler(this.FileMenu_DropDownOpening);
            // 
            // File_OpenProjectFolder
            // 
            this.File_OpenProjectFolder.Name = "File_OpenProjectFolder";
            this.File_OpenProjectFolder.ShortcutKeyDisplayString = "";
            this.File_OpenProjectFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.File_OpenProjectFolder.Size = new System.Drawing.Size(224, 22);
            this.File_OpenProjectFolder.Tag = "";
            this.File_OpenProjectFolder.Text = "Open pro&ject folder...";
            this.File_OpenProjectFolder.Click += new System.EventHandler(this.File_OpenProjectFolder_Click);
            // 
            // File_CloseProjectFolder
            // 
            this.File_CloseProjectFolder.Name = "File_CloseProjectFolder";
            this.File_CloseProjectFolder.Size = new System.Drawing.Size(224, 22);
            this.File_CloseProjectFolder.Text = "Close project folder";
            this.File_CloseProjectFolder.Click += new System.EventHandler(this.File_CloseProjectFolder_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(221, 6);
            // 
            // File_New
            // 
            this.File_New.Name = "File_New";
            this.File_New.ShortcutKeyDisplayString = "";
            this.File_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.File_New.Size = new System.Drawing.Size(224, 22);
            this.File_New.Text = "&New";
            this.File_New.Click += new System.EventHandler(this.File_New_Click);
            // 
            // File_Open
            // 
            this.File_Open.Name = "File_Open";
            this.File_Open.ShortcutKeyDisplayString = "";
            this.File_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.File_Open.Size = new System.Drawing.Size(224, 22);
            this.File_Open.Text = "&Open...";
            this.File_Open.Click += new System.EventHandler(this.File_Open_Click);
            // 
            // File_Save
            // 
            this.File_Save.Name = "File_Save";
            this.File_Save.ShortcutKeyDisplayString = "";
            this.File_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.File_Save.Size = new System.Drawing.Size(224, 22);
            this.File_Save.Text = "&Save";
            this.File_Save.Click += new System.EventHandler(this.File_Save_Click);
            // 
            // File_SaveAs
            // 
            this.File_SaveAs.Name = "File_SaveAs";
            this.File_SaveAs.ShortcutKeyDisplayString = "";
            this.File_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.File_SaveAs.Size = new System.Drawing.Size(224, 22);
            this.File_SaveAs.Text = "&Save as...";
            this.File_SaveAs.Click += new System.EventHandler(this.File_SaveAs_Click);
            // 
            // File_Close
            // 
            this.File_Close.Name = "File_Close";
            this.File_Close.ShortcutKeyDisplayString = "Ctrl+F4";
            this.File_Close.Size = new System.Drawing.Size(224, 22);
            this.File_Close.Text = "&Close";
            this.File_Close.Click += new System.EventHandler(this.File_Close_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(221, 6);
            // 
            // File_Exit
            // 
            this.File_Exit.Name = "File_Exit";
            this.File_Exit.ShortcutKeyDisplayString = "Alt+F4";
            this.File_Exit.Size = new System.Drawing.Size(224, 22);
            this.File_Exit.Text = "E&xit";
            this.File_Exit.Click += new System.EventHandler(this.File_Exit_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit_Undo,
            this.Edit_Redo,
            this.toolStripMenuItem3,
            this.Edit_Cut,
            this.Edit_Copy,
            this.Edit_Paste,
            this.Edit_Delete,
            this.toolStripMenuItem2,
            this.Edit_SelectAll,
            this.toolStripMenuItem4,
            this.Edit_Find,
            this.Edit_FindNext,
            this.Edit_FindPrevious,
            this.Edit_FindAndReplace});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // Edit_Undo
            // 
            this.Edit_Undo.Name = "Edit_Undo";
            this.Edit_Undo.ShortcutKeyDisplayString = "";
            this.Edit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Edit_Undo.Size = new System.Drawing.Size(196, 22);
            this.Edit_Undo.Text = "&Undo";
            this.Edit_Undo.Click += new System.EventHandler(this.Edit_Undo_Click);
            // 
            // Edit_Redo
            // 
            this.Edit_Redo.Name = "Edit_Redo";
            this.Edit_Redo.ShortcutKeyDisplayString = "";
            this.Edit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.Edit_Redo.Size = new System.Drawing.Size(196, 22);
            this.Edit_Redo.Text = "R&edo";
            this.Edit_Redo.Click += new System.EventHandler(this.Edit_Redo_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // Edit_Cut
            // 
            this.Edit_Cut.Name = "Edit_Cut";
            this.Edit_Cut.ShortcutKeyDisplayString = "";
            this.Edit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Edit_Cut.Size = new System.Drawing.Size(196, 22);
            this.Edit_Cut.Text = "C&ut";
            this.Edit_Cut.Click += new System.EventHandler(this.Edit_Cut_Click);
            // 
            // Edit_Copy
            // 
            this.Edit_Copy.Name = "Edit_Copy";
            this.Edit_Copy.ShortcutKeyDisplayString = "";
            this.Edit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Edit_Copy.Size = new System.Drawing.Size(196, 22);
            this.Edit_Copy.Text = "&Copy";
            this.Edit_Copy.Click += new System.EventHandler(this.Edit_Copy_Click);
            // 
            // Edit_Paste
            // 
            this.Edit_Paste.Name = "Edit_Paste";
            this.Edit_Paste.ShortcutKeyDisplayString = "";
            this.Edit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.Edit_Paste.Size = new System.Drawing.Size(196, 22);
            this.Edit_Paste.Text = "&Paste";
            this.Edit_Paste.Click += new System.EventHandler(this.Edit_Paste_Click);
            // 
            // Edit_Delete
            // 
            this.Edit_Delete.Name = "Edit_Delete";
            this.Edit_Delete.ShortcutKeyDisplayString = "Del";
            this.Edit_Delete.Size = new System.Drawing.Size(196, 22);
            this.Edit_Delete.Text = "&Delete";
            this.Edit_Delete.Click += new System.EventHandler(this.Edit_Delete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // Edit_SelectAll
            // 
            this.Edit_SelectAll.Name = "Edit_SelectAll";
            this.Edit_SelectAll.ShortcutKeyDisplayString = "";
            this.Edit_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.Edit_SelectAll.Size = new System.Drawing.Size(196, 22);
            this.Edit_SelectAll.Text = "Select &all";
            this.Edit_SelectAll.Click += new System.EventHandler(this.Edit_SelectAll_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(193, 6);
            // 
            // Edit_Find
            // 
            this.Edit_Find.Name = "Edit_Find";
            this.Edit_Find.ShortcutKeyDisplayString = "";
            this.Edit_Find.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.Edit_Find.Size = new System.Drawing.Size(196, 22);
            this.Edit_Find.Text = "&Find...";
            this.Edit_Find.Click += new System.EventHandler(this.Edit_Find_Click);
            // 
            // Edit_FindNext
            // 
            this.Edit_FindNext.Name = "Edit_FindNext";
            this.Edit_FindNext.ShortcutKeyDisplayString = "";
            this.Edit_FindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.Edit_FindNext.Size = new System.Drawing.Size(196, 22);
            this.Edit_FindNext.Text = "Find &Next";
            this.Edit_FindNext.Click += new System.EventHandler(this.Edit_FindNext_Click);
            // 
            // Edit_FindPrevious
            // 
            this.Edit_FindPrevious.Name = "Edit_FindPrevious";
            this.Edit_FindPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.Edit_FindPrevious.Size = new System.Drawing.Size(196, 22);
            this.Edit_FindPrevious.Text = "Find &Previous";
            this.Edit_FindPrevious.Click += new System.EventHandler(this.Edit_FindPrevious_Click);
            // 
            // Edit_FindAndReplace
            // 
            this.Edit_FindAndReplace.Name = "Edit_FindAndReplace";
            this.Edit_FindAndReplace.ShortcutKeyDisplayString = "";
            this.Edit_FindAndReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.Edit_FindAndReplace.Size = new System.Drawing.Size(196, 22);
            this.Edit_FindAndReplace.Text = "&Replace...";
            this.Edit_FindAndReplace.Click += new System.EventHandler(this.Edit_FindAndReplace_Click);
            // 
            // Text_Menu
            // 
            this.Text_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Text_MakeUppercase,
            this.Text_MakeLowercase,
            this.toolStripMenuItem8,
            this.Text_Indent,
            this.Text_Unindent,
            this.Text_EnableSmartIndent,
            this.toolStripMenuItem9,
            this.Text_CommentOut,
            this.Text_UncommentBackIn});
            this.Text_Menu.Name = "Text_Menu";
            this.Text_Menu.Size = new System.Drawing.Size(40, 20);
            this.Text_Menu.Text = "Te&xt";
            // 
            // Text_MakeUppercase
            // 
            this.Text_MakeUppercase.Name = "Text_MakeUppercase";
            this.Text_MakeUppercase.ShortcutKeyDisplayString = "";
            this.Text_MakeUppercase.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.Text_MakeUppercase.Size = new System.Drawing.Size(255, 22);
            this.Text_MakeUppercase.Text = "Make U&PPERCASE";
            this.Text_MakeUppercase.Click += new System.EventHandler(this.Text_MakeUppercase_Click);
            // 
            // Text_MakeLowercase
            // 
            this.Text_MakeLowercase.Name = "Text_MakeLowercase";
            this.Text_MakeLowercase.ShortcutKeyDisplayString = "";
            this.Text_MakeLowercase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.Text_MakeLowercase.Size = new System.Drawing.Size(255, 22);
            this.Text_MakeLowercase.Text = "Make &lowercase";
            this.Text_MakeLowercase.Click += new System.EventHandler(this.Text_MakeLowercase_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(252, 6);
            // 
            // Text_Indent
            // 
            this.Text_Indent.Name = "Text_Indent";
            this.Text_Indent.ShortcutKeyDisplayString = "Tab";
            this.Text_Indent.Size = new System.Drawing.Size(255, 22);
            this.Text_Indent.Text = "&Indent";
            this.Text_Indent.Click += new System.EventHandler(this.Text_Indent_Click);
            // 
            // Text_Unindent
            // 
            this.Text_Unindent.Name = "Text_Unindent";
            this.Text_Unindent.ShortcutKeyDisplayString = "Shift+Tab";
            this.Text_Unindent.Size = new System.Drawing.Size(255, 22);
            this.Text_Unindent.Text = "U&nindent";
            this.Text_Unindent.Click += new System.EventHandler(this.Text_Unindent_Click);
            // 
            // Text_EnableSmartIndent
            // 
            this.Text_EnableSmartIndent.Name = "Text_EnableSmartIndent";
            this.Text_EnableSmartIndent.Size = new System.Drawing.Size(255, 22);
            this.Text_EnableSmartIndent.Text = "Enable &Smart Indent";
            this.Text_EnableSmartIndent.Click += new System.EventHandler(this.Text_EnableSmartIndent_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(252, 6);
            // 
            // Text_CommentOut
            // 
            this.Text_CommentOut.Name = "Text_CommentOut";
            this.Text_CommentOut.ShortcutKeyDisplayString = "";
            this.Text_CommentOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.Text_CommentOut.Size = new System.Drawing.Size(255, 22);
            this.Text_CommentOut.Text = "Co&mment out";
            this.Text_CommentOut.Click += new System.EventHandler(this.Text_CommentOut_Click);
            // 
            // Text_UncommentBackIn
            // 
            this.Text_UncommentBackIn.Name = "Text_UncommentBackIn";
            this.Text_UncommentBackIn.ShortcutKeyDisplayString = "";
            this.Text_UncommentBackIn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
            this.Text_UncommentBackIn.Size = new System.Drawing.Size(255, 22);
            this.Text_UncommentBackIn.Text = "Uncomment back in";
            this.Text_UncommentBackIn.Click += new System.EventHandler(this.Text_UncommentBackIn_Click);
            // 
            // View_Menu
            // 
            this.View_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View_GoToLine,
            this.View_GoToDefinition,
            this.toolStripMenuItem13,
            this.View_ShowWhitespace,
            this.View_ShowLineNumbers,
            this.View_WordWrap,
            this.toolStripMenuItem6,
            this.View_CollapseFunction,
            this.View_CollapseRegion,
            this.View_CollapseLiterateCode,
            this.View_CollapseLiterateText,
            this.toolStripMenuItem7,
            this.View_CollapseAll,
            this.View_ExpandAll,
            this.toolStripSeparator1,
            this.View_ZoomIn,
            this.View_ZoomOut,
            this.View_ZoomReset});
            this.View_Menu.Name = "View_Menu";
            this.View_Menu.Size = new System.Drawing.Size(44, 20);
            this.View_Menu.Text = "&View";
            // 
            // View_GoToLine
            // 
            this.View_GoToLine.Name = "View_GoToLine";
            this.View_GoToLine.ShortcutKeyDisplayString = "";
            this.View_GoToLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.View_GoToLine.Size = new System.Drawing.Size(187, 22);
            this.View_GoToLine.Text = "&Go to line...";
            // 
            // View_GoToDefinition
            // 
            this.View_GoToDefinition.Name = "View_GoToDefinition";
            this.View_GoToDefinition.ShortcutKeyDisplayString = "";
            this.View_GoToDefinition.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.View_GoToDefinition.Size = new System.Drawing.Size(187, 22);
            this.View_GoToDefinition.Text = "Go to &definition";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(184, 6);
            // 
            // View_ShowWhitespace
            // 
            this.View_ShowWhitespace.Name = "View_ShowWhitespace";
            this.View_ShowWhitespace.Size = new System.Drawing.Size(187, 22);
            this.View_ShowWhitespace.Text = "Show &whitespace";
            this.View_ShowWhitespace.Click += new System.EventHandler(this.View_ShowWhitespace_Click);
            // 
            // View_ShowLineNumbers
            // 
            this.View_ShowLineNumbers.Name = "View_ShowLineNumbers";
            this.View_ShowLineNumbers.Size = new System.Drawing.Size(187, 22);
            this.View_ShowLineNumbers.Text = "Show &line numbers";
            this.View_ShowLineNumbers.Click += new System.EventHandler(this.View_ShowLineNumbers_Click);
            // 
            // View_WordWrap
            // 
            this.View_WordWrap.Name = "View_WordWrap";
            this.View_WordWrap.Size = new System.Drawing.Size(187, 22);
            this.View_WordWrap.Text = "W&ord wrap";
            this.View_WordWrap.Click += new System.EventHandler(this.View_WordWrap_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(184, 6);
            // 
            // View_CollapseFunction
            // 
            this.View_CollapseFunction.Name = "View_CollapseFunction";
            this.View_CollapseFunction.Size = new System.Drawing.Size(187, 22);
            this.View_CollapseFunction.Text = "Collapse &function";
            // 
            // View_CollapseRegion
            // 
            this.View_CollapseRegion.Name = "View_CollapseRegion";
            this.View_CollapseRegion.Size = new System.Drawing.Size(187, 22);
            this.View_CollapseRegion.Text = "Collapse &region";
            // 
            // View_CollapseLiterateCode
            // 
            this.View_CollapseLiterateCode.Name = "View_CollapseLiterateCode";
            this.View_CollapseLiterateCode.Size = new System.Drawing.Size(187, 22);
            this.View_CollapseLiterateCode.Text = "Collapse literate co&de";
            // 
            // View_CollapseLiterateText
            // 
            this.View_CollapseLiterateText.Name = "View_CollapseLiterateText";
            this.View_CollapseLiterateText.Size = new System.Drawing.Size(187, 22);
            this.View_CollapseLiterateText.Text = "Collapse &literate text";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(184, 6);
            // 
            // View_CollapseAll
            // 
            this.View_CollapseAll.Name = "View_CollapseAll";
            this.View_CollapseAll.Size = new System.Drawing.Size(187, 22);
            this.View_CollapseAll.Text = "&Collapse all";
            // 
            // View_ExpandAll
            // 
            this.View_ExpandAll.Name = "View_ExpandAll";
            this.View_ExpandAll.Size = new System.Drawing.Size(187, 22);
            this.View_ExpandAll.Text = "E&xpand all";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // View_ZoomIn
            // 
            this.View_ZoomIn.Name = "View_ZoomIn";
            this.View_ZoomIn.ShortcutKeyDisplayString = "Ctrl-+";
            this.View_ZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.View_ZoomIn.Size = new System.Drawing.Size(187, 22);
            this.View_ZoomIn.Text = "Zoom In";
            this.View_ZoomIn.Click += new System.EventHandler(this.View_ZoomIn_Click);
            // 
            // View_ZoomOut
            // 
            this.View_ZoomOut.Name = "View_ZoomOut";
            this.View_ZoomOut.ShortcutKeyDisplayString = "Ctrl--";
            this.View_ZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.View_ZoomOut.Size = new System.Drawing.Size(187, 22);
            this.View_ZoomOut.Text = "Zoom out";
            this.View_ZoomOut.Click += new System.EventHandler(this.View_ZoomOut_Click);
            // 
            // View_ZoomReset
            // 
            this.View_ZoomReset.Name = "View_ZoomReset";
            this.View_ZoomReset.ShortcutKeyDisplayString = "Ctrl+0";
            this.View_ZoomReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.NumPad0)));
            this.View_ZoomReset.Size = new System.Drawing.Size(187, 22);
            this.View_ZoomReset.Text = "Zoom reset";
            this.View_ZoomReset.Click += new System.EventHandler(this.View_ZoomReset_Click);
            // 
            // Run_Menu
            // 
            this.Run_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Run_RunWithDebugger,
            this.Run_Run,
            this.toolStripMenuItem10,
            this.Run_SetPrimaryScript,
            this.Run_NoPrimaryScript,
            this.toolStripMenuItem11});
            this.Run_Menu.Name = "Run_Menu";
            this.Run_Menu.Size = new System.Drawing.Size(40, 20);
            this.Run_Menu.Text = "&Run";
            // 
            // Run_RunWithDebugger
            // 
            this.Run_RunWithDebugger.Name = "Run_RunWithDebugger";
            this.Run_RunWithDebugger.ShortcutKeyDisplayString = "";
            this.Run_RunWithDebugger.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Run_RunWithDebugger.Size = new System.Drawing.Size(238, 22);
            this.Run_RunWithDebugger.Text = "Run with &debugger...";
            this.Run_RunWithDebugger.Click += new System.EventHandler(this.Run_RunWithDebugger_Click);
            // 
            // Run_Run
            // 
            this.Run_Run.Name = "Run_Run";
            this.Run_Run.ShortcutKeyDisplayString = "";
            this.Run_Run.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.Run_Run.Size = new System.Drawing.Size(238, 22);
            this.Run_Run.Text = "&Run...";
            this.Run_Run.Click += new System.EventHandler(this.Run_Run_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(235, 6);
            // 
            // Run_SetPrimaryScript
            // 
            this.Run_SetPrimaryScript.Name = "Run_SetPrimaryScript";
            this.Run_SetPrimaryScript.ShortcutKeyDisplayString = "";
            this.Run_SetPrimaryScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.Run_SetPrimaryScript.Size = new System.Drawing.Size(238, 22);
            this.Run_SetPrimaryScript.Text = "Set &primary script";
            // 
            // Run_NoPrimaryScript
            // 
            this.Run_NoPrimaryScript.Name = "Run_NoPrimaryScript";
            this.Run_NoPrimaryScript.ShortcutKeyDisplayString = "";
            this.Run_NoPrimaryScript.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.Run_NoPrimaryScript.Size = new System.Drawing.Size(238, 22);
            this.Run_NoPrimaryScript.Text = "&No primary script";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(235, 6);
            // 
            // Tools_Menu
            // 
            this.Tools_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tools_Options});
            this.Tools_Menu.Name = "Tools_Menu";
            this.Tools_Menu.Size = new System.Drawing.Size(46, 20);
            this.Tools_Menu.Text = "&Tools";
            // 
            // Tools_Options
            // 
            this.Tools_Options.Name = "Tools_Options";
            this.Tools_Options.Size = new System.Drawing.Size(125, 22);
            this.Tools_Options.Text = "&Options...";
            this.Tools_Options.Click += new System.EventHandler(this.Tools_Options_Click);
            // 
            // Window_Menu
            // 
            this.Window_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Window_CloseAllDocuments,
            this.Window_CloseAllButThis,
            this.toolStripMenuItem1});
            this.Window_Menu.Name = "Window_Menu";
            this.Window_Menu.Size = new System.Drawing.Size(63, 20);
            this.Window_Menu.Text = "&Window";
            // 
            // Window_CloseAllDocuments
            // 
            this.Window_CloseAllDocuments.Name = "Window_CloseAllDocuments";
            this.Window_CloseAllDocuments.Size = new System.Drawing.Size(181, 22);
            this.Window_CloseAllDocuments.Text = "Close &all documents";
            this.Window_CloseAllDocuments.Click += new System.EventHandler(this.Window_CloseAllDocuments_Click);
            // 
            // Window_CloseAllButThis
            // 
            this.Window_CloseAllButThis.Name = "Window_CloseAllButThis";
            this.Window_CloseAllButThis.Size = new System.Drawing.Size(181, 22);
            this.Window_CloseAllButThis.Text = "Close all but &this";
            this.Window_CloseAllButThis.Click += new System.EventHandler(this.Window_CloseAllButThis_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // Help_Menu
            // 
            this.Help_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_AboutJoy});
            this.Help_Menu.Name = "Help_Menu";
            this.Help_Menu.Size = new System.Drawing.Size(44, 20);
            this.Help_Menu.Text = "&Help";
            // 
            // Help_AboutJoy
            // 
            this.Help_AboutJoy.Name = "Help_AboutJoy";
            this.Help_AboutJoy.Size = new System.Drawing.Size(136, 22);
            this.Help_AboutJoy.Text = "&About Joy...";
            this.Help_AboutJoy.Click += new System.EventHandler(this.Help_AboutJoy_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CodeStatusLabel,
            this.ZoomStatusLabel,
            this.LineAndColumnStatusLabel,
            this.LengthStatusLabel,
            this.LinesStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 587);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(984, 24);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // CodeStatusLabel
            // 
            this.CodeStatusLabel.Name = "CodeStatusLabel";
            this.CodeStatusLabel.Size = new System.Drawing.Size(562, 19);
            this.CodeStatusLabel.Spring = true;
            this.CodeStatusLabel.Text = "Ready";
            this.CodeStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineAndColumnStatusLabel
            // 
            this.LineAndColumnStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LineAndColumnStatusLabel.Name = "LineAndColumnStatusLabel";
            this.LineAndColumnStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.LineAndColumnStatusLabel.Size = new System.Drawing.Size(131, 19);
            this.LineAndColumnStatusLabel.Text = "Line 1, Col 1, Char 1";
            // 
            // LengthStatusLabel
            // 
            this.LengthStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LengthStatusLabel.Name = "LengthStatusLabel";
            this.LengthStatusLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.LengthStatusLabel.Size = new System.Drawing.Size(76, 19);
            this.LengthStatusLabel.Text = "Length: 1";
            // 
            // LinesStatusLabel
            // 
            this.LinesStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LinesStatusLabel.Name = "LinesStatusLabel";
            this.LinesStatusLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.LinesStatusLabel.Size = new System.Drawing.Size(66, 19);
            this.LinesStatusLabel.Text = "Lines: 1";
            // 
            // DockPanel
            // 
            this.DockPanel.Location = new System.Drawing.Point(0, 27);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(984, 557);
            this.DockPanel.TabIndex = 10;
            // 
            // ZoomStatusLabel
            // 
            this.ZoomStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ZoomStatusLabel.Name = "ZoomStatusLabel";
            this.ZoomStatusLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.ZoomStatusLabel.Size = new System.Drawing.Size(103, 19);
            this.ZoomStatusLabel.Text = "Zoom: Default";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.DockPanel);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.MainStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Joy";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.StatusStrip MainStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel CodeStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel LineAndColumnStatusLabel;
		private WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel;
		private System.Windows.Forms.ToolStripStatusLabel LinesStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel LengthStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem FileMenu;
		private System.Windows.Forms.ToolStripMenuItem File_OpenProjectFolder;
		private System.Windows.Forms.ToolStripMenuItem File_CloseProjectFolder;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
		private System.Windows.Forms.ToolStripMenuItem File_New;
		private System.Windows.Forms.ToolStripMenuItem File_Open;
		private System.Windows.Forms.ToolStripMenuItem File_Save;
		private System.Windows.Forms.ToolStripMenuItem File_SaveAs;
		private System.Windows.Forms.ToolStripMenuItem File_Close;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem File_Exit;
		private System.Windows.Forms.ToolStripMenuItem EditMenu;
		private System.Windows.Forms.ToolStripMenuItem Edit_Undo;
		private System.Windows.Forms.ToolStripMenuItem Edit_Redo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem Edit_Cut;
		private System.Windows.Forms.ToolStripMenuItem Edit_Copy;
		private System.Windows.Forms.ToolStripMenuItem Edit_Paste;
		private System.Windows.Forms.ToolStripMenuItem Edit_Delete;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem Edit_SelectAll;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem Edit_Find;
		private System.Windows.Forms.ToolStripMenuItem Edit_FindNext;
		private System.Windows.Forms.ToolStripMenuItem Edit_FindPrevious;
		private System.Windows.Forms.ToolStripMenuItem Edit_FindAndReplace;
		private System.Windows.Forms.ToolStripMenuItem View_Menu;
		private System.Windows.Forms.ToolStripMenuItem View_GoToLine;
		private System.Windows.Forms.ToolStripMenuItem View_GoToDefinition;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
		private System.Windows.Forms.ToolStripMenuItem View_ShowWhitespace;
		private System.Windows.Forms.ToolStripMenuItem View_ShowLineNumbers;
		private System.Windows.Forms.ToolStripMenuItem View_WordWrap;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem View_CollapseFunction;
		private System.Windows.Forms.ToolStripMenuItem View_CollapseRegion;
		private System.Windows.Forms.ToolStripMenuItem View_CollapseLiterateCode;
		private System.Windows.Forms.ToolStripMenuItem View_CollapseLiterateText;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem View_CollapseAll;
		private System.Windows.Forms.ToolStripMenuItem View_ExpandAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem View_ZoomIn;
		private System.Windows.Forms.ToolStripMenuItem View_ZoomOut;
		private System.Windows.Forms.ToolStripMenuItem View_ZoomReset;
		private System.Windows.Forms.ToolStripMenuItem Run_Menu;
		private System.Windows.Forms.ToolStripMenuItem Run_RunWithDebugger;
		private System.Windows.Forms.ToolStripMenuItem Run_Run;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem Run_SetPrimaryScript;
		private System.Windows.Forms.ToolStripMenuItem Run_NoPrimaryScript;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
		private System.Windows.Forms.ToolStripMenuItem Tools_Menu;
		private System.Windows.Forms.ToolStripMenuItem Tools_Options;
		private System.Windows.Forms.ToolStripMenuItem Help_Menu;
		private System.Windows.Forms.ToolStripMenuItem Help_AboutJoy;
		private System.Windows.Forms.ToolStripMenuItem Text_Menu;
		private System.Windows.Forms.ToolStripMenuItem Text_MakeUppercase;
		private System.Windows.Forms.ToolStripMenuItem Text_MakeLowercase;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem Text_Indent;
		private System.Windows.Forms.ToolStripMenuItem Text_Unindent;
		private System.Windows.Forms.ToolStripMenuItem Text_EnableSmartIndent;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem Text_CommentOut;
		private System.Windows.Forms.ToolStripMenuItem Text_UncommentBackIn;
		private System.Windows.Forms.ToolStripMenuItem Window_Menu;
		private System.Windows.Forms.ToolStripMenuItem Window_CloseAllDocuments;
		private System.Windows.Forms.ToolStripMenuItem Window_CloseAllButThis;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripStatusLabel ZoomStatusLabel;
	}
}


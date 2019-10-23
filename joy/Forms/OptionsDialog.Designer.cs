namespace Joy.Forms
{
	partial class OptionsDialog
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GeneralOptionsTabPage = new System.Windows.Forms.TabPage();
            this.IndentationGroupBox = new System.Windows.Forms.GroupBox();
            this.IndentationSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SpacesRadioButton = new System.Windows.Forms.RadioButton();
            this.TabsRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextStylesTabPage = new System.Windows.Forms.TabPage();
            this.ImportThemeButton = new System.Windows.Forms.Button();
            this.ExportThemeButton = new System.Windows.Forms.Button();
            this.FontsGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EditorColorsPanel = new System.Windows.Forms.Panel();
            this.MainThemeGroupBox = new System.Windows.Forms.GroupBox();
            this.BlueThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.DarkThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.LightThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.FilesAndPathsTabPage = new System.Windows.Forms.TabPage();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.DefaultsButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FontDropdownComboBox = new System.Windows.Forms.ComboBox();
            this.FontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IndicatorStylesTabPage = new System.Windows.Forms.TabPage();
            this.OtherStylesTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartupGroupBox = new System.Windows.Forms.GroupBox();
            this.ReopenFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.ReopenProjectCheckBox = new System.Windows.Forms.CheckBox();
            this.RestoreWindowPositionRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.EditorConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.TextStyleButtonsPanel = new System.Windows.Forms.Panel();
            this.LightThemeButton = new System.Windows.Forms.Button();
            this.DarkThemeButton = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.GeneralOptionsTabPage.SuspendLayout();
            this.IndentationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IndentationSizeNumericUpDown)).BeginInit();
            this.TextStylesTabPage.SuspendLayout();
            this.FontsGroupBox.SuspendLayout();
            this.MainThemeGroupBox.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontSizeNumericUpDown)).BeginInit();
            this.OtherStylesTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.StartupGroupBox.SuspendLayout();
            this.TextStyleButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GeneralOptionsTabPage);
            this.MainTabControl.Controls.Add(this.TextStylesTabPage);
            this.MainTabControl.Controls.Add(this.IndicatorStylesTabPage);
            this.MainTabControl.Controls.Add(this.OtherStylesTabPage);
            this.MainTabControl.Controls.Add(this.FilesAndPathsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(8, 8);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(688, 451);
            this.MainTabControl.TabIndex = 0;
            // 
            // GeneralOptionsTabPage
            // 
            this.GeneralOptionsTabPage.Controls.Add(this.StartupGroupBox);
            this.GeneralOptionsTabPage.Controls.Add(this.IndentationGroupBox);
            this.GeneralOptionsTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralOptionsTabPage.Name = "GeneralOptionsTabPage";
            this.GeneralOptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralOptionsTabPage.Size = new System.Drawing.Size(680, 425);
            this.GeneralOptionsTabPage.TabIndex = 0;
            this.GeneralOptionsTabPage.Text = "General Options";
            this.GeneralOptionsTabPage.UseVisualStyleBackColor = true;
            // 
            // IndentationGroupBox
            // 
            this.IndentationGroupBox.Controls.Add(this.EditorConfigCheckBox);
            this.IndentationGroupBox.Controls.Add(this.IndentationSizeNumericUpDown);
            this.IndentationGroupBox.Controls.Add(this.SpacesRadioButton);
            this.IndentationGroupBox.Controls.Add(this.TabsRadioButton);
            this.IndentationGroupBox.Controls.Add(this.label2);
            this.IndentationGroupBox.Controls.Add(this.label1);
            this.IndentationGroupBox.Location = new System.Drawing.Point(7, 7);
            this.IndentationGroupBox.Name = "IndentationGroupBox";
            this.IndentationGroupBox.Size = new System.Drawing.Size(261, 167);
            this.IndentationGroupBox.TabIndex = 0;
            this.IndentationGroupBox.TabStop = false;
            this.IndentationGroupBox.Text = "Indentation";
            // 
            // IndentationSizeNumericUpDown
            // 
            this.IndentationSizeNumericUpDown.Location = new System.Drawing.Point(58, 28);
            this.IndentationSizeNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.IndentationSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IndentationSizeNumericUpDown.Name = "IndentationSizeNumericUpDown";
            this.IndentationSizeNumericUpDown.Size = new System.Drawing.Size(38, 20);
            this.IndentationSizeNumericUpDown.TabIndex = 7;
            this.IndentationSizeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IndentationSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IndentationSizeNumericUpDown.ValueChanged += new System.EventHandler(this.IndentationSizeNumericUpDown_ValueChanged);
            // 
            // SpacesRadioButton
            // 
            this.SpacesRadioButton.AutoSize = true;
            this.SpacesRadioButton.Location = new System.Drawing.Point(25, 84);
            this.SpacesRadioButton.Name = "SpacesRadioButton";
            this.SpacesRadioButton.Size = new System.Drawing.Size(97, 17);
            this.SpacesRadioButton.TabIndex = 4;
            this.SpacesRadioButton.TabStop = true;
            this.SpacesRadioButton.Text = "Use spaces (\' \')";
            this.SpacesRadioButton.UseVisualStyleBackColor = true;
            this.SpacesRadioButton.CheckedChanged += new System.EventHandler(this.SpacesRadioButton_CheckedChanged);
            // 
            // TabsRadioButton
            // 
            this.TabsRadioButton.AutoSize = true;
            this.TabsRadioButton.Location = new System.Drawing.Point(25, 61);
            this.TabsRadioButton.Name = "TabsRadioButton";
            this.TabsRadioButton.Size = new System.Drawing.Size(91, 17);
            this.TabsRadioButton.TabIndex = 3;
            this.TabsRadioButton.TabStop = true;
            this.TabsRadioButton.Text = "Use tabs (\'\\9\')";
            this.TabsRadioButton.UseVisualStyleBackColor = true;
            this.TabsRadioButton.CheckedChanged += new System.EventHandler(this.TabsRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "chars";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size:";
            // 
            // TextStylesTabPage
            // 
            this.TextStylesTabPage.Controls.Add(this.TextStyleButtonsPanel);
            this.TextStylesTabPage.Controls.Add(this.EditorColorsPanel);
            this.TextStylesTabPage.Location = new System.Drawing.Point(4, 22);
            this.TextStylesTabPage.Name = "TextStylesTabPage";
            this.TextStylesTabPage.Size = new System.Drawing.Size(680, 425);
            this.TextStylesTabPage.TabIndex = 2;
            this.TextStylesTabPage.Text = "Text Styles";
            this.TextStylesTabPage.UseVisualStyleBackColor = true;
            // 
            // ImportThemeButton
            // 
            this.ImportThemeButton.Location = new System.Drawing.Point(23, 60);
            this.ImportThemeButton.Name = "ImportThemeButton";
            this.ImportThemeButton.Size = new System.Drawing.Size(140, 23);
            this.ImportThemeButton.TabIndex = 4;
            this.ImportThemeButton.Text = "Import styles from file...";
            this.ImportThemeButton.UseVisualStyleBackColor = true;
            // 
            // ExportThemeButton
            // 
            this.ExportThemeButton.Location = new System.Drawing.Point(23, 31);
            this.ExportThemeButton.Name = "ExportThemeButton";
            this.ExportThemeButton.Size = new System.Drawing.Size(140, 23);
            this.ExportThemeButton.TabIndex = 3;
            this.ExportThemeButton.Text = "Export styles to file...";
            this.ExportThemeButton.UseVisualStyleBackColor = true;
            // 
            // FontsGroupBox
            // 
            this.FontsGroupBox.Controls.Add(this.label5);
            this.FontsGroupBox.Controls.Add(this.label4);
            this.FontsGroupBox.Controls.Add(this.FontSizeNumericUpDown);
            this.FontsGroupBox.Controls.Add(this.FontDropdownComboBox);
            this.FontsGroupBox.Controls.Add(this.label3);
            this.FontsGroupBox.Location = new System.Drawing.Point(284, 3);
            this.FontsGroupBox.Name = "FontsGroupBox";
            this.FontsGroupBox.Size = new System.Drawing.Size(199, 174);
            this.FontsGroupBox.TabIndex = 2;
            this.FontsGroupBox.TabStop = false;
            this.FontsGroupBox.Text = "Fonts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Main Editor Font:";
            // 
            // EditorColorsPanel
            // 
            this.EditorColorsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorColorsPanel.AutoScroll = true;
            this.EditorColorsPanel.Location = new System.Drawing.Point(3, 3);
            this.EditorColorsPanel.Name = "EditorColorsPanel";
            this.EditorColorsPanel.Size = new System.Drawing.Size(674, 390);
            this.EditorColorsPanel.TabIndex = 0;
            // 
            // MainThemeGroupBox
            // 
            this.MainThemeGroupBox.Controls.Add(this.label8);
            this.MainThemeGroupBox.Controls.Add(this.label7);
            this.MainThemeGroupBox.Controls.Add(this.label6);
            this.MainThemeGroupBox.Controls.Add(this.BlueThemeRadioButton);
            this.MainThemeGroupBox.Controls.Add(this.DarkThemeRadioButton);
            this.MainThemeGroupBox.Controls.Add(this.LightThemeRadioButton);
            this.MainThemeGroupBox.Location = new System.Drawing.Point(3, 3);
            this.MainThemeGroupBox.Name = "MainThemeGroupBox";
            this.MainThemeGroupBox.Size = new System.Drawing.Size(275, 174);
            this.MainThemeGroupBox.TabIndex = 0;
            this.MainThemeGroupBox.TabStop = false;
            this.MainThemeGroupBox.Text = "Window Theme";
            // 
            // BlueThemeRadioButton
            // 
            this.BlueThemeRadioButton.AutoSize = true;
            this.BlueThemeRadioButton.Location = new System.Drawing.Point(22, 118);
            this.BlueThemeRadioButton.Name = "BlueThemeRadioButton";
            this.BlueThemeRadioButton.Size = new System.Drawing.Size(82, 17);
            this.BlueThemeRadioButton.TabIndex = 2;
            this.BlueThemeRadioButton.TabStop = true;
            this.BlueThemeRadioButton.Text = "Blue Theme";
            this.BlueThemeRadioButton.UseVisualStyleBackColor = true;
            this.BlueThemeRadioButton.CheckedChanged += new System.EventHandler(this.BlueThemeRadioButton_CheckedChanged);
            // 
            // DarkThemeRadioButton
            // 
            this.DarkThemeRadioButton.AutoSize = true;
            this.DarkThemeRadioButton.Location = new System.Drawing.Point(22, 71);
            this.DarkThemeRadioButton.Name = "DarkThemeRadioButton";
            this.DarkThemeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.DarkThemeRadioButton.TabIndex = 1;
            this.DarkThemeRadioButton.TabStop = true;
            this.DarkThemeRadioButton.Text = "Dark Theme";
            this.DarkThemeRadioButton.UseVisualStyleBackColor = true;
            this.DarkThemeRadioButton.CheckedChanged += new System.EventHandler(this.DarkThemeRadioButton_CheckedChanged);
            // 
            // LightThemeRadioButton
            // 
            this.LightThemeRadioButton.AutoSize = true;
            this.LightThemeRadioButton.Location = new System.Drawing.Point(22, 24);
            this.LightThemeRadioButton.Name = "LightThemeRadioButton";
            this.LightThemeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.LightThemeRadioButton.TabIndex = 0;
            this.LightThemeRadioButton.TabStop = true;
            this.LightThemeRadioButton.Text = "Light Theme";
            this.LightThemeRadioButton.UseVisualStyleBackColor = true;
            this.LightThemeRadioButton.CheckedChanged += new System.EventHandler(this.LightThemeRadioButton_CheckedChanged);
            // 
            // FilesAndPathsTabPage
            // 
            this.FilesAndPathsTabPage.Location = new System.Drawing.Point(4, 22);
            this.FilesAndPathsTabPage.Name = "FilesAndPathsTabPage";
            this.FilesAndPathsTabPage.Size = new System.Drawing.Size(680, 425);
            this.FilesAndPathsTabPage.TabIndex = 3;
            this.FilesAndPathsTabPage.Text = "Files and Paths";
            this.FilesAndPathsTabPage.UseVisualStyleBackColor = true;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.DefaultsButton);
            this.ButtonPanel.Controls.Add(this.OkButton);
            this.ButtonPanel.Controls.Add(this.ApplyButton);
            this.ButtonPanel.Controls.Add(this.CancelButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(8, 459);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Padding = new System.Windows.Forms.Padding(6);
            this.ButtonPanel.Size = new System.Drawing.Size(688, 34);
            this.ButtonPanel.TabIndex = 1;
            // 
            // DefaultsButton
            // 
            this.DefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultsButton.Location = new System.Drawing.Point(499, 6);
            this.DefaultsButton.Name = "DefaultsButton";
            this.DefaultsButton.Size = new System.Drawing.Size(90, 24);
            this.DefaultsButton.TabIndex = 3;
            this.DefaultsButton.Text = "Set to Defaults";
            this.DefaultsButton.UseVisualStyleBackColor = true;
            this.DefaultsButton.Click += new System.EventHandler(this.DefaultsButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(307, 6);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(90, 24);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(403, 6);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(90, 24);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "Apply Changes";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(595, 6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 24);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FontDropdownComboBox
            // 
            this.FontDropdownComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FontDropdownComboBox.FormattingEnabled = true;
            this.FontDropdownComboBox.Location = new System.Drawing.Point(31, 43);
            this.FontDropdownComboBox.Name = "FontDropdownComboBox";
            this.FontDropdownComboBox.Size = new System.Drawing.Size(135, 21);
            this.FontDropdownComboBox.TabIndex = 1;
            this.FontDropdownComboBox.DropDown += new System.EventHandler(this.FontDropdownComboBox_DropDown);
            this.FontDropdownComboBox.SelectedIndexChanged += new System.EventHandler(this.FontDropdownComboBox_SelectedIndexChanged);
            // 
            // FontSizeNumericUpDown
            // 
            this.FontSizeNumericUpDown.Location = new System.Drawing.Point(74, 74);
            this.FontSizeNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.FontSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FontSizeNumericUpDown.Name = "FontSizeNumericUpDown";
            this.FontSizeNumericUpDown.Size = new System.Drawing.Size(39, 20);
            this.FontSizeNumericUpDown.TabIndex = 2;
            this.FontSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FontSizeNumericUpDown.ValueChanged += new System.EventHandler(this.FontSizeNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "points";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Size:";
            // 
            // IndicatorStylesTabPage
            // 
            this.IndicatorStylesTabPage.Location = new System.Drawing.Point(4, 22);
            this.IndicatorStylesTabPage.Name = "IndicatorStylesTabPage";
            this.IndicatorStylesTabPage.Size = new System.Drawing.Size(680, 425);
            this.IndicatorStylesTabPage.TabIndex = 4;
            this.IndicatorStylesTabPage.Text = "Indicator Styles";
            this.IndicatorStylesTabPage.UseVisualStyleBackColor = true;
            // 
            // OtherStylesTabPage
            // 
            this.OtherStylesTabPage.Controls.Add(this.groupBox1);
            this.OtherStylesTabPage.Controls.Add(this.MainThemeGroupBox);
            this.OtherStylesTabPage.Controls.Add(this.FontsGroupBox);
            this.OtherStylesTabPage.Location = new System.Drawing.Point(4, 22);
            this.OtherStylesTabPage.Name = "OtherStylesTabPage";
            this.OtherStylesTabPage.Size = new System.Drawing.Size(680, 425);
            this.OtherStylesTabPage.TabIndex = 5;
            this.OtherStylesTabPage.Text = "Other Styles";
            this.OtherStylesTabPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "White backgrounds and light gray borders.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Black backgrounds and dark gray borders.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Light gray backgrounds and blue highlights.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportThemeButton);
            this.groupBox1.Controls.Add(this.ImportThemeButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 106);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import/Export";
            // 
            // StartupGroupBox
            // 
            this.StartupGroupBox.Controls.Add(this.radioButton2);
            this.StartupGroupBox.Controls.Add(this.radioButton1);
            this.StartupGroupBox.Controls.Add(this.RestoreWindowPositionRadioButton);
            this.StartupGroupBox.Controls.Add(this.ReopenProjectCheckBox);
            this.StartupGroupBox.Controls.Add(this.ReopenFilesCheckBox);
            this.StartupGroupBox.Location = new System.Drawing.Point(274, 8);
            this.StartupGroupBox.Name = "StartupGroupBox";
            this.StartupGroupBox.Size = new System.Drawing.Size(252, 166);
            this.StartupGroupBox.TabIndex = 1;
            this.StartupGroupBox.TabStop = false;
            this.StartupGroupBox.Text = "Startup";
            // 
            // ReopenFilesCheckBox
            // 
            this.ReopenFilesCheckBox.AutoSize = true;
            this.ReopenFilesCheckBox.Location = new System.Drawing.Point(21, 25);
            this.ReopenFilesCheckBox.Name = "ReopenFilesCheckBox";
            this.ReopenFilesCheckBox.Size = new System.Drawing.Size(131, 17);
            this.ReopenFilesCheckBox.TabIndex = 0;
            this.ReopenFilesCheckBox.Text = "Re-open previous files";
            this.ReopenFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReopenProjectCheckBox
            // 
            this.ReopenProjectCheckBox.AutoSize = true;
            this.ReopenProjectCheckBox.Location = new System.Drawing.Point(21, 48);
            this.ReopenProjectCheckBox.Name = "ReopenProjectCheckBox";
            this.ReopenProjectCheckBox.Size = new System.Drawing.Size(174, 17);
            this.ReopenProjectCheckBox.TabIndex = 1;
            this.ReopenProjectCheckBox.Text = "Re-open previous project folder";
            this.ReopenProjectCheckBox.UseVisualStyleBackColor = true;
            // 
            // RestoreWindowPositionRadioButton
            // 
            this.RestoreWindowPositionRadioButton.AutoSize = true;
            this.RestoreWindowPositionRadioButton.Location = new System.Drawing.Point(21, 84);
            this.RestoreWindowPositionRadioButton.Name = "RestoreWindowPositionRadioButton";
            this.RestoreWindowPositionRadioButton.Size = new System.Drawing.Size(183, 17);
            this.RestoreWindowPositionRadioButton.TabIndex = 2;
            this.RestoreWindowPositionRadioButton.TabStop = true;
            this.RestoreWindowPositionRadioButton.Text = "Restore previous window position";
            this.RestoreWindowPositionRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 107);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(211, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Start with a draggable \"normal\" window";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(21, 130);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(164, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Window should be maximized";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // EditorConfigCheckBox
            // 
            this.EditorConfigCheckBox.AutoSize = true;
            this.EditorConfigCheckBox.Location = new System.Drawing.Point(25, 132);
            this.EditorConfigCheckBox.Name = "EditorConfigCheckBox";
            this.EditorConfigCheckBox.Size = new System.Drawing.Size(204, 17);
            this.EditorConfigCheckBox.TabIndex = 8;
            this.EditorConfigCheckBox.Text = "Follow \".editorconfig,\" when available";
            this.EditorConfigCheckBox.UseVisualStyleBackColor = true;
            this.EditorConfigCheckBox.CheckedChanged += new System.EventHandler(this.EditorConfigCheckBox_CheckedChanged);
            // 
            // TextStyleButtonsPanel
            // 
            this.TextStyleButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextStyleButtonsPanel.Controls.Add(this.DarkThemeButton);
            this.TextStyleButtonsPanel.Controls.Add(this.LightThemeButton);
            this.TextStyleButtonsPanel.Location = new System.Drawing.Point(4, 399);
            this.TextStyleButtonsPanel.Name = "TextStyleButtonsPanel";
            this.TextStyleButtonsPanel.Size = new System.Drawing.Size(673, 23);
            this.TextStyleButtonsPanel.TabIndex = 1;
            // 
            // LightThemeButton
            // 
            this.LightThemeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LightThemeButton.Location = new System.Drawing.Point(529, 0);
            this.LightThemeButton.Name = "LightThemeButton";
            this.LightThemeButton.Size = new System.Drawing.Size(144, 23);
            this.LightThemeButton.TabIndex = 0;
            this.LightThemeButton.Text = "Set to Default Light Theme";
            this.LightThemeButton.UseVisualStyleBackColor = true;
            this.LightThemeButton.Click += new System.EventHandler(this.LightThemeButton_Click);
            // 
            // DarkThemeButton
            // 
            this.DarkThemeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DarkThemeButton.Location = new System.Drawing.Point(379, 0);
            this.DarkThemeButton.Name = "DarkThemeButton";
            this.DarkThemeButton.Size = new System.Drawing.Size(144, 23);
            this.DarkThemeButton.TabIndex = 1;
            this.DarkThemeButton.Text = "Set to Default Dark Theme";
            this.DarkThemeButton.UseVisualStyleBackColor = true;
            this.DarkThemeButton.Click += new System.EventHandler(this.DarkThemeButton_Click);
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 501);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.ButtonPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.MainTabControl.ResumeLayout(false);
            this.GeneralOptionsTabPage.ResumeLayout(false);
            this.IndentationGroupBox.ResumeLayout(false);
            this.IndentationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IndentationSizeNumericUpDown)).EndInit();
            this.TextStylesTabPage.ResumeLayout(false);
            this.FontsGroupBox.ResumeLayout(false);
            this.FontsGroupBox.PerformLayout();
            this.MainThemeGroupBox.ResumeLayout(false);
            this.MainThemeGroupBox.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FontSizeNumericUpDown)).EndInit();
            this.OtherStylesTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.StartupGroupBox.ResumeLayout(false);
            this.StartupGroupBox.PerformLayout();
            this.TextStyleButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl MainTabControl;
		private System.Windows.Forms.TabPage GeneralOptionsTabPage;
		private System.Windows.Forms.TabPage TextStylesTabPage;
		private System.Windows.Forms.TabPage FilesAndPathsTabPage;
		private System.Windows.Forms.Panel ButtonPanel;
		private System.Windows.Forms.Button ApplyButton;
		private new System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.GroupBox IndentationGroupBox;
		private System.Windows.Forms.RadioButton SpacesRadioButton;
		private System.Windows.Forms.RadioButton TabsRadioButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown IndentationSizeNumericUpDown;
		private System.Windows.Forms.GroupBox MainThemeGroupBox;
		private System.Windows.Forms.RadioButton BlueThemeRadioButton;
		private System.Windows.Forms.RadioButton DarkThemeRadioButton;
		private System.Windows.Forms.RadioButton LightThemeRadioButton;
		private System.Windows.Forms.Button DefaultsButton;
		private System.Windows.Forms.GroupBox FontsGroupBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel EditorColorsPanel;
		private System.Windows.Forms.Button ImportThemeButton;
		private System.Windows.Forms.Button ExportThemeButton;
		private System.Windows.Forms.ComboBox FontDropdownComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown FontSizeNumericUpDown;
		private System.Windows.Forms.TabPage IndicatorStylesTabPage;
		private System.Windows.Forms.TabPage OtherStylesTabPage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox StartupGroupBox;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton RestoreWindowPositionRadioButton;
		private System.Windows.Forms.CheckBox ReopenProjectCheckBox;
		private System.Windows.Forms.CheckBox ReopenFilesCheckBox;
		private System.Windows.Forms.CheckBox EditorConfigCheckBox;
		private System.Windows.Forms.Panel TextStyleButtonsPanel;
		private System.Windows.Forms.Button DarkThemeButton;
		private System.Windows.Forms.Button LightThemeButton;
	}
}
namespace Joy.Forms
{
	partial class ReplaceControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.PatternComboBox = new System.Windows.Forms.ComboBox();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.WholeWordCheckbox = new System.Windows.Forms.CheckBox();
            this.RegexCheckBox = new System.Windows.Forms.CheckBox();
            this.ReplaceNextButton = new System.Windows.Forms.Button();
            this.ReplaceAllButton = new System.Windows.Forms.Button();
            this.ReplacementComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find:";
            // 
            // PatternComboBox
            // 
            this.PatternComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatternComboBox.FormattingEnabled = true;
            this.PatternComboBox.Location = new System.Drawing.Point(69, 10);
            this.PatternComboBox.Name = "PatternComboBox";
            this.PatternComboBox.Size = new System.Drawing.Size(194, 21);
            this.PatternComboBox.TabIndex = 0;
            this.PatternComboBox.SelectedIndexChanged += new System.EventHandler(this.PatternComboBox_SelectedIndexChanged);
            this.PatternComboBox.TextChanged += new System.EventHandler(this.PatternComboBox_TextChanged);
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(69, 66);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(82, 17);
            this.CaseSensitiveCheckBox.TabIndex = 2;
            this.CaseSensitiveCheckBox.Text = "Match case";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.CaseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.CaseSensitiveCheckBox_CheckedChanged);
            // 
            // WholeWordCheckbox
            // 
            this.WholeWordCheckbox.AutoSize = true;
            this.WholeWordCheckbox.Location = new System.Drawing.Point(69, 89);
            this.WholeWordCheckbox.Name = "WholeWordCheckbox";
            this.WholeWordCheckbox.Size = new System.Drawing.Size(105, 17);
            this.WholeWordCheckbox.TabIndex = 3;
            this.WholeWordCheckbox.Text = "Whole word only";
            this.WholeWordCheckbox.UseVisualStyleBackColor = true;
            this.WholeWordCheckbox.CheckedChanged += new System.EventHandler(this.WholeWordCheckbox_CheckedChanged);
            // 
            // RegexCheckBox
            // 
            this.RegexCheckBox.AutoSize = true;
            this.RegexCheckBox.Location = new System.Drawing.Point(69, 112);
            this.RegexCheckBox.Name = "RegexCheckBox";
            this.RegexCheckBox.Size = new System.Drawing.Size(144, 17);
            this.RegexCheckBox.TabIndex = 4;
            this.RegexCheckBox.Text = "Use Regular Expressions";
            this.RegexCheckBox.UseVisualStyleBackColor = true;
            this.RegexCheckBox.CheckedChanged += new System.EventHandler(this.RegexCheckBox_CheckedChanged);
            // 
            // ReplaceNextButton
            // 
            this.ReplaceNextButton.Location = new System.Drawing.Point(69, 136);
            this.ReplaceNextButton.Name = "ReplaceNextButton";
            this.ReplaceNextButton.Size = new System.Drawing.Size(90, 23);
            this.ReplaceNextButton.TabIndex = 5;
            this.ReplaceNextButton.Text = "Replace Next";
            this.ReplaceNextButton.UseVisualStyleBackColor = true;
            this.ReplaceNextButton.Click += new System.EventHandler(this.ReplaceNextButton_Click);
            // 
            // ReplaceAllButton
            // 
            this.ReplaceAllButton.Location = new System.Drawing.Point(165, 136);
            this.ReplaceAllButton.Name = "ReplaceAllButton";
            this.ReplaceAllButton.Size = new System.Drawing.Size(90, 23);
            this.ReplaceAllButton.TabIndex = 6;
            this.ReplaceAllButton.Text = "Replace All";
            this.ReplaceAllButton.UseVisualStyleBackColor = true;
            this.ReplaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // ReplacementComboBox
            // 
            this.ReplacementComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplacementComboBox.FormattingEnabled = true;
            this.ReplacementComboBox.Location = new System.Drawing.Point(69, 37);
            this.ReplacementComboBox.Name = "ReplacementComboBox";
            this.ReplacementComboBox.Size = new System.Drawing.Size(194, 21);
            this.ReplacementComboBox.TabIndex = 1;
            this.ReplacementComboBox.SelectedIndexChanged += new System.EventHandler(this.ReplacementComboBox_SelectedIndexChanged);
            this.ReplacementComboBox.TextChanged += new System.EventHandler(this.ReplacementComboBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Replace:";
            // 
            // ReplaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 172);
            this.Controls.Add(this.ReplacementComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReplaceAllButton);
            this.Controls.Add(this.ReplaceNextButton);
            this.Controls.Add(this.RegexCheckBox);
            this.Controls.Add(this.WholeWordCheckbox);
            this.Controls.Add(this.CaseSensitiveCheckBox);
            this.Controls.Add(this.PatternComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9999, 211);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 211);
            this.Name = "ReplaceControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox PatternComboBox;
		private System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
		private System.Windows.Forms.CheckBox WholeWordCheckbox;
		private System.Windows.Forms.CheckBox RegexCheckBox;
		private System.Windows.Forms.Button ReplaceNextButton;
		private System.Windows.Forms.Button ReplaceAllButton;
		private System.Windows.Forms.ComboBox ReplacementComboBox;
		private System.Windows.Forms.Label label2;
	}
}

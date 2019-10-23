namespace Joy.Forms
{
	partial class FindControl
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
            this.TextComboBox = new System.Windows.Forms.ComboBox();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.WholeWordCheckbox = new System.Windows.Forms.CheckBox();
            this.RegexCheckBox = new System.Windows.Forms.CheckBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.FindPreviousButton = new System.Windows.Forms.Button();
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
            // TextComboBox
            // 
            this.TextComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextComboBox.FormattingEnabled = true;
            this.TextComboBox.Location = new System.Drawing.Point(49, 10);
            this.TextComboBox.Name = "TextComboBox";
            this.TextComboBox.Size = new System.Drawing.Size(187, 21);
            this.TextComboBox.TabIndex = 0;
            this.TextComboBox.DropDown += new System.EventHandler(this.TextComboBox_DropDown);
            this.TextComboBox.SelectedIndexChanged += new System.EventHandler(this.TextComboBox_SelectedIndexChanged);
            this.TextComboBox.TextChanged += new System.EventHandler(this.TextComboBox_TextChanged);
            this.TextComboBox.Enter += new System.EventHandler(this.TextComboBox_Enter);
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(49, 38);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(82, 17);
            this.CaseSensitiveCheckBox.TabIndex = 1;
            this.CaseSensitiveCheckBox.Text = "Match case";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.CaseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.CaseSensitiveCheckBox_CheckedChanged);
            // 
            // WholeWordCheckbox
            // 
            this.WholeWordCheckbox.AutoSize = true;
            this.WholeWordCheckbox.Location = new System.Drawing.Point(49, 61);
            this.WholeWordCheckbox.Name = "WholeWordCheckbox";
            this.WholeWordCheckbox.Size = new System.Drawing.Size(105, 17);
            this.WholeWordCheckbox.TabIndex = 2;
            this.WholeWordCheckbox.Text = "Whole word only";
            this.WholeWordCheckbox.UseVisualStyleBackColor = true;
            this.WholeWordCheckbox.CheckedChanged += new System.EventHandler(this.WholeWordCheckbox_CheckedChanged);
            // 
            // RegexCheckBox
            // 
            this.RegexCheckBox.AutoSize = true;
            this.RegexCheckBox.Location = new System.Drawing.Point(49, 84);
            this.RegexCheckBox.Name = "RegexCheckBox";
            this.RegexCheckBox.Size = new System.Drawing.Size(144, 17);
            this.RegexCheckBox.TabIndex = 3;
            this.RegexCheckBox.Text = "Use Regular Expressions";
            this.RegexCheckBox.UseVisualStyleBackColor = true;
            this.RegexCheckBox.CheckedChanged += new System.EventHandler(this.RegexCheckBox_CheckedChanged);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(49, 108);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(90, 23);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find Next";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FindPreviousButton
            // 
            this.FindPreviousButton.Location = new System.Drawing.Point(145, 108);
            this.FindPreviousButton.Name = "FindPreviousButton";
            this.FindPreviousButton.Size = new System.Drawing.Size(90, 23);
            this.FindPreviousButton.TabIndex = 5;
            this.FindPreviousButton.Text = "Find Previous";
            this.FindPreviousButton.UseVisualStyleBackColor = true;
            this.FindPreviousButton.Click += new System.EventHandler(this.FindPreviousButton_Click);
            // 
            // FindControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 144);
            this.Controls.Add(this.FindPreviousButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.RegexCheckBox);
            this.Controls.Add(this.WholeWordCheckbox);
            this.Controls.Add(this.CaseSensitiveCheckBox);
            this.Controls.Add(this.TextComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9999, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 183);
            this.Name = "FindControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox TextComboBox;
		private System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
		private System.Windows.Forms.CheckBox WholeWordCheckbox;
		private System.Windows.Forms.CheckBox RegexCheckBox;
		private System.Windows.Forms.Button FindButton;
		private System.Windows.Forms.Button FindPreviousButton;
	}
}

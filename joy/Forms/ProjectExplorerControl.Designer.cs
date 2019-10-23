namespace Joy.Forms
{
	partial class ProjectExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectExplorerControl));
            this.ButtonToolStrip = new System.Windows.Forms.ToolStrip();
            this.FileTreeView = new BetterControls.TreeView.BetterTreeView();
            this.SuspendLayout();
            // 
            // ButtonToolStrip
            // 
            this.ButtonToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ButtonToolStrip.Name = "ButtonToolStrip";
            this.ButtonToolStrip.Size = new System.Drawing.Size(472, 25);
            this.ButtonToolStrip.TabIndex = 0;
            this.ButtonToolStrip.Text = "toolStrip1";
            // 
            // FileTreeView
            // 
            this.FileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTreeView.DataSource = null;
            this.FileTreeView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTreeView.Location = new System.Drawing.Point(0, 25);
            this.FileTreeView.Name = "FileTreeView";
            this.FileTreeView.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.FileTreeView.Size = new System.Drawing.Size(472, 425);
            this.FileTreeView.TabIndex = 1;
            // 
            // ProjectExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 450);
            this.Controls.Add(this.FileTreeView);
            this.Controls.Add(this.ButtonToolStrip);
            this.Name = "ProjectExplorerControl";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ButtonToolStrip;
		private BetterControls.TreeView.BetterTreeView FileTreeView;
	}
}

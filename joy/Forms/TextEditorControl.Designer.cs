namespace Joy.Forms
{
	partial class TextEditorControl
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
			this.Editor = new ScintillaNET.Scintilla();
			this.VerticalScrollbar = new BetterControls.Scrollbar.BetterVerticalScrollbar();
			this.HorizontalScrollbar = new BetterControls.Scrollbar.BetterHorizontalScrollbar();
			this.SuspendLayout();
			// 
			// Editor
			// 
			this.Editor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Editor.FontQuality = ScintillaNET.FontQuality.LcdOptimized;
			this.Editor.HScrollBar = false;
			this.Editor.IndentationGuides = ScintillaNET.IndentView.LookBoth;
			this.Editor.Location = new System.Drawing.Point(0, 0);
			this.Editor.Name = "Editor";
			this.Editor.ScrollWidth = 1;
			this.Editor.Size = new System.Drawing.Size(659, 546);
			this.Editor.TabIndex = 0;
			this.Editor.VScrollBar = false;
			// 
			// VerticalScrollbar
			// 
			this.VerticalScrollbar.Dock = System.Windows.Forms.DockStyle.Right;
			this.VerticalScrollbar.Location = new System.Drawing.Point(659, 0);
			this.VerticalScrollbar.Name = "VerticalScrollbar";
			this.VerticalScrollbar.ScrollbarStyle = ((BetterControls.Scrollbar.ScrollbarStyle)(((((((((((BetterControls.Scrollbar.ScrollbarStyle.PrevArrow | BetterControls.Scrollbar.ScrollbarStyle.NextArrow) 
            | BetterControls.Scrollbar.ScrollbarStyle.PrevPageArrow) 
            | BetterControls.Scrollbar.ScrollbarStyle.NextPageArrow) 
            | BetterControls.Scrollbar.ScrollbarStyle.StartArrow) 
            | BetterControls.Scrollbar.ScrollbarStyle.EndArrow) 
            | BetterControls.Scrollbar.ScrollbarStyle.InitialMarks) 
            | BetterControls.Scrollbar.ScrollbarStyle.FinalMarks) 
            | BetterControls.Scrollbar.ScrollbarStyle.CrossMarks) 
            | BetterControls.Scrollbar.ScrollbarStyle.RangeClickAddsOneStep) 
            | BetterControls.Scrollbar.ScrollbarStyle.RangeClickJumpsToEnd)));
			this.VerticalScrollbar.Size = new System.Drawing.Size(22, 546);
			this.VerticalScrollbar.TabIndex = 1;
			this.VerticalScrollbar.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.VerticalScrollbar_Scroll);
			// 
			// HorizontalScrollbar
			// 
			this.HorizontalScrollbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.HorizontalScrollbar.Location = new System.Drawing.Point(0, 546);
			this.HorizontalScrollbar.Name = "HorizontalScrollbar";
			this.HorizontalScrollbar.Padding = new System.Windows.Forms.Padding(0, 1, 22, 1);
			this.HorizontalScrollbar.ScrollbarStyle = ((BetterControls.Scrollbar.ScrollbarStyle)((((BetterControls.Scrollbar.ScrollbarStyle.PrevArrow | BetterControls.Scrollbar.ScrollbarStyle.NextArrow) 
            | BetterControls.Scrollbar.ScrollbarStyle.RangeClickAddsOneStep) 
            | BetterControls.Scrollbar.ScrollbarStyle.RangeClickJumpsToEnd)));
			this.HorizontalScrollbar.Size = new System.Drawing.Size(681, 8);
			this.HorizontalScrollbar.Step = 16;
			this.HorizontalScrollbar.TabIndex = 2;
			this.HorizontalScrollbar.Scroll += new System.EventHandler<System.Windows.Forms.ScrollEventArgs>(this.HorizontalScrollbar_Scroll);
			// 
			// TextEditorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 554);
			this.Controls.Add(this.Editor);
			this.Controls.Add(this.VerticalScrollbar);
			this.Controls.Add(this.HorizontalScrollbar);
			this.Name = "TextEditorControl";
			this.ResumeLayout(false);

		}

		#endregion

		private ScintillaNET.Scintilla Editor;
		private BetterControls.Scrollbar.BetterVerticalScrollbar VerticalScrollbar;
		private BetterControls.Scrollbar.BetterHorizontalScrollbar HorizontalScrollbar;
	}
}

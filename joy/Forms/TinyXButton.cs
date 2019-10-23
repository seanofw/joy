using System;
using System.Drawing;
using System.Windows.Forms;

namespace Joy.Forms
{
	public class TinyXButton : Button
	{
		public bool Hovered
		{
			get => _hovered;
			private set
			{
				_hovered = value;
				Invalidate();
			}
		}
		private bool _hovered;

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			Hovered = true;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			Hovered = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.FillRectangle(new SolidBrush(Color.White),
				0, 0, Width, Height);
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.DrawLine(new Pen(Focused || Hovered ? SystemColors.Highlight : Color.DarkGray, 2f),
				0, 0, Width - 1, Height - 1);
			e.Graphics.DrawLine(new Pen(Focused || Hovered ? SystemColors.Highlight : Color.DarkGray, 2f),
				Width - 1, 0, 0, Height - 1);

			if (Focused)
				ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(0, 0, Width, Height));
		}
	}
}

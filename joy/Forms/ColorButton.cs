using System;
using System.Drawing;
using System.Windows.Forms;

namespace Joy.Forms
{
	public class ColorButton : Button
	{
		public Color? Color
		{
			get => _color;
			set
			{
				_color = value;
				Invalidate();
			}
		}
		private Color? _color;

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

			if (!_color.HasValue)
			{
				e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White),
					new Rectangle(1, 1, Width - 2, Height - 2));
				e.Graphics.DrawLine(new Pen(System.Drawing.Color.LightGray),
					1, 1, Width - 2, Height - 2);
				e.Graphics.DrawLine(new Pen(System.Drawing.Color.LightGray),
					Width - 2, 1, 1, Height - 2);
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(Color.Value),
					new Rectangle(1, 1, Width - 2, Height - 2));
			}

			e.Graphics.DrawRectangle(new Pen(Focused || Hovered ? SystemColors.Highlight : System.Drawing.Color.DarkGray),
					new Rectangle(0, 0, Width - 1, Height - 1));

			if (Focused)
			{
				ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(1, 1, Width - 2, Height - 2));
			}
		}
	}
}

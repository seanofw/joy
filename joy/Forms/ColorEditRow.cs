using Joy.Config;
using Joy.Extensions;
using Joy.Types;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using System;

namespace Joy.Forms
{
	public class ColorEditRow : Panel
	{
		public StyleKind StyleKind { get; }
		public string Category { get; }
		public new string Name { get; }
		public string RationalName { get; }
		public string Description { get; }

		public Style? Style
		{
			get => _style;
			set
			{
				if (_style.HasValue != value.HasValue
					|| (value.HasValue && Style.HasValue && value.Value != Style.Value))
				{
					_style = value;
					ReRender();
					Invalidate();

					StyleChanged?.Invoke(this, new StyleChangedEventArgs(StyleKind, value));
				}
			}
		}
		private Style? _style;

		public new EventHandler<StyleChangedEventArgs> StyleChanged;

		private Func<Style> _defaultStyleProvider;
		public Style DefaultStyle => _defaultStyleProvider();

		private static readonly Font[] _fonts;

		private static readonly Image _crossImage;
		private static readonly Image _pencilImage;
		private static readonly Image _textBoldImage;
		private static readonly Image _textItalicImage;
		private static readonly Image _textUnderlineImage;

		private static readonly Brush _blackBrush = new SolidBrush(Color.Black);
		private static readonly Brush _lightGrayBrush = new SolidBrush(Color.LightGray);

		static ColorEditRow()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			_crossImage = assembly.LoadEmbeddedImage(@"Resources\cross.png");
			_pencilImage = assembly.LoadEmbeddedImage(@"Resources\pencil.png");
			_textBoldImage = assembly.LoadEmbeddedImage(@"Resources\text_bold.png");
			_textItalicImage = assembly.LoadEmbeddedImage(@"Resources\text_italic.png");
			_textUnderlineImage = assembly.LoadEmbeddedImage(@"Resources\text_underline.png");

			Font[] fonts = new Font[8];
			for (int i = 0; i < 8; i++)
			{
				FontFlags fontFlags = (FontFlags)i;
				FontStyle fontStyle = 0;
				if ((fontFlags & FontFlags.Bold) != 0) fontStyle |= FontStyle.Bold;
				if ((fontFlags & FontFlags.Italic) != 0) fontStyle |= FontStyle.Italic;
				if ((fontFlags & FontFlags.Underline) != 0) fontStyle |= FontStyle.Underline;
				Font font = new Font("Verdana", 9, fontStyle);
				fonts[i] = font;
			}
			_fonts = fonts;
		}

		public ColorEditRow(StyleKind styleKind, Style? style = null, Func<Style> defaultStyleProvider = null)
		{
			StyleKind = styleKind;
			_style = style;
			_defaultStyleProvider = defaultStyleProvider
				?? (() => new Style(StyleKind.Default, Color.Black, Color.White));

			string category, name;
			SplitStyleKindIntoCategoryAndName(styleKind, out category, out name);
			Category = category;
			Name = name;

			DoubleBuffered = true;

			RationalName = !string.IsNullOrEmpty(category)
				? "\"" + category + ": " + name + "\" text"
				: "\"" + name + "\" text";

			Description = StyleKind.GetEnumValueDescription();

			ReRender();
		}

		private void ReRender()
		{
			SuspendLayout();

			Controls.Clear();
			ToolTip tooltip = new ToolTip();

			if (_style.HasValue)
			{
				if (StyleKind != StyleKind.Meta_CursorLineBackground
					&& StyleKind != StyleKind.Meta_Selection)
				{
					ColorButton foreColorButton = new ColorButton();
					foreColorButton.Location = new Point(400, 0);
					foreColorButton.Size = new Size(40, 22);
					foreColorButton.Color = _style.Value.Color;
					Controls.Add(foreColorButton);
					tooltip.SetToolTip(foreColorButton, _style.Value.Color.HasValue
						? "Change the current foreground color for " + RationalName + "."
						: "Assign a new foreground color for " + RationalName + ".");
					foreColorButton.Click += ForeColorButton_Click;

					if (StyleKind != StyleKind.Default)
					{
						TinyXButton foreColorRevertButton = new TinyXButton();
						foreColorRevertButton.Location = new Point(442, 0);
						foreColorRevertButton.Size = new Size(8, 8);
						foreColorRevertButton.Visible = _style.Value.Color.HasValue;
						Controls.Add(foreColorRevertButton);
						tooltip.SetToolTip(foreColorRevertButton, "Reset this foreground color and inherit the foreground color instead.");
						foreColorRevertButton.Click += ForeColorButtonRevert_Click;
					}
				}

				if (StyleKind != StyleKind.Meta_CursorColor)
				{
					ColorButton backColorButton = new ColorButton();
					backColorButton.Location = new Point(474, 0);
					backColorButton.Size = new Size(40, 22);
					backColorButton.Color = _style.Value.Background;
					Controls.Add(backColorButton);
					tooltip.SetToolTip(backColorButton, _style.Value.Background.HasValue
						? "Change the current background color for " + RationalName + "."
						: "Assign a new background color for " + RationalName + ".");
					backColorButton.Click += BackColorButton_Click;

					if (StyleKind != StyleKind.Default)
					{
						TinyXButton backColorRevertButton = new TinyXButton();
						backColorRevertButton.Location = new Point(516, 0);
						backColorRevertButton.Size = new Size(8, 8);
						backColorRevertButton.Visible = _style.Value.Background.HasValue && StyleKind != StyleKind.Default;
						Controls.Add(backColorRevertButton);
						tooltip.SetToolTip(backColorRevertButton, "Reset this background color and inherit the background color instead.");
						backColorRevertButton.Click += BackColorButtonRevert_Click;
					}
				}

				if (StyleKind != StyleKind.Default
					&& StyleKind != StyleKind.Meta_CursorColor
					&& StyleKind != StyleKind.Meta_CursorLineBackground
					&& StyleKind != StyleKind.Meta_Selection)
				{
					CheckBox boldButton = new CheckBox();
					boldButton.Appearance = Appearance.Button;
					boldButton.FlatStyle = FlatStyle.Flat;
					boldButton.FlatAppearance.BorderSize = 0;
					boldButton.Image = _textBoldImage;
					boldButton.ImageAlign = ContentAlignment.MiddleCenter;
					boldButton.Size = new Size(22, 22);
					boldButton.Location = new Point(530, 0);
					boldButton.Checked = _style.HasValue && (_style.Value.FontFlags & FontFlags.Bold) != 0;
					boldButton.BackColor = _style.HasValue && (_style.Value.FontFlags & FontFlags.Bold) != 0
						? Color.CornflowerBlue : Color.White;
					Controls.Add(boldButton);
					tooltip.SetToolTip(boldButton, "Toggle whether " + RationalName + " uses a bold font.");
					boldButton.CheckedChanged += BoldButton_CheckedChanged;

					CheckBox italicButton = new CheckBox();
					italicButton.Appearance = Appearance.Button;
					italicButton.FlatStyle = FlatStyle.Flat;
					italicButton.FlatAppearance.BorderSize = 0;
					italicButton.Image = _textItalicImage;
					italicButton.ImageAlign = ContentAlignment.MiddleCenter;
					italicButton.Size = new Size(22, 22);
					italicButton.Location = new Point(555, 0);
					italicButton.Checked = _style.HasValue && (_style.Value.FontFlags & FontFlags.Italic) != 0;
					italicButton.BackColor = _style.HasValue && (_style.Value.FontFlags & FontFlags.Italic) != 0
						? Color.CornflowerBlue : Color.White;
					Controls.Add(italicButton);
					tooltip.SetToolTip(italicButton, "Toggle whether " + RationalName + " uses an italic font.");
					italicButton.CheckedChanged += ItalicButton_CheckedChanged;

					CheckBox underlineButton = new CheckBox();
					underlineButton.Appearance = Appearance.Button;
					underlineButton.FlatStyle = FlatStyle.Flat;
					underlineButton.FlatAppearance.BorderSize = 0;
					underlineButton.Image = _textUnderlineImage;
					underlineButton.ImageAlign = ContentAlignment.MiddleCenter;
					underlineButton.Size = new Size(22, 22);
					underlineButton.Location = new Point(580, 0);
					underlineButton.Checked = _style.HasValue && (_style.Value.FontFlags & FontFlags.Underline) != 0;
					underlineButton.BackColor = _style.HasValue && (_style.Value.FontFlags & FontFlags.Underline) != 0
						? Color.CornflowerBlue : Color.White;
					Controls.Add(underlineButton);
					tooltip.SetToolTip(underlineButton, "Toggle whether " + RationalName + " uses an underlined font.");
					underlineButton.CheckedChanged += UnderlineButton_CheckedChanged;
				}

				if (StyleKind != StyleKind.Default)
				{
					Button resetButton = new Button();
					resetButton.FlatStyle = FlatStyle.Flat;
					resetButton.FlatAppearance.BorderSize = 0;
					resetButton.Image = _crossImage;
					resetButton.ImageAlign = ContentAlignment.MiddleCenter;
					resetButton.Size = new Size(22, 22);
					resetButton.Location = new Point(615, 0);
					Controls.Add(resetButton);
					tooltip.SetToolTip(resetButton, "Reset " + RationalName + " to inherit default styles.");
					resetButton.Click += ResetButton_Click;
				}
			}
			else
			{
				Button editButton = new Button();
				editButton.FlatStyle = FlatStyle.Flat;
				editButton.FlatAppearance.BorderSize = 0;
				editButton.Image = _pencilImage;
				editButton.ImageAlign = ContentAlignment.MiddleCenter;
				editButton.Size = new Size(22, 22);
				editButton.Location = new Point(615, 0);
				Controls.Add(editButton);
				tooltip.SetToolTip(editButton, "Customize styles for " + RationalName + ".");
				editButton.Click += EditButton_Click;
			}

			ResumeLayout();
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			Style = new Style(StyleKind);
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			Style = null;
		}

		private void UnderlineButton_CheckedChanged(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;

			Style oldStyle = Style.Value;
			Style newStyle = new Style(StyleKind, oldStyle.Color, oldStyle.Background,
				((CheckBox)sender).Checked
					? oldStyle.FontFlags | FontFlags.Underline
					: oldStyle.FontFlags & ~FontFlags.Underline);

			Style = newStyle;
		}

		private void ItalicButton_CheckedChanged(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;

			Style oldStyle = Style.Value;
			Style newStyle = new Style(StyleKind, oldStyle.Color, oldStyle.Background,
				((CheckBox)sender).Checked
					? oldStyle.FontFlags | FontFlags.Italic
					: oldStyle.FontFlags & ~FontFlags.Italic);

			Style = newStyle;
		}

		private void BoldButton_CheckedChanged(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;

			Style oldStyle = Style.Value;
			Style newStyle = new Style(StyleKind, oldStyle.Color, oldStyle.Background,
				((CheckBox)sender).Checked
					? oldStyle.FontFlags | FontFlags.Bold
					: oldStyle.FontFlags & ~FontFlags.Bold);

			Style = newStyle;
		}

		public static void SplitStyleKindIntoCategoryAndName(StyleKind styleKind,
			out string category, out string name)
		{
			string styleKindString = styleKind.ToString();

			int underscoreIndex;
			if ((underscoreIndex = styleKindString.IndexOf('_')) > 0)
			{
				category = SplitEnumName(styleKindString.Substring(0, underscoreIndex));
				name = SplitEnumName(styleKindString.Substring(underscoreIndex + 1));
			}
			else
			{
				category = null;
				name = SplitEnumName(styleKindString);
			}
		}

		public static string SplitEnumName(string rawEnumName)
		{
			StringBuilder stringBuilder = new StringBuilder();

			int src, start = 0;
			for (src = 0; src < rawEnumName.Length; src++)
			{
				char ch = rawEnumName[src];
				if (ch >= 'A' && ch <= 'Z')
				{
					if (src > start)
					{
						stringBuilder.Append(rawEnumName, start, src - start);
						stringBuilder.Append(' ');
						start = src;
					}
				}
			}

			if (src > start)
				stringBuilder.Append(rawEnumName, start, src - start);

			return stringBuilder.ToString();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawString(Name, _fonts[StyleKind == StyleKind.Default ? (int)FontStyle.Bold : 0], _blackBrush, 0, 3);

			if (!string.IsNullOrEmpty(Description))
			{
				string text = Description;
				Color foreColor = (_style.HasValue && _style.Value.Color.HasValue ? _style.Value.Color.Value : DefaultStyle.Color.Value);
				Color backColor = (_style.HasValue && _style.Value.Background.HasValue ? _style.Value.Background.Value : DefaultStyle.Background.Value);

				const int HorzPadding = 6;
				e.Graphics.FillRectangle(new SolidBrush(backColor), 176 - HorzPadding, 0,
					222, 25  /* Magic numbers for uniform fill */);
				e.Graphics.DrawString(text, _fonts[_style.HasValue ? (int)_style.Value.FontFlags & 7 : 0], new SolidBrush(foreColor), 176, 3);
			}

			if (!Style.HasValue)
			{
				e.Graphics.DrawString("(not styled)", _fonts[(int)FontFlags.Italic], _lightGrayBrush, 470, 3);
				return;
			}

			if (StyleKind != StyleKind.Meta_CursorColor
				&& StyleKind != StyleKind.Meta_CursorLineBackground)
			{
				e.Graphics.DrawString("on", _fonts[0], _blackBrush, 452, 5);
			}
		}

		private void ForeColorButton_Click(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;

			Style originalStyle = Style.Value;

			using (ColorPickerDialog dialog = new ColorPickerDialog())
			{
				dialog.Color = originalStyle.Color.HasValue ? originalStyle.Color.Value : Color.Black;
				dialog.ShowAlphaChannel = false;
				dialog.PreviewColorChanged += (s2, e2) =>
				{
					Color previewColor = ((ColorPickerDialog)s2).Color;
					((ColorButton)sender).Color = previewColor;
					_style = new Style(StyleKind, previewColor, originalStyle.Background, originalStyle.FontFlags);
					Invalidate();
				};

				DialogResult dialogResult = dialog.ShowDialog(this);

				_style = originalStyle;
				if (dialogResult == DialogResult.OK)
				{
					Style = new Style(StyleKind, dialog.Color, originalStyle.Background, originalStyle.FontFlags);
				}
			}
		}

		private void ForeColorButtonRevert_Click(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;
			Style = new Style(StyleKind, null, Style.Value.Background, Style.Value.FontFlags);
		}

		private void BackColorButton_Click(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;

			Style originalStyle = Style.Value;

			using (ColorPickerDialog dialog = new ColorPickerDialog())
			{
				dialog.Color = originalStyle.Background.HasValue ? originalStyle.Background.Value : Color.White;
				dialog.ShowAlphaChannel = false;
				dialog.PreviewColorChanged += (s2, e2) =>
				{
					Color previewColor = ((ColorPickerDialog)s2).Color;
					((ColorButton)sender).Color = previewColor;
					_style = new Style(StyleKind, originalStyle.Color, previewColor, originalStyle.FontFlags);
					Invalidate();
				};

				DialogResult dialogResult = dialog.ShowDialog(this);

				_style = originalStyle;
				if (dialogResult == DialogResult.OK)
				{
					Style = new Style(StyleKind, originalStyle.Color, dialog.Color, originalStyle.FontFlags);
				}
			}
		}

		private void BackColorButtonRevert_Click(object sender, EventArgs e)
		{
			if (!Style.HasValue) return;
			Style = new Style(StyleKind, Style.Value.Color, null, Style.Value.FontFlags);
		}
	}
}

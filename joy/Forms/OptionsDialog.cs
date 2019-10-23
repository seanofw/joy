using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BetterControls.MessageBox;
using Joy.Config;
using Joy.Types;
using Joy.Win32;

namespace Joy.Forms
{
	public partial class OptionsDialog : Form
	{
		public readonly Configurator Configurator;
		public readonly Dispatcher Dispatcher;

		protected AppConfig AppConfig { get; set; }
		protected TextEditorConfig TextEditorConfig { get; set; }
		protected StyleConfig StyleConfig { get; set; }

		public OptionsDialog(Configurator configurator, Dispatcher dispatcher)
		{
			InitializeComponent();

			Configurator = configurator;
			Dispatcher = dispatcher;

			AppConfig = configurator.AppConfig;
			TextEditorConfig = configurator.TextEditorConfig;
			StyleConfig = configurator.StyleConfig;

			PopulateThemeUI(AppConfig);
			PopulateTextEditorConfigUI(TextEditorConfig);
			PopulateColorEditorUI(StyleConfig);
			PopulateFontUI(TextEditorConfig);
		}

		private void PopulateTextEditorConfigUI(TextEditorConfig textEditorConfig)
		{
			IndentationSizeNumericUpDown.Value = textEditorConfig.Indentation;
			TabsRadioButton.Checked = textEditorConfig.IndentationMode == IndentationMode.Tabs;
			SpacesRadioButton.Checked = textEditorConfig.IndentationMode == IndentationMode.Spaces;
			EditorConfigCheckBox.Checked = textEditorConfig.UseEditorConfig;
		}

		private static Font _colorEditorHeaderFont = new Font("Verdana", 11, FontStyle.Bold | FontStyle.Underline);

		private void PopulateColorEditorUI(StyleConfig styleConfig)
		{
			StyleKind[] styleKinds = Enum.GetValues(typeof(StyleKind)).Cast<StyleKind>().ToArray();
			Dictionary<StyleKind, Style> styleLookup = styleConfig.ToDictionary(p => p.StyleKind);
			ToolTip tooltip = new ToolTip();

			EditorColorsPanel.SuspendLayout();
			EditorColorsPanel.Controls.Clear();

			int yOffset = 8;
			string lastCategory = null;
			foreach (StyleKind styleKind in styleKinds)
			{
				Style? style = styleLookup.TryGetValue(styleKind, out Style trueStyle)
					? (Style?)trueStyle : null;

				// First, figure out what the category and name are for this color option.
				string category, name;
				ColorEditRow.SplitStyleKindIntoCategoryAndName(styleKind, out category, out name);

				// If we switched categories, generate a header row.
				if (category != lastCategory)
				{
					yOffset += 10;

					Label headerLabel = new Label();
					headerLabel.Text = category;
					headerLabel.Location = new Point(0, yOffset);
					headerLabel.Font = _colorEditorHeaderFont;
					headerLabel.AutoSize = true;
					EditorColorsPanel.Controls.Add(headerLabel);
					yOffset += 30;

					lastCategory = category;
				}

				ColorEditRow colorEditRow = new ColorEditRow(styleKind, style, GetDefaultStyle);
				colorEditRow.Location = new Point(0, yOffset);
				colorEditRow.Size = new Size(EditorColorsPanel.Width, 25);
				colorEditRow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				colorEditRow.StyleChanged += ColorEditRow_StyleChanged;
				EditorColorsPanel.Controls.Add(colorEditRow);

				yOffset += 25;
			}

			EditorColorsPanel.ResumeLayout();
		}

		private Style GetDefaultStyle()
			=> StyleConfig.DefaultStyle;

		private void ColorEditRow_StyleChanged(object sender, StyleChangedEventArgs e)
		{
			if (e.Style.HasValue)
				StyleConfig = StyleConfig.WithStyles(e.Style.Value);
			else
				StyleConfig = StyleConfig.WithoutStyleKinds(e.StyleKind);

			if (e.StyleKind == StyleKind.Default)
			{
				foreach (Control control in EditorColorsPanel.Controls)
				{
					control.Invalidate();
				}
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			ApplyChanges();
			Close();
		}

		private void ApplyButton_Click(object sender, EventArgs e) => ApplyChanges();
		private void CancelButton_Click(object sender, EventArgs e) => Close();

		public void ApplyChanges()
		{
			bool needsRestart = false;

			if (AppConfig.Theme != Configurator.AppConfig.Theme)
				needsRestart = true;

			Configurator.AppConfig = AppConfig;
			Configurator.TextEditorConfig = TextEditorConfig;
			Configurator.StyleConfig = StyleConfig;

			if (needsRestart)
			{
				DialogResult result = BetterMessageBox.Caption("Joy")
					.Message("You must restart Joy to apply these changes.")
					.Owner(this)
					.Button("Restart now", DialogResult.OK, true)
					.Button("Later", DialogResult.Cancel)
					.StandardImage(StandardImageKind.Warning)
					.Show();
				if (result == DialogResult.OK)
				{
					Close();
					Dispatcher.Restart();
				}
			}
		}

		private void DefaultsButton_Click(object sender, EventArgs e)
		{
			AppConfig = AppConfig.LoadFromRegistry(null);
			TextEditorConfig = TextEditorConfig.LoadFromRegistry(null);
			StyleConfig = StyleConfig.LoadFromRegistry(null);

			PopulateThemeUI(AppConfig);
			PopulateTextEditorConfigUI(TextEditorConfig);
			PopulateColorEditorUI(StyleConfig);
			PopulateFontUI(TextEditorConfig);
		}

		private void FontDropdownComboBox_DropDown(object sender, EventArgs e)
		{
			PopulateFontDropdown();
		}

		private void PopulateThemeUI(AppConfig appConfig)
		{
			LightThemeRadioButton.Checked = (appConfig.Theme == ThemeKind.Light);
			DarkThemeRadioButton.Checked = (appConfig.Theme == ThemeKind.Dark);
			BlueThemeRadioButton.Checked = (appConfig.Theme == ThemeKind.Blue);
		}

		private void PopulateFontUI(TextEditorConfig textEditorConfig)
		{
			PopulateFontDropdown(textEditorConfig.MainFontName);
			FontSizeNumericUpDown.Value = textEditorConfig.MainFontSize;
		}

		private void PopulateFontDropdown(string selectedName = null)
		{
			List<FontData> fontDatas = EnumFontFamiliesEx.Invoke(f =>
				f.FixedPitch == true
				&& (f.CharSet == Gdi32.FontLanguageCharSet.OEM_CHARSET || f.CharSet == Gdi32.FontLanguageCharSet.ANSI_CHARSET)
				&& f.Vertical == false);

			List<string> fontNames = fontDatas.Select(f => f.Name).OrderBy(n => n.ToLowerInvariant()).ToList();

			string selectedFont = selectedName
				?? (FontDropdownComboBox.SelectedIndex >= 0
					? (string)FontDropdownComboBox.Items[FontDropdownComboBox.SelectedIndex]
					: null);
			FontDropdownComboBox.Items.Clear();
			FontDropdownComboBox.Items.AddRange(fontNames.ToArray());
			FontDropdownComboBox.SelectedIndex = fontNames.IndexOf(selectedFont);
		}

		private void FontDropdownComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedFont = FontDropdownComboBox.SelectedIndex >= 0
				? (string)FontDropdownComboBox.Items[FontDropdownComboBox.SelectedIndex]
				: null;
			TextEditorConfig = TextEditorConfig.WithMainFontName(selectedFont);
		}

		private void FontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			TextEditorConfig = TextEditorConfig.WithMainFontSize((int)FontSizeNumericUpDown.Value);
		}

		private void LightThemeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			AppConfig = AppConfig.WithTheme(ThemeKind.Light);
		}

		private void DarkThemeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			AppConfig = AppConfig.WithTheme(ThemeKind.Dark);
		}

		private void BlueThemeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			AppConfig = AppConfig.WithTheme(ThemeKind.Blue);
		}

		private void IndentationSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			TextEditorConfig = TextEditorConfig.WithIndentation((int)IndentationSizeNumericUpDown.Value);
		}

		private void TabsRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			TextEditorConfig = TextEditorConfig.WithIndentationMode(IndentationMode.Tabs);
		}

		private void SpacesRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			TextEditorConfig = TextEditorConfig.WithIndentationMode(IndentationMode.Spaces);
		}

		private void EditorConfigCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TextEditorConfig = TextEditorConfig.WithUseEditorConfig(EditorConfigCheckBox.Checked);
		}

		private void LightThemeButton_Click(object sender, EventArgs e)
		{
			if (BetterMessageBox.Owner(this)
				.Message("You are about to replace all of your current text\r\n"
					+ "styles with the default \"light\" color scheme.\r\n"
					+ "Are you sure you want to do this?\r\n")
				.Button("OK", DialogResult.OK, true)
				.Button("Cancel", DialogResult.Cancel)
				.Caption("Warning")
				.StandardImage(StandardImageKind.Warning)
				.Show() == DialogResult.OK)
			{
				StyleConfig = new StyleConfig(DefaultStyles.LightTheme);
				PopulateColorEditorUI(StyleConfig);
			}
		}

		private void DarkThemeButton_Click(object sender, EventArgs e)
		{
			if (BetterMessageBox.Owner(this)
				.Message("You are about to replace all of your current text\r\n"
					+ "styles with the default \"dark\" color scheme.\r\n"
					+ "Are you sure you want to do this?\r\n")
				.Button("OK", DialogResult.OK, true)
				.Button("Cancel", DialogResult.Cancel)
				.Caption("Warning")
				.StandardImage(StandardImageKind.Warning)
				.Show() == DialogResult.OK)
			{
				StyleConfig = new StyleConfig(DefaultStyles.DarkTheme);
				PopulateColorEditorUI(StyleConfig);
			}
		}
	}
}

using static Joy.Win32.Gdi32;

namespace Joy.Win32
{
	public class FontData
	{
		public ENUMLOGFONT LogFont;
		public NEWTEXTMETRIC TextMetric;
		public uint FontType;

		public string Name => LogFont.elfFullName;
		public string Style => LogFont.elfStyle;

		public bool Italic => LogFont.elfLogFont.lfItalic != 0;
		public bool Underline => LogFont.elfLogFont.lfUnderline != 0;
		public bool StrikeOut => LogFont.elfLogFont.lfStrikeOut != 0;

		public int Weight => LogFont.elfLogFont.lfWeight;
		public bool Bold => Weight >= 550;
		public bool Light => Weight <= 350;

		public bool FixedPitch => ((FontPitch)LogFont.elfLogFont.lfPitchAndFamily & FontPitch.FIXED_PITCH) != 0;
		public bool VariablePitch => ((FontPitch)LogFont.elfLogFont.lfPitchAndFamily & FontPitch.VARIABLE_PITCH) != 0;
		public bool MonoFont => ((FontPitch)LogFont.elfLogFont.lfPitchAndFamily & FontPitch.MONO_FONT) != 0;

		public bool Roman => ((FontFamily)LogFont.elfLogFont.lfPitchAndFamily & FontFamily.FF_MASK) == FontFamily.FF_ROMAN;
		public bool Swiss => ((FontFamily)LogFont.elfLogFont.lfPitchAndFamily & FontFamily.FF_MASK) == FontFamily.FF_SWISS;
		public bool Modern => ((FontFamily)LogFont.elfLogFont.lfPitchAndFamily & FontFamily.FF_MASK) == FontFamily.FF_MODERN;
		public bool Script => ((FontFamily)LogFont.elfLogFont.lfPitchAndFamily & FontFamily.FF_MASK) == FontFamily.FF_SCRIPT;
		public bool Decorative => ((FontFamily)LogFont.elfLogFont.lfPitchAndFamily & FontFamily.FF_MASK) == FontFamily.FF_DECORATIVE;

		public FontLanguageCharSet CharSet => (FontLanguageCharSet)LogFont.elfLogFont.lfCharSet;

		public bool Vertical => LogFont.elfLogFont.lfFaceName.StartsWith("@");

		public override string ToString()
			=> Name + " (" + CharSet + ")";
	}
}

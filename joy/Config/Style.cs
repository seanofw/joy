using Joy.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Joy.Config
{
	public struct Style : IEquatable<Style>
	{
		public readonly StyleKind StyleKind;
		public readonly FontFlags FontFlags;
		public readonly Color? Color;
		public readonly Color? Background;

		public Style(StyleKind styleKind, Color? color = null, Color? background = null, FontFlags fontFlags = 0)
		{
			StyleKind = styleKind;
			Color = color;
			Background = background;
			FontFlags = fontFlags;
		}

		public Style WithStyleKind(StyleKind styleKind)
			=> new Style(styleKind: styleKind, color: Color, background: Background, fontFlags: FontFlags);
		public Style WithColor(Color? color)
			=> new Style(styleKind: StyleKind, color: color, background: Background, fontFlags: FontFlags);
		public Style WithBackground(Color? background)
			=> new Style(styleKind: StyleKind, color: Color, background: background, fontFlags: FontFlags);
		public Style WithFontFlags(FontFlags fontFlags)
			=> new Style(styleKind: StyleKind, color: Color, background: Background, fontFlags: fontFlags);

		public override bool Equals(object obj)
			=> (obj is Style style) && Equals(style);

		public bool Equals(Style other)
			=> StyleKind == other.StyleKind && Color == other.Color
				&& Background == other.Background && FontFlags == other.FontFlags;

		public override int GetHashCode()
			=> ((((int)FontFlags) * 29
				+ Background.GetHashCode()) * 29
				+ Color.GetHashCode()) * 29
				+ (int)StyleKind;

		public static bool operator==(Style a, Style b) => a.Equals(b);
		public static bool operator!=(Style a, Style b) => !a.Equals(b);

		public override string ToString()
			=> Serialize(true);

		public string Serialize(bool includeStyleKind)
		{
			List<string> pieces = new List<string>();

			if (includeStyleKind)
				pieces.Add("kind=" + StyleKind);

			if (Color.HasValue)
				pieces.Add(string.Format("color=#{0:X2}{1:X2}{2:X2}",
					Color.Value.R, Color.Value.G, Color.Value.B));

			if (Background.HasValue)
				pieces.Add(string.Format("background=#{0:X2}{1:X2}{2:X2}",
					Background.Value.R, Background.Value.G, Background.Value.B));

			if (FontFlags != 0)
			{
				string fontFlagsString = string.Empty;
				if ((FontFlags & FontFlags.Bold) != 0) fontFlagsString += ",bold";
				if ((FontFlags & FontFlags.Italic) != 0) fontFlagsString += ",italic";
				if ((FontFlags & FontFlags.Underline) != 0) fontFlagsString += ",underline";

				if (!string.IsNullOrEmpty(fontFlagsString))
					pieces.Add("font=" + fontFlagsString.Substring(1));
			}

			return string.Join(" ", pieces);
		}

		private static readonly Regex _splitter = new Regex(@"[\x00-\x20]+");
		private static readonly Regex _hexDecoder = new Regex(@"[#](?<Red>[0-9A-Fa-f]{2})(?<Green>[0-9A-Fa-f]{2})(?<Blue>[0-9A-Fa-f]{2})");

		private static Color? ParseColor(string colorValue)
		{
			Match match = _hexDecoder.Match(colorValue);

			if (!match.Success)
				return null;

			int red = int.Parse(match.Groups["Red"].Value, NumberStyles.HexNumber);
			int green = int.Parse(match.Groups["Green"].Value, NumberStyles.HexNumber);
			int blue = int.Parse(match.Groups["Blue"].Value, NumberStyles.HexNumber);

			return System.Drawing.Color.FromArgb(red, green, blue);
		}

		public static Style Deserialize(string serialized, StyleKind? styleKindOverride = null)
		{
			Style style = styleKindOverride.HasValue ? new Style(styleKindOverride.Value) : new Style();

			foreach (string piece in _splitter.Split(serialized))
			{
				int eqIndex = piece.IndexOf('=');
				if (eqIndex < 0) continue;

				string key = piece.Substring(0, eqIndex);
				string value = piece.Substring(eqIndex + 1);

				switch (key)
				{
					case "kind":
						if (!styleKindOverride.HasValue)
						{
							Enum.TryParse(value, out StyleKind styleKind);
							style = style.WithStyleKind(styleKind);
						}
						break;

					case "color":
						style = style.WithColor(ParseColor(value));
						break;

					case "background":
						style = style.WithBackground(ParseColor(value));
						break;

					case "font":
						FontFlags fontFlags = 0;
						foreach (string flagValue in value.Split(','))
						{
							switch (flagValue)
							{
								case "bold":      fontFlags |= FontFlags.Bold;      break;
								case "italic":    fontFlags |= FontFlags.Italic;    break;
								case "underline": fontFlags |= FontFlags.Underline; break;
								default: break;
							}
						}
						style = style.WithFontFlags(fontFlags);
						break;
				}
			}

			return style;
		}
	}
}

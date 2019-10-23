using Joy.Types;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;

namespace Joy.Config
{
	public class StyleConfig : IEquatable<StyleConfig>, IEnumerable<Style>
	{
		public readonly ImmutableDictionary<StyleKind, Style> Styles;
		
		public Style? this[StyleKind styleKind]
			=> Styles.TryGetValue(styleKind, out Style style) ? (Style?)style : null;

		/// <summary>
		/// Return the "most default" style for this theme; this guarantees that all values
		/// of the Style object will be filled in with meaningful defaults.
		/// </summary>
		public Style DefaultStyle
		{
			get
			{
				Style style = this[StyleKind.Default] ?? new Style(StyleKind.Default, Color.Black, Color.White);
				if (!style.Color.HasValue)
					style = new Style(style.StyleKind, Color.Black, style.Background, style.FontFlags);
				if (!style.Background.HasValue)
					style = new Style(style.StyleKind, style.Color, Color.White, style.FontFlags);
				return style;
			}
		}

		public StyleConfig()
		{
			Styles = ImmutableDictionary<StyleKind, Style>.Empty;
		}

		public StyleConfig(IEnumerable<Style> styles)
			: this(ImmutableDictionary<StyleKind, Style>.Empty, styles)
		{
		}

		private StyleConfig(ImmutableDictionary<StyleKind, Style> stylesDictionary, IEnumerable<Style> styles)
		{
			if (styles != null)
			{
				foreach (Style style in styles)
				{
					stylesDictionary = stylesDictionary.SetItem(style.StyleKind, style);
				}
			}

			Styles = stylesDictionary;
		}

		public void SaveToRegistry(RegistryKey key)
		{
			StyleKind[] styleKinds = (StyleKind[])Enum.GetValues(typeof(StyleKind));

			HashSet<string> currentValueNames;
			try
			{
				currentValueNames = new HashSet<string>(key.GetValueNames());
			}
			catch
			{
				currentValueNames = new HashSet<string>();
			}

			foreach (StyleKind styleKind in styleKinds)
			{
				Style? style = this[styleKind];
				string valueName = styleKind.ToString();
				try
				{
					if (style.HasValue)
						key.SetValue(valueName, style.Value.Serialize(false));
					else
					{
						if (currentValueNames.Contains(valueName))
							key.DeleteValue(valueName);
					}
				}
				catch { }
			}
		}

		public static StyleConfig LoadFromRegistry(RegistryKey key)
		{
			if (key == null)
				return new StyleConfig(DefaultStyles.LightTheme);

			List<Style> styles = new List<Style>();

			foreach (string valueName in key.GetValueNames())
			{
				try
				{
					if (Enum.TryParse(valueName, out StyleKind styleKind))
					{
						string value = key.GetValue(valueName).ToString();
						Style style = Style.Deserialize(value, styleKind);
						styles.Add(style);
					}
				}
				catch { }
			}

			return new StyleConfig(styles);
		}

		public StyleConfig WithStyles(IEnumerable<Style> styles)
		{
			if (styles == null) return this;
			return new StyleConfig(Styles, styles);
		}

		public StyleConfig WithStyles(params Style[] styles)
		{
			return new StyleConfig(Styles, styles);
		}

		public StyleConfig WithoutStyleKinds(IEnumerable<StyleKind> styleKinds)
		{
			if (styleKinds == null) return this;
			return new StyleConfig(Styles.RemoveRange(styleKinds), null);
		}

		public StyleConfig WithoutStyleKinds(params StyleKind[] styleKinds)
		{
			return new StyleConfig(Styles.RemoveRange(styleKinds), null);
		}

		public override bool Equals(object obj)
			=> Equals(obj as StyleConfig);

		public bool Equals(StyleConfig other)
			=> !ReferenceEquals(other, null) && ReferenceEquals(Styles, other.Styles);

		public static bool operator ==(StyleConfig a, StyleConfig b)
			=> ReferenceEquals(a, null) ? ReferenceEquals(b, null) : a.Equals(b);
		public static bool operator !=(StyleConfig a, StyleConfig b)
			=> ReferenceEquals(a, null) ? !ReferenceEquals(b, null) : !a.Equals(b);

		public override int GetHashCode()
			=> Styles.GetHashCode();

		public override string ToString()
			=> string.Join("\r\n", Styles.Values.OrderBy(s => (int)s.StyleKind).Select(s => s.ToString()));

		public IEnumerator<Style> GetEnumerator() => Styles.Values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public int Count => Styles.Count;
	}
}

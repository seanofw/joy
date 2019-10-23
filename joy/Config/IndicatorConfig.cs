using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;

namespace Joy.Config
{
	public class IndicatorConfig : IEquatable<IndicatorConfig>, IEnumerable<IndicatorStyle>
	{
		public readonly ImmutableDictionary<IndicatorKind, IndicatorStyle> Styles;

		public IndicatorStyle? this[IndicatorKind IndicatorKind]
			=> Styles.TryGetValue(IndicatorKind, out IndicatorStyle style) ? (IndicatorStyle?)style : null;

		public IndicatorStyle NoStyle => _noStyle;
		private static readonly IndicatorStyle _noStyle = new IndicatorStyle(IndicatorKind.None, IndicatorShape.Hidden, Color.Black);

		public IndicatorConfig()
		{
			Styles = ImmutableDictionary<IndicatorKind, IndicatorStyle>.Empty;
		}

		public IndicatorConfig(IEnumerable<IndicatorStyle> styles)
			: this(ImmutableDictionary<IndicatorKind, IndicatorStyle>.Empty, styles)
		{
		}

		private IndicatorConfig(ImmutableDictionary<IndicatorKind, IndicatorStyle> stylesDictionary, IEnumerable<IndicatorStyle> styles)
		{
			if (styles != null)
			{
				foreach (IndicatorStyle style in styles)
				{
					stylesDictionary = stylesDictionary.SetItem(style.IndicatorKind, style);
				}
			}

			Styles = stylesDictionary;
		}

		public IndicatorConfig WithStyles(IEnumerable<IndicatorStyle> styles)
		{
			if (styles == null) return this;
			return new IndicatorConfig(Styles, styles);
		}

		public IndicatorConfig WithStyles(params IndicatorStyle[] styles)
		{
			return new IndicatorConfig(Styles, styles);
		}

		public IndicatorConfig WithoutIndicatorKinds(IEnumerable<IndicatorKind> IndicatorKinds)
		{
			if (IndicatorKinds == null) return this;
			return new IndicatorConfig(Styles.RemoveRange(IndicatorKinds), null);
		}

		public IndicatorConfig WithoutIndicatorKinds(params IndicatorKind[] IndicatorKinds)
		{
			return new IndicatorConfig(Styles.RemoveRange(IndicatorKinds), null);
		}

		public override bool Equals(object obj)
			=> Equals(obj as IndicatorConfig);

		public bool Equals(IndicatorConfig other)
			=> !ReferenceEquals(other, null) && ReferenceEquals(Styles, other.Styles);

		public static bool operator ==(IndicatorConfig a, IndicatorConfig b)
			=> ReferenceEquals(a, null) ? ReferenceEquals(b, null) : a.Equals(b);
		public static bool operator !=(IndicatorConfig a, IndicatorConfig b)
			=> ReferenceEquals(a, null) ? !ReferenceEquals(b, null) : !a.Equals(b);

		public override int GetHashCode()
			=> Styles.GetHashCode();

		public override string ToString()
			=> string.Join("\r\n", Styles.Values.OrderBy(s => (int)s.IndicatorKind).Select(s => s.ToString()));

		public IEnumerator<IndicatorStyle> GetEnumerator() => Styles.Values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public int Count => Styles.Count;
	}

}

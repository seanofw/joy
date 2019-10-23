using System;
using System.Drawing;

namespace Joy.Config
{
	public struct IndicatorStyle : IEquatable<IndicatorStyle>
	{
		public readonly IndicatorKind IndicatorKind;
		public readonly IndicatorShape IndicatorShape;
		public readonly Color Color;
		public readonly bool BehindText;

		public IndicatorStyle(IndicatorKind indicatorKind, IndicatorShape indicatorShape, Color color, bool behindText = false)
		{
			IndicatorKind = indicatorKind;
			IndicatorShape = indicatorShape;
			Color = color;
			BehindText = behindText;
		}

		public override bool Equals(object obj)
			=> (obj is IndicatorStyle style) && Equals(style);

		public bool Equals(IndicatorStyle other)
			=> IndicatorKind == other.IndicatorKind && IndicatorShape == other.IndicatorShape
				&& Color == other.Color && BehindText == other.BehindText;

		public override int GetHashCode()
			=> ((BehindText.GetHashCode() * 29
				+ (int)IndicatorShape) * 29
				+ Color.GetHashCode()) * 29
				+ (int)IndicatorKind;

		public static bool operator ==(IndicatorStyle a, IndicatorStyle b) => a.Equals(b);
		public static bool operator !=(IndicatorStyle a, IndicatorStyle b) => !a.Equals(b);

		public override string ToString()
		{
			string colorString = $"({Color.R},{Color.G},{Color.B})";

			return $"{IndicatorKind}: Shape={IndicatorShape}, Color={colorString}, BehindText={BehindText}";
		}
	}

}

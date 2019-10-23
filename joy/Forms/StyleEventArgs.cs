using Joy.Config;
using Joy.Types;
using System;

namespace Joy.Forms
{
	public class StyleChangedEventArgs : EventArgs
	{
		public Style? Style { get; }
		public StyleKind StyleKind { get; }

		public StyleChangedEventArgs(StyleKind styleKind, Style? style)
		{
			StyleKind = styleKind;
			Style = style;
		}
	}
}
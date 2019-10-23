using System;

namespace Joy.Config
{
	[Flags]
	public enum FontFlags : byte
	{
		Bold = (1 << 0),
		Italic = (1 << 1),
		Underline = (1 << 2),
		FillLine = (1 << 3),	// Fill the background of the rest of the line, if this is at a newline.
	}
}

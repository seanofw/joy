using System;

namespace Joy.Types
{
	public class StatusEventArgs : EventArgs
	{
		public readonly int Line;
		public readonly int Column;
		public readonly int CharOfLine;
		public readonly int SelectionStart;
		public readonly int SelectionEnd;
		public readonly int Lines;
		public readonly int Chars;

		public StatusEventArgs(int line, int column, int charOfLine,
			int selectionStart, int selectionEnd, int lines, int chars)
		{
			Line = line;
			Column = column;
			CharOfLine = charOfLine;
			SelectionStart = selectionStart;
			SelectionEnd = selectionEnd;
			Lines = lines;
			Chars = chars;
		}
	}
}
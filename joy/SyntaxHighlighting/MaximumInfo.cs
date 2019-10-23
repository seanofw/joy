namespace Joy.SyntaxHighlighting
{
	internal struct MaximumInfo
	{
		public int Lines { get; }
		public int Columns { get; }
		public int LineOfMaxColumn { get; }

		public MaximumInfo(int lines, int columns, int lineOfMaxColumn)
		{
			Lines = lines;
			Columns = columns;
			LineOfMaxColumn = lineOfMaxColumn;
		}

		public override string ToString()
			=> $"Lines: {Lines}, Columns: {Columns}, LineOfMaxColumn: {LineOfMaxColumn}";
	}
}
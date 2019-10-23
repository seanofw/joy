namespace Joy.Types
{
	public class FindInfo
	{
		public readonly string Pattern;
		public readonly bool CaseSensitive;
		public readonly bool WholeWord;
		public readonly bool UseRegex;

		public FindInfo(string pattern = "",
			bool caseSensitive = false, bool wholeWord = false, bool useRegex = false)
		{
			Pattern = pattern;
			CaseSensitive = caseSensitive;
			WholeWord = wholeWord;
			UseRegex = useRegex;
		}
	}
}
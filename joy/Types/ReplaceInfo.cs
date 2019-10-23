namespace Joy.Types
{
	public class ReplaceInfo
	{
		public readonly string Pattern;
		public readonly string Replacement;
		public readonly bool CaseSensitive;
		public readonly bool WholeWord;
		public readonly bool UseRegex;

		public ReplaceInfo(string pattern = "", string replacement = "",
			bool caseSensitive = false, bool wholeWord = false, bool useRegex = false)
		{
			Pattern = pattern;
			Replacement = replacement;
			CaseSensitive = caseSensitive;
			WholeWord = wholeWord;
			UseRegex = useRegex;
		}
	}
}
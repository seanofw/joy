namespace Joy.Config
{
	public enum ConfigSectionFlags
	{
		AppConfig				= (1 << 0),
		TextEditorConfig		= (1 << 1),
		StyleConfig				= (1 << 2),
		IndicatorConfig			= (1 << 3),
		RecentFiles				= (1 << 4),
		RecentFindPatterns		= (1 << 5),
		RecentReplacePatterns	= (1 << 6),
		RecentReplacements		= (1 << 7),

		None = 0,
		All = (AppConfig | TextEditorConfig | StyleConfig | IndicatorConfig
			| RecentFiles | RecentFindPatterns | RecentReplacePatterns | RecentReplacements),
	}
}
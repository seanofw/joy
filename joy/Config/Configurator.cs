using Joy.Types;
using Microsoft.Win32;
using System;

namespace Joy.Config
{
	public class Configurator
	{
		public AppConfig AppConfig
		{
			get => _appConfig;
			set
			{
				_appConfig = value;
				SaveConfigToRegistry(ConfigSectionFlags.AppConfig);
				AppConfigChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		private AppConfig _appConfig = new AppConfig();

		public event EventHandler AppConfigChanged;

		public TextEditorConfig TextEditorConfig
		{
			get => _textEditorConfig;
			set
			{
				_textEditorConfig = value;
				SaveConfigToRegistry(ConfigSectionFlags.TextEditorConfig);
				TextEditorConfigChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		private TextEditorConfig _textEditorConfig = new TextEditorConfig();

		public event EventHandler TextEditorConfigChanged;

		public StyleConfig StyleConfig
		{
			get => _styleConfig;
			set
			{
				_styleConfig = value;
				SaveConfigToRegistry(ConfigSectionFlags.StyleConfig);
				StyleConfigChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		private StyleConfig _styleConfig = new StyleConfig();

		public event EventHandler StyleConfigChanged;

		public IndicatorConfig IndicatorConfig
		{
			get => _indicatorConfig;
			set
			{
				_indicatorConfig = value;
				SaveConfigToRegistry(ConfigSectionFlags.IndicatorConfig);
				IndicatorConfigChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		private IndicatorConfig _indicatorConfig = new IndicatorConfig();

		public event EventHandler IndicatorConfigChanged;

		public RecentItems<string> RecentFiles { get; private set; }
		public event EventHandler<RecentItemsChangedEventArgs> RecentFilesChanged;

		public RecentItems<string> RecentFindPatterns { get; private set; }
		public event EventHandler<RecentItemsChangedEventArgs> RecentFindPatternsChanged;

		public RecentItems<string> RecentReplacePatterns { get; private set; }
		public event EventHandler<RecentItemsChangedEventArgs> RecentReplacePatternsChanged;

		public RecentItems<string> RecentReplacements { get; private set; }
		public event EventHandler<RecentItemsChangedEventArgs> RecentReplacementsChanged;

		public Configurator()
		{
			RecentFiles = new RecentItems<string>(10);
			RecentFiles.Changed += (sender, e) => RecentFilesChanged?.Invoke(sender, e);
			RecentFiles.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentFiles);

			RecentFindPatterns = new RecentItems<string>(10);
			RecentFindPatterns.Changed += (sender, e) => RecentFindPatternsChanged?.Invoke(sender, e);
			RecentFindPatterns.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentFindPatterns);

			RecentReplacePatterns = new RecentItems<string>(50);
			RecentReplacePatterns.Changed += (sender, e) => RecentReplacePatternsChanged?.Invoke(sender, e);
			RecentReplacePatterns.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentReplacePatterns);

			RecentReplacements = new RecentItems<string>(50);
			RecentReplacements.Changed += (sender, e) => RecentReplacementsChanged?.Invoke(sender, e);
			RecentReplacements.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentReplacements);
		}

		public void LoadConfigFromRegistry()
		{
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\SmileFoundation\Joy", RegistryKeyPermissionCheck.ReadSubTree))
			{
				try
				{
					using (RegistryKey childKey = key.OpenSubKey("AppConfig", RegistryKeyPermissionCheck.ReadSubTree))
					{
						_appConfig = AppConfig.LoadFromRegistry(childKey);
					}
				}
				catch
				{
					_appConfig = AppConfig.LoadFromRegistry(null);
				}

				try
				{
					using (RegistryKey childKey = key.OpenSubKey("TextEditorConfig", RegistryKeyPermissionCheck.ReadSubTree))
					{
						_textEditorConfig = TextEditorConfig.LoadFromRegistry(childKey);
					}
				}
				catch
				{
					_textEditorConfig = TextEditorConfig.LoadFromRegistry(null);
				}

				try
				{
					using (RegistryKey childKey = key.OpenSubKey("StyleConfig", RegistryKeyPermissionCheck.ReadSubTree))
					{
						_styleConfig = StyleConfig.LoadFromRegistry(childKey);
					}
				}
				catch
				{
					_styleConfig = StyleConfig.LoadFromRegistry(null);
				}

				try
				{
					using (RegistryKey childKey = key.OpenSubKey("RecentFiles", RegistryKeyPermissionCheck.ReadSubTree))
					{
						RecentFiles = RecentItems<string>.LoadFromRegistry(childKey, 10);
					}
				}
				catch
				{
					RecentFiles = new RecentItems<string>(10);
				}
				RecentFiles.Changed += (sender, e) => RecentFilesChanged?.Invoke(sender, e);
				RecentFiles.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentFiles);

				try
				{
					using (RegistryKey childKey = key.OpenSubKey("Find\\RecentPatterns", RegistryKeyPermissionCheck.ReadSubTree))
					{
						RecentFindPatterns = RecentItems<string>.LoadFromRegistry(childKey, 50);
					}
				}
				catch
				{
					RecentFindPatterns = new RecentItems<string>(50);
				}
				RecentFindPatterns.Changed += (sender, e) => RecentFindPatternsChanged?.Invoke(sender, e);
				RecentFindPatterns.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentFindPatterns);

				try
				{
					using (RegistryKey childKey = key.OpenSubKey("Replace\\RecentPatterns", RegistryKeyPermissionCheck.ReadSubTree))
					{
						RecentReplacePatterns = RecentItems<string>.LoadFromRegistry(childKey, 50);
					}
				}
				catch
				{
					RecentReplacePatterns = new RecentItems<string>(50);
				}
				RecentReplacePatterns.Changed += (sender, e) => RecentReplacePatternsChanged?.Invoke(sender, e);
				RecentReplacePatterns.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentReplacePatterns);

				try
				{
					using (RegistryKey childKey = key.OpenSubKey("Replace\\RecentReplacements", RegistryKeyPermissionCheck.ReadSubTree))
					{
						RecentReplacements = RecentItems<string>.LoadFromRegistry(childKey, 50);
					}
				}
				catch
				{
					RecentReplacements = new RecentItems<string>(50);
				}
				RecentReplacements.Changed += (sender, e) => RecentReplacementsChanged?.Invoke(sender, e);
				RecentReplacements.Changed += (sender, e) => SaveConfigToRegistry(ConfigSectionFlags.RecentReplacements);
			}

			AppConfigChanged?.Invoke(this, EventArgs.Empty);
			TextEditorConfigChanged?.Invoke(this, EventArgs.Empty);
			StyleConfigChanged?.Invoke(this, EventArgs.Empty);
			IndicatorConfigChanged?.Invoke(this, EventArgs.Empty);
			RecentFilesChanged?.Invoke(this, new RecentItemsChangedEventArgs(RecentItemsChangeAction.AddRange));
			RecentFindPatternsChanged?.Invoke(this, new RecentItemsChangedEventArgs(RecentItemsChangeAction.AddRange));
			RecentReplacePatternsChanged?.Invoke(this, new RecentItemsChangedEventArgs(RecentItemsChangeAction.AddRange));
			RecentReplacementsChanged?.Invoke(this, new RecentItemsChangedEventArgs(RecentItemsChangeAction.AddRange));
		}

		public void SaveConfigToRegistry(ConfigSectionFlags configSectionFlags = ConfigSectionFlags.All)
		{
			try
			{
				using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\SmileFoundation\Joy", RegistryKeyPermissionCheck.ReadWriteSubTree))
				{
					if ((configSectionFlags & ConfigSectionFlags.AppConfig) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("AppConfig", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								AppConfig.SaveToRegistry(childKey);
							}
						}
						catch { }
					}

					if ((configSectionFlags & ConfigSectionFlags.TextEditorConfig) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("TextEditorConfig", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								TextEditorConfig.SaveToRegistry(childKey);
							}
						}
						catch { }
					}

					if ((configSectionFlags & ConfigSectionFlags.StyleConfig) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("StyleConfig", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								StyleConfig.SaveToRegistry(childKey);
							}
						}
						catch { }
					}

					if ((configSectionFlags & ConfigSectionFlags.RecentFiles) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("RecentFiles", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								RecentFiles.SaveToRegistry(childKey);
							}
						}
						catch { }
					}

					if ((configSectionFlags & ConfigSectionFlags.RecentFindPatterns) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("Find\\RecentPatterns", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								RecentFindPatterns.SaveToRegistry(childKey);
							}
						}
						catch { }
					}

					if ((configSectionFlags & ConfigSectionFlags.RecentReplacePatterns) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("Replace\\RecentPatterns", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								RecentReplacePatterns.SaveToRegistry(childKey);
							}
						}
						catch { }
					}

					if ((configSectionFlags & ConfigSectionFlags.RecentReplacements) != 0)
					{
						try
						{
							using (RegistryKey childKey = key.CreateSubKey("Replace\\RecentReplacements", RegistryKeyPermissionCheck.ReadWriteSubTree))
							{
								RecentReplacePatterns.SaveToRegistry(childKey);
							}
						}
						catch { }
					}
				}
			}
			catch { }
		}
	}
}

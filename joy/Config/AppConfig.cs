using Joy.Extensions;
using Microsoft.Win32;
using System;

namespace Joy.Config
{
	public class AppConfig : IEquatable<AppConfig>
	{
		public readonly ThemeKind Theme;

		public AppConfig()
		{
			Theme = ThemeKind.Light;
		}

		public AppConfig(
			ThemeKind theme
		)
		{
			Theme = theme;
		}

		public void SaveToRegistry(RegistryKey key)
		{
			key.SetValue("Theme", Theme.ToString());
		}

		public static AppConfig LoadFromRegistry(RegistryKey key)
		{
			return new AppConfig(
				theme: key.GetEnumOrDefault<ThemeKind>("Theme", ThemeKind.Light)
			);
		}

		public AppConfig WithZoom(int zoom)
		{
			return new AppConfig(
				theme: Theme
			);
		}

		public AppConfig WithTheme(ThemeKind theme)
		{
			return new AppConfig(
				theme: theme
			);
		}

		public override bool Equals(object obj) => Equals(obj as AppConfig);

		public virtual bool Equals(AppConfig other) =>
			!ReferenceEquals(other, null)
			&& Theme == other.Theme;

		public override int GetHashCode()
		{
			int hashCode = 0;
			hashCode = (hashCode * 29) + Theme.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(AppConfig a, AppConfig b)
			=> ReferenceEquals(a, null) ? ReferenceEquals(b, null) : a.Equals(b);

		public static bool operator !=(AppConfig a, AppConfig b)
			=> ReferenceEquals(a, null) ? !ReferenceEquals(b, null) : !a.Equals(b);

		public override string ToString()
			=> $"Theme={Theme}";
	}
}

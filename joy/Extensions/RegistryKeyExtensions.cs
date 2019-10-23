using Microsoft.Win32;
using System;

namespace Joy.Extensions
{
	public static class RegistryKeyExtensions
	{
		public static bool GetBoolOrDefault(this RegistryKey key, string name, bool defaultValue = default)
		{
			if (key == null)
				return defaultValue;
			object value = key.GetValue(name);
			if (value is int intValue)
				return intValue == 0 ? false
					: intValue == 1 ? true
					: defaultValue;
			return defaultValue;
		}

		public static int GetIntOrDefault(this RegistryKey key, string name, int defaultValue = default,
			int minimumValue = -0x80000000, int maximumValue = 0x7FFFFFFF)
		{
			if (key == null)
				return defaultValue;
			object value = key.GetValue(name);
			if (value is int intValue)
				return intValue >= minimumValue && intValue <= maximumValue ? intValue
					: defaultValue;
			return defaultValue;
		}

		public static T GetEnumOrDefault<T>(this RegistryKey key, string name, T defaultValue = default)
			where T : struct
		{
			if (key == null)
				return defaultValue;
			object value = key.GetValue(name);
			if (value is string stringValue && Enum.TryParse(stringValue, out T result))
				return result;
			return defaultValue;
		}

		public static string GetStringOrDefault(this RegistryKey key, string name, string defaultValue = null)
		{
			if (key == null)
				return defaultValue;
			object value = key.GetValue(name);
			if (value is string stringValue)
				return stringValue;
			return defaultValue;
		}
	}
}

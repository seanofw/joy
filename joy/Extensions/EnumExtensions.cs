using System.ComponentModel;
using System.Reflection;

namespace Joy.Extensions
{
	public static class EnumExtensions
	{
		public static string GetEnumValueDescription<T>(this T enumValue)
			where T : struct
		{
			MemberInfo[] memberInfo = typeof(T).GetMember(enumValue.ToString());

			object[] descriptionAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

			return descriptionAttributes.Length > 0
				? ((DescriptionAttribute)descriptionAttributes[0]).Description
				: null;
		}
	}
}

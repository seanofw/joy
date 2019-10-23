#include "pch.h"
#include "SmileLibInterop.h"
#include "Native/Exports.h"
#include <vcclr.h>

namespace SmileLibInterop {

	public ref class CachedString {
	internal:
		SmileLibInterop::Native::String SmileString;
		System::String ^DotNetString;

	internal:
		CachedString(SmileLibInterop::Native::String smileString,
			System::String ^dotNetString)
		{
			SmileString = smileString;
			DotNetString = dotNetString;
		}
	};

	public ref class StringCache {
	internal:
		static StringCache ^Instance = gcnew StringCache;

	private:
		array<CachedString ^> ^Strings = gcnew array<CachedString ^>(16);
		const int length = 16;

	internal:
		StringCache()
		{
			for (int i = 0; i < length; i++)
			{
				Strings[i] = gcnew CachedString(nullptr, nullptr);
			}
		}

		CachedString ^Find(SmileLibInterop::Native::String smileString)
		{
			for (int i = 0; i < length; i++)
			{
				CachedString ^target = Strings[i];
				if (target->SmileString == smileString) {
					for (int j = i; j > 0; j--) {
						Strings[j] = Strings[j - 1];
					}
					Strings[0] = target;
					return target;
				}
			}
			return nullptr;
		}

		CachedString ^Find(System::String ^dotNetString)
		{
			for (int i = 0; i < length; i++)
			{
				CachedString ^target = Strings[i];
				if (ReferenceEquals(target->DotNetString, dotNetString)) {
					for (int j = i; j > 0; j--) {
						Strings[j] = Strings[j - 1];
					}
					Strings[0] = target;
					return target;
				}
			}
			return nullptr;
		}

		CachedString ^Insert(SmileLibInterop::Native::String smileString, System::String ^dotNetString)
		{
			for (int i = length - 1; i > 0; i--)
			{
				Strings[i] = Strings[i - 1];
			}
			return (Strings[0] = gcnew CachedString(smileString, dotNetString));
		}
	};

	System::String ^Utils::SmileStringToDotNetString(SmileLibInterop::Native::String str)
	{
		if (str == nullptr)
			return nullptr;
		if (str->_opaque.length == 0)
			return System::String::Empty;

		CachedString ^cacheEntry = StringCache::Instance->Find(str);
		if (cacheEntry != nullptr)
			return cacheEntry->DotNetString;

		Native::Int length;
		Native::UInt16 *text16 = SmileLibInterop::Native::String_ToUtf16(str, &length);

		System::String ^dotNetStr = gcnew System::String((wchar_t *)text16, 0, (int)length);

		StringCache::Instance->Insert(str, dotNetStr);
		return dotNetStr;
	}

	SmileLibInterop::Native::String Utils::DotNetStringToSmileString(System::String ^dotNetStr)
	{
		if (dotNetStr == nullptr)
			return nullptr;
		if (dotNetStr->Length == 0)
			return SmileLibInterop::Native::String_Empty;

		pin_ptr<const wchar_t> pinnedChars = PtrToStringChars(dotNetStr);
		int length = dotNetStr->Length;

		SmileLibInterop::Native::String str = SmileLibInterop::Native::String_FromUtf16((const Native::UInt16 *)(const wchar_t *)pinnedChars, length);
		StringCache::Instance->Insert(str, dotNetStr);
		return str;
	}

	SmileLibInterop::Native::String Utils::DotNetStringToSmileStringWithMap(System::String ^dotNetStr, array<System::Int32> ^&map)
	{
		if (dotNetStr == nullptr)
			return nullptr;
		if (dotNetStr->Length == 0)
			return SmileLibInterop::Native::String_Empty;

		pin_ptr<const wchar_t> pinnedChars = PtrToStringChars(dotNetStr);
		int length = dotNetStr->Length;

		SmileLibInterop::Native::Int32 *rawMap;

		SmileLibInterop::Native::String str = SmileLibInterop::Native::String_FromUtf16WithMap((const Native::UInt16 *)(const wchar_t *)pinnedChars, length, &rawMap);
		StringCache::Instance->Insert(str, dotNetStr);
		return str;
	}
}

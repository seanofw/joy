using System;
using System.Collections.Generic;
using System.Drawing;
using static Joy.Win32.Gdi32;

namespace Joy.Win32
{
	public class EnumFontFamiliesEx
	{
		private List<FontData> _fontDatas = new List<FontData>();
		private Func<FontData, bool> _filter;

		private EnumFontFamiliesEx()
		{
		}

		private int EnumFontFamiliesExCallback(ref ENUMLOGFONT lpelf, ref NEWTEXTMETRIC lpntm, uint FontType, IntPtr lParam)
		{
			FontData fontData = new FontData
			{
				LogFont = lpelf,
				TextMetric = lpntm,
				FontType = FontType
			};

			if (_filter == null || _filter(fontData))
				_fontDatas.Add(fontData);

			return 1;
		}

		public static List<FontData> Invoke(Func<FontData, bool> filter = null)
		{
			EnumFontFamiliesEx container = new EnumFontFamiliesEx
			{
				_filter = filter
			};

			Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
			try
			{
				IntPtr hdc = graphics.GetHdc();
				LOGFONT logfont = new LOGFONT
				{
					lfCharSet = (byte)FontLanguageCharSet.DEFAULT_CHARSET
				};
				EnumFontFamiliesEx(hdc, ref logfont, new FONTENUMPROC(container.EnumFontFamiliesExCallback), IntPtr.Zero, 0);
			}
			catch (Exception)
			{
			}
			finally
			{
				graphics.ReleaseHdc();
			}

			return container._fontDatas;
		}
	}
}

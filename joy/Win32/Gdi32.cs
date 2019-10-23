using System;
using System.Runtime.InteropServices;

namespace Joy.Win32
{
	public static class Gdi32
	{
		#region Delegates

		public delegate Int32 FONTENUMPROC(ref ENUMLOGFONT lpelf, ref NEWTEXTMETRIC lpntm, UInt32 FontType, IntPtr lParam);

		#endregion

		#region Enums

		/// <summary>
		/// From WinGDI.h
		/// #define RASTER_FONTTYPE     0x0001
		/// #define DEVICE_FONTTYPE     0x0002
		/// #define TRUETYPE_FONTTYPE   0x0004
		/// </summary>
		public enum FontMask
		{
			RASTER_FONTTYPE = 0x0001,
			DEVICE_FONTTYPE = 0x0002,
			TRUETYPE_FONTTYPE = 0x0004
		}

		/// <summary>
		/// From WinGDI.h
		/// #define FW_DONTCARE     0
		/// #define FW_THIN         100
		/// #define FW_EXTRALIGHT       200
		/// #define FW_LIGHT        300
		/// #define FW_NORMAL       400
		/// #define FW_MEDIUM       500
		/// #define FW_SEMIBOLD     600
		/// #define FW_BOLD         700
		/// #define FW_EXTRABOLD    800
		/// #define FW_HEAVY        900
		/// #define FW_ULTRALIGHT       FW_EXTRALIGHT
		/// #define FW_REGULAR      FW_NORMAL
		/// #define FW_DEMIBOLD     FW_SEMIBOLD
		/// #define FW_ULTRABOLD    FW_EXTRABOLD
		/// #define FW_BLACK        FW_HEAVY
		/// </summary>
		public enum FontWeight
		{
			FW_DONTCARE = 0,
			FW_THIN = 100,
			FW_EXTRALIGHT = 200,
			FW_LIGHT = 300,
			FW_NORMAL = 400,
			FW_MEDIUM = 500,
			FW_SEMIBOLD = 600,
			FW_BOLD = 700,
			FW_EXTRABOLD = 800,
			FW_HEAVY = 900
		}

		/// <summary>
		/// From WinGDI.h
		///    #define DEFAULT_PITCH       0
		/// #define FIXED_PITCH         1
		/// #define VARIABLE_PITCH      2
		/// #if(WINVER >= 0x0400)
		/// #define MONO_FONT           8
		/// #endif /* WINVER >= 0x0400 */
		/// </summary>
		public enum FontPitch : int
		{
			DEFAULT_PITCH = 0,
			FIXED_PITCH = 1,
			VARIABLE_PITCH = 2,
			MONO_FONT = 8
		}

		/// <summary>
		/// From WinGDI.h
		/// #define FF_DONTCARE     (0<<4)  Don't care or don't know.
		/// #define FF_ROMAN        (1<<4)  Variable stroke width, serifed.
		///                                        Times Roman, Century Schoolbook, etc.
		/// #define FF_SWISS        (2<<4)  Variable stroke width, sans-serifed.
		///                                        Helvetica, Swiss, etc.
		/// #define FF_MODERN       (3<<4)  Constant stroke width, serifed or sans-serifed.
		///                                        Pica, Elite, Courier, etc.
		/// #define FF_SCRIPT       (4<<4)  Cursive, etc.
		/// #define FF_DECORATIVE       (5<<4)  Old English, etc.
		/// </summary>
		public enum FontFamily
		{
			FF_DONTCARE = 0 << 4,
			FF_ROMAN = 1 << 4,
			FF_SWISS = 2 << 4,
			FF_MODERN = 3 << 4,
			FF_SCRIPT = 4 << 4,
			FF_DECORATIVE = 5 << 4,

			FF_MASK = 0xF << 4,
		}

		/// <summary>
		/// From WinGDI.h
		/// #define MM_TEXT         1
		/// #define MM_LOMETRIC     2
		/// #define MM_HIMETRIC     3
		/// #define MM_LOENGLISH    4
		/// #define MM_HIENGLISH    5
		/// #define MM_TWIPS        6
		/// #define MM_ISOTROPIC    7
		/// #define MM_ANISOTROPIC      8
		/// </summary>
		public enum FontMappingMode
		{
			MM_TEXT = 1,
			MM_LOMETRIC = 2,
			MM_HIMETRIC = 3,
			MM_LOENGLISH = 4,
			MM_HIENGLISH = 5,
			MM_TWIPS = 6,
			MM_ISOTROPIC = 7,
			MM_ANISOTROPIC = 8
		}

		public enum FontLanguageCharSet
		{
			ANSI_CHARSET = 0x00000000,
			DEFAULT_CHARSET = 0x00000001,
			SYMBOL_CHARSET = 0x00000002,
			MAC_CHARSET = 0x0000004D,
			SHIFTJIS_CHARSET = 0x00000080,
			HANGUL_CHARSET = 0x00000081,
			JOHAB_CHARSET = 0x00000082,
			GB2312_CHARSET = 0x00000086,
			CHINESEBIG5_CHARSET = 0x00000088,
			GREEK_CHARSET = 0x000000A1,
			TURKISH_CHARSET = 0x000000A2,
			VIETNAMESE_CHARSET = 0x000000A3,
			HEBREW_CHARSET = 0x000000B1,
			ARABIC_CHARSET = 0x000000B2,
			BALTIC_CHARSET = 0x000000BA,
			RUSSIAN_CHARSET = 0x000000CC,
			THAI_CHARSET = 0x000000DE,
			EASTEUROPE_CHARSET = 0x000000EE,
			OEM_CHARSET = 0x000000FF
		}

		public const Int32 LF_FACESIZE = 32; // ref WinGDI.h
		public const Int32 LF_FULLFACESIZE = 64; // ref WinGDI.h

		#endregion

		#region Structs

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LOGFONT
		{
			public Int32 lfHeight;
			public Int32 lfWidth;
			public Int32 lfEscapement;
			public Int32 lfOrientation;
			public Int32 lfWeight;
			public Byte lfItalic;
			public Byte lfUnderline;
			public Byte lfStrikeOut;
			public Byte lfCharSet;
			public Byte lfOutPrecision;
			public Byte lfClipPrecision;
			public Byte lfQuality;
			public Byte lfPitchAndFamily;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
			public String lfFaceName;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TEXTMETRIC
		{
			public Int32 tmHeight;
			public Int32 tmAscent;
			public Int32 tmDescent;
			public Int32 tmInternalLeading;
			public Int32 tmExternalLeading;
			public Int32 tmAveCharWidth;
			public Int32 tmMaxCharWidth;
			public Int32 tmWeight;
			public Int32 tmOverhang;
			public Int32 tmDigitizedAspectX;
			public Int32 tmDigitizedAspectY;
			public Char tmFirstChar;
			public Char tmLastChar;
			public Char tmDefaultChar;
			public Char tmBreakChar;
			public Byte tmItalic;
			public Byte tmUnderlined;
			public Byte tmStruckOut;
			public Byte tmPitchAndFamily;
			public Byte tmCharSet;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ENUMLOGFONT
		{
			public LOGFONT elfLogFont;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FULLFACESIZE)]
			public String elfFullName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
			public String elfStyle;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NEWTEXTMETRIC
		{
			public Int32 tmHeight;
			public Int32 tmAscent;
			public Int32 tmDescent;
			public Int32 tmInternalLeading;
			public Int32 tmExternalLeading;
			public Int32 tmAveCharWidth;
			public Int32 tmMaxCharWidth;
			public Int32 tmWeight;
			public Int32 tmOverhang;
			public Int32 tmDigitizedAspectX;
			public Int32 tmDigitizedAspectY;
			public Char tmFirstChar;
			public Char tmLastChar;
			public Char tmDefaultChar;
			public Char tmBreakChar;
			public Byte tmItalic;
			public Byte tmUnderlined;
			public Byte tmStruckOut;
			public Byte tmPitchAndFamily;
			public Byte tmCharSet;
			public UInt32 ntmFlags;
			public UInt32 ntmSizeEM;
			public UInt32 ntmCellHeight;
			public UInt32 ntmAvgWidth;
		}

		#endregion

		#region API functions

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int EnumFontFamiliesEx(IntPtr hdc, ref LOGFONT lpLogfont,
			FONTENUMPROC lpEnumFontFamExProc, IntPtr lParam, uint dwFlags);

		#endregion
	}
}

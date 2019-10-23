using Joy.Types;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Joy.Config
{
	public static class DefaultStyles
	{
		public static readonly IList<IndicatorStyle> LightThemeIndicators = new ReadOnlyCollection<IndicatorStyle>(new IndicatorStyle[]
		{
			new IndicatorStyle(IndicatorKind.Error, IndicatorShape.Squiggle, Color.Red),
			new IndicatorStyle(IndicatorKind.Warning, IndicatorShape.Squiggle, Color.Blue),
			new IndicatorStyle(IndicatorKind.Suggestion, IndicatorShape.Squiggle, Color.Green),
		});

		public static readonly IList<Style> LightTheme = new ReadOnlyCollection<Style>(new Style[]
		{
			new Style(StyleKind.Default, Color.Black, Color.White),

			new Style(StyleKind.Meta_CursorColor, Color.Black),
			new Style(StyleKind.Meta_Error, Color.Red),
			new Style(StyleKind.Meta_Whitespace, Color.LightGray),
			new Style(StyleKind.Meta_Selection, background: Color.FromArgb(153, 201, 240)),

			new Style(StyleKind.Comment_Docs, Color.Gray),
			new Style(StyleKind.Comment_HashBang, Color.LightGray),
			new Style(StyleKind.Comment_MultiLine, Color.Green, Color.FromArgb(240, 255, 240), FontFlags.FillLine),
			new Style(StyleKind.Comment_SingleLine, Color.Green),
			new Style(StyleKind.Comment_SeparatorHyphen, Color.FromArgb(64, 160, 64)),
			new Style(StyleKind.Comment_SeparatorEquals, Color.FromArgb(64, 160, 64)),

			new Style(StyleKind.Const_RawString, Color.DarkRed),
			new Style(StyleKind.Const_DynamicString, Color.DarkRed),
			new Style(StyleKind.Const_LongRawString, Color.DarkRed, Color.FromArgb(255, 248, 248), FontFlags.FillLine),
			new Style(StyleKind.Const_LongDynamicString, Color.DarkRed, Color.FromArgb(255, 248, 248), FontFlags.FillLine),

			new Style(StyleKind.Const_Char, Color.SaddleBrown),
			new Style(StyleKind.Const_Uni, Color.SaddleBrown),
			new Style(StyleKind.Const_Symbol, Color.FromArgb(0x8B, 0x22, 0x11)),
			new Style(StyleKind.Const_Integer, Color.SaddleBrown),
			new Style(StyleKind.Const_Real, Color.SaddleBrown),
			new Style(StyleKind.Const_Float, Color.SaddleBrown),

			new Style(StyleKind.Parse_Include, Color.DarkViolet),
			new Style(StyleKind.Parse_IncludeAs, Color.DarkViolet),
			new Style(StyleKind.Parse_Syntax, Color.DarkViolet),
			new Style(StyleKind.Parse_Regex, Color.DarkViolet),
			new Style(StyleKind.Parse_OtherStandardLoanword, Color.DarkViolet),
			new Style(StyleKind.Parse_CustomLoanword, Color.DarkViolet),
			new Style(StyleKind.Parse_LoanwordDeclaration, Color.DarkViolet),
			new Style(StyleKind.Parse_SyntaxClass, Color.FromArgb(96, 0, 96)),

			new Style(StyleKind.Loanword_XmlDefault, Color.DarkRed, Color.FromArgb(240, 240, 240)),
			new Style(StyleKind.Loanword_JsonDefault, Color.DarkRed, Color.FromArgb(248, 248, 224)),

			new Style(StyleKind.Keyword_Standard, Color.Blue),
			new Style(StyleKind.Keyword_Declaration, Color.Blue),

			new Style(StyleKind.Name_Variable, Color.FromArgb(0, 128, 128)),
			new Style(StyleKind.Name_Property, Color.FromArgb(160, 120, 80)),
			new Style(StyleKind.Name_TypeName, Color.FromArgb(0, 160, 160)),
			new Style(StyleKind.Name_ConstVariable, Color.FromArgb(0, 96, 96)),
			new Style(StyleKind.Name_AutoVariable, Color.FromArgb(0, 48, 96)),
			new Style(StyleKind.Name_TillFlag, Color.FromArgb(0, 0, 96)),

			new Style(StyleKind.Declaration_Variable, Color.FromArgb(0, 128, 128), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_TypeName, Color.FromArgb(0, 160, 160), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_ConstVariable, Color.FromArgb(0, 96, 96), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_AutoVariable, Color.FromArgb(0, 48, 96), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_TillFlag, Color.FromArgb(0, 0, 96), fontFlags: FontFlags.Underline),

			new Style(StyleKind.Special_FunctionDeclaration, Color.Purple),
			new Style(StyleKind.Special_VariableSubstitution, Color.FromArgb(0, 128, 128)),
			new Style(StyleKind.Special_Splice, Color.FromArgb(0, 128, 128)),
			new Style(StyleKind.Special_SpecialForm, Color.Blue),

			new Style(StyleKind.Meta_LineNumber, Color.FromArgb(64, 128, 128), Color.FromArgb(240, 240, 240)),
			new Style(StyleKind.Meta_IndentGuide, Color.LightGray),
			new Style(StyleKind.Meta_BraceMatch, Color.DarkGreen, Color.FromArgb(224, 255, 224), FontFlags.Bold),
			new Style(StyleKind.Meta_BraceMismatch, Color.Red, Color.FromArgb(255, 240, 240), FontFlags.Bold),
		});

		public static readonly IList<Style> DarkTheme = new ReadOnlyCollection<Style>(new Style[]
		{
			new Style(StyleKind.Default, Color.White, Color.FromArgb(32, 32, 32)),

			new Style(StyleKind.Meta_CursorColor, Color.White),
			new Style(StyleKind.Meta_Error, Color.FromArgb(255, 64, 64)),
			new Style(StyleKind.Meta_Whitespace, Color.FromArgb(64, 64, 64)),
			new Style(StyleKind.Meta_Selection, background: Color.FromArgb(40, 80, 120)),

			new Style(StyleKind.Comment_Docs, Color.LightGray),
			new Style(StyleKind.Comment_HashBang, Color.FromArgb(96, 96, 96)),
			new Style(StyleKind.Comment_MultiLine, Color.FromArgb(32, 224, 32), Color.FromArgb(24, 40, 24), FontFlags.FillLine),
			new Style(StyleKind.Comment_SingleLine, Color.FromArgb(32, 224, 32)),
			new Style(StyleKind.Comment_SeparatorHyphen, Color.FromArgb(0, 128, 0)),
			new Style(StyleKind.Comment_SeparatorEquals, Color.FromArgb(0, 128, 0)),

			new Style(StyleKind.Const_RawString, Color.FromArgb(255, 128, 128)),
			new Style(StyleKind.Const_DynamicString, Color.FromArgb(255, 128, 128)),
			new Style(StyleKind.Const_LongRawString, Color.FromArgb(255, 128, 128), Color.FromArgb(48, 32, 32), FontFlags.FillLine),
			new Style(StyleKind.Const_LongDynamicString, Color.FromArgb(255, 128, 128), Color.FromArgb(48, 32, 32), FontFlags.FillLine),

			new Style(StyleKind.Const_Char, Color.FromArgb(255, 192, 128)),
			new Style(StyleKind.Const_Uni, Color.FromArgb(255, 192, 128)),
			new Style(StyleKind.Const_Symbol, Color.FromArgb(255, 192, 160)),
			new Style(StyleKind.Const_Integer, Color.FromArgb(255, 192, 128)),
			new Style(StyleKind.Const_Real, Color.FromArgb(255, 192, 128)),
			new Style(StyleKind.Const_Float, Color.FromArgb(255, 192, 128)),

			new Style(StyleKind.Parse_Include, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_IncludeAs, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_Syntax, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_Regex, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_OtherStandardLoanword, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_CustomLoanword, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_LoanwordDeclaration, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Parse_SyntaxClass, Color.FromArgb(224, 160, 224)),

			new Style(StyleKind.Loanword_XmlDefault, Color.FromArgb(255, 128, 128), Color.FromArgb(64, 64, 64)),
			new Style(StyleKind.Loanword_JsonDefault, Color.FromArgb(255, 128, 128), Color.FromArgb(32, 32, 64)),

			new Style(StyleKind.Keyword_Standard, Color.FromArgb(128, 160, 255)),
			new Style(StyleKind.Keyword_Declaration, Color.FromArgb(128, 160, 255)),

			new Style(StyleKind.Name_Variable, Color.FromArgb(128, 255, 255)),
			new Style(StyleKind.Name_Property, Color.FromArgb(255, 224, 192)),
			new Style(StyleKind.Name_TypeName, Color.FromArgb(128, 224, 224)),
			new Style(StyleKind.Name_ConstVariable, Color.FromArgb(192, 255, 255)),
			new Style(StyleKind.Name_AutoVariable, Color.FromArgb(192, 224, 255)),
			new Style(StyleKind.Name_TillFlag, Color.FromArgb(192, 192, 255)),

			new Style(StyleKind.Declaration_Variable, Color.FromArgb(128, 255, 255), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_TypeName, Color.FromArgb(128, 224, 224), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_ConstVariable, Color.FromArgb(192, 255, 255), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_AutoVariable, Color.FromArgb(192, 224, 255), fontFlags: FontFlags.Underline),
			new Style(StyleKind.Declaration_TillFlag, Color.FromArgb(192, 192, 255), fontFlags: FontFlags.Underline),

			new Style(StyleKind.Special_FunctionDeclaration, Color.FromArgb(224, 128, 224)),
			new Style(StyleKind.Special_VariableSubstitution, Color.FromArgb(128, 255, 255)),
			new Style(StyleKind.Special_Splice, Color.FromArgb(128, 255, 255)),
			new Style(StyleKind.Special_SpecialForm, Color.FromArgb(128, 160, 255)),

			new Style(StyleKind.Meta_LineNumber, Color.FromArgb(64, 128, 128), Color.FromArgb(40, 40, 40)),
			new Style(StyleKind.Meta_IndentGuide, Color.FromArgb(64, 64, 64)),
			new Style(StyleKind.Meta_BraceMatch, Color.FromArgb(224, 255, 224), Color.FromArgb(32, 96, 32), FontFlags.Bold),
			new Style(StyleKind.Meta_BraceMismatch, Color.FromArgb(255, 240, 240), Color.FromArgb(192, 64, 64), FontFlags.Bold),
		});
	}
}

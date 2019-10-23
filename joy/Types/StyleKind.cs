
using System.ComponentModel;

namespace Joy.Types
{
	public enum StyleKind : byte
	{
		[Description("Normal text")]							Default = 0,

		[Description("|")]										Meta_CursorColor = 16,
		[Description("Background for the current line")]		Meta_CursorLineBackground = 17,
		[Description("Background for selected text")]			Meta_Selection = 18,
		[Description("Line numbers")]							Meta_LineNumber = 33,
		[Description("{ ... }")]								Meta_BraceMatch = 34,
		[Description("{ ... {")]								Meta_BraceMismatch = 35,
		[Description("Indentation guide marks")]				Meta_IndentGuide = 37,
		[Description("Whitespace / whitespace marks")]			Meta_Whitespace = 40,
		[Description("Lexical errors")]							Meta_Error = 41,

		// Scintilla reserves numbers in [32,39] for itself, so we number all
		// of our meaningful content starting at 64 and going up.
		[Description("\"//...\" comments")]						Comment_SingleLine = 64,
		[Description("\"/*...*/\" comments")]					Comment_MultiLine,
		[Description("\"///...\" or \"/**...*/\" comments")]	Comment_Docs,
		[Description("Unix-style \"#!\" lines")]				Comment_HashBang,
		[Description("\"-----\" separator bars")]				Comment_SeparatorHyphen,
		[Description("\"=====\" separator bars")]				Comment_SeparatorEquals,

		[Description("Default style")]							LiterateText_Body,
		[Description("## ...")]									LiterateText_Header,
		[Description("#> ...")]									LiterateText_Reference,

		[Description("'x'")]									Const_Char,
		[Description("'\\u2024'")]								Const_Uni,
		[Description("\" ... \"")]								Const_DynamicString,
		[Description("\"\"\" ... \"\"\"")]						Const_LongDynamicString,
		[Description("\' \' ... \' \'")]						Const_RawString,
		[Description("\' \' \' ... \' \' \'")]					Const_LongRawString,
		[Description("`abc")]									Const_Symbol,
		[Description("123, 123t, 123s, 123x")]					Const_Integer,
		[Description("123.45, 123.45t")]						Const_Real,
		[Description("123.45f, 123.45ft")]						Const_Float,

		[Description("var, const, auto, type, keyword")]		Keyword_Declaration,
		[Description("if, while, do, till, etc.")]				Keyword_Standard,

		[Description("From \"keyword\" or \"#syntax\"")]		Name_CustomKeyword,
		[Description("Names of variables")]						Name_Variable,
		[Description("Names of constants")]						Name_ConstVariable,
		[Description("Names of auto-variables")]				Name_AutoVariable,
		[Description("Names of function arguments")]			Name_FunctionArgument,
		[Description("Names of types")]							Name_TypeName,
		[Description("Names of object properties")]				Name_Property,
		[Description("Keywords from \"till\"")]					Name_TillFlag,

		[Description("Declared by \"keyword\"")]				Declaration_CustomKeyword,
		[Description("Declared by \"var\" (or implicitly)")]	Declaration_Variable,
		[Description("Declared by \"const\"")]					Declaration_ConstVariable,
		[Description("Declared by \"auto\"")]					Declaration_AutoVariable,
		[Description("Declared between \"|...|\"")]				Declaration_FunctionArgument,
		[Description("Declared by \"type\"")]					Declaration_TypeName,
		[Description("Declared in an object (\"foo:\")")]		Declaration_Property,
		[Description("Declared by \"till\"")]					Declaration_TillFlag,

		[Description("+, -, *, /, ==, etc.")]					Operator_Standard,
		[Description("Equal sign (=)")]							Operator_Assignment,
		[Description("+=, -=, *=, /=, etc.")]					Operator_StandardOpEquals,
		[Description("substr=, mod=, where=, etc.")]			Operator_CustomOpEquals,
		[Description("~x, sin x, sort x, close x, etc.")]		Operator_CustomUnary,
		[Description("substr, mod, where, open, etc.")]			Operator_CustomBinary,
		[Description("1..5")]									Operator_Range,

		[Description("|a b c|")]								Special_FunctionDeclaration,
		[Description("[foo ...]")]								Special_FunctionCall,
		[Description("[$if ...], [$scope ...], etc.")]			Special_SpecialForm,
		[Description("`[a b c ...]")]							Special_QuotedList,
		[Description("`(x + y), `{ if foo then bar }")]			Special_OtherQuotedForm,
		[Description("@x, @(...)")]								Special_VariableSubstitution,
		[Description("@@x, @@(...)")]							Special_Splice,

		[Description("#include ...")]							Parse_Include,
		[Description("#include ... as ...")]					Parse_IncludeAs,
		[Description("#syntax ...")]							Parse_Syntax,
		[Description("#/[a-z][a-z0-9]+/")]						Parse_Regex,
		[Description("#loanword ...")]							Parse_LoanwordDeclaration,
		[Description("#html, #json, #brk, etc.")]				Parse_OtherStandardLoanword,
		[Description("#csv, #markdown, #matrix, etc.")]			Parse_CustomLoanword,
		[Description("CLASS")]									Parse_SyntaxClass,
		[Description("[if ... then ...]")]						Parse_SyntaxPattern,
		[Description("[... [EXPR x] ...]")]						Parse_SyntaxNonterminal,
		[Description("=>")]										Parse_SyntaxArrow,
		[Description("'with' keyword")]							Parse_SyntaxWith,

		[Description("Default style")]							Loanword_JsonDefault,
		[Description("property:")]								Loanword_JsonProperty,
		[Description("true, false, null")]						Loanword_JsonKeyword,
		[Description("@x, @(x)")]								Loanword_JsonSubstitution,
		[Description("Default style")]							Loanword_XmlDefault,
		[Description("Plain text")]								Loanword_XmlText,
		[Description("<element>")]								Loanword_XmlElementName,
		[Description("attribute=...")]							Loanword_XmlAttributeName,
		[Description("...=\"value\"")]							Loanword_XmlAttributeValue,
		[Description("@x, @(x)")]								Loanword_XmlSubstitution,
	}
}

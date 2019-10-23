using Joy.Config;
using Joy.Forms;
using Joy.Types;
using ScintillaNET;
using SmileLibInterop;
using System;
using System.Collections.Generic;

namespace Joy.SyntaxHighlighting
{
	internal class LexicalStyler
	{
		/// <summary>
		/// Perform a simple lexical styling of the given range of content.  This will *not*
		/// correctly style many constructs, and it's not smart enough to understand
		/// context.  But it's fast enough that it can style most content while you type, and
		/// it's accurate enough that it's good enough for a first pass.  Various background
		/// threads will be responsible for running the full parser and re-styling the content
		/// more accurately afterward.
		/// </summary>
		/// <param name="editor">The editor that holds the content.</param>
		/// <param name="startPos">The starting character position within the text to style.</param>
		/// <param name="endPos">The ending character position within the text to style.</param>
		/// <param name="filename">The name of the file being styled (for generating errors)</param>
		public static void StyleRange(Scintilla editor, TextEditorControl owner, int startPos, int endPos, string filename)
		{
			try
			{
				// Ensure startPos/endPos actually refer to the document.
				ValidateStartAndEndPos(editor, ref startPos, ref endPos);

				// Get the real range of lines to style.
				int startLine = editor.LineFromPosition(startPos);
				int endLine = editor.LineFromPosition(endPos);

				// Remove all the error/warning marks in this range.
				owner.ClearLineMarks(startLine + 1, endLine - startLine + 1);

				// Now find the actual document start and end of the range we're going to color.
				int trueStartPos = editor.Lines[startLine].Position;
				int trueEndPos = editor.Lines[endLine].EndPosition;

				// Get the text itself in that range.
				string textSlice = editor.GetTextRange(trueStartPos, trueEndPos - trueStartPos);

				// Ask the real Smile Lexer to begin lexical analysis on it.
				SmileLibInterop.Lexer lexer = new SmileLibInterop.Lexer(textSlice,
					0, textSlice.Length, filename, startLine + 1, 1, true);

				editor.StartStyling(trueStartPos);

				Token token;
				int lastPos = 0;
				Token previousToken = null;
				while ((token = lexer.Next()).Kind != TokenKind.EOI)
				{
					LexerPosition lexerPosition = token.Position;
					int tokenStartPos = lexerPosition.LineStart + lexerPosition.Column - 1;
					int tokenLength = lexerPosition.Length;

					if (tokenStartPos > lastPos)
					{
						// Token somehow skipped over some content, so style it plain.
						editor.SetStyling(tokenStartPos - lastPos, (int)StyleKind.Default);
						editor.IndicatorClearRange(trueStartPos + lastPos, tokenStartPos - lastPos);

						System.Diagnostics.Debug.WriteLine($"Warning: Lexer skipped {tokenStartPos - lastPos} characters at {lastPos}.");
					}
					else if (tokenStartPos < lastPos)
					{
						// For some reason, the previous token had too many characters in it,
						// so shorten this one by a bit to make up for that mistake.
						tokenLength -= lastPos - tokenStartPos;

						System.Diagnostics.Debug.WriteLine($"Warning: Lexer grabbed too many characters ({lastPos - tokenStartPos} extra) at {lastPos}.");
					}

					if (tokenLength > 0)
					{
						StyleKind styleKind = GetDefaultStyleKindForToken(previousToken, token);
						editor.SetStyling(tokenLength, (int)styleKind);

						if (styleKind == StyleKind.Meta_Error)
						{
							editor.IndicatorCurrent = (int)IndicatorKind.Error;
							editor.IndicatorFillRange(trueStartPos + tokenStartPos, tokenLength);
							owner.SetLineMark(lexerPosition.Line, IndicatorKind.Error);
						}
						else
						{
							editor.IndicatorClearRange(trueStartPos + tokenStartPos, tokenLength);
						}
					}

					lastPos = tokenStartPos + tokenLength;
					previousToken = IsSemanticToken(token) ? token : previousToken;
				}
			}
			catch (Exception e)
			{
				// Should never get here, but just in case, we swallow errors
				// and hope a later pass will restyle the content better.
				System.Diagnostics.Debug.WriteLine("Warning: LexicalStyler.StyleRange() crashed: " + e.Message);
			}
		}

		private static void ValidateStartAndEndPos(Scintilla editor, ref int startPos, ref int endPos)
		{
			if (startPos < 0)
				startPos = 0;
			if (endPos < 0)
				endPos = 0;
			if (startPos > editor.TextLength)
				startPos = editor.TextLength;
			if (endPos > editor.TextLength)
				endPos = editor.TextLength;
			if (endPos < startPos)
			{
				int temp = startPos;
				startPos = endPos;
				endPos = temp;
			}
		}

		/// <summary>
		/// Perform a simple lexical styling of the given collection of lexical tokens.
		/// </summary>
		/// <param name="editor">The editor that holds the content.</param>
		/// <param name="tokens">The tokens to be restyled.</param>
		public static void StyleTokens(Scintilla editor, TextEditorControl owner, IEnumerable<Token> tokens)
		{
			try
			{
				bool isFirst = true;
				int lastPos = 0;
				int trueStartPos = 0;
				Token previousToken = null;
				foreach (Token token in tokens)
				{
					LexerPosition lexerPosition = token.Position;
					int tokenStartPos = lexerPosition.LineStart + lexerPosition.Column - 1;
					int tokenEndPos = tokenStartPos + lexerPosition.Length;
					ValidateStartAndEndPos(editor, ref tokenStartPos, ref tokenEndPos);
					int tokenLength = tokenEndPos - tokenStartPos;

					if (isFirst)
					{
						editor.StartStyling(tokenStartPos);
						trueStartPos = lastPos = tokenStartPos;
						isFirst = false;
					}

					if (tokenStartPos > lastPos)
					{
						// Token somehow skipped over some content, so style it plain.
						editor.SetStyling(tokenStartPos - lastPos, (int)StyleKind.Default);
						editor.IndicatorClearRange(trueStartPos + lastPos, tokenStartPos - lastPos);

						System.Diagnostics.Debug.WriteLine($"Warning: Lexer skipped {tokenStartPos - lastPos} characters at {lastPos}.");
					}
					else if (tokenStartPos < lastPos)
					{
						// For some reason, the previous token had too many characters in it,
						// so shorten this one by a bit to make up for that mistake.
						tokenLength -= lastPos - tokenStartPos;

						System.Diagnostics.Debug.WriteLine($"Warning: Lexer grabbed too many characters ({lastPos - tokenStartPos} extra) at {lastPos}.");
					}

					if (tokenLength > 0)
					{
						StyleKind styleKind = GetDefaultStyleKindForToken(previousToken, token);
						editor.SetStyling(tokenLength, (int)styleKind);

						if (styleKind == StyleKind.Meta_Error)
						{
							editor.IndicatorCurrent = (int)IndicatorKind.Error;
							editor.IndicatorFillRange(trueStartPos + tokenStartPos, tokenLength);
							owner.SetLineMark(lexerPosition.Line, IndicatorKind.Error);
						}
						else
						{
							editor.IndicatorClearRange(trueStartPos + tokenStartPos, tokenLength);
						}
					}

					lastPos = tokenStartPos + tokenLength;
					previousToken = IsSemanticToken(token) ? token : previousToken;
				}
			}
			catch (Exception e)
			{
				// Should never get here, but just in case, we swallow errors
				// and hope a later pass will restyle the content better.
				System.Diagnostics.Debug.WriteLine("Warning: LexicalStyler.StyleTokens() crashed: " + e.Message);
			}
		}

		/// <summary>
		/// Determine whether the given token is semantically-meaningful, or is
		/// equivalent to whitespace.
		/// </summary>
		/// <param name="token">The token to test.</param>
		/// <returns>True if it's semantically-meaningful, false if it's effectively
		/// some form of whitespace.</returns>
		private static bool IsSemanticToken(Token token)
		{
			switch (token.Kind)
			{
				case TokenKind.EOI:

				case TokenKind.WHITESPACE:
				case TokenKind.NEWLINE:
				case TokenKind.WHITESPACE_BOM:

				case TokenKind.COMMENT_HASHBANG:
				case TokenKind.COMMENT_MULTILINE:
				case TokenKind.COMMENT_SINGLELINE:
				case TokenKind.COMMENT_SEPARATOR_EQUALS:
				case TokenKind.COMMENT_SEPARATOR_HYPHEN:
					return false;

				default:
					return true;
			}
		}

		/// <summary>
		/// Make a quick "best guess" initial mapping of tokens to styles.  This is likely
		/// to be at least somewhat wrong, but it's fast, running in O(1) time, so it can
		/// be performed while you type, and it's close enough that the user won't feel
		/// confused by the result (in most cases).
		/// </summary>
		/// <param name="previousToken">The previous semantic token, if known.</param>
		/// <param name="token">The lexical token to map to a style.</param>
		/// <returns>The "best guess" style to use for that token.</returns>
		private static StyleKind GetDefaultStyleKindForToken(Token previousToken, Token token)
		{
			switch (token.Kind)
			{
				case TokenKind.ERROR:					return StyleKind.Meta_Error;
				case TokenKind.EOI:						return StyleKind.Meta_Whitespace;

				case TokenKind.WHITESPACE:				return StyleKind.Meta_Whitespace;
				case TokenKind.NEWLINE:					return StyleKind.Meta_Whitespace;
				case TokenKind.WHITESPACE_BOM:			return StyleKind.Meta_Whitespace;

				case TokenKind.COMMENT_HASHBANG:		return StyleKind.Comment_HashBang;
				case TokenKind.COMMENT_MULTILINE:		return StyleKind.Comment_MultiLine;
				case TokenKind.COMMENT_SINGLELINE:		return StyleKind.Comment_SingleLine;
				case TokenKind.COMMENT_SEPARATOR_EQUALS: return StyleKind.Comment_SeparatorEquals;
				case TokenKind.COMMENT_SEPARATOR_HYPHEN: return StyleKind.Comment_SeparatorHyphen;

				case TokenKind.RAWSTRING:				return StyleKind.Const_RawString;
				case TokenKind.LONGRAWSTRING:			return StyleKind.Const_LongRawString;
				case TokenKind.DYNSTRING:				return StyleKind.Const_DynamicString;
				case TokenKind.LONGDYNSTRING:			return StyleKind.Const_LongDynamicString;
				case TokenKind.CHAR:					return StyleKind.Const_Char;
				case TokenKind.UNI:						return StyleKind.Const_Uni;
				case TokenKind.BYTE:					return StyleKind.Const_Integer;
				case TokenKind.INTEGER16:				return StyleKind.Const_Integer;
				case TokenKind.INTEGER32:				return StyleKind.Const_Integer;
				case TokenKind.INTEGER64:				return StyleKind.Const_Integer;
				case TokenKind.INTEGER128:				return StyleKind.Const_Integer;
				case TokenKind.REAL32:					return StyleKind.Const_Real;
				case TokenKind.REAL64:					return StyleKind.Const_Real;
				case TokenKind.REAL128:					return StyleKind.Const_Real;
				case TokenKind.FLOAT32:					return StyleKind.Const_Float;
				case TokenKind.FLOAT64:					return StyleKind.Const_Float;
				case TokenKind.FLOAT128:				return StyleKind.Const_Float;

				case TokenKind.LOANWORD_INCLUDE:		return StyleKind.Parse_Include;
				case TokenKind.LOANWORD_REGEX:			return StyleKind.Parse_Regex;
				case TokenKind.LOANWORD_XML:			return StyleKind.Loanword_XmlDefault;
				case TokenKind.LOANWORD_JSON:			return StyleKind.Loanword_JsonDefault;
				case TokenKind.LOANWORD_BRK:			return StyleKind.Parse_OtherStandardLoanword;
				case TokenKind.LOANWORD_SYNTAX:			return StyleKind.Parse_Syntax;
				case TokenKind.LOANWORD_LOANWORD:		return StyleKind.Parse_OtherStandardLoanword;
				case TokenKind.LOANWORD_CUSTOM:			return StyleKind.Parse_CustomLoanword;

				case TokenKind.DOTDOT:					return StyleKind.Operator_Range;

				case TokenKind.AT:						return StyleKind.Special_VariableSubstitution;
				case TokenKind.ATAT:					return StyleKind.Special_Splice;

				case TokenKind.BAR:						return StyleKind.Special_FunctionDeclaration;

				case TokenKind.ALPHANAME:
				case TokenKind.UNKNOWNALPHANAME:
				case TokenKind.PUNCTNAME:
				case TokenKind.UNKNOWNPUNCTNAME:
				case TokenKind.KNOWNNAME:

					if (previousToken != null)
					{
						// Best guess: ".foo" probably is a property.
						if (previousToken.Kind == TokenKind.DOT)
							return StyleKind.Name_Property;

						// Best guess: "`foo" probably is a symbol.
						if (previousToken.Kind == TokenKind.BACKTICK)
							return StyleKind.Const_Symbol;

						// Best guess: "@foo" probably is a variable substitution.
						if (previousToken.Kind == TokenKind.AT)
							return StyleKind.Special_VariableSubstitution;

						// Best guess: "@@foo" probably is a list splice.
						if (previousToken.Kind == TokenKind.ATAT)
							return StyleKind.Special_Splice;
					}

					string text = token.Text;
					if (string.IsNullOrEmpty(text))
						return StyleKind.Default;

					switch (text)
					{
						case "==": case "!=": case "===": case "!==":
						case "<": case ">": case "<=": case ">=":
						case "+": case "-":
						case "*": case "/":
							return StyleKind.Operator_Standard;
						case "if": case "then": case "else": case "unless":
						case "while": case "until": case "do": case "till": case "when":
						case "try": case "catch": case "return":
						case "as": case "is": case "typeof": case "new":
						case "not": case "and": case "or":
							return StyleKind.Keyword_Standard;
						case "var": case "const": case "auto": case "keyword": case "type":
							return StyleKind.Keyword_Declaration;
						case "true": case "false": case "null":
							return StyleKind.Name_ConstVariable;
						default:
							if (char.IsUpper(text[0]) && token.Text.Length > 1 && char.IsLower(text[1]))
							{
								// Best guess: An initial capital letter and then a lowercase letter is probably for a type.
								return StyleKind.Name_TypeName;
							}
							else if (text[0] == '$' && IsAllLowercase(text))
							{
								// Best guess: One of the special built-in forms.
								return StyleKind.Special_SpecialForm;
							}
							else if (IsAllUppercase(text))
							{
								// Best guess: A syntax class.
								return StyleKind.Parse_SyntaxClass;
							}
							else return StyleKind.Default;	// Don't know if operator, variable, or otherwise.
					}

				default: return StyleKind.Default;
			}
		}

		private static bool IsAllLowercase(string text)
		{
			foreach (char ch in text)
			{
				if (!(char.IsLower(ch) || char.IsDigit(ch)
					|| ch == '-' || ch == '_' || ch == '$' || ch == '\'' || ch == '\"'))
					return false;
			}
			return true;
		}

		private static bool IsAllUppercase(string text)
		{
			foreach (char ch in text)
			{
				if (!(char.IsUpper(ch) || char.IsDigit(ch)
					|| ch == '-' || ch == '_' || ch == '$' || ch == '\'' || ch == '\"'))
					return false;
			}
			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Joy.Config;
using Joy.Forms;
using ScintillaNET;
using SmileLibInterop;

namespace Joy.SyntaxHighlighting
{
	internal class FullRestyler
	{
		private readonly TextEditorControl _owner;
		private readonly Scintilla _editor;
		private readonly Configurator _configurator;

		private bool ShouldCancel => _shouldCancel();
		private Func<bool> _shouldCancel;

		public FullRestyler(TextEditorControl owner, Scintilla editor, Func<bool> shouldCancel, Configurator configurator)
		{
			_owner = owner;
			_editor = editor;
			_shouldCancel = shouldCancel;
			_configurator = configurator;
		}

		private void RunOnWinFormsThread(Action action)
		{
			if (ShouldCancel) return;
			try
			{
				_owner.BeginInvoke((Action)(() => action())).AsyncWaitHandle.WaitOne();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Warning: Dispatch to WinForms thread failed: " + e.Message);
			}
		}

		public void Restyle()
		{
			// Get the current text from the editor.
			string text = null;
			string filename = null;
			RunOnWinFormsThread(() =>
			{
				if (ShouldCancel) return;
				filename = _owner.Filename;
				text = _editor.Text;
			});

			if (ShouldCancel) return;

			// First, do a fast easy pass over the input to find its maximum width,
			// so that we can keep the horizontal scrollbar up-to-date.
			MaximumInfo maximumInfo = CalculateMaximumInfo(text, _configurator.TextEditorConfig.Indentation);
			RunOnWinFormsThread(() =>
			{
				if (ShouldCancel) return;
				_owner.SetMaximumInfo(maximumInfo);
				_owner.ClearLineMarks();
			});

			// Create a Smile Lexer to begin lexical analysis on it.
			SmileLibInterop.Lexer lexer = new SmileLibInterop.Lexer(text, 0, text.Length, filename, 1, 1, true);

			// Spin over the input, collect tokens in approximately ~64K chunks (or ~1024 tokens),
			// and pass them to the LexicalStyler class to style.
			int currentChunkSize = 0;
			const int MaximumChunkSize = 64 * 1024;
			const int TokenWeight = 8 * 8;  // Approximate guess for how much memory a Token object uses.
			List<Token> tokens = new List<Token>();
			Token token;

			while ((token = lexer.Next()).Kind != TokenKind.EOI)
			{
				tokens.Add(token);

				currentChunkSize += token.Position.Length + TokenWeight;
				if (currentChunkSize >= MaximumChunkSize)
				{
					if (ShouldCancel) break;

					RunOnWinFormsThread(() =>
					{
						if (ShouldCancel) return;
						LexicalStyler.StyleTokens(_editor, _owner, tokens);
					});

					tokens.Clear();
					currentChunkSize = 0;
					if (ShouldCancel) break;
				}
			}

			if (tokens.Any())
			{
				RunOnWinFormsThread(() =>
				{
					if (ShouldCancel) return;
					LexicalStyler.StyleTokens(_editor, _owner, tokens);
				});
			}
		}

		private MaximumInfo CalculateMaximumInfo(string text, int tabSize)
		{
			int maxLine = 0;
			int maxColumn = 0;
			int lineOfMaxColumn = 0;

			int end = text.Length;
			int column = 0;
			for (int i = 0; i < end; )
			{
				char ch = text[i++];
				column++;
				if (ch == '\r')
				{
					if (column > maxColumn)
					{
						maxColumn = column;
						lineOfMaxColumn = maxLine;
					}
					if (i < end && text[i] == '\n')
						i++;
					maxLine++;
					column = 0;
				}
				else if (ch == '\n')
				{
					if (column > maxColumn)
					{
						maxColumn = column;
						lineOfMaxColumn = maxLine;
					}
					if (i < end && text[i] == '\r')
						i++;
					maxLine++;
					column = 0;
				}
				else if (ch == '\t')
				{
					column = ((column + tabSize - 1) / tabSize) * tabSize;
				}
			}

			if (column > maxColumn)
			{
				maxColumn = column;
				lineOfMaxColumn = maxLine;
			}

			return new MaximumInfo(lines: maxLine, columns: maxColumn, lineOfMaxColumn: lineOfMaxColumn);
		}
	}
}
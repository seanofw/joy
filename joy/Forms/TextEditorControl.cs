using System.IO;
using System.ComponentModel;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;
using Joy.Config;
using Joy.Types;
using Joy.SyntaxHighlighting;
using BetterControls.MessageBox;
using System.Collections.Immutable;
using System.Collections.Generic;
using BetterControls.Scrollbar;
using System.Drawing;

namespace Joy.Forms
{
	public partial class TextEditorControl : DockContent
	{
		private Timer _statusUpdateTimer;
		private Timer _fullRestylerTimer;
		private FullRestylerManager _fullRestylerManager;
		private ImmutableDictionary<int, Mark> _lineMarks = ImmutableDictionary<int, Mark>.Empty;

		public string FullPathname
		{
			get => _fullPathname;
			set
			{
				_fullPathname = value;
				_directory = Path.GetDirectoryName(_fullPathname);
				string filename = Path.GetFileName(_fullPathname);
				if (filename != _filename)
				{
					_filename = filename;
					UpdateTitle();
				}
			}
		}

		public string Directory
		{
			get => _directory;
			set
			{
				_directory = value;
				_fullPathname = Path.Combine(_directory, _filename);
			}
		}

		public string Filename
		{
			get => _filename;
			set
			{
				if (value != _filename)
				{
					_filename = value;
					_fullPathname = Path.Combine(_directory, _filename);
					UpdateTitle();
				}
			}
		}

		private string _filename = string.Empty;
		private string _directory = string.Empty;
		private string _fullPathname = string.Empty;

		public bool IsModified
		{
			get => _isModified;
			set
			{
				if (_isModified != value)
				{
					_isModified = value;
					UpdateTitle();
				}
			}
		}
		private bool _isModified;

		public bool IsNew => string.IsNullOrEmpty(Directory);

		private Configurator Configurator { get; }

		private TextEditorControl(bool ignored, string content, Configurator configurator)
		{
			InitializeComponent();

			Configurator = configurator;
			Configurator.TextEditorConfigChanged += Configurator_TextEditorConfigChanged;

			DockAreas = DockAreas.Float | DockAreas.Document;

			ConfigureEditor();

			ApplyStyles(Configurator.StyleConfig, Configurator.TextEditorConfig);
			ApplyIndicatorStyles(Configurator.IndicatorConfig);

			Editor.Text = content;
			Editor.EmptyUndoBuffer();

			_fullRestylerManager = new FullRestylerManager(this, Editor, Configurator);
			_fullRestylerManager.Started += (sender, e) =>
			{
				System.Diagnostics.Debug.WriteLine("Styling " + (e.Restarting ? "Restarted" : "Started"));
			};
			_fullRestylerManager.Finished += (sender, e) =>
			{
				System.Diagnostics.Debug.WriteLine("Styling " + (e.FinishedSuccessfully ? "Finished" : "Aborted"));
			};

			Editor.TextChanged += OnTextChanged;
			Editor.UpdateUI += OnUpdateUI;
			Editor.StyleNeeded += Scintilla_StyleNeeded;

			NeedStatusUpdate();
		}

		private void VerticalScrollbar_Scroll(object sender, ScrollEventArgs e)
		{
			Editor.FirstVisibleLine = e.NewValue;
		}

		private void HorizontalScrollbar_Scroll(object sender, ScrollEventArgs e)
		{
			Editor.XOffset = e.NewValue;
		}

		private void Scintilla_ZoomChanged(object sender, EventArgs e)
		{
			Configurator.TextEditorConfig = Configurator.TextEditorConfig.WithZoom(Editor.Zoom);
		}

		private void Scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
		{
			int startPos = Editor.GetEndStyled();
			int endPos = e.Position;

			LexicalStyler.StyleRange(Editor, this, startPos, endPos, Filename);

			EnqueueFullRestyle();
		}

		private void EnqueueFullRestyle()
		{
			if (_fullRestylerTimer != null)
			{
				_fullRestylerTimer.Stop();
				_fullRestylerTimer.Start();
				return;
			}

			_fullRestylerTimer = new Timer();
			_fullRestylerTimer.Interval = 250;
			_fullRestylerTimer.Tick += (sender, e) =>
			{
				_fullRestylerManager.EnqueueFullRestyle();

				_fullRestylerTimer.Stop();
				_fullRestylerTimer = null;
			};
			_fullRestylerTimer.Start();
		}

		private void StopFullRestyleTimer()
		{
			if (_fullRestylerTimer != null)
			{
				_fullRestylerTimer.Stop();
				_fullRestylerTimer = null;
			}
		}

		public void ApplyIndicatorStyles(IndicatorConfig indicatorConfig)
		{
			Indicator indicator;
			
			indicator = Editor.Indicators[0];
			indicator.ForeColor = indicatorConfig.NoStyle.Color;
			indicator.Style = (ScintillaNET.IndicatorStyle)(int)indicatorConfig.NoStyle.IndicatorShape;
			indicator.Under = false;

			foreach (Config.IndicatorStyle style in indicatorConfig)
			{
				indicator = Editor.Indicators[(int)style.IndicatorKind];

				indicator.ForeColor = style.Color;
				indicator.Style = (ScintillaNET.IndicatorStyle)(int)style.IndicatorShape;
				indicator.Under = style.BehindText;
			}
		}

		public void ApplyStyles(StyleConfig styleConfig, TextEditorConfig textEditorConfig)
		{
			Config.Style defaultStyle = styleConfig.DefaultStyle;

			// Set the default style across the board.
			Editor.StyleResetDefault();
			Editor.Styles[ScintillaNET.Style.Default].Font = textEditorConfig.MainFontName;
			Editor.Styles[ScintillaNET.Style.Default].Size = textEditorConfig.MainFontSize;
			Editor.Styles[ScintillaNET.Style.Default].BackColor = defaultStyle.Background.Value;
			Editor.Styles[ScintillaNET.Style.Default].ForeColor = defaultStyle.Color.Value;
			Editor.StyleClearAll();

			// Set the cursor color.
			Config.Style? cursorStyle = styleConfig[StyleKind.Meta_CursorColor];
			Editor.CaretForeColor = cursorStyle.HasValue && cursorStyle.Value.Color.HasValue
				? cursorStyle.Value.Color.Value
				: defaultStyle.Color.Value;			// Default caret color matches default text color.

			// Set the cursor line background color, if desired.
			Config.Style? cursorLineStyle = styleConfig[StyleKind.Meta_CursorLineBackground];
			Editor.CaretLineVisible = cursorLineStyle.HasValue && cursorLineStyle.Value.Background.HasValue;
			Editor.CaretLineBackColor = cursorLineStyle.HasValue && cursorLineStyle.Value.Background.HasValue
				? cursorLineStyle.Value.Background.Value
				: defaultStyle.Background.Value;    // Default caret line color matches default background.

			// Set the selection background color.
			Config.Style? selectionStyle = styleConfig[StyleKind.Meta_Selection];
			Editor.SetSelectionBackColor(true, selectionStyle.HasValue && selectionStyle.Value.Background.HasValue
				? selectionStyle.Value.Background.Value
				: System.Drawing.Color.FromArgb(128, 128, 128));

			// Line numbers and guides always get styled.
			ApplyStyle(StyleKind.Meta_LineNumber, styleConfig[StyleKind.Meta_LineNumber], defaultStyle);
			ApplyStyle(StyleKind.Meta_IndentGuide, styleConfig[StyleKind.Meta_IndentGuide], defaultStyle);

			// Apply any other custom styles to anything else that should have them.
			foreach (Config.Style style in styleConfig)
			{
				if (style.StyleKind == StyleKind.Meta_LineNumber
					|| style.StyleKind == StyleKind.Meta_IndentGuide
					|| style.StyleKind == StyleKind.Meta_Selection)
					continue;

				ApplyStyle(style.StyleKind, style, defaultStyle);
			}
		}

		private void ApplyStyle(StyleKind styleKind, Config.Style? optionalStyle, Config.Style defaultStyle)
		{
			Config.Style style = optionalStyle.HasValue ? optionalStyle.Value : defaultStyle;
			ScintillaNET.Style scintillaStyle = Editor.Styles[(int)styleKind];

			scintillaStyle.ForeColor = style.Color.HasValue ? style.Color.Value : defaultStyle.Color.Value;
			scintillaStyle.BackColor = style.Background.HasValue ? style.Background.Value : defaultStyle.Background.Value;

			scintillaStyle.Bold = ((style.FontFlags & FontFlags.Bold) != 0);
			scintillaStyle.Italic = ((style.FontFlags & FontFlags.Italic) != 0);
			scintillaStyle.Underline = ((style.FontFlags & FontFlags.Underline) != 0);
			scintillaStyle.FillLine = ((style.FontFlags & FontFlags.FillLine) != 0);
		}

		private void Configurator_TextEditorConfigChanged(object sender, EventArgs e) => ConfigureEditor();

		private void ConfigureEditor()
		{
			TextEditorConfig textEditorConfig = Configurator.TextEditorConfig;

			Editor.IndentWidth = textEditorConfig.Indentation;
			Editor.TabWidth = textEditorConfig.Indentation;
			Editor.UseTabs = textEditorConfig.IndentationMode == IndentationMode.Tabs;
			Editor.ViewWhitespace = textEditorConfig.ShowWhitespace
				? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
			Editor.WrapMode = textEditorConfig.WordWrap ? WrapMode.Word : WrapMode.None;

			Editor.Margins.Capacity = 1;

			Editor.ZoomChanged -= Scintilla_ZoomChanged;
			Editor.Zoom = textEditorConfig.Zoom;
			Editor.ZoomChanged += Scintilla_ZoomChanged;

			if (textEditorConfig.ShowLineNumbers)
			{
				Editor.Margins.Capacity++;

				Editor.Margins[1].Width = (11 * 5);
				Editor.Margins[1].Type = MarginType.Number;
				Editor.Margins[1].Sensitive = true;
				Editor.Margins[1].Mask = 0;
			}
		}

		public TextEditorControl(Configurator configurator)
			: this(true, string.Empty, configurator)
		{
			Filename = "New Document";
		}

		public TextEditorControl(string fullPathname, string content, Configurator configurator)
			: this(true, content, configurator)
		{
			FullPathname = fullPathname;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Configurator.TextEditorConfigChanged -= Configurator_TextEditorConfigChanged;
		}

		private void UpdateTitle()
		{
			Text = IsModified ? Filename + " *" : Filename;
		}

		public static TextEditorControl FromFile(string fullPathname, Configurator configurator)
		{
			string text;

			fullPathname = Path.GetFullPath(fullPathname);

			for (; ; )
			{
				try
				{
					UTF8Encoding encoding = new UTF8Encoding(false, false);
					using (FileStream fileStream = new FileStream(fullPathname, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						using (StreamReader reader = new StreamReader(fileStream, encoding))
						{
							text = reader.ReadToEnd();
						}
					}
				}
				catch (Exception ex)
				{
					if (BetterMessageBox
							.Caption("Error")
							.Message($"Cannot read \"{fullPathname}\":\r\n{ex}")
							.Button("Retry", DialogResult.Retry, true)
							.Button("Cancel", DialogResult.Cancel)
							.StandardImage(StandardImageKind.Error)
							.Show() == DialogResult.Retry)
						continue;

					// If we genuinely can't open it, make sure it gets removed from the
					// list of recent files too.
					int index;
					if ((index = configurator.RecentFiles.IndexOf(fullPathname)) >= 0)
					{
						configurator.RecentFiles.RemoveAt(index);
					}

					return null;
				}
				break;
			}

			TextEditorControl textEditorControl = new TextEditorControl(fullPathname, text, configurator);
			configurator.RecentFiles.Add(fullPathname);
			return textEditorControl;
		}

		private bool Save(string fullPathname)
		{
			for (;;)
			{
				try
				{
					UTF8Encoding encoding = new UTF8Encoding(false, false);
					using (FileStream fileStream = new FileStream(fullPathname, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
					{
						using (StreamWriter writer = new StreamWriter(fileStream, encoding))
						{
							writer.Write(Editor.Text);
						}
					}
				}
				catch (Exception ex)
				{
					if (BetterMessageBox
							.Caption("Error")
							.Message($"Cannot write to \"{fullPathname}\":\r\n{ex}")
							.Button("Retry", DialogResult.Retry)
							.Button("Cancel", DialogResult.Cancel)
							.StandardImage(StandardImageKind.Error)
							.Show() == DialogResult.Retry)
						continue;
					return false;
				}

				Configurator.RecentFiles.Add(FullPathname);
				return true;
			}
		}

		public bool Save()
		{
			if (IsNew)
			{
				return SaveAs();
			}
			else
			{
				if (Save(FullPathname))
				{
					IsModified = false;
					return true;
				}
				return false;
			}
		}

		public bool SaveAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".sm";
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.AutoUpgradeEnabled = true;
			saveFileDialog.AddExtension = true;
			saveFileDialog.DereferenceLinks = true;
			saveFileDialog.FileName = Filename;
			saveFileDialog.Filter = "Smile scripts (*.sm)|*.sm"
				+ "|JSON documents (*.json)|*.json"
				+ "|XML documents (*.xml)|*.xml"
				+ "|Text files (*.txt)|*.txt"
				+ "|All files (*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.Title = "Save as...";
			saveFileDialog.ValidateNames = true;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fullPathname = Path.GetFullPath(saveFileDialog.FileName);
				if (Save(fullPathname))
				{
					FullPathname = fullPathname;
					IsModified = false;
					return true;
				}
			}

			return false;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			if (IsModified)
			{
				DialogResult result = BetterMessageBox
					.Owner(this)
					.Message($"\"{Filename}\" has not yet been saved.\r\nAre you sure you want to close this document?")
					.Caption("Warning")
					.Button("Save changes", DialogResult.OK, true)
					.Button("Discard changes", DialogResult.Ignore)
					.Button("Cancel", DialogResult.Cancel)
					.StandardImage(StandardImageKind.Warning)
					.Show();

				switch (result)
				{
					case DialogResult.OK:
						if (!Save())
							e.Cancel = true;
						break;
					case DialogResult.Ignore:
						break;
					default:
						e.Cancel = true;
						break;
				}
			}

			if (!e.Cancel)
			{
				StopFullRestyleTimer();
				_fullRestylerManager.CancelAndAbort();
			}
		}

		protected virtual void OnTextChanged(object sender, EventArgs e)
		{
			IsModified = true;
			NeedStatusUpdate();
			UpdateScrollbars();
			EnqueueFullRestyle();
		}

		protected virtual void OnUpdateUI(object sender, UpdateUIEventArgs e)
		{
			NeedStatusUpdate();
			UpdateScrollbars();
			BraceMatch(Editor);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			NeedStatusUpdate();
			UpdateScrollbars();
			EnqueueFullRestyle();
		}

		private bool _scrollbarsUpdating;

		private void UpdateScrollbars()
		{
			if (Editor == null || VerticalScrollbar == null || HorizontalScrollbar == null)
				return;

			if (_scrollbarsUpdating)
				return;
			_scrollbarsUpdating = true;

			Timer timer = new Timer();
			timer.Interval = 25;
			timer.Tick += (sender, e) =>
			{
				timer.Stop();
				timer.Dispose();
				_scrollbarsUpdating = false;

				VerticalScrollbar.Maximum = Editor.Lines.Count;
				VerticalScrollbar.Start = Editor.FirstVisibleLine;
				VerticalScrollbar.Length = Editor.LinesOnScreen;

				HorizontalScrollbar.Maximum = _cachedScrollWidth;
				HorizontalScrollbar.Start = Editor.XOffset;
				HorizontalScrollbar.Length = Width - Editor.Margins[1].Width - VerticalScrollbar.Width;
			};
			timer.Start();
		}

		private int _cachedScrollWidth;

		internal void SetMaximumInfo(MaximumInfo maximumInfo)
		{
			Line longestLine = maximumInfo.LineOfMaxColumn < Editor.Lines.Count
				? Editor.Lines[maximumInfo.LineOfMaxColumn]
				: null;
			int viewportWidth = Width - Editor.Margins[1].Width - VerticalScrollbar.Width;
			int lineEnd = CalculateLineEnd(longestLine.Text);
			int oldXOffset = Editor.XOffset;
			Editor.XOffset = 0;
			int padding = Math.Max(1, Configurator.TextEditorConfig.MainFontSize + Configurator.TextEditorConfig.Zoom) * 5;
			int maximumScrollWidth = longestLine != null 
				? Editor.PointXFromPosition(longestLine.Position + lineEnd) - Editor.Margins[1].Width + padding
				: 0;
			Editor.XOffset = oldXOffset;
			if (maximumScrollWidth < viewportWidth)
				maximumScrollWidth = viewportWidth;
			_cachedScrollWidth = maximumScrollWidth;
			UpdateScrollbars();
		}

		private static int CalculateLineEnd(string text)
		{
			int end = text.Length;
			while (end > 0 && (text[end - 1] == '\r' || text[end - 1] == '\n'))
				end--;
			return end;
		}

		private int _lastCaretPos = 0;

		private void BraceMatch(Scintilla editor)
		{
			// Has the caret changed position?
			int caretPos = editor.CurrentPosition;
			if (_lastCaretPos == caretPos)
				return;
			_lastCaretPos = caretPos;

			int bracePos1 = Scintilla.InvalidPosition;

			// Is there a brace to the left or right?
			if (caretPos > 0 && IsBrace(editor.GetCharAt(caretPos - 1)))
				bracePos1 = (caretPos - 1);
			else if (IsBrace(editor.GetCharAt(caretPos)))
				bracePos1 = caretPos;

			if (bracePos1 >= 0)
			{
				// Find the matching brace.
				int bracePos2 = editor.BraceMatch(bracePos1);
				if (bracePos2 == Scintilla.InvalidPosition)
					editor.BraceBadLight(bracePos1);
				else
					editor.BraceHighlight(bracePos1, bracePos2);
			}
			else
			{
				// Turn off brace matching.
				editor.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
			}
		}

		private static bool IsBrace(int c)
		{
			switch (c)
			{
				case '(': case ')':
				case '[': case ']':
				case '{': case '}':
					return true;
				default:
					return false;
			}
		}

		public void Undo() => Editor.Undo();
		public void Redo() => Editor.Redo();
		public void Cut() => Editor.Cut();
		public void Copy() => Editor.Copy();
		public void Paste() => Editor.Paste();
		public void Delete() => Editor.ReplaceSelection(string.Empty);
		public void SelectAll() => Editor.SelectAll();

		public void FindNext(FindInfo findInfo)
		{
			if (string.IsNullOrEmpty(findInfo.Pattern)) return;

			int selectionStart = Editor.SelectionStart;
			int selectionEnd = Editor.SelectionEnd;

			if (selectionEnd < selectionStart)
			{
				int temp = selectionStart;
				selectionStart = selectionEnd;
				selectionEnd = temp;
			}

			int startPosition = selectionStart;

			Regex regex;
			RegexOptions options = 0;
			string pattern = findInfo.Pattern;
			if (!findInfo.UseRegex) pattern = Regex.Escape(pattern);
			if (findInfo.WholeWord) pattern = "\\b" + pattern + "\\b";
			if (!findInfo.CaseSensitive) options |= RegexOptions.IgnoreCase;
			regex = new Regex(pattern, options);

		retry:
			Match match = regex.Match(Editor.Text, startPosition);
			if (match.Success)
			{
				// If we already have it selected, find the next match.
				if (match.Index == selectionStart && match.Length == selectionEnd - selectionStart
					&& match.Length > 0)
				{
					startPosition = selectionEnd;
					goto retry;
				}

				// Not already selected, so select it.
				Editor.SelectionStart = match.Index;
				Editor.SelectionEnd = match.Index + match.Length;
				Editor.ScrollRange(match.Index, match.Index + match.Length);
			}
			else
			{
				Editor.SelectionStart = Editor.SelectionEnd = Editor.Text.Length;
				DialogResult result = BetterMessageBox.Caption("Find")
					.Message("No further matches found in this document.")
					.Button("Restart from top", DialogResult.Retry)
					.Button("Close", DialogResult.Cancel)
					.Owner(this)
					.StandardImage(StandardImageKind.Success)
					.Show();
				if (result == DialogResult.Retry)
				{
					Editor.SelectionStart = Editor.SelectionEnd = 0;
					FindNext(findInfo);
				}
			}
		}

		public void FindPrevious(FindInfo findInfo)
		{
			if (string.IsNullOrEmpty(findInfo.Pattern)) return;

			int selectionStart = Editor.SelectionStart;
			int selectionEnd = Editor.SelectionEnd;

			if (selectionEnd < selectionStart)
			{
				int temp = selectionStart;
				selectionStart = selectionEnd;
				selectionEnd = temp;
			}

			int startPosition = selectionEnd;

			Regex regex;
			RegexOptions options = RegexOptions.RightToLeft;
			string pattern = findInfo.Pattern;
			if (!findInfo.UseRegex) pattern = Regex.Escape(pattern);
			if (findInfo.WholeWord) pattern = "\\b" + pattern + "\\b";
			if (!findInfo.CaseSensitive) options |= RegexOptions.IgnoreCase;
			regex = new Regex(pattern, options);

			Match match = regex.Match(Editor.Text, startPosition);
			if (match.Success)
			{
				Editor.SelectionStart = match.Index;
				Editor.SelectionEnd = match.Index + match.Length;
				Editor.ScrollRange(match.Index, match.Index + match.Length);
			}
			else
			{
				Editor.SelectionStart = Editor.SelectionEnd = 0;
				DialogResult result = BetterMessageBox.Caption("Find")
					.Message("No prior matches found in this document.")
					.Button("Restart from bottom", DialogResult.Retry)
					.Button("Close", DialogResult.Cancel)
					.Owner(this)
					.StandardImage(StandardImageKind.Success)
					.Show();
				if (result == DialogResult.Retry)
				{
					Editor.SelectionStart = Editor.SelectionEnd = Editor.Text.Length;
					FindPrevious(findInfo);
				}
			}
		}

		public void ReplaceNext(ReplaceInfo replaceInfo)
		{
			if (string.IsNullOrEmpty(replaceInfo.Pattern)) return;

			int selectionStart = Editor.SelectionStart;
			int selectionEnd = Editor.SelectionEnd;

			if (selectionEnd < selectionStart)
			{
				int temp = selectionStart;
				selectionStart = selectionEnd;
				selectionEnd = temp;
			}

			int startPosition = selectionStart;

			Regex regex;
			RegexOptions options = 0;
			string pattern = replaceInfo.Pattern;
			if (!replaceInfo.UseRegex) pattern = Regex.Escape(pattern);
			if (replaceInfo.WholeWord) pattern = "\\b" + pattern + "\\b";
			if (!replaceInfo.CaseSensitive) options |= RegexOptions.IgnoreCase;
			regex = new Regex(pattern, options);

			Match match = regex.Match(Editor.Text, startPosition);
			if (match.Success)
			{
				if (match.Length > 0 && match.Index == selectionStart && match.Index + match.Length == selectionEnd)
				{
					// If the selected text *is* the match, then perform the replacement.
					string replacement = replaceInfo.Replacement;
					if (replaceInfo.UseRegex)
						replacement = ConstructRegexReplacementFromMatch(match, replacement);
					Editor.ReplaceSelection(replacement);

					// Now scan forward from there to the next match and highlight it.
					Editor.SelectionStart = startPosition;
					Editor.SelectionEnd = startPosition + replacement.Length;
					Editor.ScrollRange(match.Index, match.Index + match.Length);
					match = regex.Match(Editor.Text, Editor.SelectionEnd);
				}

				if (match.Success)
				{
					// If we found it farther from where we started, then just act like 'Find Next'
					// and highlight it without changing it.
					Editor.SelectionStart = match.Index;
					Editor.SelectionEnd = match.Index + match.Length;
					Editor.ScrollRange(match.Index, match.Index + match.Length);
				}
			}
			else
			{
				Editor.SelectionStart = Editor.SelectionEnd = Editor.Text.Length;
				DialogResult result = BetterMessageBox.Caption("Replace")
					.Message("No further matches found in this document.")
					.Button("Restart from top", DialogResult.Retry)
					.Button("Close", DialogResult.Cancel)
					.Owner(this)
					.StandardImage(StandardImageKind.Success)
					.Show();
				if (result == DialogResult.Retry)
				{
					Editor.SelectionStart = Editor.SelectionEnd = 0;
					ReplaceNext(replaceInfo);
				}
			}
		}

		public void Indent()
		{
			Editor.BeginUndoAction();

			int startLine, endLine;
			CalculateSelectionLines(out startLine, out endLine);

			int indentationConfig = Configurator.TextEditorConfig.Indentation;

			for (int i = startLine; i <= endLine; i++)
			{
				Editor.Lines[i].Indentation += indentationConfig;
			}

			Editor.EndUndoAction();
		}

		public void Unindent()
		{
			Editor.BeginUndoAction();

			int startLine, endLine;
			CalculateSelectionLines(out startLine, out endLine);

			int indentationConfig = Configurator.TextEditorConfig.Indentation;

			for (int i = startLine; i <= endLine; i++)
			{
				int indentation = Editor.Lines[i].Indentation;
				Editor.Lines[i].Indentation = Math.Max(indentation - indentationConfig, 0);
			}

			Editor.EndUndoAction();
		}

		private static Regex _commentOutRegex = new Regex("^([\x00-\x20]*)(.*)");
		private static Regex _commentInRegex = new Regex("^([\x00-\x20]*)//(.*)");

		public void CommentOut()
		{
			string whitespacePattern = null;

			// Figure out how much whitespace goes before each "//" by scanning
			// the lines and finding the longest common whitespace pattern across all of them.
			ScanSelectionLines(line =>
			{
				// Ignore empty lines.
				if (string.IsNullOrEmpty(line))
					return;

				Match match = _commentOutRegex.Match(line);
				string lineWhitespacePattern = match.Groups[1].Value;

				// Ignore whitespace-only lines.
				if (lineWhitespacePattern.Length == line.Length)
					return;

				if (whitespacePattern == null)
				{
					// If this is the first line with whitespace on it, start with that as a basis.
					whitespacePattern = lineWhitespacePattern;
				}
				else
				{
					// Find the longest initial substring between the existing
					// whitespace pattern and the new line's whitespace pattern.
					int i, end = Math.Min(whitespacePattern.Length, lineWhitespacePattern.Length);
					for (i = 0; i < end; i++)
						if (whitespacePattern[i] != lineWhitespacePattern[i])
							break;
					if (end < whitespacePattern.Length)
						whitespacePattern = whitespacePattern.Substring(0, end);
				}
			});

			UpdateSelectionLines(line =>
			{
				// If it starts with the known whitespace pattern, comment in the right place.
				if (whitespacePattern != null && line.StartsWith(whitespacePattern))
					return line.Substring(0, whitespacePattern.Length)
						+ "//" + line.Substring(whitespacePattern.Length);

				// If the line is completely whitespace (or otherwise blank), skip it.
				if (string.IsNullOrEmpty(line))
					return line;
				Match match = _commentOutRegex.Match(line);
				if (match.Success && match.Groups[1].Value == line)
					return line;

				// It has content, but somehow wasn't matched.  We shouldn't be able to
				// get here, but if we do, just jam a "//" on the front to make sure it
				// gets commented out anyway.
				return "//" + line;
			});
		}

		public void UncommentBackIn()
		{
			UpdateSelectionLines(line =>
				_commentInRegex.Replace(line, e => e.Groups[1].Value + e.Groups[2].Value));
		}

		private void CalculateSelectionLines(out int startLine, out int endLine)
		{
			int selectionStart = Editor.SelectionStart;
			int selectionEnd = Editor.SelectionEnd;

			if (selectionEnd < selectionStart)
			{
				int temp = selectionStart;
				selectionStart = selectionEnd;
				selectionEnd = temp;
			}

			// Contract away from the zeroth column, so we're focusing on real content.
			if (Editor.GetColumn(selectionEnd) == 0 && selectionEnd > selectionStart)
				selectionEnd--;
			if (Editor.GetColumn(selectionStart) == 0 && selectionEnd > selectionStart)
				selectionStart++;

			startLine = Editor.LineFromPosition(selectionStart);
			endLine = Editor.LineFromPosition(selectionEnd);
		}

		public void ScanSelectionLines(Action<string> lineReader)
		{
			int startLine, endLine;
			CalculateSelectionLines(out startLine, out endLine);

			for (int i = startLine; i <= endLine; i++)
			{
				Line line = Editor.Lines[i];
				lineReader(line.Text);
			}
		}

		public void UpdateSelectionLines(Func<string, string> lineUpdater)
		{
			Editor.BeginUndoAction();

			int startLine, endLine;
			CalculateSelectionLines(out startLine, out endLine);

			for (int i = startLine; i <= endLine; i++)
			{
				Line line = Editor.Lines[i];
				string newLineText = lineUpdater(line.Text);
				Editor.SelectionStart = line.Position;
				Editor.SelectionEnd = line.EndPosition;
				Editor.ReplaceSelection(newLineText);
			}

			Editor.SelectionStart = Editor.Lines[startLine].Position;
			Editor.SelectionEnd = Editor.Lines[endLine].EndPosition;

			Editor.EndUndoAction();
		}

		public void ReplaceAll(ReplaceInfo replaceInfo)
		{
			if (string.IsNullOrEmpty(replaceInfo.Pattern)) return;

			Editor.BeginUndoAction();

			int startPosition = 0;

			Regex regex;
			RegexOptions options = 0;
			string pattern = replaceInfo.Pattern;
			if (!replaceInfo.UseRegex) pattern = Regex.Escape(pattern);
			if (replaceInfo.WholeWord) pattern = "\\b" + pattern + "\\b";
			if (!replaceInfo.CaseSensitive) options |= RegexOptions.IgnoreCase;
			regex = new Regex(pattern, options);

			int numMatches = 0;
			while (true)
			{
				Match match = regex.Match(Editor.Text, startPosition);
				if (!match.Success || match.Length <= 0) break;

				// If the selected text *is* the match, then perform the replacement.
				string replacement = replaceInfo.Replacement;
				if (replaceInfo.UseRegex)
					replacement = ConstructRegexReplacementFromMatch(match, replacement);
				Editor.SelectionStart = match.Index;
				Editor.SelectionEnd = match.Index + match.Length;
				Editor.ReplaceSelection(replacement);

				// Now scan forward from there to the next match and highlight it.
				startPosition = match.Index + replacement.Length;
				Editor.SelectionStart = match.Index;
				Editor.SelectionEnd = match.Index + replacement.Length;
				numMatches++;
			}

			Editor.ScrollRange(Editor.SelectionStart, Editor.SelectionEnd);

			BetterMessageBox
				.Caption("Replace")
				.Message(numMatches == 0 ? "No matches found in this document."
					: $"Replaced {numMatches} occurrences in this document.")
				.Button("OK", DialogResult.OK)
				.Owner(this)
				.StandardImage(StandardImageKind.Success)
				.Show();

			Editor.EndUndoAction();
		}

		private static string ConstructRegexReplacementFromMatch(Match match, string replacement)
		{
			// We support \0 through \9 in the replacement in regex mode,
			// and \a, \b, \n, \v, \f, \r, \t, \e become control codes, and \\
			// becomes backslash.
			StringBuilder replacementBuilder = new StringBuilder();
			for (int i = 0; i < replacement.Length;)
			{
				if (replacement[i] != '\\')
				{
					int start = i;
					while (i < replacement.Length && replacement[i] != '\\')
						i++;
					replacementBuilder.Append(replacement, start, i - start);
					continue;
				}

				i++;
				if (i >= replacement.Length)
				{
					replacementBuilder.Append('\\');
					continue;
				}

				switch (replacement[i++])
				{
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						int index = replacement[i - 1] - '0';
						replacementBuilder.Append(index < match.Groups.Count ? match.Groups[index].Value : string.Empty);
						break;

					case 'r': replacementBuilder.Append('\r'); break;
					case 'n': replacementBuilder.Append('\n'); break;
					case 't': replacementBuilder.Append('\t'); break;
					case 'v': replacementBuilder.Append('\v'); break;
					case 'f': replacementBuilder.Append('\f'); break;
					case 'a': replacementBuilder.Append('\a'); break;
					case 'b': replacementBuilder.Append('\b'); break;
					case 'e': replacementBuilder.Append('\x1B'); break;

					default:
						replacementBuilder.Append(replacement[i - 1]);
						break;
				}
			}

			replacement = replacementBuilder.ToString();
			return replacement;
		}

		private void SubstituteSelection(string text)
		{
			int selectionStart = Editor.SelectionStart;
			int selectionEnd = Editor.SelectionEnd;
			Editor.ReplaceSelection(text);
			if (selectionStart <= selectionEnd)
			{
				Editor.SelectionStart = selectionStart;
				Editor.SelectionEnd = selectionStart + text.Length;
			}
			else
			{
				Editor.SelectionStart = selectionStart;
				Editor.SelectionEnd = selectionStart - text.Length;
			}
		}

		public void MakeUppercase()
		{
			SubstituteSelection(Editor.SelectedText.ToUpperInvariant());
		}

		public void MakeLowercase()
		{
			SubstituteSelection(Editor.SelectedText.ToLowerInvariant());
		}

		public void NeedStatusUpdate()
		{
			if (_statusUpdateTimer != null) return;

			_statusUpdateTimer = new Timer();
			_statusUpdateTimer.Interval = 100;
			_statusUpdateTimer.Tick += (sender, e) =>
			{
				_statusUpdateTimer.Dispose();
				_statusUpdateTimer = null;

				int lineOfSelectionEnd = Editor.LineFromPosition(Editor.SelectionEnd);

				StatusUpdate.Invoke(this, new StatusEventArgs(
					line: lineOfSelectionEnd,
					column: Editor.GetColumn(Editor.SelectionEnd),
					charOfLine: Editor.SelectionEnd - Editor.Lines[lineOfSelectionEnd].Position,
					selectionStart: Editor.SelectionStart,
					selectionEnd: Editor.SelectionEnd,
					lines: Editor.Lines.Count,
					chars: Editor.TextLength
				));
			};
			_statusUpdateTimer.Start();
		}

		public event EventHandler<StatusEventArgs> StatusUpdate;

		public string DocumentText
		{
			get => Editor.Text;
			set => Editor.Text = value;
		}

		public void ClearLineMarks()
		{
			VerticalScrollbar.Marks = ImmutableDictionary<int, Mark>.Empty;
		}

		public void ClearLineMarks(int startLine, int length)
		{
			for (int i = startLine - 1; i < startLine - 1 + length; i++)
			{
				_lineMarks = _lineMarks.Remove(i);
			}
			VerticalScrollbar.Marks = _lineMarks;
		}

		public void SetLineMark(int line, IndicatorKind indicatorKind)
		{
			Mark? mark = MarkFromIndicator(indicatorKind);
			if (!mark.HasValue)
				_lineMarks = _lineMarks.Remove(line - 1);
			else
				_lineMarks = _lineMarks.SetItem(line - 1, mark.Value);
			VerticalScrollbar.Marks = _lineMarks;
		}

		private Mark? MarkFromIndicator(IndicatorKind indicatorKind)
		{
			switch (indicatorKind)
			{
				case IndicatorKind.Error:
					return new Mark(Color.Red, MarkStyle.FinalMargin, 4);
				case IndicatorKind.Warning:
					return new Mark(Color.Blue, MarkStyle.FinalMargin, 4);
				case IndicatorKind.Suggestion:
					return new Mark(Color.Green, MarkStyle.FinalMargin, 4);
				default:
					return null;
			}
		}
	}
}

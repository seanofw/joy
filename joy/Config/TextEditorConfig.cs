using Microsoft.Win32;
using System;
using Joy.Extensions;

namespace Joy.Config
{
	public class TextEditorConfig : IEquatable<TextEditorConfig>
	{
		public readonly int Indentation;
		public readonly IndentationMode IndentationMode;
		public readonly bool UseEditorConfig;
		public readonly bool ShowLineNumbers;
		public readonly bool ShowWhitespace;
		public readonly bool WordWrap;
		public readonly bool SmartIndent;
		public readonly string MainFontName;
		public readonly int MainFontSize;
		public readonly int Zoom;

		public TextEditorConfig()
		{
			Indentation = 4;
			IndentationMode = IndentationMode.Tabs;
			UseEditorConfig = true;
			ShowLineNumbers = true;
			ShowWhitespace = false;
			WordWrap = false;
			SmartIndent = true;
			MainFontName = "Consolas";
			MainFontSize = 12;
			Zoom = 0;
		}

		public TextEditorConfig(
			int indentation,
			IndentationMode indentationMode,
			bool useEditorConfig,
			bool showLineNumbers,
			bool showWhitespace,
			bool wordWrap,
			bool smartIndent,
			string mainFontName,
			int mainFontSize,
			int zoom
		)
		{
			Indentation = indentation;
			IndentationMode = indentationMode;
			UseEditorConfig = useEditorConfig;
			ShowLineNumbers = showLineNumbers;
			ShowWhitespace = showWhitespace;
			WordWrap = wordWrap;
			SmartIndent = smartIndent;
			MainFontName = mainFontName;
			MainFontSize = mainFontSize;
			Zoom = zoom;
		}

		public void SaveToRegistry(RegistryKey key)
		{
			key.SetValue("Indentation", Indentation, RegistryValueKind.DWord);
			key.SetValue("IndentationMode", IndentationMode.ToString(), RegistryValueKind.String);
			key.SetValue("UseEditorConfig", UseEditorConfig ? 1 : 0, RegistryValueKind.DWord);
			key.SetValue("ShowLineNumbers", ShowLineNumbers ? 1 : 0, RegistryValueKind.DWord);
			key.SetValue("ShowWhitespace", ShowWhitespace ? 1 : 0, RegistryValueKind.DWord);
			key.SetValue("WordWrap", WordWrap ? 1 : 0, RegistryValueKind.DWord);
			key.SetValue("SmartIndent", SmartIndent ? 1 : 0, RegistryValueKind.DWord);
			key.SetValue("MainFontName", MainFontName);
			key.SetValue("MainFontSize", MainFontSize);
			key.SetValue("Zoom", Zoom);
		}

		public static TextEditorConfig LoadFromRegistry(RegistryKey key)
		{
			return new TextEditorConfig(
				indentation: key.GetIntOrDefault("Indentation", 4, minimumValue: 1, maximumValue: 99),
				indentationMode: key.GetEnumOrDefault<IndentationMode>("IndentationMode", IndentationMode.Tabs),
				useEditorConfig: key.GetBoolOrDefault("UseEditorConfig", true),
				showLineNumbers: key.GetBoolOrDefault("ShowLineNumbers", true),
				showWhitespace: key.GetBoolOrDefault("ShowWhitespace", false),
				wordWrap: key.GetBoolOrDefault("WordWrap", false),
				smartIndent: key.GetBoolOrDefault("SmartIndent", true),
				mainFontName: key.GetStringOrDefault("MainFontName", "Consolas"),
				mainFontSize: key.GetIntOrDefault("MainFontSize", 12, 1, 99),
				zoom: key.GetIntOrDefault("Zoom", 0, -10, +20)
			);
		}

		public TextEditorConfig WithUseEditorConfig(bool useEditorConfig)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: useEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithIndentation(int indentation)
		{
			return new TextEditorConfig(
				indentation: indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithIndentationMode(IndentationMode indentationMode)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: indentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithShowLineNumbers(bool showLineNumbers)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: showLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithShowWhitespace(bool showWhitespace)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: showWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithWordWrap(bool wordWrap)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: wordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithSmartIndent(bool smartIndent)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: smartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithMainFontName(string mainFontName)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: mainFontName,
				mainFontSize: MainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithMainFontSize(int mainFontSize)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: mainFontSize,
				zoom: Zoom
			);
		}

		public TextEditorConfig WithZoom(int zoom)
		{
			return new TextEditorConfig(
				indentation: Indentation,
				indentationMode: IndentationMode,
				useEditorConfig: UseEditorConfig,
				showLineNumbers: ShowLineNumbers,
				showWhitespace: ShowWhitespace,
				wordWrap: WordWrap,
				smartIndent: SmartIndent,
				mainFontName: MainFontName,
				mainFontSize: MainFontSize,
				zoom: zoom
			);
		}

		public override bool Equals(object obj) => Equals(obj as TextEditorConfig);

		public virtual bool Equals(TextEditorConfig other) =>
			!ReferenceEquals(other, null)
			&& Indentation == other.Indentation
			&& IndentationMode == other.IndentationMode
			&& UseEditorConfig == other.UseEditorConfig
			&& ShowLineNumbers == other.ShowLineNumbers
			&& ShowWhitespace == other.ShowWhitespace
			&& WordWrap == other.WordWrap
			&& SmartIndent == other.SmartIndent
			&& MainFontName == other.MainFontName
			&& MainFontSize == other.MainFontSize
			&& Zoom == other.Zoom;

		public override int GetHashCode()
		{
			int hashCode = 0;
			hashCode = (hashCode * 29) + Indentation.GetHashCode();
			hashCode = (hashCode * 29) + IndentationMode.GetHashCode();
			hashCode = (hashCode * 29) + UseEditorConfig.GetHashCode();
			hashCode = (hashCode * 29) + ShowLineNumbers.GetHashCode();
			hashCode = (hashCode * 29) + ShowWhitespace.GetHashCode();
			hashCode = (hashCode * 29) + WordWrap.GetHashCode();
			hashCode = (hashCode * 29) + SmartIndent.GetHashCode();
			hashCode = (hashCode * 29) + (MainFontName != null ? MainFontName.GetHashCode() : 0);
			hashCode = (hashCode * 29) + MainFontSize.GetHashCode();
			hashCode = (hashCode * 29) + Zoom.GetHashCode();
			return hashCode;
		}

		public static bool operator==(TextEditorConfig a, TextEditorConfig b)
			=> ReferenceEquals(a, null) ? ReferenceEquals(b, null) : a.Equals(b);

		public static bool operator!=(TextEditorConfig a, TextEditorConfig b)
			=> ReferenceEquals(a, null) ? !ReferenceEquals(b, null) : !a.Equals(b);

		public override string ToString()
			=> $"Indentation={Indentation}, IndentationMode={IndentationMode}, UseEditorConfig={UseEditorConfig}, ShowLineNumbers={ShowLineNumbers}, ShowWhitespace={ShowWhitespace}, WordWrap={WordWrap}, SmartIndent={SmartIndent}, MainFontName={MainFontName}, MainFontSize={MainFontSize}, Zoom={Zoom}";
	}
}

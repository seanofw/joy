#ifndef __SMILELIBINTEROP_H__
#define __SMILELIBINTEROP_H__

#ifndef __NATIVE_TYPES_H__
#include "Native/Types.h"
#endif
#ifndef __NATIVE_STRING_H__
#include "Native/String.h"
#endif
#ifndef __NATIVE_LEXER_H__
#include "Native/Lexer.h"
#endif

#ifndef __TOKENKIND_H__
#include "TokenKind.h"
#endif

namespace SmileLibInterop {

	public ref class LexerPosition {
	internal:
		System::String ^_filename;
		int _line;
		int _column;
		int _lineStart;
		int _length;

	public:
		property System::String ^Filename { inline System::String ^get() { return _filename; } }
		property int Line { inline int get() { return _line; } }
		property int Column { inline int get() { return _column; } }
		property int LineStart { inline int get() { return _lineStart; } }
		property int Length { inline int get() { return _length; } }

	internal:
		LexerPosition(void *ptr);
	};

	public ref struct TokenData {
	private:
		array<System::Byte> ^_dataValue;

	internal:
		inline TokenData(array<System::Byte> ^dataValue) { _dataValue = dataValue; }

	public:
		property int Symbol { int get(); }
		property unsigned char Byte { unsigned char get(); }
		property short Int16 { short get(); }
		property int Int32 { int get(); }
		property long long Int64 { long long get(); }
		property float Float32 { float get(); }
		property double Float64 { double get(); }
		property unsigned int Real32 { unsigned int get(); }
		property unsigned long long Real64 { unsigned long long get(); }
		property unsigned char Ch { unsigned char get(); }
		property unsigned int Uni { unsigned int get(); }
		property System::IntPtr Ptr { System::IntPtr get(); }
	};

	public ref class Token {
	internal:
		System::String ^_text;
		TokenKind _kind;
		LexerPosition ^_position;
		array<System::Byte> ^_dataValue;

	public:
		property System::String ^Text { inline System::String ^get() { return _text; } }
		property TokenKind Kind { inline TokenKind get() { return _kind; } }
		property LexerPosition ^Position { inline LexerPosition ^get() { return _position; } }
		property TokenData ^Data { inline TokenData ^get() { return gcnew TokenData(_dataValue); }}

	internal:
		Token(void *ptr);

	public:
		virtual System::String ^ToString() override;
	};

	public ref class Lexer {
	internal:
		void *_lexer;
		array<System::Int32> ^_inputMap;

	public:
		Lexer(System::String ^input, int start, int length,
			System::String ^filename, int firstLine, int firstColumn, bool syntaxHighlighterMode);

		Token ^Next();
		Token ^Peek();
		void Unget();
	};

	public ref class Utils {
	internal:
		static System::String ^SmileStringToDotNetString(SmileLibInterop::Native::String string);
		static SmileLibInterop::Native::String DotNetStringToSmileString(System::String ^string);
		static SmileLibInterop::Native::String DotNetStringToSmileStringWithMap(System::String ^string, array<System::Int32> ^&map);
	};

	public ref class Smile {
	public:
		static void Init();
		static void Reset();
		static void End();

		static bool IsInitialized();
		static void AssertInitialized();
	};

	/// <summary>
	/// If you intend to invoke the Smile runtime on a .NET background thread,
	/// you *must* create one of these inside your thread before invoking any
	/// Smile functions; and you *must* Dispose() of it before your thread
	/// exits.  Failure to do so will break Smile's GC.
	/// </summary>
	public ref class BackgroundThread {
	public:
		BackgroundThread();
		~BackgroundThread();
	};
}

#endif
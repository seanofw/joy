#include "pch.h"
#include "SmileLibInterop.h"
#include "Native/Exports.h"

namespace SmileLibInterop {

	Lexer::Lexer(System::String ^input, int start, int length,
		System::String ^filename, int firstLine, int firstColumn, bool syntaxHighlighterMode)
	{
		Smile::AssertInitialized();

		Native::String inputString = Utils::DotNetStringToSmileString(input);
		Native::String filenameString = Utils::DotNetStringToSmileString(filename);

		void *ptr = Native::Lexer_Create(inputString, start, length, filenameString, firstLine, firstColumn, syntaxHighlighterMode);

		_lexer = ptr;
	}

	Token ^Lexer::Next()
	{
		void *ptr = Native::Lexer_NextToken(_lexer);
		Token ^token = gcnew Token(ptr);
		return token;
	}

	Token ^Lexer::Peek()
	{
		void *ptr = Native::Lexer_PeekToken(_lexer);
		Token ^token = gcnew Token(ptr);
		return token;
	}

	void Lexer::Unget()
	{
		Native::Lexer_UngetToken(_lexer);
	}
}

#include "pch.h"
#include "SmileLibInterop.h"
#include "Native/Exports.h"

namespace SmileLibInterop {

	LexerPosition::LexerPosition(void *ptr)
	{
		Native::LexerPosition lexerPosition = (Native::LexerPosition)ptr;

		_line = lexerPosition->line;
		_column = lexerPosition->column;
		_lineStart = lexerPosition->lineStart;
		_length = lexerPosition->length;
		_filename = Utils::SmileStringToDotNetString(lexerPosition->filename);
	}
}

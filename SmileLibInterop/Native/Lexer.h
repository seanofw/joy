#ifndef __NATIVE_LEXER_H__
#define __NATIVE_LEXER_H__

#ifndef __NATIVE_TYPES_H__
#include "Types.h"
#endif
#ifndef __NATIVE_STRING_H__
#include "String.h"
#endif

#pragma managed(push, off)

namespace SmileLibInterop {
	namespace Native {
		typedef struct LexerPositionStruct {
			String filename;	// Which source file this position is in.
			Int32 line;			// On which line this position begins.
			Int32 column;		// The column within that line (note: tabs count as 1 char)
			Int32 lineStart;	// The offset of the start of this line from the start of the file.
			Int32 length;		// The length of the span of content, in characters.
		} *LexerPosition;

		typedef union TokenDataUnion {
			Symbol symbol;		// The symbol for this token (for identifiers).
			Byte byte;			// A 8-bit (unsigned) byte value for this token.
			Int16 int16;		// A 16-bit integer value for this token.
			Int32 int32;		// A 32-bit integer value for this token.
			Int64 int64;		// A 64-bit integer value for this token.
			Float32 float32;	// A 32-bit float value for this token.
			Float64 float64;	// A 64-bit float value for this token.
			Real32 real32;		// A 32-bit real value for this token.
			Real64 real64;		// A 64-bit real value for this token.
			Real128 real128;	// A 128-bit real value for this token.
			Byte ch;			// An 8-bit character value for this token.
			UInt32 uni;			// A 32-bit Unicode code point for this token.
			void *ptr;			// Pointer to nontrivial/complex/compound #loanwords.
		} *TokenData;

		typedef struct TokenStruct {

			int kind;								// What kind of token this is (see tokenkind.h)

			struct LexerPositionStruct _position;	// The position where the start of this token was found.
			Bool isFirstContentOnLine;				// Whether this token is the first content on the line.
			Bool hasEscapes;						// Whether this token's text used escape codes (mainly needed for symbols).

			String text;							// The text of this token (for strings/numbers/#loanwords).

			// The various kinds of data this token can represent ('kind' determines which of these is valid).
			union TokenDataUnion data;
		} *Token;

		typedef struct LexerStruct {

			// The actual input, and current position within it.
			String stringInput;			// The original input, as an immutable string.
			const Byte *input;			// The input (source file) itself.
			const Byte *src;			// The current read pointer within the input.
			const Byte *end;			// The end of the input (one past the last valid byte).
			const Byte *lineStart;		// The start of the current line of input (for computing the current char index).

			// The current filename/line number, for computing LexerPositions.
			String filename;			// The current filename.
			Int line;					// The current line number.

			// The most-recently-read token, and a stack of previously-read tokens for ungetting.
			struct TokenStruct tokenBuffer[16];
			Token token;				// The current read pointer within the tokenBuffer.
			Int tokenIndex;				// The current index of the token pointer within the token ring buffer.  Cached for speed.
			Int ungetCount;				// The number of tokens we have ungotten.  This maxes out at 15 levels deep.
			const Byte *tokenStart;		// The starting pointer of the current token.

			Bool syntaxHighlighterMode;	// Return everything, including whitespace.

			// External helper constructs.
			void *symbolTable;	// The symbol table, for resolving identifiers.

			// These flags are used internally as part of the state to keep track of what
			// kind of token to return next.  Don't change them outside the Lexer itself.
			Bool _isFirstContentOnLine;
			Bool _hasPrecedingWhitespace;
		} *Lexer;
	}
}

#pragma managed(pop)

#endif
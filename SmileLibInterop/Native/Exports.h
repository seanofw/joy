#ifndef __NATIVE_EXPORTS_H__
#define __NATIVE_EXPORTS_H__

#ifndef __NATIVE_TYPES_H__
#include "Types.h"
#endif
#ifndef __NATIVE_STRING_H__
#include "String.h"
#endif

#pragma managed(push, off)

#define SMILE_API_FUNC __declspec(dllimport)
#define SMILE_API_DATA __declspec(dllimport)

namespace SmileLibInterop {
	namespace Native {
		extern "C" {
			SMILE_API_FUNC String String_FromUtf16WithMap(const UInt16 *text, Int64 length, Int32 **map);
			SMILE_API_FUNC String String_FromUtf16(const UInt16 *text, Int64 length);
			SMILE_API_FUNC UInt16 *String_ToUtf16(const String str, Int64 *length);
			SMILE_API_DATA String String_Empty;

			SMILE_API_FUNC void *Lexer_Create(String input, Int64 start, Int64 length, String filename, Int64 firstLine, Int64 firstColumn, Byte syntaxHighlighterMode);
			SMILE_API_FUNC void *Lexer_NextToken(void *lexer);
			SMILE_API_FUNC void *Lexer_PeekToken(void *lexer);
			SMILE_API_FUNC void Lexer_UngetToken(void *lexer);

			SMILE_API_FUNC void Smile_Init(void);
			SMILE_API_FUNC void Smile_ResetEnvironment(void);
			SMILE_API_FUNC void Smile_End(void);

			struct GC_stack_base {
				void *mem_base; /* Base of memory stack. */
#				if defined(__ia64) || defined(__ia64__) || defined(_M_IA64)
					void *reg_base; /* Base of separate register stack. */
#				endif
			};

			SMILE_API_FUNC void GC_allow_register_threads(void);
			SMILE_API_FUNC int GC_register_my_thread(struct GC_stack_base *);
			SMILE_API_FUNC int GC_get_stack_base(struct GC_stack_base *);
			SMILE_API_FUNC int GC_unregister_my_thread(void);
		};
	}
}

#pragma comment(lib, "SmileLib.lib")
#pragma managed(pop)

#endif
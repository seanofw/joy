#ifndef __STRING_H__
#define __STRING_H__

#pragma managed(push, off)

namespace SmileLibInterop {
	namespace Native {

		typedef struct StringStruct {
			UInt32 kind;	// What kind of native object this is, from the SMILE_KIND enumeration
			struct SmileVTableInt *vtable;	// A pointer to this object's virtual table, which must match SMILE_VTABLE_TYPE.
			struct SmileObjectInt *base;	// A pointer to the String base object.

			struct {
				Int length;	// The length of the text array (in bytes, not Unicode code points).
				Byte text[65536];	// The actual bytes of the string (nul-terminated).  Not actually an array of 65536 bytes, either.
			} _opaque;
		} *String;

#		define String_GetBytes(__str__) \
			((const Byte *)(__str__)->_opaque.text)
#		define String_ToC(__str__) \
			((const char *)(__str__)->_opaque.text)
#		define String_Length(__str__) \
			((const Int)(__str__)->_opaque.length)
	}
}

#pragma managed(pop)

#endif

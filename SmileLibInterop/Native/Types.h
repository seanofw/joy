#ifndef __TYPES_H__
#define __TYPES_H__

namespace SmileLibInterop {
	namespace Native {
		typedef unsigned char Bool;

		typedef char SByte;
		typedef unsigned char Byte;
		typedef char Int8;
		typedef unsigned char UInt8;
		typedef short Int16;
		typedef unsigned short UInt16;
		typedef int Int32;
		typedef unsigned int UInt32;
		typedef __int64 Int64;
		typedef unsigned __int64 UInt64;

		typedef float Float32;
		typedef double Float64;
		typedef struct __declspec(align(16)) { UInt64 value[2]; } Float128;

		typedef struct { UInt32 value; } Real32;
		typedef struct { UInt64 value; } Real64;
		typedef struct __declspec(align(16)) { UInt64 value[2]; } Real128;

		typedef UInt64 PtrInt;		// An unsigned integer type that is the same size as a pointer.
		typedef Int64 Int;			// A signed integer type that matches the native platform's "best" register size.
		typedef UInt64 UInt;		// An unsigned integer type that matches the native platform's "best" register size.

		typedef int Symbol;
	}
}

#endif
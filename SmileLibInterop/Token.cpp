#include "pch.h"
#include "SmileLibInterop.h"
#include "Native/Exports.h"
#include "Native/Lexer.h"

namespace SmileLibInterop {

	Token::Token(void *ptr)
	{
		Native::Token token = (Native::Token)ptr;

		_kind = (TokenKind)token->kind;
		_position = gcnew LexerPosition(&token->_position);
		_text = Utils::SmileStringToDotNetString(token->text);

		_dataValue = gcnew array<System::Byte>(sizeof(union Native::TokenDataUnion));
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		memcpy(dataValueBase, &token->data, sizeof(union Native::TokenDataUnion));
	}

	System::String ^Token::ToString()
	{
		System::String ^text;

		switch (_kind) {
			case TokenKind::ALPHANAME: 
			case TokenKind::PUNCTNAME:
				text = Text;
				break;
			case TokenKind::CHAR:
				text = ((char)Data->Ch).ToString();
				break;
			case TokenKind::UNI:
				text = Data->Uni.ToString();
				break;
			case TokenKind::BYTE:
				text = Data->Byte.ToString();
				break;
			case TokenKind::INTEGER16:
				text = Data->Int16.ToString();
				break;
			case TokenKind::INTEGER32:
				text = Data->Int32.ToString();
				break;
			case TokenKind::INTEGER64:
				text = Data->Int64.ToString();
				break;
			case TokenKind::REAL32:
				text = Data->Real32.ToString();
				break;
			case TokenKind::REAL64:
				text = Data->Real64.ToString();
				break;
			case TokenKind::FLOAT32:
				text = Data->Float32.ToString();
				break;
			case TokenKind::FLOAT64:
				text = Data->Float64.ToString();
				break;
			case TokenKind::RAWSTRING:
				text = "\''" + Text + "\''";
				break;
			case TokenKind::DYNSTRING:
				text = "\"" + Text + "\"";
				break;
			default:
				text = nullptr;
				break;
		}

		if (text == nullptr || text->Length == 0)
			return _kind.ToString();
		else
			return _kind.ToString() + ": " + Text;
	}

	int TokenData::Symbol::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->symbol;
	}

	unsigned char TokenData::Byte::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->byte;
	}

	short TokenData::Int16::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->int16;
	}

	int TokenData::Int32::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->int32;
	}

	long long TokenData::Int64::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->int64;
	}

	float TokenData::Float32::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->float32;
	}

	double TokenData::Float64::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->float64;
	}

	unsigned int TokenData::Real32::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return *(unsigned int *)&((Native::TokenData)dataValueBase)->real32;
	}

	unsigned long long TokenData::Real64::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return *(unsigned long long *)&((Native::TokenData)dataValueBase)->real64;
	}

	unsigned char TokenData::Ch::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->ch;
	}

	unsigned int TokenData::Uni::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return ((Native::TokenData)dataValueBase)->uni;
	}

	System::IntPtr TokenData::Ptr::get()
	{
		pin_ptr<System::Byte> dataValueBase = &_dataValue[0];
		return (System::IntPtr)((Native::TokenData)dataValueBase)->ptr;
	}
}

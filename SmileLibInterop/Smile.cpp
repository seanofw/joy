#include "pch.h"
#include "SmileLibInterop.h"
#include "Native/Exports.h"

namespace SmileLibInterop {

	static bool _isInitialized = false;

	void Smile::Init()
	{
		SmileLibInterop::Native::GC_allow_register_threads();
		SmileLibInterop::Native::Smile_Init();
		_isInitialized = true;
	}

	void Smile::Reset()
	{
		SmileLibInterop::Native::Smile_ResetEnvironment();
	}

	void Smile::End()
	{
		SmileLibInterop::Native::Smile_End();
		_isInitialized = false;
	}

	bool Smile::IsInitialized()
	{
		return _isInitialized;
	}

	void Smile::AssertInitialized()
	{
		if (Smile::IsInitialized()) return;

		System::Diagnostics::Debug::WriteLine("Cannot continue without calling Smile::Init() first.");
		System::Diagnostics::Debugger::Break();
	}
}
#include "pch.h"
#include "SmileLibInterop.h"
#include "Native/Exports.h"

namespace SmileLibInterop {

	BackgroundThread::BackgroundThread()
	{
		struct SmileLibInterop::Native::GC_stack_base stackBase;

		SmileLibInterop::Native::GC_get_stack_base(&stackBase);
		SmileLibInterop::Native::GC_register_my_thread(&stackBase);
	}

	BackgroundThread::~BackgroundThread()
	{
		SmileLibInterop::Native::GC_unregister_my_thread();
	}
}

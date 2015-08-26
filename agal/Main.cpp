#pragma once
//#include "Lic.h"
//#define EXPORT_FUNC
#define DLL_EXPORT _declspec(dllexport)
#include "Lic.h"


#if __cplusplus

extern "C"
{
#endif
	DLL_EXPORT int GetLicState(string *s);
#if __cplusplus
}
#else
extern "C"
{
#include "Lic.h";
}
#endif

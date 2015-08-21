#include "stdafx.h"
#include "Lic.h"


Lic::Lic()
{
}


Lic::~Lic()
{
}


int _declspec(dllexport) Lic::LicInfo()
{
	return 10;
}

#include "stdafx.h"
#include "VersionInfo.h"


VersionInfo::VersionInfo()
{
	const int __version__ = 1;

	version = __version__;
}



VersionInfo::~VersionInfo()
{
}

 void VersionInfo::GetVersionInfo(int * args)
{
	args = &version;
}

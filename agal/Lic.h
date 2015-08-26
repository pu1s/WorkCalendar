#pragma once
#include <string>
using namespace std;
//#define LIC_H


namespace AGSoft
{
	class Lic
	{
	public:
		Lic();
		~Lic();
		int GetLicState(std::string *str);
		void Encode(string &word);
		void Decode(string &word);
		void GenerateLic(string *uname, string *email);
	};
}


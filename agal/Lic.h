#pragma once
#include <string>
using namespace std;
#define _AGS_FF *u32string
#define _UName &uname
#define _UEmail &uemail
#define _ASTRING string
#define pixel (int*)
#define _ww_args unsigned int
typedef int* _WW_AST;
typedef struct {
	unsigned x;
	unsigned y;
} POINT;

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
	private:
		char *_name;
		const string _WIN_A = "TestStr";
	
	public:
		int *protected_FF;
		string *str;
		

		
		_ASTRING GetA(_ASTRING & str);
		_WW_AST ImplFunc(_ASTRING * _UEmale, _ASTRING * _UName);
		_WW_AST Set_WW_AST(int* i);
		int URS_intPtr(int** args);
		POINT GetPoint(_ww_args x, _ww_args y);
	};
}


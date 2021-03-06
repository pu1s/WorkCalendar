﻿/**********************************************************
 Базовые классы, перечисления и интерфейсы для работы 
 с производственным календарем 
 MS Framework .Net 4.5
==========================================================
Этот файл является частью программы WorkCalendar
отображения календаря для использования на производстве и 
в бухгалтерском учете
==========================================================
Автор кода программы: Горин Александр pu1s@outlook.com
Copyright © Alex Gorin Software 2015 All rights reserved
==========================================================
Программа является иннтеллектуальной собственностью 
автора. Изменения в исходном коде программы должны
согласовыватьяс с автором.
Программа распостраняется в соответствии с
GNU GENERAL PUBLIC LICENSE
Версия 2, июнь 1991г.
Copyright (C) 1989, 1991 Free Software Foundation, Inc.
59 Temple Place - Suite 330, Boston, MA 02111-1307, USA
==========================================================
*/
using System.Collections.Generic;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    public static class OrdinaryCalendar
    {
        public static Dictionary<string, string> GetCalendar()
        {
            return new Dictionary<string, string>
            {
                {"01.01", "Новый год"},
                {"23.02", "День защитника отечества"},
                {"08.03", "Международный женский день"},
                {"01.05", "Первое мая"},
                {"09.05", "День победы"}
            };
        }
    }
}
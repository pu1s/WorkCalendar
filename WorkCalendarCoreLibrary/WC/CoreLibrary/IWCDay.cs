//**********************************************************
// ������� ������, ������������ � ���������� ��� ������ 
// � ���������������� ���������� 
// MS Framework .Net 4.5
// �# version 6.0
// ����� ��������� 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

using System;

namespace AGSoft.WC.CoreLibrary
{
    /// <summary>
    ///     ���������, ������������ ����������� ����
    /// </summary>
    public interface IWCDay
    {
        /// <summary>
        ///     ����, ��������������� ������������ ���
        /// </summary>
        DateTime WCDayDate { get; }

        /// <summary>
        ///     ��������, ������������ ��������� ��� � ���������������� ���������
        /// </summary>
        WCDayAttribute WCDayAttribute { get; }

        /// <summary>
        ///     ��������, ������������ ��������� ������������ ���
        /// </summary>
        WCDayDescription WCDayDescription { get; }

        /// <summary>
        ///     ����������� ��� ������������ ���
        /// </summary>
        string WCDayComment { get; set; }

        /// <summary>
        ///     ���������� �������������� ������������ ���
        /// </summary>
        int WCDayHandle { get; }
    }
}
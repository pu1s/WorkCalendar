using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WorkCalendar
{
    public partial class FormMain : Form
    {
        [DllImport("AuthLib.dll", EntryPoint = "GetVersionInfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern void GetVersionInfo(out int a);

        private int _a = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            GetVersionInfo(out _a);
            button1.Text = _a.ToString();
        }
    }
}

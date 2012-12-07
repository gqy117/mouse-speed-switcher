using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MonitorLibrary
{
    public class MonitorClass
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, int lParam);
        private const uint WM_SYSCOMMAND = 0x0112;
        private const uint SC_MONITORPOWER = 0xF170;



        public void Close()
        {
            using (Form2 f2 = new Form2())
            {
                SendMessage(f2.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
            }
            return;
        }
    }
}

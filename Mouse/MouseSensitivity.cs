using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MouseLibrary
{
    public class MouseSensitivity
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;

        [DllImport("User32.dll")]
        public static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);
        public static void Switch_Mouse(int sensitivy)
        {
            MouseLibrary.MouseSensitivity.SystemParametersInfo(MouseLibrary.MouseSensitivity.SPI_SETMOUSESPEED, 0, uint.Parse(sensitivy.ToString()), 0);
        }
    }
}

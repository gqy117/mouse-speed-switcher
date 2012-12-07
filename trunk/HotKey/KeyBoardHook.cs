using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace KeyBoardLibrary
{
    public class KeyBoardHook
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        public static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo)) return 0;
            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }
        public static bool IsKeyBoardActive(double timerInterval)
        {
            long lastInputTime = KeyBoardHook.GetLastInputTime();
            if (lastInputTime >= timerInterval)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyBoardLibrary
{
    public class KeyBoardHotKey
    {
        public const int HOTKEY_ID_1 = 786;    //any number to be used as an id within this app
        public const int HOTKEY_ID_2 = 787;    //any number to be used as an id within this app
        public const int HOTKEY_ID_3 = 788;    //any number to be used as an id within this app
        public const int WM_HOTKEY = 0x0312;

        public enum KeyModifiers        //enum to call 3rd parameter of RegisterHotKey easily
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
        //API Imports
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static void RegisterHotKey_All(IntPtr Handle, string ctrlStr, string altStr, string shiftStr, Keys key)
        {
            bool ctrl = false; bool alt = false; bool shift = false;
            ctrl = (ctrlStr == "1"); alt = (altStr == "1"); shift = (shiftStr == "1");
            if (ctrl && alt && shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Alt | KeyBoardHotKey.KeyModifiers.Control | KeyBoardHotKey.KeyModifiers.Shift, key);
            }
            else if (ctrl && alt && !shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Alt | KeyBoardHotKey.KeyModifiers.Control, key);
            }
            else if (!ctrl && alt && shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Alt | KeyBoardHotKey.KeyModifiers.Shift, key);
            }
            else if (ctrl && !alt && shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Shift | KeyBoardHotKey.KeyModifiers.Control, key);
            }
            else if (ctrl && !alt && !shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Control, key);
            }
            else if (!ctrl && !alt && shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Shift, key);
            }
            else if (!ctrl && alt && !shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.Alt, key);
            }
            else if (!ctrl && !alt && !shift)
            {
                KeyBoardHotKey.RegisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1, KeyBoardHotKey.KeyModifiers.None, key);
            }
        }
        public static void RegisterHotKey_All(IntPtr Handle, string ctrl, string alt, string shift, string key)
        {
            try
            {
                KeysConverter kc = new KeysConverter();
                Keys keyCode = (Keys)kc.ConvertFromString(key);
                RegisterHotKey_All(Handle, ctrl, alt, shift, keyCode);
            }
            catch { }
        }
        public static void UnregisterHotKey_All(IntPtr Handle)
        {
            KeyBoardHotKey.UnregisterHotKey(Handle, KeyBoardHotKey.HOTKEY_ID_1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IniFileLibrary
{
    public class HotKey_Ini : IniFile
    {
        public string SwitchKey = "";
        public string Ctrl = "0";
        public string Alt = "0";
        public string Shift = "0";
        public HotKey_Ini() { }
        public void Get()
        {
            SwitchKey = IniReadValue("HotKey", "SwitchKey");
            Ctrl = IniReadValue("HotKey", "Ctrl");
            Alt = IniReadValue("HotKey", "Alt");
            Shift = IniReadValue("HotKey", "Shift");
        }
        public void Set()
        {
            IniWriteValue("HotKey", "SwitchKey", SwitchKey);
            IniWriteValue("HotKey", "Ctrl", Ctrl);
            IniWriteValue("HotKey", "Alt", Alt);
            IniWriteValue("HotKey", "Shift", Shift);
        }
        public void Set(KeyEventArgs e)
        {
            KeysConverter kc = new KeysConverter();
            string keyString = kc.ConvertToString(e.KeyCode);
            SwitchKey = keyString;
            Ctrl = (e.Control) ? "1" : "0";
            Alt = (e.Alt) ? "1" : "0";
            Shift = (e.Shift) ? "1" : "0";
            Set();
        }
    }
}

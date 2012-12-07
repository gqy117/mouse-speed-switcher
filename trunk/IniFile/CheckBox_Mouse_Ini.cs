using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IniFileLibrary
{
    public class CheckBox_Mouse_Ini : Mouse_Ini
    {
        public CheckBox_Mouse_Ini()
        {
            MouseEnabled = new List<string>();
            for (int i = 0; i < MouseCount; i++)
            {
                MouseEnabled.Add("0");
            }
        }
        public List<string> MouseEnabled;
        
        public void Get()
        {
            for (int i = 0; i < MouseCount; i++)
            {
                MouseEnabled[i] = IniReadValue("Mouse", "MouseEnabled" + (i + 1).ToString());
            }
        }
        public void Set()
        {
            for (int i = 0; i < MouseCount; i++)
            {
                IniWriteValue("Mouse", "MouseEnabled" + (i + 1).ToString(), MouseEnabled[i]);
            }
        }
    }
}

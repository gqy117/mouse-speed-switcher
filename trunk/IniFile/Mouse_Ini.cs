using System;
using System.Collections.Generic;
using System.Text;

namespace IniFileLibrary
{
    public class Mouse_Ini : IniFile
    {
        public int Current_Select = 0;
        private int _Current_Sensitivity_Value = -1;
        public int Current_Sensitivity_Value
        {
            get
            {
                if (-1 == _Current_Sensitivity_Value)
                {
                    int.TryParse(IniReadValue("Mouse", "Current_Sensitivity_Value"), out _Current_Sensitivity_Value);
                }
                return _Current_Sensitivity_Value;
            }
            set
            {
                _Current_Sensitivity_Value = value;
                IniWriteValue("Mouse", "Current_Sensitivity_Value", _Current_Sensitivity_Value.ToString());
            }
        }
        private string _Mouse_Sound_File = "";
        public string Mouse_Sound_File
        {
            get
            {
                _Mouse_Sound_File = IniReadValue("Mouse", "Mouse_Sound_File");
                return _Mouse_Sound_File;
            }
            set
            {
                _Mouse_Sound_File = value;
                IniWriteValue("Mouse", "Mouse_Sound_File", _Mouse_Sound_File);
            }
        }
        private string _Mouse_Sound_Ext = ".wav";
        public string Mouse_Sound_Ext
        {
            get { return _Mouse_Sound_Ext; }
            set { _Mouse_Sound_Ext = value; }
        }

        public List<string> Sensitivity;
        public int MouseCount = 3;
        public Mouse_Ini()
        {
            Init_Sensitivity();
        }
        public Mouse_Ini(string INIPath)
        {
            Path = INIPath + "\\" + ConfigFileName;
            Get_Current_Select();
            Init_Sensitivity();
        }
        private void Init_Sensitivity()
        {
            Sensitivity = new List<string>();
            for (int i = 0; i < MouseCount; i++)
            {
                Sensitivity.Add("0");
            }
        }
        public void Set_Current_Select()
        {
            IniWriteValue("Mouse", "Current_Select", this.Current_Select.ToString());
        }
        public void Get_Current_Select()
        {
            int.TryParse(IniReadValue("Mouse", "Current_Select"), out Current_Select);
        }
        public void Get_Mouse_Sensitive_From_Ini()
        {
            for (int i = 0; i < MouseCount; i++)
            {
                Sensitivity[i] = IniReadValue("Mouse", "Sensitivity" + (i + 1).ToString());
            }
        }
        public void Set_Mouse_Sensitive_To_Ini()
        {
            for (int i = 0; i < MouseCount; i++)
            {
                IniWriteValue("Mouse", "Sensitivity" + (i + 1).ToString(), Sensitivity[i]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeyBoardLibrary;
using IniFileLibrary;
using MouseSpeedSwitcher_Logic;

namespace MouseSpeedSwitcher
{
    public partial class MouseSwitcher : Form
    {
        public Mouse_Ini mouse_Ini; public HotKey_Ini hotKey_Ini; public Mouse mouse; public Mouse1 mouse1; public Mouse2 mouse2; public Mouse3 mouse3;
        public Lbl_Sensitivity lbl_Sensitivity; public Lbl_Sensitivity_Color lbl_Sensitivity_Color; public Lbl_Sensitivity_Value lbl_Sensitivity_Value;
        public TB_Sensitivity tB_Sensitivity; public TxT_HotKey txT_HotKey; public CheckBox_Mouse_Ini checkBox_Mouse_Ini; public CheckBox_Mouse checkBox_Mouse; public Mouse_Sound mouse_Sound;
        public MouseSwitcher()
        {
            InitializeComponent();
            Init_Interface_Control();
            txT_HotKey.Get();
            checkBox_Mouse.Get();
            tB_Sensitivity.Bind();
            lbl_Sensitivity.Set();
        }
        public void Init_Interface_Control()
        {
            mouse = new Mouse(this); lbl_Sensitivity = new Lbl_Sensitivity(this); tB_Sensitivity = new TB_Sensitivity(this);
            mouse1 = new Mouse1(this); mouse2 = new Mouse2(this); mouse3 = new Mouse3(this);
            hotKey_Ini = new HotKey_Ini(); mouse_Ini = new Mouse_Ini(Application.StartupPath);
            checkBox_Mouse = new CheckBox_Mouse(this);
            lbl_Sensitivity_Color = new Lbl_Sensitivity_Color(this);
            lbl_Sensitivity_Value = new Lbl_Sensitivity_Value(this);
            checkBox_Mouse_Ini = new CheckBox_Mouse_Ini();
            txT_HotKey = new TxT_HotKey(this);
            mouse_Sound = new Mouse_Sound(this);
        }
        //having registered a hotkey the thread that registered it receives a WM_HOTKEY message upon the keypress which has to be caught by overwriting the WndProc method
        protected override void WndProc(ref Message msg)
        {
            //Listen for operating system messages.
            switch (msg.Msg)
            {
                case KeyBoardLibrary.KeyBoardHotKey.HOTKEY_ID_1:
                    mouse.Switch();
                    break;
            }
            base.WndProc(ref msg);
        }
        private void MouseSwitcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
            else
            {
                this.Close_It();
            }
        }
        public void Close_It()
        {
            KeyBoardLibrary.KeyBoardHotKey.UnregisterHotKey_All(Handle);
            Application.Exit();
        }
        public void tB_Sensitivity1_ValueChanged(object sender, EventArgs e)
        {
            mouse1.Switch_SetCurrent(this.tB_Sensitivity1.Value);
        }
        public void tB_Sensitivity2_ValueChanged(object sender, EventArgs e)
        {
            mouse2.Switch_SetCurrent(this.tB_Sensitivity2.Value);
        }
        public void tB_Sensitivity3_ValueChanged(object sender, EventArgs e)
        {
            mouse3.Switch_SetCurrent(this.tB_Sensitivity3.Value);
        }
        private void txt_HotKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (18 != e.KeyValue && 17 != e.KeyValue && 16 != e.KeyValue && 91 != e.KeyValue)
            {
                txT_HotKey.Set(e);
            }
        }
        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Mouse.Set(1);
        }
        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Mouse.Set(2);
        }
        public void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Mouse.Set(3);
        }
    }
}
namespace MouseSpeedSwitcher_Logic
{
    using MouseSpeedSwitcher;
    using SoundLibrary;
    public class Interface_MouseSwitcher
    {
        public enum Form_Name
        {
            Main,
            MouseSwitcher,
            MonitorCloser
        }
        public MouseSwitcher mouseSwitcher;
        public Monitor_Form monitor_Form;
        public Interface_MouseSwitcher()
        {
            mouseSwitcher = new MouseSwitcher();
            monitor_Form = new Monitor_Form();
        }
        public Interface_MouseSwitcher(MouseSwitcher mouseSwitcher1) { }
        public void Close_It()
        {
            KeyBoardLibrary.KeyBoardHotKey.UnregisterHotKey_All(mouseSwitcher.Handle);
            Application.Exit();
        }
        public void Show_Form(Form_Name form_Name)
        {
            Hide_All_Form();
            switch (form_Name)
            {
                case Form_Name.MouseSwitcher:
                    mouseSwitcher.Visible = true;
                    break;
                case Form_Name.MonitorCloser:
                    monitor_Form.Visible = true;
                    break;
            }
        }
        public void Hide_All_Form()
        {
            monitor_Form.Visible = false;
            mouseSwitcher.Visible = false;
        }
    }
    public class MouseSwitcher_Form
    {
        public MouseSwitcher mouseSwitcher;
        public WSounds wSounds = new WSounds();
    }
    public class Mouse : MouseSwitcher_Form
    {
        public Mouse() { }
        public Mouse(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public virtual void Switch()
        {
            int next = Get_Next_Mouse_Number();
            switch (next)
            {
                case 0:
                    mouseSwitcher.mouse1.SetCurrent();
                    break;
                case 1:
                    mouseSwitcher.mouse2.SetCurrent();
                    break;
                case 2:
                    mouseSwitcher.mouse3.SetCurrent();
                    break;
            }
        }
        private int Get_Next_Mouse_Number()
        {
            int next = mouseSwitcher.mouse_Ini.Current_Select;
            while (1 == 1)
            {
                if (IsLastNumber(next))
                {
                    next = 0;
                }
                else
                {
                    next++;
                }
                if (IsEnabled(next)) { break; }
            }
            return next;
        }
        private bool IsLastNumber(int number)
        {
            return ((mouseSwitcher.mouse_Ini.MouseCount - 1) == number) ? true : false;
        }
        private bool IsEnabled(int number)
        {
            return ("1" == mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[number]) ? true : false;
        }
        public void Save_Mouse_Sensitive_To_Ini()
        {
            mouseSwitcher.mouse_Ini.Sensitivity[0] = mouseSwitcher.tB_Sensitivity1.Value.ToString();
            mouseSwitcher.mouse_Ini.Sensitivity[1] = mouseSwitcher.tB_Sensitivity2.Value.ToString();
            mouseSwitcher.mouse_Ini.Sensitivity[2] = mouseSwitcher.tB_Sensitivity3.Value.ToString();
            mouseSwitcher.mouse_Ini.Set_Mouse_Sensitive_To_Ini();
        }
        public void Switch_SetCurrent(int sensitivity)
        {
            SetCurrent();
        }
        public virtual void Save_Mouse_Sensitive_To_Ini_Set_lbl_Sensitivity_Value()
        {
            Save_Mouse_Sensitive_To_Ini();
            mouseSwitcher.lbl_Sensitivity_Value.Set();
            mouseSwitcher.lbl_Sensitivity_Color.Set();
        }
        public virtual void SetCurrent()
        {
            SetCurrent_Mouse();
            Save_Mouse_Sensitive_To_Ini_Set_lbl_Sensitivity_Value();
            mouseSwitcher.mouse_Sound.Play();
        }
        public void SetCurrent_Mouse_Sensitivity(int sensitivity)
        {
            mouseSwitcher.mouse_Ini.Current_Sensitivity_Value = sensitivity;
        }
        public virtual void SetCurrent_Mouse() { }
    }
    public class Mouse_Sound : MouseSwitcher_Form
    {
        WSounds wSounds = new WSounds();
        private int wait_Time = 500;
        public Mouse_Sound(MouseSwitcher mouseSwitcher1) { this.mouseSwitcher = mouseSwitcher1; wSounds = new WSounds(); }
        public void Play()
        {
            string tens_Num = ((mouseSwitcher.mouse_Ini.Current_Sensitivity_Value / 10) * 10).ToString();
            string single_Num = (mouseSwitcher.mouse_Ini.Current_Sensitivity_Value % 10).ToString();
            if ("10" == tens_Num && "0" == single_Num)
            {
                tens_Num = "10";
                single_Num = "";
            }
            else if ("20" == tens_Num && "0" == single_Num)
            {
                tens_Num = "2";
                single_Num = "10";
            }
            else if ("0" == tens_Num)
            {
                tens_Num = "";
            }
            this.Play(tens_Num);
            this.Play(single_Num);
        }
        public void Play(string fileName)
        {
            if (0 != fileName.Trim().Length)
            {
                string pathFileName = Application.StartupPath + "\\" + mouseSwitcher.mouse_Ini.Mouse_Sound_File + fileName + mouseSwitcher.mouse_Ini.Mouse_Sound_Ext;
                wSounds.Play(pathFileName);
                System.Threading.Thread.Sleep(wait_Time);
            }
        }
    }
    public class Mouse1 : Mouse
    {
        public Mouse1(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public override void SetCurrent_Mouse()
        {
            mouseSwitcher.mouse_Ini.Current_Select = 0;
            MouseLibrary.MouseSensitivity.Switch_Mouse(mouseSwitcher.tB_Sensitivity1.Value);
            SetCurrent_Mouse_Sensitivity(mouseSwitcher.tB_Sensitivity1.Value);
        }
    }
    public class Mouse2 : Mouse
    {
        public Mouse2(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public override void SetCurrent_Mouse()
        {
            mouseSwitcher.mouse_Ini.Current_Select = 1;
            MouseLibrary.MouseSensitivity.Switch_Mouse(mouseSwitcher.tB_Sensitivity2.Value);
            SetCurrent_Mouse_Sensitivity(mouseSwitcher.tB_Sensitivity2.Value);
        }
    }
    public class Mouse3 : Mouse
    {
        public Mouse3(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public override void SetCurrent_Mouse()
        {
            mouseSwitcher.mouse_Ini.Current_Select = 2;
            MouseLibrary.MouseSensitivity.Switch_Mouse(mouseSwitcher.tB_Sensitivity3.Value);
            SetCurrent_Mouse_Sensitivity(mouseSwitcher.tB_Sensitivity3.Value);
        }
    }
    public class Lbl_Sensitivity : MouseSwitcher_Form
    {
        public Lbl_Sensitivity() { }
        public Lbl_Sensitivity(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public void Set()
        {
            mouseSwitcher.lbl_Sensitivity_Color.Set();
            mouseSwitcher.lbl_Sensitivity_Value.Set();
        }
    }
    public class Lbl_Sensitivity_Color : Lbl_Sensitivity
    {
        public Lbl_Sensitivity_Color(MouseSwitcher mouseSwitcher1) { this.mouseSwitcher = mouseSwitcher1; }
        public void Set()
        {
            ReSet();
            switch (mouseSwitcher.mouse_Ini.Current_Select)
            {
                case 0:
                    mouseSwitcher.lbl_Sensitivity1.ForeColor = Color.Red;
                    break;
                case 1:
                    mouseSwitcher.lbl_Sensitivity2.ForeColor = Color.Red;
                    break;
                case 2:
                    mouseSwitcher.lbl_Sensitivity3.ForeColor = Color.Red;
                    break;
            }
        }
        public void ReSet()
        {
            mouseSwitcher.lbl_Sensitivity1.ForeColor = Color.Black;
            mouseSwitcher.lbl_Sensitivity2.ForeColor = Color.Black;
            mouseSwitcher.lbl_Sensitivity3.ForeColor = Color.Black;
        }
    }
    public class Lbl_Sensitivity_Value : Lbl_Sensitivity
    {
        public Lbl_Sensitivity_Value(MouseSwitcher mouseSwitcher1) { this.mouseSwitcher = mouseSwitcher1; }
        public void Set()
        {
            mouseSwitcher.lbl_Sensitivity1_Value.Text = mouseSwitcher.tB_Sensitivity1.Value.ToString();
            mouseSwitcher.lbl_Sensitivity2_Value.Text = mouseSwitcher.tB_Sensitivity2.Value.ToString();
            mouseSwitcher.lbl_Sensitivity3_Value.Text = mouseSwitcher.tB_Sensitivity3.Value.ToString();
        }
    }
    public class TB_Sensitivity : MouseSwitcher_Form
    {
        public TB_Sensitivity(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public void Bind()
        {
            mouseSwitcher.mouse_Ini.Get_Mouse_Sensitive_From_Ini();
            int sensitivity1 = 0, sensitivity2 = 0, sensitivity3 = 0;
            int.TryParse(mouseSwitcher.mouse_Ini.Sensitivity[0], out sensitivity1); int.TryParse(mouseSwitcher.mouse_Ini.Sensitivity[1], out sensitivity2); int.TryParse(mouseSwitcher.mouse_Ini.Sensitivity[2], out sensitivity3);
            UnBindEvent_ValueChanged();
            mouseSwitcher.tB_Sensitivity1.Value = sensitivity1;
            mouseSwitcher.tB_Sensitivity2.Value = sensitivity2;
            mouseSwitcher.tB_Sensitivity3.Value = sensitivity3;
            BindEvent_ValueChanged();
        }
        private void BindEvent_ValueChanged()
        {
            mouseSwitcher.tB_Sensitivity1.ValueChanged += new System.EventHandler(mouseSwitcher.tB_Sensitivity1_ValueChanged);
            mouseSwitcher.tB_Sensitivity2.ValueChanged += new System.EventHandler(mouseSwitcher.tB_Sensitivity2_ValueChanged);
            mouseSwitcher.tB_Sensitivity3.ValueChanged += new System.EventHandler(mouseSwitcher.tB_Sensitivity3_ValueChanged);
        }
        private void UnBindEvent_ValueChanged()
        {
            mouseSwitcher.tB_Sensitivity1.ValueChanged -= new System.EventHandler(mouseSwitcher.tB_Sensitivity1_ValueChanged);
            mouseSwitcher.tB_Sensitivity2.ValueChanged -= new System.EventHandler(mouseSwitcher.tB_Sensitivity2_ValueChanged);
            mouseSwitcher.tB_Sensitivity3.ValueChanged -= new System.EventHandler(mouseSwitcher.tB_Sensitivity3_ValueChanged);
        }
    }
    public class TxT_HotKey : MouseSwitcher_Form
    {
        private const int Lengh_Alt = 26;
        private const int Lengh_Ctrl = Lengh_Alt + 4;
        private const int Lengh_Shift = Lengh_Ctrl + 4;
        public TxT_HotKey(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public void Set(KeyEventArgs e)
        {
            KeyBoardLibrary.KeyBoardHotKey.UnregisterHotKey_All(mouseSwitcher.Handle);
            mouseSwitcher.hotKey_Ini.Set(e);
            mouseSwitcher.hotKey_Ini.Get();
            KeyBoardLibrary.KeyBoardHotKey.RegisterHotKey_All(mouseSwitcher.Handle, mouseSwitcher.hotKey_Ini.Ctrl, mouseSwitcher.hotKey_Ini.Alt, mouseSwitcher.hotKey_Ini.Shift, mouseSwitcher.hotKey_Ini.SwitchKey);
            Set_Text();
        }
        public void Get()
        {
            KeyBoardLibrary.KeyBoardHotKey.UnregisterHotKey_All(mouseSwitcher.Handle);
            mouseSwitcher.hotKey_Ini.Get();
            KeyBoardLibrary.KeyBoardHotKey.RegisterHotKey_All(mouseSwitcher.Handle, mouseSwitcher.hotKey_Ini.Ctrl, mouseSwitcher.hotKey_Ini.Alt, mouseSwitcher.hotKey_Ini.Shift, mouseSwitcher.hotKey_Ini.SwitchKey);
            Set_Text();
        }
        private void Set_Text()
        {
            mouseSwitcher.txt_HotKey.Text = mouseSwitcher.hotKey_Ini.SwitchKey;
            Set_lbl_Ctrl();
            mouseSwitcher.tB_Sensitivity1.Focus();
        }
        private void Set_lbl_Ctrl()
        {
            mouseSwitcher.lbl_Ctrl.Text = Set_Text_Location();
        }
        private string Set_Text_Location()
        {
            string lbl_Ctrl_Text = "";
            mouseSwitcher.txt_HotKey.Left = mouseSwitcher.lbl_Ctrl.Left;
            if ("1" == mouseSwitcher.hotKey_Ini.Ctrl)
            {
                lbl_Ctrl_Text += "Ctrl + ";
                mouseSwitcher.txt_HotKey.Left += Lengh_Ctrl;
            }
            if ("1" == mouseSwitcher.hotKey_Ini.Alt)
            {
                lbl_Ctrl_Text += "Alt + ";
                mouseSwitcher.txt_HotKey.Left += Lengh_Alt;
            }
            if ("1" == mouseSwitcher.hotKey_Ini.Shift)
            {
                lbl_Ctrl_Text += "Shift + ";
                mouseSwitcher.txt_HotKey.Left += Lengh_Shift;
            }
            return lbl_Ctrl_Text;
        }
    }
    public class CheckBox_Mouse : MouseSwitcher_Form
    {
        public CheckBox_Mouse(MouseSwitcher mouseSwitcher1)
        {
            this.mouseSwitcher = mouseSwitcher1;
        }
        public void Set(int number)
        {
            Set_tB_Sensitivity_Enabled();
            switch (number)
            {
                case 1:
                    mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[number - 1] = (mouseSwitcher.checkBox1.Checked) ? "1" : "0";
                    break;
                case 2:
                    mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[number - 1] = (mouseSwitcher.checkBox2.Checked) ? "1" : "0";
                    break;
                case 3:
                    mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[number - 1] = (mouseSwitcher.checkBox3.Checked) ? "1" : "0";
                    break;
            }
            mouseSwitcher.checkBox_Mouse_Ini.Set();
        }
        private void Set_tB_Sensitivity_Enabled()
        {
            mouseSwitcher.tB_Sensitivity1.Enabled = mouseSwitcher.checkBox1.Checked;
            mouseSwitcher.tB_Sensitivity2.Enabled = mouseSwitcher.checkBox2.Checked;
            mouseSwitcher.tB_Sensitivity3.Enabled = mouseSwitcher.checkBox3.Checked;
        }
        public void Get()
        {
            mouseSwitcher.checkBox_Mouse_Ini.Get();
            UnBindEvent_ValueChanged();
            Set_checkBox_Checked();
            BindEvent_CheckedChanged();
            Set_tB_Sensitivity_Enabled();
        }
        private void Set_checkBox_Checked()
        {
            mouseSwitcher.checkBox1.Checked = (mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[0] == "1") ? true : false;
            mouseSwitcher.checkBox2.Checked = (mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[1] == "1") ? true : false;
            mouseSwitcher.checkBox3.Checked = (mouseSwitcher.checkBox_Mouse_Ini.MouseEnabled[2] == "1") ? true : false;
        }
        private void BindEvent_CheckedChanged()
        {
            mouseSwitcher.checkBox1.CheckedChanged += new System.EventHandler(mouseSwitcher.checkBox1_CheckedChanged);
            mouseSwitcher.checkBox2.CheckedChanged += new System.EventHandler(mouseSwitcher.checkBox2_CheckedChanged);
            mouseSwitcher.checkBox3.CheckedChanged += new System.EventHandler(mouseSwitcher.checkBox3_CheckedChanged);
        }
        private void UnBindEvent_ValueChanged()
        {
            mouseSwitcher.checkBox1.CheckedChanged -= new System.EventHandler(mouseSwitcher.checkBox1_CheckedChanged);
            mouseSwitcher.checkBox2.CheckedChanged -= new System.EventHandler(mouseSwitcher.checkBox2_CheckedChanged);
            mouseSwitcher.checkBox3.CheckedChanged -= new System.EventHandler(mouseSwitcher.checkBox3_CheckedChanged);
        }
    }
}
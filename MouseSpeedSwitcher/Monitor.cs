using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MouseLibrary;
using KeyBoardLibrary;
using IniFileLibrary;
using Monitor_Logic;

namespace MouseSpeedSwitcher
{
    public partial class Monitor_Form : Form
    {
        private bool FirstRun = true;
        public Monitor_Ini monitor_Ini; Point pre; Point cur; public Txt_Interval txT_Interval;
        public DateTime Last_Click = DateTime.Now;
        public System.Timers.Timer t;

        public Monitor_Form()
        {
            monitor_Ini = new Monitor_Ini();
            this.Visible = false;
            InitializeComponent();
            Init_TxT_Interval();
            txT_Interval.Init_Timer_Monitor_Close();
            Init_MouseHook();
        }
        private void Init_TxT_Interval()
        {
            txT_Interval = new Txt_Interval(this);
            txt_Interval.Text = monitor_Ini.IntervalMinute.ToString();
        }
        private void Init_MouseHook()
        {
            MouseHook mouse = new MouseHook();
            mouse.OnMouseActivity += new MouseEventHandler(this.mouse_OnMouseActivity);
            mouse.OnMouseClick += new MouseEventHandler(this.mouse_OnMouseClick);
            mouse.Start();
        }
        public void mouse_OnMouseActivity(object sender, MouseEventArgs e)
        {
            cur.X = e.X;
            cur.Y = e.Y;

        }
        public void mouse_OnMouseClick(object sender, MouseEventArgs e)
        {
            Last_Click = DateTime.Now;
        }
        public void IsClose(object source, System.Timers.ElapsedEventArgs e)
        {
            if (this.FirstRun)
            {
                pre = cur;
                this.FirstRun = false;
            }
            else
            {
                //cur 是最新的
                string temp = KeyBoardHook.GetLastInputTime().ToString();
                MouseHook mh = new MouseHook();
                //if (!mh.IsMouseActive(cur.X, pre.X, cur.Y, pre.Y) && !KeyBoardHook.IsKeyBoardActive(monitor_Ini.IntervalTime))
                //if (!mh.IsMouseActive(this.Last_Click, new TimeSpan(0, 0, 0, 0, monitor_Ini.IntervalTime)) && !KeyBoardHook.IsKeyBoardActive(monitor_Ini.IntervalTime))
                //if (!mh.IsMouseActive(this.Last_Click, new TimeSpan(0, 0, 0, 0, monitor_Ini.IntervalTime)) )
                if (!KeyBoardHook.IsKeyBoardActive(monitor_Ini.IntervalTime))
                {
                    using (Close_Monitor_Form m = new Close_Monitor_Form())
                    {
                        m.Close();
                    }
                }
                pre = cur;
            }
            return;
        }
        private void txt_Interval_TextChanged(object sender, EventArgs e)
        {
            txT_Interval.Set();
        }

        private void Monitor_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
    public class Close_Monitor_Form : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, int lParam);
        private const uint WM_SYSCOMMAND = 0x0112;
        private const uint SC_MONITORPOWER = 0xF170;
        public Close_Monitor_Form()
        {
            InitializeComponent();
        }
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }
        public void Close()
        {
            using (Close_Monitor_Form f2 = new Close_Monitor_Form())
            {
                SendMessage(f2.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
            }
            return;
        }
    }
}
namespace Monitor_Logic
{
    using MouseSpeedSwitcher;
    public class Monitor_Form_Logic
    {
        public Monitor_Form monitor_Form;
    }
    public class Txt_Interval : Monitor_Form_Logic
    {
        public Txt_Interval(Monitor_Form monitor_Form1)
        {
            monitor_Form = monitor_Form1;
        }
        public void Set()
        {
            Set_Monitor_Ini();
            Set_Interval_Min();
        }
        public void Set_Monitor_Ini()
        {
            int intervalMinute = 0;
            int.TryParse(monitor_Form.txt_Interval.Text, out intervalMinute);
            monitor_Form.monitor_Ini.IntervalMinute = intervalMinute;
            monitor_Form.monitor_Ini.Set();
        }
        public void Set_Interval_Min()
        {
            monitor_Form.monitor_Ini.Get();
            Init_Timer_Monitor_Close();
        }
        public void Init_Timer_Monitor_Close()
        {
            if (null != monitor_Form.t) { monitor_Form.t.Dispose(); }
            monitor_Form.t = new System.Timers.Timer(monitor_Form.monitor_Ini.IntervalTime);
            //到达时间的时候执行事件；   
            monitor_Form.t.Elapsed += new System.Timers.ElapsedEventHandler(monitor_Form.IsClose);
            //设置是执行一次（false）还是一直执行(true)；   
            monitor_Form.t.AutoReset = true;
            //是否执行System.Timers.Timer.Elapsed事件； 
            monitor_Form.t.Enabled = true;
        }
    }
}
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MouseSpeedSwitcher_Logic;

namespace MouseSpeedSwitcher
{
    public class Tray : Form
    {
        private System.ComponentModel.Container components = null;
        private Icon mNetTrayIcon = new Icon("Tray.ico");
        private NotifyIcon TrayIcon;
        private ContextMenu notifyiconMnu;
        public Interface_MouseSwitcher interface_MouseSwitcher;
        public Tray()
        {
            InitializeComponent();
            //初始化托盘程序的各个要素
            Initialize_Notify_Icon();
            interface_MouseSwitcher = new Interface_MouseSwitcher();
            this.Visible = false;
        }
        private void Initialize_Notify_Icon()
        {
            //设定托盘程序的各个属性
            TrayIcon = new NotifyIcon();
            TrayIcon.Icon = mNetTrayIcon;
            TrayIcon.Text = "Mouse Switcher";
            TrayIcon.Visible = true;
            TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);

            //定义一个MenuItem数组，并把此数组同时赋值给ContextMenu对象
            MenuItem[] mnuItms = new MenuItem[6]; int i = 0;
            //mnuItms[i] = new MenuItem();
            //mnuItms[i].Text = "Main";
            //mnuItms[i].Click += new System.EventHandler(this.Menu_Main_Clicked);
            //i++;
            mnuItms[i] = new MenuItem("-");
            i++;
            mnuItms[i] = new MenuItem();
            mnuItms[i].Text = "Show Mouse Switcher";
            mnuItms[i].Click += new System.EventHandler(this.Menu_MouseSwitcher_Clicked);
            i++;
            mnuItms[i] = new MenuItem("-");
            i++;
            mnuItms[i] = new MenuItem();
            mnuItms[i].Text = "Monitor Closer";
            mnuItms[i].Click += new System.EventHandler(this.Menu_Monitor_Clicked);
            i++;
            mnuItms[i] = new MenuItem("-");
            i++;
            mnuItms[i] = new MenuItem();
            mnuItms[i].Text = "Exit";
            mnuItms[i].Click += new System.EventHandler(this.ExitSelect);
            mnuItms[i].DefaultItem = true;

            notifyiconMnu = new ContextMenu(mnuItms);
            TrayIcon.ContextMenu = notifyiconMnu;
            //为托盘程序加入设定好的ContextMenu对象
        }
        public void TrayIcon_DoubleClick(object sender, System.EventArgs e)
        {
            Show_Form_MouseSwitcher();
        }
        private void Show_Form_Main()
        {
            interface_MouseSwitcher.Hide_All_Form();
            //this.Visible = true;
        }
        private void Show_Form_MouseSwitcher()
        {
            interface_MouseSwitcher.Show_Form(Interface_MouseSwitcher.Form_Name.MouseSwitcher);
        }
        private void Show_Form_MonitorCloser()
        {
            interface_MouseSwitcher.Show_Form(Interface_MouseSwitcher.Form_Name.MonitorCloser);
        }
        public void Menu_Main_Clicked(object sender, System.EventArgs e)
        {
            Show_Form_Main();
        }
        public void Menu_MouseSwitcher_Clicked(object sender, System.EventArgs e)
        {
            Show_Form_MouseSwitcher();
        }
        public void Menu_Monitor_Clicked(object sender, System.EventArgs e)
        {
            Show_Form_MonitorCloser();
        }
        public void ExitSelect(object sender, System.EventArgs e)
        {
            //隐藏托盘程序中的图标
            TrayIcon.Visible = false;
            interface_MouseSwitcher.Close_It();
            Application.Exit();
        }
        //清除程序中使用过的资源
        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose();
        //    if (components != null)
        //        components.Dispose();
        //}
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tray));
            this.SuspendLayout();
            // 
            // Tray
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(319, 54);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tray";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }
    }
}
using PasswordManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace ClickerPassword
{
    public partial class LoginForm : Form
    {
        MainForm mainView;
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            mainView = new MainForm(this);
            textBoxUser.Text = "me";
            textBoxPassword.Text = "zaq1@WSX";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (LoginManager.Login(textBoxUser.Text, textBoxPassword.Text))
            {
                mainView.setUserAndPassword(textBoxUser.Text, textBoxPassword.Text);
                mainView.Show();
                this.Hide();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WritePasword.ToggleCapsLock();
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            WritePasword.WarningIfCapslockIsActive();
        }



    }
}

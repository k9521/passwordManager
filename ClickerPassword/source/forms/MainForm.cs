using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClickerPassword;


namespace PasswordManager
{
    public partial class MainForm : Form
    {

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);


        String user, password;
        Data[] currentData;
        bool pushBothAlts = false;
        LoginForm loginForm;
        private DateTime fillPasswordTime;

        public MainForm(LoginForm loginForm)
        {
            this.loginForm = loginForm;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public void setUserAndPassword(String user, String password)
        {
            this.user = user;
            this.password = password;
            this.Text += " | user: " + user;
            ReftreshPasswordList();
        }
        private void buttonOnePassword_Click(object sender, EventArgs e)
        {
            if (passwordListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Choose name of password to use.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String selectedOption = passwordListView.SelectedItems[0].ToString();
            currentData = new Data[1];
            currentData[0] = FileEncryption.GetEntry(password, user, selectedOption);
            if (currentData[0].username.Length != 0 && currentData[0].password.Length != 0)
            {
                timerOnePassword.Tag = "0";
            } else
            {
                timerOnePassword.Tag = null;
            }
            pushBothAlts = false;
            timerOnePassword.Enabled = true;
            changeEnabledOnePasswordAction(false);
            this.WindowState = FormWindowState.Minimized;
        }

        private void changeEnabledOnePasswordAction(bool enable)
        {
            addPassword.Enabled = enable;
            buttonUpdatePassword.Enabled = enable;
            removePassword.Enabled = enable;
            buttonOnePassword.Enabled = enable;
            buttonAllPassword.Enabled = enable;
            passwordListView.Enabled = enable;
        }

        private void changeEnabledAllPasswordAction(bool enable)
        {
            addPassword.Enabled = enable;
            buttonUpdatePassword.Enabled = enable;
            removePassword.Enabled = enable;
            buttonOnePassword.Enabled = enable;
            passwordListView.Enabled = enable;
        }

        private void timerOnePassword_Tick(object sender, EventArgs e)
        {
            if (timerOnePassword.Tag == "100")
            {
                timerOnePassword.Enabled = false;
                changeEnabledOnePasswordAction(true);
            }
            bool isLeftAltPressed = (GetAsyncKeyState(Keys.LControlKey) & 0x8000) != 0;
            bool isRightAltPressed = (GetAsyncKeyState(Keys.RControlKey) & 0x8000) != 0;
            if (isLeftAltPressed && isRightAltPressed)
            {
                if( (currentData[0].isStrictWidnow && 
                     Window.getActiveWindowTitle() == currentData[0].widnowTitle) 
                     || !currentData[0].isStrictWidnow)
                {
                    pushBothAlts = true;
                }
            }
            if (timerOnePassword.Tag == "2" && (DateTime.Now - fillPasswordTime).TotalSeconds > 10) {
                timerOnePassword.Tag = "100";
            }
            if (pushBothAlts && !isLeftAltPressed && !isRightAltPressed)
            {
                pushBothAlts = false;
                writeData(currentData[0], timerOnePassword);
            }
        }
        private void writeData(Data currentData, Timer timer)
        {
            if (currentData.username.Length != 0 && currentData.password.Length != 0)
            {
                if (timer.Tag == "0")
                {
                    WritePasword.write(currentData.username, currentData.keyboardLayout);
                    timer.Tag = "1";
                }
                else if (timer.Tag == "1")
                {
                    WritePasword.write(currentData.password, currentData.keyboardLayout);
                    if(currentData.auth2FASecret == null)
                    {
                        timer.Tag = null;
                        currentData = null;
                        timer.Tag = "100";
                    } else
                    {
                        timer.Tag = "2";
                        fillPasswordTime = DateTime.Now;
                    }
                }
                else if (timer.Tag == "2")
                {
                    WritePasword.write(Auth2FA.GeneratePin(currentData.auth2FASecret), currentData.keyboardLayout);
                    
                    timer.Tag = null;
                    currentData = null;
                    timer.Tag = "100";
                }
            }
            else
            {
                String textToWrite = currentData.username.Length != 0 ? currentData.username : currentData.password;
                WritePasword.write(textToWrite, currentData.keyboardLayout);
                currentData = null;
                timer.Tag = "100";
            }

        }

        private void addPassword_Click(object sender, EventArgs e)
        {
            AddPassword addpass = new AddPassword(this, password, user);
            addpass.ShowDialog();
        }

        private void removePassword_Click(object sender, EventArgs e)
        {
            if(passwordListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("You need select password to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(" Are you sure you want to delete the password? This action cannot be undone, and the data will be permanently lost.",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                String selectedOption = passwordListView.SelectedItems[0].ToString();
                FileEncryption.RemoveEntry(password, user, selectedOption);
                ReftreshPasswordList();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonUpdatePassword_Click(object sender, EventArgs e)
        {
            if (passwordListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("You need select password to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String selectedOption = passwordListView.SelectedItems[0].ToString();
            AddPassword addpass = new AddPassword(this, password, user, selectedOption);
            addpass.ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            currentData = null;
            pushBothAlts = false;
            timerAllPassword.Enabled = false;
            timerOnePassword.Enabled = false;
            loginForm.Show();
        }

        private void buttonAllPassword_Click(object sender, EventArgs e)
        {
            buttonAllPassword.Text = (timerAllPassword.Enabled ? "On" : "OFF") + " | Write All Password";
            timerAllPassword.Enabled = !timerAllPassword.Enabled;
            
            if (timerAllPassword.Enabled)
            {
                List<Data> listOfData = new List<Data>();
                foreach (string item in passwordListView.Items)
                {
                    listOfData.Add(FileEncryption.GetEntry(password, user, item));
                }
                currentData = listOfData.ToArray();
                pushBothAlts = false;
                this.WindowState = FormWindowState.Minimized;
                timerAllPassword.Tag = null;
                changeEnabledAllPasswordAction(false);
            } else
            {
                currentData = null;
                changeEnabledAllPasswordAction(true);
            }
        }

        private void timerAllPassword_Tick(object sender, EventArgs e)
        {
            bool isLeftAltPressed = (GetAsyncKeyState(Keys.RControlKey) & 0x8000) != 0;
            bool isRightAltPressed = (GetAsyncKeyState(Keys.LControlKey) & 0x8000) != 0;
            if (timerAllPassword.Tag == "2" && (DateTime.Now - fillPasswordTime).TotalSeconds > 10)
            {
                timerAllPassword.Tag = "100";
            }
            if (isLeftAltPressed && isRightAltPressed)
            {
                    pushBothAlts = true;
            }
            if (pushBothAlts && !isLeftAltPressed && !isRightAltPressed)
            {
                pushBothAlts = false;
                Data matchData = findMatchData();
                if (matchData != null && (matchData.username != null || matchData.password != null))
                {
                    if (timerAllPassword.Tag == "100")
                    {
                        timerAllPassword.Tag = null;
                    }
                    if (matchData.username.Length != 0 && matchData.password.Length != 0 &&  timerAllPassword.Tag == null)
                    {
                        timerAllPassword.Tag = "0";
                    }
                    writeData(matchData, timerAllPassword);
                }
                
            }
        }

        private Data findMatchData()
        {
            string currentAcctiveWindow = Window.getActiveWindowTitle();
            return currentData.FirstOrDefault(p => p.isStrictWidnow && p.widnowTitle == currentAcctiveWindow);
        }

        internal void ReftreshPasswordList()
        {
            List<String> allPasswordKeys = FileEncryption.getAllKeys(password, user);
            passwordListView.Items.Clear();
            foreach (String ownName in allPasswordKeys)
            {
                passwordListView.Items.Add(ownName);
            }
        }
    }
}

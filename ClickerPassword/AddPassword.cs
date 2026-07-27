using ClickerPassword;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class AddPassword : Form
    {

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);


        const string lowercaseChars = "qwertyuiopasdfghjklzxcvbnm";
        const string uppercaseChars = "QWERTYUIOPASDFGHJKLZXCVBNM";
        const string Numbers = "1234567890";
        const string specialChars = "!@#$%^&*()-=_+[]{}\\|;':\",./<>?";

        MainForm Parent;
        String user, password;
        String key;

        public AddPassword(MainForm parent, String password, String user, String key = null)
        {
            this.Parent = parent;
            this.password = password;
            this.user = user;
            this.key = key;
//            this.labelFile2FAAuthPath.Text = "";
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            if(key == null)
            {
                setupAccesibility();
                labelFile2FAAuthPath.Text = null;
            } else
            {
                setupAccesibilityToUpdatePassword(key);
            }

        }

        private void setupAccesibilityToUpdatePassword(String key)
        {
            checkBoxGeneratePassword.Checked = false;
            buttonPasswordGenerate.Enabled = false;
            checkBox_az.Enabled = false;
            checkBox_Capitalaz.Enabled = false;
            checkBoxNumbers.Enabled = false;
            checkBoxSpecialCharactes.Enabled = false;
            lenghtPassword.Enabled = false;
            textBoxPassword.Enabled = true;
            textBoxConfirmPassword.Enabled = true;
            checkBoxWindowTitle.Enabled = false;
            button2FA.Enabled = false;
            label2FAPath.Text = "";
            labelFile2FAAuthPath.Text = "";

            Data data = FileEncryption.GetEntry(password, user, key);
            textBoxUser.Text = data.username;
            textBoxUser.Enabled = false;
            textBoxWindowTitle.Text = data.widnowTitle;
            textBoxWindowTitle.Enabled = false;
            textBoxOwnName.Text = data.ownName;
            textBoxOwnName.Enabled = false;

            checkBoxWindowTitle.Checked = data.isStrictWidnow;
            labelWindowTtitleClarification.Enabled = false;
            buttonGetWindowTitle.Enabled = false; ;
            labelWindowTitle.Enabled = false; ;
            textBoxWindowTitle.Enabled = false;

            buttonSavePassword.Text = "Update";
        }

        private void setupAccesibility()
        {
            checkBoxGeneratePassword.Checked = false;
            buttonPasswordGenerate.Enabled = checkBoxGeneratePassword.Checked;
            checkBox_az.Enabled = checkBoxGeneratePassword.Checked;
            checkBox_Capitalaz.Enabled = checkBoxGeneratePassword.Checked;
            checkBoxNumbers.Enabled = checkBoxGeneratePassword.Checked;
            checkBoxSpecialCharactes.Enabled = checkBoxGeneratePassword.Checked;
            lenghtPassword.Enabled = checkBoxGeneratePassword.Checked;
            textBoxPassword.Enabled = !checkBoxGeneratePassword.Checked;
            textBoxConfirmPassword.Enabled = !checkBoxGeneratePassword.Checked;
            checkBoxWindowTitle.Checked = false;
            labelWindowTtitleClarification.Enabled = checkBoxWindowTitle.Checked;
            buttonGetWindowTitle.Enabled = checkBoxWindowTitle.Checked;
            labelWindowTitle.Enabled = checkBoxWindowTitle.Checked;
            textBoxWindowTitle.Enabled = checkBoxWindowTitle.Checked;
            button2FA.Enabled = true;
        }

        private void checkBoxGeneratePassword_CheckedChanged(object sender, EventArgs e)
        {
            buttonPasswordGenerate.Enabled = checkBoxGeneratePassword.Checked;
            checkBox_az.Enabled = checkBoxGeneratePassword.Checked;
            checkBox_Capitalaz.Enabled = checkBoxGeneratePassword.Checked;
            checkBoxNumbers.Enabled = checkBoxGeneratePassword.Checked;
            checkBoxSpecialCharactes.Enabled = checkBoxGeneratePassword.Checked;
            lenghtPassword.Enabled = checkBoxGeneratePassword.Checked;
            textBoxPassword.Enabled = !checkBoxGeneratePassword.Checked;
            textBoxConfirmPassword.Enabled = !checkBoxGeneratePassword.Checked;
        }

        private void buttonPasswordGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder characterPool = new StringBuilder();
            if (checkBox_az.Checked) characterPool.Append(lowercaseChars);
            if (checkBox_Capitalaz.Checked) characterPool.Append(uppercaseChars);
            if (checkBoxNumbers.Checked) characterPool.Append(Numbers);
            if (checkBoxSpecialCharactes.Checked) characterPool.Append(specialChars);

            if (characterPool.Length == 0)
            {
                MessageBox.Show("You need to select type of chars to use in password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            Random random = new Random();
            StringBuilder password = new StringBuilder();
            
            for (int i = 0; i < (int)lenghtPassword.Value; i++)
            {
                int index = random.Next(characterPool.Length);
                password.Append(characterPool[index]);
            }
            textBoxPassword.Text = password.ToString();
            textBoxConfirmPassword.Text = password.ToString();
        }

        private void checkBoxWindowTitle_CheckedChanged(object sender, EventArgs e)
        {
            labelWindowTtitleClarification.Enabled = checkBoxWindowTitle.Checked;
            buttonGetWindowTitle.Enabled = checkBoxWindowTitle.Checked;
            labelWindowTitle.Enabled = checkBoxWindowTitle.Checked;
            textBoxWindowTitle.Enabled = checkBoxWindowTitle.Checked;
        }

        private void buttonGetWindowTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To add a window title, you need to press the button and go to the desired window. Then, press both the left and right CTRL keys."
                , "Get Window Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer.Enabled = true;
            this.Hide();
            Parent.Hide();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            bool isLeftAltPressed = (GetAsyncKeyState(Keys.LControlKey) & 0x8000) != 0;
            bool isRightAltPressed = (GetAsyncKeyState(Keys.RControlKey) & 0x8000) != 0;

            if (isLeftAltPressed && isRightAltPressed)
            {
                timer.Enabled = false;
                textBoxWindowTitle.Text = Window.getActiveWindowTitle();
                Parent.Show();
                this.Show();
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            WritePasword.WarningIfCapslockIsActive();
        }

        private void button2FA_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            labelFile2FAAuthPath.Text = openFileDialog.FileName;
        }

        private void buttonSavePassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length == 0 && textBoxUser.Text.Length == 0)
            {
                MessageBox.Show("You need to provide at least a username or a password..",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Your passwords do not match. Please correct them!",
                    "Warning", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                return;
            }
            if (checkBoxWindowTitle.Checked && textBoxWindowTitle.Text.Length == 0)
            {
                MessageBox.Show("You need to provide a name of window.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (textBoxOwnName.Text.Length == 0)
            {
                MessageBox.Show("You need to provide a name for this data.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (key == null && FileEncryption.ContainsKey(password, user, textBoxOwnName.Text))
            {
                MessageBox.Show("You need to provide a unique name for this data",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } else if(key != null)
            {
                Data existedData = FileEncryption.GetEntry(password, user, key);
                if(existedData.password == textBoxPassword.Text)
                {
                    MessageBox.Show("The new password you entered is the same as your current password.\nPlease choose a different one.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            Data data = new Data(textBoxOwnName.Text, textBoxUser.Text, textBoxPassword.Text, textBoxWindowTitle.Text, checkBoxWindowTitle.Checked);
            if(labelFile2FAAuthPath.Text != "")
            {
                string qrURL = Auth2FA.ReadQrCode(labelFile2FAAuthPath.Text);
                data.Update2FASecret(Auth2FA.ParseSecretFromUrl(qrURL));
            }
            if (key != null)
            {
                FileEncryption.UpdatePasswordEntry(password, user, key, data);
            } else
            {
                FileEncryption.AddEntry(password, user, data);
            }
            Parent.ReftreshPasswordList();
            this.Close();
        }
    }
}

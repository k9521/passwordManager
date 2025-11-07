namespace PasswordManager
{
    partial class AddPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPassword));
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonPasswordGenerate = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_az = new System.Windows.Forms.CheckBox();
            this.checkBox_Capitalaz = new System.Windows.Forms.CheckBox();
            this.checkBoxNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxSpecialCharactes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lenghtPassword = new System.Windows.Forms.NumericUpDown();
            this.checkBoxGeneratePassword = new System.Windows.Forms.CheckBox();
            this.labelWindowTtitleClarification = new System.Windows.Forms.Label();
            this.checkBoxWindowTitle = new System.Windows.Forms.CheckBox();
            this.buttonGetWindowTitle = new System.Windows.Forms.Button();
            this.textBoxWindowTitle = new System.Windows.Forms.TextBox();
            this.labelWindowTitle = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonSavePassword = new System.Windows.Forms.Button();
            this.textBoxOwnName = new System.Windows.Forms.TextBox();
            this.labelOwnName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lenghtPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(124, 62);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(29, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(124, 25);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 6;
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(29, 28);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(32, 13);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "User:";
            // 
            // buttonPasswordGenerate
            // 
            this.buttonPasswordGenerate.Location = new System.Drawing.Point(364, 62);
            this.buttonPasswordGenerate.Name = "buttonPasswordGenerate";
            this.buttonPasswordGenerate.Size = new System.Drawing.Size(104, 25);
            this.buttonPasswordGenerate.TabIndex = 9;
            this.buttonPasswordGenerate.Text = "Generate new password";
            this.buttonPasswordGenerate.UseVisualStyleBackColor = true;
            this.buttonPasswordGenerate.Click += new System.EventHandler(this.buttonPasswordGenerate_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(124, 99);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxConfirmPassword.TabIndex = 11;
            this.textBoxConfirmPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Confirm Password:";
            // 
            // checkBox_az
            // 
            this.checkBox_az.AutoSize = true;
            this.checkBox_az.Location = new System.Drawing.Point(242, 101);
            this.checkBox_az.Name = "checkBox_az";
            this.checkBox_az.Size = new System.Drawing.Size(40, 17);
            this.checkBox_az.TabIndex = 12;
            this.checkBox_az.Text = "a-z";
            this.checkBox_az.UseVisualStyleBackColor = true;
            // 
            // checkBox_Capitalaz
            // 
            this.checkBox_Capitalaz.AutoSize = true;
            this.checkBox_Capitalaz.Location = new System.Drawing.Point(288, 102);
            this.checkBox_Capitalaz.Name = "checkBox_Capitalaz";
            this.checkBox_Capitalaz.Size = new System.Drawing.Size(43, 17);
            this.checkBox_Capitalaz.TabIndex = 13;
            this.checkBox_Capitalaz.Text = "A-Z";
            this.checkBox_Capitalaz.UseVisualStyleBackColor = true;
            // 
            // checkBoxNumbers
            // 
            this.checkBoxNumbers.AutoSize = true;
            this.checkBoxNumbers.Location = new System.Drawing.Point(337, 102);
            this.checkBoxNumbers.Name = "checkBoxNumbers";
            this.checkBoxNumbers.Size = new System.Drawing.Size(41, 17);
            this.checkBoxNumbers.TabIndex = 14;
            this.checkBoxNumbers.Text = "0-9";
            this.checkBoxNumbers.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpecialCharactes
            // 
            this.checkBoxSpecialCharactes.AutoSize = true;
            this.checkBoxSpecialCharactes.Location = new System.Drawing.Point(384, 102);
            this.checkBoxSpecialCharactes.Name = "checkBoxSpecialCharactes";
            this.checkBoxSpecialCharactes.Size = new System.Drawing.Size(156, 17);
            this.checkBoxSpecialCharactes.TabIndex = 15;
            this.checkBoxSpecialCharactes.Text = "!@#$%^&*()_+={}:\"<>?,./;\'[\\]";
            this.checkBoxSpecialCharactes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Lenght Password:";
            // 
            // lenghtPassword
            // 
            this.lenghtPassword.Location = new System.Drawing.Point(337, 139);
            this.lenghtPassword.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.lenghtPassword.Name = "lenghtPassword";
            this.lenghtPassword.Size = new System.Drawing.Size(120, 20);
            this.lenghtPassword.TabIndex = 18;
            this.lenghtPassword.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBoxGeneratePassword
            // 
            this.checkBoxGeneratePassword.AutoSize = true;
            this.checkBoxGeneratePassword.Location = new System.Drawing.Point(242, 65);
            this.checkBoxGeneratePassword.Name = "checkBoxGeneratePassword";
            this.checkBoxGeneratePassword.Size = new System.Drawing.Size(116, 17);
            this.checkBoxGeneratePassword.TabIndex = 19;
            this.checkBoxGeneratePassword.Text = "GeneratePassword";
            this.checkBoxGeneratePassword.UseVisualStyleBackColor = true;
            this.checkBoxGeneratePassword.CheckedChanged += new System.EventHandler(this.checkBoxGeneratePassword_CheckedChanged);
            // 
            // labelWindowTtitleClarification
            // 
            this.labelWindowTtitleClarification.AutoSize = true;
            this.labelWindowTtitleClarification.Location = new System.Drawing.Point(29, 185);
            this.labelWindowTtitleClarification.Name = "labelWindowTtitleClarification";
            this.labelWindowTtitleClarification.Size = new System.Drawing.Size(625, 13);
            this.labelWindowTtitleClarification.TabIndex = 20;
            this.labelWindowTtitleClarification.Text = "!! To add a window title, you need to press the button and go to the desired wind" +
    "ow. Then, press both the left and right ALT keys. !!";
            // 
            // checkBoxWindowTitle
            // 
            this.checkBoxWindowTitle.AutoSize = true;
            this.checkBoxWindowTitle.Location = new System.Drawing.Point(32, 165);
            this.checkBoxWindowTitle.Name = "checkBoxWindowTitle";
            this.checkBoxWindowTitle.Size = new System.Drawing.Size(203, 17);
            this.checkBoxWindowTitle.TabIndex = 21;
            this.checkBoxWindowTitle.Text = "Use window title to recognize window";
            this.checkBoxWindowTitle.UseVisualStyleBackColor = true;
            this.checkBoxWindowTitle.CheckedChanged += new System.EventHandler(this.checkBoxWindowTitle_CheckedChanged);
            // 
            // buttonGetWindowTitle
            // 
            this.buttonGetWindowTitle.Location = new System.Drawing.Point(32, 201);
            this.buttonGetWindowTitle.Name = "buttonGetWindowTitle";
            this.buttonGetWindowTitle.Size = new System.Drawing.Size(101, 23);
            this.buttonGetWindowTitle.TabIndex = 22;
            this.buttonGetWindowTitle.Text = "Get Window Title";
            this.buttonGetWindowTitle.UseVisualStyleBackColor = true;
            this.buttonGetWindowTitle.Click += new System.EventHandler(this.buttonGetWindowTitle_Click);
            // 
            // textBoxWindowTitle
            // 
            this.textBoxWindowTitle.Location = new System.Drawing.Point(124, 230);
            this.textBoxWindowTitle.Name = "textBoxWindowTitle";
            this.textBoxWindowTitle.Size = new System.Drawing.Size(512, 20);
            this.textBoxWindowTitle.TabIndex = 24;
            // 
            // labelWindowTitle
            // 
            this.labelWindowTitle.AutoSize = true;
            this.labelWindowTitle.Location = new System.Drawing.Point(38, 237);
            this.labelWindowTitle.Name = "labelWindowTitle";
            this.labelWindowTitle.Size = new System.Drawing.Size(69, 13);
            this.labelWindowTitle.TabIndex = 23;
            this.labelWindowTitle.Text = "WindowTitle:";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonSavePassword
            // 
            this.buttonSavePassword.Location = new System.Drawing.Point(32, 289);
            this.buttonSavePassword.Name = "buttonSavePassword";
            this.buttonSavePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonSavePassword.TabIndex = 25;
            this.buttonSavePassword.Text = "Save Password";
            this.buttonSavePassword.UseVisualStyleBackColor = true;
            this.buttonSavePassword.Click += new System.EventHandler(this.buttonSavePassword_Click);
            // 
            // textBoxOwnName
            // 
            this.textBoxOwnName.Location = new System.Drawing.Point(124, 256);
            this.textBoxOwnName.Name = "textBoxOwnName";
            this.textBoxOwnName.Size = new System.Drawing.Size(100, 20);
            this.textBoxOwnName.TabIndex = 27;
            // 
            // labelOwnName
            // 
            this.labelOwnName.AutoSize = true;
            this.labelOwnName.Location = new System.Drawing.Point(29, 259);
            this.labelOwnName.Name = "labelOwnName";
            this.labelOwnName.Size = new System.Drawing.Size(98, 13);
            this.labelOwnName.TabIndex = 26;
            this.labelOwnName.Text = "Name of password:";
            // 
            // AddPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 326);
            this.Controls.Add(this.textBoxOwnName);
            this.Controls.Add(this.labelOwnName);
            this.Controls.Add(this.buttonSavePassword);
            this.Controls.Add(this.textBoxWindowTitle);
            this.Controls.Add(this.labelWindowTitle);
            this.Controls.Add(this.buttonGetWindowTitle);
            this.Controls.Add(this.checkBoxWindowTitle);
            this.Controls.Add(this.labelWindowTtitleClarification);
            this.Controls.Add(this.checkBoxGeneratePassword);
            this.Controls.Add(this.lenghtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxSpecialCharactes);
            this.Controls.Add(this.checkBoxNumbers);
            this.Controls.Add(this.checkBox_Capitalaz);
            this.Controls.Add(this.checkBox_az);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPasswordGenerate);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPassword";
            this.Text = "Add Password";
            ((System.ComponentModel.ISupportInitialize)(this.lenghtPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonPasswordGenerate;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_az;
        private System.Windows.Forms.CheckBox checkBox_Capitalaz;
        private System.Windows.Forms.CheckBox checkBoxNumbers;
        private System.Windows.Forms.CheckBox checkBoxSpecialCharactes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown lenghtPassword;
        private System.Windows.Forms.CheckBox checkBoxGeneratePassword;
        private System.Windows.Forms.Label labelWindowTtitleClarification;
        private System.Windows.Forms.CheckBox checkBoxWindowTitle;
        private System.Windows.Forms.Button buttonGetWindowTitle;
        private System.Windows.Forms.TextBox textBoxWindowTitle;
        private System.Windows.Forms.Label labelWindowTitle;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonSavePassword;
        private System.Windows.Forms.TextBox textBoxOwnName;
        private System.Windows.Forms.Label labelOwnName;
    }
}
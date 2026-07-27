namespace PasswordManager
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonOnePassword = new System.Windows.Forms.Button();
            this.timerOnePassword = new System.Windows.Forms.Timer(this.components);
            this.addPassword = new System.Windows.Forms.Button();
            this.passwordListView = new System.Windows.Forms.ListBox();
            this.removePassword = new System.Windows.Forms.Button();
            this.buttonUpdatePassword = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonAllPassword = new System.Windows.Forms.Button();
            this.timerAllPassword = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonOnePassword
            // 
            this.buttonOnePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOnePassword.Location = new System.Drawing.Point(12, 321);
            this.buttonOnePassword.Name = "buttonOnePassword";
            this.buttonOnePassword.Size = new System.Drawing.Size(406, 98);
            this.buttonOnePassword.TabIndex = 0;
            this.buttonOnePassword.Text = "Write Password";
            this.buttonOnePassword.UseVisualStyleBackColor = true;
            this.buttonOnePassword.Click += new System.EventHandler(this.buttonOnePassword_Click);
            // 
            // timerOnePassword
            // 
            this.timerOnePassword.Tick += new System.EventHandler(this.timerOnePassword_Tick);
            // 
            // addPassword
            // 
            this.addPassword.Location = new System.Drawing.Point(12, 12);
            this.addPassword.Name = "addPassword";
            this.addPassword.Size = new System.Drawing.Size(138, 53);
            this.addPassword.TabIndex = 1;
            this.addPassword.Text = "Add Password";
            this.addPassword.UseVisualStyleBackColor = true;
            this.addPassword.Click += new System.EventHandler(this.addPassword_Click);
            // 
            // passwordListView
            // 
            this.passwordListView.FormattingEnabled = true;
            this.passwordListView.Items.AddRange(new object[] {
            "Test1",
            "test2",
            "test3",
            "test4"});
            this.passwordListView.Location = new System.Drawing.Point(172, 12);
            this.passwordListView.Name = "passwordListView";
            this.passwordListView.Size = new System.Drawing.Size(246, 303);
            this.passwordListView.TabIndex = 2;
            // 
            // removePassword
            // 
            this.removePassword.Location = new System.Drawing.Point(12, 189);
            this.removePassword.Name = "removePassword";
            this.removePassword.Size = new System.Drawing.Size(138, 53);
            this.removePassword.TabIndex = 3;
            this.removePassword.Text = "Remove Password";
            this.removePassword.UseVisualStyleBackColor = true;
            this.removePassword.Click += new System.EventHandler(this.removePassword_Click);
            // 
            // buttonUpdatePassword
            // 
            this.buttonUpdatePassword.Location = new System.Drawing.Point(12, 71);
            this.buttonUpdatePassword.Name = "buttonUpdatePassword";
            this.buttonUpdatePassword.Size = new System.Drawing.Size(138, 53);
            this.buttonUpdatePassword.TabIndex = 4;
            this.buttonUpdatePassword.Text = "Update Password";
            this.buttonUpdatePassword.UseVisualStyleBackColor = true;
            this.buttonUpdatePassword.Click += new System.EventHandler(this.buttonUpdatePassword_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(12, 248);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(138, 53);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonAllPassword
            // 
            this.buttonAllPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllPassword.Location = new System.Drawing.Point(12, 431);
            this.buttonAllPassword.Name = "buttonAllPassword";
            this.buttonAllPassword.Size = new System.Drawing.Size(406, 98);
            this.buttonAllPassword.TabIndex = 6;
            this.buttonAllPassword.Text = "On | Write All Password";
            this.buttonAllPassword.UseVisualStyleBackColor = true;
            this.buttonAllPassword.Click += new System.EventHandler(this.buttonAllPassword_Click);
            // 
            // timerAllPassword
            // 
            this.timerAllPassword.Interval = 1000;
            this.timerAllPassword.Tick += new System.EventHandler(this.timerAllPassword_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 541);
            this.Controls.Add(this.buttonAllPassword);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonUpdatePassword);
            this.Controls.Add(this.removePassword);
            this.Controls.Add(this.passwordListView);
            this.Controls.Add(this.addPassword);
            this.Controls.Add(this.buttonOnePassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Password Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOnePassword;
        private System.Windows.Forms.Timer timerOnePassword;
        private System.Windows.Forms.Button addPassword;
        private System.Windows.Forms.ListBox passwordListView;
        private System.Windows.Forms.Button removePassword;
        private System.Windows.Forms.Button buttonUpdatePassword;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonAllPassword;
        private System.Windows.Forms.Timer timerAllPassword;
    }
}


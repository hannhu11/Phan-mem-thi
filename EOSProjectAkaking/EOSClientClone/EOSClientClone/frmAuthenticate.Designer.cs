namespace FakeEOS
{
    partial class frmAuthenticate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuthenticate));
            tableLayoutPanelCaution = new TableLayoutPanel();
            lblCaution = new Label();
            tableLayoutPanelStudentInput = new TableLayoutPanel();
            lblDomain = new Label();
            txtPassword = new TextBox();
            lblExamCode = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtExamCode = new TextBox();
            txtUsername = new TextBox();
            txtDomain = new TextBox();
            tableLayoutPanelContainAction = new TableLayoutPanel();
            tableLayoutPanelAction = new TableLayoutPanel();
            btnLogin = new Button();
            btnExit = new Button();
            linklblCheckSound = new LinkLabel();
            linklblCheckFont = new LinkLabel();
            lblVersion = new Label();
            tableLayoutPanelMessage = new TableLayoutPanel();
            lblMessage = new Label();
            tableLayoutPanelCaution.SuspendLayout();
            tableLayoutPanelStudentInput.SuspendLayout();
            tableLayoutPanelContainAction.SuspendLayout();
            tableLayoutPanelAction.SuspendLayout();
            tableLayoutPanelMessage.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelCaution
            // 
            tableLayoutPanelCaution.ColumnCount = 1;
            tableLayoutPanelCaution.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCaution.Controls.Add(lblCaution, 0, 0);
            tableLayoutPanelCaution.Dock = DockStyle.Top;
            tableLayoutPanelCaution.Location = new Point(0, 0);
            tableLayoutPanelCaution.Name = "tableLayoutPanelCaution";
            tableLayoutPanelCaution.RowCount = 1;
            tableLayoutPanelCaution.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelCaution.Size = new Size(409, 35);
            tableLayoutPanelCaution.TabIndex = 0;
            // 
            // lblCaution
            // 
            lblCaution.Anchor = AnchorStyles.None;
            lblCaution.AutoSize = true;
            lblCaution.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaution.ForeColor = Color.Crimson;
            lblCaution.Location = new Point(20, 9);
            lblCaution.Name = "lblCaution";
            lblCaution.Size = new Size(368, 17);
            lblCaution.TabIndex = 0;
            lblCaution.Text = "You cannot take the exam if EOS runs under a virtual machine.";
            lblCaution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelStudentInput
            // 
            tableLayoutPanelStudentInput.ColumnCount = 2;
            tableLayoutPanelStudentInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStudentInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanelStudentInput.Controls.Add(lblDomain, 0, 3);
            tableLayoutPanelStudentInput.Controls.Add(txtPassword, 1, 2);
            tableLayoutPanelStudentInput.Controls.Add(lblExamCode, 0, 0);
            tableLayoutPanelStudentInput.Controls.Add(lblUsername, 0, 1);
            tableLayoutPanelStudentInput.Controls.Add(lblPassword, 0, 2);
            tableLayoutPanelStudentInput.Controls.Add(txtExamCode, 1, 0);
            tableLayoutPanelStudentInput.Controls.Add(txtUsername, 1, 1);
            tableLayoutPanelStudentInput.Controls.Add(txtDomain, 1, 3);
            tableLayoutPanelStudentInput.Dock = DockStyle.Top;
            tableLayoutPanelStudentInput.Location = new Point(0, 35);
            tableLayoutPanelStudentInput.Name = "tableLayoutPanelStudentInput";
            tableLayoutPanelStudentInput.RowCount = 4;
            tableLayoutPanelStudentInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelStudentInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelStudentInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelStudentInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelStudentInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelStudentInput.Size = new Size(409, 149);
            tableLayoutPanelStudentInput.TabIndex = 1;
            // 
            // lblDomain
            // 
            lblDomain.Anchor = AnchorStyles.Right;
            lblDomain.AutoSize = true;
            lblDomain.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblDomain.Location = new Point(43, 121);
            lblDomain.Name = "lblDomain";
            lblDomain.Size = new Size(56, 17);
            lblDomain.TabIndex = 8;
            lblDomain.Text = "Domain:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left;
            txtPassword.Location = new Point(105, 81);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(263, 23);
            txtPassword.TabIndex = 3;
            // 
            // lblExamCode
            // 
            lblExamCode.Anchor = AnchorStyles.Right;
            lblExamCode.AutoSize = true;
            lblExamCode.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblExamCode.Location = new Point(22, 10);
            lblExamCode.Name = "lblExamCode";
            lblExamCode.Size = new Size(77, 17);
            lblExamCode.TabIndex = 3;
            lblExamCode.Text = "Exam Code:";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Right;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.Location = new Point(22, 47);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(77, 17);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "User Name:";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(32, 84);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 17);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";
            // 
            // txtExamCode
            // 
            txtExamCode.Anchor = AnchorStyles.Left;
            txtExamCode.Location = new Point(105, 7);
            txtExamCode.Name = "txtExamCode";
            txtExamCode.Size = new Size(263, 23);
            txtExamCode.TabIndex = 1;
            txtExamCode.KeyPress += txtExamCode_KeyPress;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left;
            txtUsername.Location = new Point(105, 44);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(263, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtDomain
            // 
            txtDomain.Anchor = AnchorStyles.Left;
            txtDomain.Enabled = false;
            txtDomain.Location = new Point(105, 118);
            txtDomain.Name = "txtDomain";
            txtDomain.ReadOnly = true;
            txtDomain.Size = new Size(263, 23);
            txtDomain.TabIndex = 7;
            txtDomain.Text = "Dự-án-HE151463.vn";
            // 
            // tableLayoutPanelContainAction
            // 
            tableLayoutPanelContainAction.ColumnCount = 1;
            tableLayoutPanelContainAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelContainAction.Controls.Add(tableLayoutPanelAction, 0, 0);
            tableLayoutPanelContainAction.Dock = DockStyle.Top;
            tableLayoutPanelContainAction.Location = new Point(0, 184);
            tableLayoutPanelContainAction.Name = "tableLayoutPanelContainAction";
            tableLayoutPanelContainAction.RowCount = 1;
            tableLayoutPanelContainAction.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelContainAction.Size = new Size(409, 61);
            tableLayoutPanelContainAction.TabIndex = 2;
            // 
            // tableLayoutPanelAction
            // 
            tableLayoutPanelAction.ColumnCount = 4;
            tableLayoutPanelAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.4285717F));
            tableLayoutPanelAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.7469F));
            tableLayoutPanelAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.3250618F));
            tableLayoutPanelAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.4285717F));
            tableLayoutPanelAction.Controls.Add(btnLogin, 1, 0);
            tableLayoutPanelAction.Controls.Add(btnExit, 2, 0);
            tableLayoutPanelAction.Controls.Add(linklblCheckSound, 1, 1);
            tableLayoutPanelAction.Controls.Add(linklblCheckFont, 2, 1);
            tableLayoutPanelAction.Controls.Add(lblVersion, 0, 0);
            tableLayoutPanelAction.Dock = DockStyle.Fill;
            tableLayoutPanelAction.Location = new Point(3, 3);
            tableLayoutPanelAction.Name = "tableLayoutPanelAction";
            tableLayoutPanelAction.RowCount = 2;
            tableLayoutPanelAction.RowStyles.Add(new RowStyle(SizeType.Percent, 66.037735F));
            tableLayoutPanelAction.RowStyles.Add(new RowStyle(SizeType.Percent, 33.962265F));
            tableLayoutPanelAction.Size = new Size(403, 55);
            tableLayoutPanelAction.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Left;
            btnLogin.Location = new Point(89, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(87, 27);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Right;
            btnExit.Location = new Point(226, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(87, 27);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // linklblCheckSound
            // 
            linklblCheckSound.ActiveLinkColor = Color.Goldenrod;
            linklblCheckSound.Anchor = AnchorStyles.Left;
            linklblCheckSound.AutoSize = true;
            linklblCheckSound.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            linklblCheckSound.LinkColor = SystemColors.HotTrack;
            linklblCheckSound.Location = new Point(89, 39);
            linklblCheckSound.Name = "linklblCheckSound";
            linklblCheckSound.Size = new Size(119, 13);
            linklblCheckSound.TabIndex = 2;
            linklblCheckSound.TabStop = true;
            linklblCheckSound.Text = "Check sound (10 secs)";
            linklblCheckSound.VisitedLinkColor = Color.DarkGoldenrod;
            linklblCheckSound.LinkClicked += linklblCheckSound_LinkClicked;
            // 
            // linklblCheckFont
            // 
            linklblCheckFont.ActiveLinkColor = Color.Goldenrod;
            linklblCheckFont.Anchor = AnchorStyles.Right;
            linklblCheckFont.AutoSize = true;
            linklblCheckFont.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            linklblCheckFont.LinkColor = SystemColors.HotTrack;
            linklblCheckFont.Location = new Point(250, 39);
            linklblCheckFont.Name = "linklblCheckFont";
            linklblCheckFont.Size = new Size(63, 13);
            linklblCheckFont.TabIndex = 3;
            linklblCheckFont.TabStop = true;
            linklblCheckFont.Text = "Check font";
            linklblCheckFont.VisitedLinkColor = Color.DarkGoldenrod;
            linklblCheckFont.LinkClicked += linklblCheckFont_LinkClicked;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.None;
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersion.ForeColor = SystemColors.HotTrack;
            lblVersion.Location = new Point(9, 10);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(68, 15);
            lblVersion.TabIndex = 4;
            lblVersion.Text = "null.version";
            // 
            // tableLayoutPanelMessage
            // 
            tableLayoutPanelMessage.ColumnCount = 1;
            tableLayoutPanelMessage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMessage.Controls.Add(lblMessage, 0, 0);
            tableLayoutPanelMessage.Dock = DockStyle.Fill;
            tableLayoutPanelMessage.Location = new Point(0, 245);
            tableLayoutPanelMessage.Name = "tableLayoutPanelMessage";
            tableLayoutPanelMessage.RowCount = 1;
            tableLayoutPanelMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMessage.Size = new Size(409, 29);
            tableLayoutPanelMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.None;
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = SystemColors.HotTrack;
            lblMessage.Location = new Point(48, 4);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(312, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Register the exam may take time, please wait!";
            lblMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmAuthenticate
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            ClientSize = new Size(409, 274);
            Controls.Add(tableLayoutPanelMessage);
            Controls.Add(tableLayoutPanelContainAction);
            Controls.Add(tableLayoutPanelStudentInput);
            Controls.Add(tableLayoutPanelCaution);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAuthenticate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EOS Login Form";
            Load += frmAuthenticate_Load;
            tableLayoutPanelCaution.ResumeLayout(false);
            tableLayoutPanelCaution.PerformLayout();
            tableLayoutPanelStudentInput.ResumeLayout(false);
            tableLayoutPanelStudentInput.PerformLayout();
            tableLayoutPanelContainAction.ResumeLayout(false);
            tableLayoutPanelAction.ResumeLayout(false);
            tableLayoutPanelAction.PerformLayout();
            tableLayoutPanelMessage.ResumeLayout(false);
            tableLayoutPanelMessage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelCaution;
        private Label lblCaution;
        private TableLayoutPanel tableLayoutPanelStudentInput;
        private Label lblDomain;
        private TextBox txtDomain;
        private TextBox txtExamCode;
        private TextBox txtPassword;
        private Label lblExamCode;
        private Label lblUsername;
        private Label lblPassword;
        private TableLayoutPanel tableLayoutPanelContainAction;
        private TableLayoutPanel tableLayoutPanelAction;
        private Button btnLogin;
        private Button btnExit;
        private LinkLabel linklblCheckSound;
        private LinkLabel linklblCheckFont;
        private Label lblVersion;
        private TableLayoutPanel tableLayoutPanelMessage;
        private Label lblMessage;
        private TextBox txtUsername;
    }
}
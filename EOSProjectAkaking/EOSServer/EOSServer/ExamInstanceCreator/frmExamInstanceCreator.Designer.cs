namespace ExamInstanceCreator
{
    partial class frmExamInstanceCreator
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnSaveLocation = new Button();
            btnChooseFile = new Button();
            btnCreateInstance = new Button();
            panel1 = new Panel();
            chkIsBlankPaper = new CheckBox();
            rtbJson = new RichTextBox();
            txtDebug = new TextBox();
            txtDesLocation = new TextBox();
            txtXLSXLocation = new TextBox();
            lblDestinationLocation = new Label();
            lblXLSXLocation = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.53589F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4641151F));
            tableLayoutPanel1.Size = new Size(695, 418);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(btnSaveLocation, 0, 0);
            tableLayoutPanel2.Controls.Add(btnChooseFile, 0, 0);
            tableLayoutPanel2.Controls.Add(btnCreateInstance, 1, 0);
            tableLayoutPanel2.Location = new Point(52, 359);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(590, 44);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSaveLocation
            // 
            btnSaveLocation.Anchor = AnchorStyles.None;
            btnSaveLocation.Location = new Point(232, 6);
            btnSaveLocation.Name = "btnSaveLocation";
            btnSaveLocation.Size = new Size(124, 31);
            btnSaveLocation.TabIndex = 2;
            btnSaveLocation.Text = "SAVE LOCATION";
            btnSaveLocation.UseVisualStyleBackColor = true;
            btnSaveLocation.Click += btnSaveLocation_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Anchor = AnchorStyles.None;
            btnChooseFile.Location = new Point(36, 6);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(124, 31);
            btnChooseFile.TabIndex = 1;
            btnChooseFile.Text = "CHOOSE FILE";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnCreateInstance
            // 
            btnCreateInstance.Anchor = AnchorStyles.None;
            btnCreateInstance.Location = new Point(429, 6);
            btnCreateInstance.Name = "btnCreateInstance";
            btnCreateInstance.Size = new Size(124, 31);
            btnCreateInstance.TabIndex = 0;
            btnCreateInstance.Text = "CREATE INSTANCE";
            btnCreateInstance.UseVisualStyleBackColor = true;
            btnCreateInstance.Click += btnCreateInstance_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(chkIsBlankPaper);
            panel1.Controls.Add(rtbJson);
            panel1.Controls.Add(txtDebug);
            panel1.Controls.Add(txtDesLocation);
            panel1.Controls.Add(txtXLSXLocation);
            panel1.Controls.Add(lblDestinationLocation);
            panel1.Controls.Add(lblXLSXLocation);
            panel1.Location = new Point(49, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 320);
            panel1.TabIndex = 2;
            // 
            // chkIsBlankPaper
            // 
            chkIsBlankPaper.AutoSize = true;
            chkIsBlankPaper.Location = new Point(39, 79);
            chkIsBlankPaper.Name = "chkIsBlankPaper";
            chkIsBlankPaper.Size = new Size(93, 19);
            chkIsBlankPaper.TabIndex = 6;
            chkIsBlankPaper.Text = "isBlankPaper";
            chkIsBlankPaper.UseVisualStyleBackColor = true;
            chkIsBlankPaper.CheckedChanged += chkIsBlankPaper_CheckedChanged;
            // 
            // rtbJson
            // 
            rtbJson.Location = new Point(21, 116);
            rtbJson.Name = "rtbJson";
            rtbJson.Size = new Size(552, 185);
            rtbJson.TabIndex = 5;
            rtbJson.Text = "";
            // 
            // txtDebug
            // 
            txtDebug.Location = new Point(183, 75);
            txtDebug.Name = "txtDebug";
            txtDebug.ReadOnly = true;
            txtDebug.Size = new Size(373, 23);
            txtDebug.TabIndex = 4;
            // 
            // txtDesLocation
            // 
            txtDesLocation.Location = new Point(183, 46);
            txtDesLocation.Name = "txtDesLocation";
            txtDesLocation.ReadOnly = true;
            txtDesLocation.Size = new Size(373, 23);
            txtDesLocation.TabIndex = 3;
            // 
            // txtXLSXLocation
            // 
            txtXLSXLocation.Location = new Point(183, 17);
            txtXLSXLocation.Name = "txtXLSXLocation";
            txtXLSXLocation.ReadOnly = true;
            txtXLSXLocation.Size = new Size(373, 23);
            txtXLSXLocation.TabIndex = 2;
            // 
            // lblDestinationLocation
            // 
            lblDestinationLocation.AutoSize = true;
            lblDestinationLocation.Location = new Point(39, 49);
            lblDestinationLocation.Name = "lblDestinationLocation";
            lblDestinationLocation.Size = new Size(116, 15);
            lblDestinationLocation.TabIndex = 1;
            lblDestinationLocation.Text = "Destination location:";
            // 
            // lblXLSXLocation
            // 
            lblXLSXLocation.AutoSize = true;
            lblXLSXLocation.Location = new Point(39, 20);
            lblXLSXLocation.Name = "lblXLSXLocation";
            lblXLSXLocation.Size = new Size(82, 15);
            lblXLSXLocation.TabIndex = 0;
            lblXLSXLocation.Text = "XLSX location:";
            // 
            // frmExamInstanceCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 418);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmExamInstanceCreator";
            Text = "frmExamInstanceCreator";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnSaveLocation;
        private Button btnChooseFile;
        private Button btnCreateInstance;
        private Panel panel1;
        private Label lblDestinationLocation;
        private Label lblXLSXLocation;
        private TextBox txtDesLocation;
        private TextBox txtXLSXLocation;
        private TextBox txtDebug;
        private RichTextBox rtbJson;
        private CheckBox chkIsBlankPaper;
    }
}
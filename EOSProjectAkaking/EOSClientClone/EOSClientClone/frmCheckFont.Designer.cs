namespace EOSClientClone
{
    partial class frmCheckFont
    {
        //this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
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
            tableLayoutPanelContainAll = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnClose = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblInVietnamese = new Label();
            lblInChinese = new Label();
            lblInJapanese = new Label();
            txtFontGuide = new TextBox();
            tableLayoutPanelContainAll.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelContainAll
            // 
            tableLayoutPanelContainAll.ColumnCount = 1;
            tableLayoutPanelContainAll.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelContainAll.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanelContainAll.Dock = DockStyle.Fill;
            tableLayoutPanelContainAll.Location = new Point(0, 0);
            tableLayoutPanelContainAll.Name = "tableLayoutPanelContainAll";
            tableLayoutPanelContainAll.Padding = new Padding(10);
            tableLayoutPanelContainAll.RowCount = 1;
            tableLayoutPanelContainAll.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelContainAll.Size = new Size(704, 526);
            tableLayoutPanelContainAll.TabIndex = 0;
            tableLayoutPanelContainAll.Paint += tableLayoutPanelContainAll_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(txtFontGuide, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(13, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            tableLayoutPanel1.Size = new Size(678, 500);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnClose, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 427);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(0, 20, 0, 0);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(672, 70);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(594, 23);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(lblInVietnamese, 0, 2);
            tableLayoutPanel3.Controls.Add(lblInChinese, 0, 1);
            tableLayoutPanel3.Controls.Add(lblInJapanese, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Size = new Size(330, 44);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // lblInVietnamese
            // 
            lblInVietnamese.AutoSize = true;
            lblInVietnamese.Font = new Font("MS Mincho", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblInVietnamese.Location = new Point(3, 28);
            lblInVietnamese.Name = "lblInVietnamese";
            lblInVietnamese.Size = new Size(173, 13);
            lblInVietnamese.TabIndex = 2;
            lblInVietnamese.Text = "Việt Nam (in Vietnamese)";
            // 
            // lblInChinese
            // 
            lblInChinese.AutoSize = true;
            lblInChinese.Font = new Font("MS Mincho", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblInChinese.Location = new Point(3, 14);
            lblInChinese.Name = "lblInChinese";
            lblInChinese.Size = new Size(126, 13);
            lblInChinese.TabIndex = 1;
            lblInChinese.Text = "越南 (in Chinese)";
            // 
            // lblInJapanese
            // 
            lblInJapanese.AutoSize = true;
            lblInJapanese.Font = new Font("MS Mincho", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblInJapanese.Location = new Point(3, 0);
            lblInJapanese.Name = "lblInJapanese";
            lblInJapanese.Size = new Size(161, 13);
            lblInJapanese.TabIndex = 0;
            lblInJapanese.Text = "ベトナム (in Japanese)";
            // 
            // txtFontGuide
            // 
            txtFontGuide.BackColor = SystemColors.ControlLightLight;
            txtFontGuide.Dock = DockStyle.Fill;
            txtFontGuide.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtFontGuide.Location = new Point(3, 3);
            txtFontGuide.Multiline = true;
            txtFontGuide.Name = "txtFontGuide";
            txtFontGuide.ReadOnly = true;
            txtFontGuide.ScrollBars = ScrollBars.Vertical;
            txtFontGuide.Size = new Size(672, 418);
            txtFontGuide.TabIndex = 1;
            txtFontGuide.Enter += txtFontGuide_Enter;
            // 
            // frmCheckFont
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(704, 526);
            Controls.Add(tableLayoutPanelContainAll);
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(600, 500);
            Name = "frmCheckFont";
            Text = "frmCheckFont";
            Load += frmCheckFont_Load;
            tableLayoutPanelContainAll.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelContainAll;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnClose;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lblInVietnamese;
        private Label lblInChinese;
        private Label lblInJapanese;
        private TextBox txtFontGuide;
    }
}
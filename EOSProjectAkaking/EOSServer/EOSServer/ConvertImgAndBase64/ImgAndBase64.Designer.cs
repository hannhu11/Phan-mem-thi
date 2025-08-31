namespace ConvertImgAndBase64
{
    partial class ImgAndBase64
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
            btnBrowser = new Button();
            btnToImg = new Button();
            btnConvertToBase64 = new Button();
            picBoxSrc = new PictureBox();
            picBoxDes = new PictureBox();
            rtbBase64 = new RichTextBox();
            txtLengthBase = new TextBox();
            txtWidth = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picBoxSrc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxDes).BeginInit();
            SuspendLayout();
            // 
            // btnBrowser
            // 
            btnBrowser.Location = new Point(12, 12);
            btnBrowser.Name = "btnBrowser";
            btnBrowser.Size = new Size(75, 23);
            btnBrowser.TabIndex = 0;
            btnBrowser.Text = "Browser";
            btnBrowser.UseVisualStyleBackColor = true;
            btnBrowser.Click += btnBrowser_Click;
            // 
            // btnToImg
            // 
            btnToImg.Location = new Point(12, 241);
            btnToImg.Name = "btnToImg";
            btnToImg.Size = new Size(75, 23);
            btnToImg.TabIndex = 1;
            btnToImg.Text = ">Img";
            btnToImg.UseVisualStyleBackColor = true;
            btnToImg.Click += btnToImg_Click;
            // 
            // btnConvertToBase64
            // 
            btnConvertToBase64.Location = new Point(255, 41);
            btnConvertToBase64.Name = "btnConvertToBase64";
            btnConvertToBase64.Size = new Size(75, 23);
            btnConvertToBase64.TabIndex = 2;
            btnConvertToBase64.Text = ">Base64";
            btnConvertToBase64.UseVisualStyleBackColor = true;
            btnConvertToBase64.Click += btnConvertToBase64_Click;
            // 
            // picBoxSrc
            // 
            picBoxSrc.Location = new Point(12, 41);
            picBoxSrc.Name = "picBoxSrc";
            picBoxSrc.Size = new Size(237, 181);
            picBoxSrc.TabIndex = 3;
            picBoxSrc.TabStop = false;
            // 
            // picBoxDes
            // 
            picBoxDes.Location = new Point(12, 270);
            picBoxDes.Name = "picBoxDes";
            picBoxDes.Size = new Size(237, 181);
            picBoxDes.TabIndex = 4;
            picBoxDes.TabStop = false;
            // 
            // rtbBase64
            // 
            rtbBase64.Location = new Point(336, 41);
            rtbBase64.Name = "rtbBase64";
            rtbBase64.Size = new Size(452, 410);
            rtbBase64.TabIndex = 5;
            rtbBase64.Text = "";
            // 
            // txtLengthBase
            // 
            txtLengthBase.Location = new Point(455, 12);
            txtLengthBase.Name = "txtLengthBase";
            txtLengthBase.Size = new Size(333, 23);
            txtLengthBase.TabIndex = 6;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(336, 13);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(113, 23);
            txtWidth.TabIndex = 7;
            // 
            // ImgAndBase64
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 463);
            Controls.Add(txtWidth);
            Controls.Add(txtLengthBase);
            Controls.Add(rtbBase64);
            Controls.Add(picBoxDes);
            Controls.Add(picBoxSrc);
            Controls.Add(btnConvertToBase64);
            Controls.Add(btnToImg);
            Controls.Add(btnBrowser);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ImgAndBase64";
            Text = "ImgAndBase64";
            ((System.ComponentModel.ISupportInitialize)picBoxSrc).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxDes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBrowser;
        private Button btnToImg;
        private Button btnConvertToBase64;
        private PictureBox picBoxSrc;
        private PictureBox picBoxDes;
        private RichTextBox rtbBase64;
        private TextBox txtLengthBase;
        private TextBox txtWidth;
    }
}
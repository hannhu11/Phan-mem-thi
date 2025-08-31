namespace frmEOSServer
{
    partial class tryAnother
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
            rtbMessenger = new RichTextBox();
            SuspendLayout();
            // 
            // rtbMessenger
            // 
            rtbMessenger.Location = new Point(12, 12);
            rtbMessenger.Name = "rtbMessenger";
            rtbMessenger.Size = new Size(605, 330);
            rtbMessenger.TabIndex = 0;
            rtbMessenger.Text = "";
            // 
            // tryAnother
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbMessenger);
            Name = "tryAnother";
            Text = "tryAnother";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbMessenger;
    }
}
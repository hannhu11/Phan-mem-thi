namespace EOSClientSimple
{
    partial class EOSClientSimple
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
            btnChange = new Button();
            poolBtn = new FlowLayoutPanel();
            btnX = new Button();
            txtNumOfBtn = new TextBox();
            poolBtn.SuspendLayout();
            SuspendLayout();
            // 
            // btnChange
            // 
            btnChange.Location = new Point(545, 262);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 23);
            btnChange.TabIndex = 0;
            btnChange.Text = "CHANGE";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // poolBtn
            // 
            poolBtn.Controls.Add(btnX);
            poolBtn.Location = new Point(12, 12);
            poolBtn.Name = "poolBtn";
            poolBtn.Size = new Size(410, 36);
            poolBtn.TabIndex = 1;
            // 
            // btnX
            // 
            btnX.Location = new Point(3, 3);
            btnX.Name = "btnX";
            btnX.Size = new Size(26, 23);
            btnX.TabIndex = 0;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = true;
            // 
            // txtNumOfBtn
            // 
            txtNumOfBtn.Location = new Point(520, 233);
            txtNumOfBtn.Name = "txtNumOfBtn";
            txtNumOfBtn.Size = new Size(100, 23);
            txtNumOfBtn.TabIndex = 2;
            // 
            // EOSClientSimple
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 297);
            Controls.Add(txtNumOfBtn);
            Controls.Add(poolBtn);
            Controls.Add(btnChange);
            Name = "EOSClientSimple";
            Text = "EOSClientSimple";
            poolBtn.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChange;
        private FlowLayoutPanel poolBtn;
        private Button btnX;
        private TextBox txtNumOfBtn;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace EOSClientSimple
{
    public partial class EOSClientSimple : Form
    {
        public EOSClientSimple()
        {
            InitializeComponent();

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("103.179.172.211", 55178);
            socket.Close();
            socket.Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            poolBtn.Controls.Clear();
            Button btnX = new Button();
            btnX.Name = "btnX";
            btnX.Size = new Size(26, 23);
            btnX.TabIndex = 0;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = true;

            int numOfButton = int.Parse(txtNumOfBtn.Text);

            for (int i = 1; i <= numOfButton; i++)
            {
                Button btnCreate = new Button();
                btnCreate.Name = i.ToString();
                btnCreate.Size = new Size(26, 23);
                //btnCreate.TabIndex = i;
                btnCreate.Text = i.ToString();
                btnCreate.UseVisualStyleBackColor = true;

               
                poolBtn.Controls.Add(btnCreate);
            }
        }
    }
}

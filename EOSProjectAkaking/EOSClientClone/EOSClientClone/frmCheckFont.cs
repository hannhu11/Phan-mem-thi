using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOSClientClone
{
    public partial class frmCheckFont : Form
    {
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);
        public frmCheckFont()
        {
            this.Icon = EOSClientClone.ResourceEOSClientClone.FptEOSClient;
            InitializeComponent();
        }

        private void tableLayoutPanelContainAll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCheckFont_Load(object sender, EventArgs e)
        {
            

            bool flagKaiTiFont = false;
            bool flagMsMinchoFont = false;
            bool flagHGSeikaiFont = false;
            bool flagNtMotoyaFont = false;
            foreach (FontFamily family in new InstalledFontCollection().Families)
            {
                string upper = family.GetName(0).Trim().ToUpper().Replace(" ", "");
                if (upper.StartsWith("KaiTi".ToUpper().Replace(" ", "")))
                    flagKaiTiFont = true;
                if (upper.StartsWith("Ms Mincho".ToUpper().Replace(" ", "")))
                    flagMsMinchoFont = true;
                if (upper.StartsWith("HGSeikai".ToUpper().Replace(" ", "")))
                    flagHGSeikaiFont = true;
                if (upper.StartsWith("NtMotoya".ToUpper().Replace(" ", "")))
                    flagNtMotoyaFont = true;
            }
            string str1 = "CHECK FONT RESULT:\r\n\r\n";
            string str2 = "KaiTi";
            string str3 = !flagKaiTiFont ? str1 + "Chinese font ('" + str2 + "') : NOT FOUND.\r\n\r\n" : str1 + "Chinese font ('" + str2 + "') : OK.\r\n\r\n";
            string str4 = "MS Mincho";
            string str5 = !flagMsMinchoFont ? str3 + "Japanese font 1 ('" + str4 + "') :  NOT FOUND.\r\n\r\n" : str3 + "Japanese font 1 ('" + str4 + "') : OK.\r\n\r\n";
            string str6 = "HGSeikaishotaiPRO";
            string str7 = !flagHGSeikaiFont ? str5 + "Japanese font 2 ('" + str6 + "') :  NOT FOUND.\r\n\r\n" : str5 + "Japanese font 2 ('" + str6 + "') : OK.\r\n\r\n";
            string str8 = "NtMotoya Kyotai";
            string str9 = !flagNtMotoyaFont ? str7 + "Japanese font 3 ('" + str8 + "') :  NOT FOUND.\r\n\r\n" : str7 + "Japanese font 3 ('" + str8 + "') : OK.\r\n\r\n";
            if (!flagMsMinchoFont || !flagKaiTiFont || !flagHGSeikaiFont || !flagNtMotoyaFont)
                str9 += "\r\n\r\nINSTALLING FONTS ON Windows:\r\n\r\nThere are several ways to install fonts on Windows.\r\nKeep in mind that you must be an Administrator on the target machine to install fonts.\r\n\r\n - Download the font.\r\n - Double-click on a font file to open the font preview and select 'Install'.\r\n\r\nOR\r\n\r\n - Right-click on a font file, and then select 'Install'.";
            this.txtFontGuide.Text = str9;
        }

        private void txtFontGuide_Enter(object sender, EventArgs e)
        {
            HideCaret(txtFontGuide.Handle);
        }
    }
}

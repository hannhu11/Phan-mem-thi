using EOSClientClone;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Media;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinForm_ADO;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Net.Sockets;


namespace FakeEOS
{


    public partial class frmAuthenticate : Form
    {


        DataProvider dp = new DataProvider();
        private frmCheckFont frmCheckFontInstance = (frmCheckFont)null;
        private frmGuiTesting frmGuiTestingInstance = (frmGuiTesting)null;
        public frmAuthenticate()
        {
            this.Icon = EOSClientClone.ResourceEOSClientClone.FptEOSClient;
            InitializeComponent();
            if (!dp.connectStatus)
            {
                MessageBox.Show("Bạn đang không có kết nối mạng hoặc mạng bạn đang dùng bị hạn chế. Hãy kết nối mạng hoặc mạng khác và khởi chạy phần mềm thi.", "Lỗi kết nối!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void txtExamCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = "[ -~]"; // Biểu thức chính quy để chỉ chấp nhận chữ cái từ a đến z (không phân biệt hoa thường)
            if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), pattern))
            {
                e.Handled = true; // Từ chối ký tự chữ cái
                //e.KeyChar = '\0'; // Xóa ký tự chữ cái
            }

            bool isJapaneseCharacter = IsJapaneseCharacter(e.KeyChar);

            if (isJapaneseCharacter)
            {
                e.Handled = true; // Từ chối ký tự tiếng Nhật
            }
        }

        private bool IsJapaneseCharacter(char character)
        {
            // Sử dụng biểu thức chính quy để kiểm tra xem ký tự có phải là tiếng Nhật không
            string pattern = @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]";
            return Regex.IsMatch(character.ToString(), pattern);
        }

        private void btnExit_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void frmAuthenticate_Load(object sender, EventArgs e)
        {
            //Kiem tra xem co khoi dong bang quyen Admin chua.
            if (!this.IsAdministrator()) //!this.IsAdministrator()
            {
                int numErrorCode = (int)MessageBox.Show("You must login Windows as System Administrator or Run [EOS Client] as Administrator", "Run as Administrator!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            string serverInfoFileName = "EOS_Server_Info.dat";

            txtExamCode.Text = "PRN211_TRIAL";
            txtUsername.Text = "HE151463";
            txtPassword.Text = "123456";


        }

        private ExamInstance IsValidAccess(string txtUserId, string txtPassword, string txtExamCode)
        {

            ExamInstance examInstance = new ExamInstance();

            //String strSQL = "SELECT * FROM [User] WHERE id = @userId AND password = @password AND roleId = '2'"; --old
            String strSQL = "SELECT \r\nu.username,\r\nu.roleId,\r\ne.examCode,\r\ne.startTime,\r\ne.endTime\r\nFROM \r\n[User] u\r\nJOIN\r\n[Group_User] gu\r\nON\r\nu.id = gu.userId\r\nJOIN\r\n[ExamCode_Group] eg\r\nON\r\neg.groupId = gu.groupId\r\nJOIN\r\n[ExamCode] e\r\nON\r\ne.examCode = eg.examCode\r\nWHERE id = @userId AND password = @password AND e.examCode = @examCode AND roleId = '2' AND e.endTime >= GETDATE() AND e.startTime <= GETDATE();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userId", txtUserId.ToLower()),
                new SqlParameter("@password", txtPassword),
                new SqlParameter("@examCode", txtExamCode.ToUpper())
            };
            using (IDataReader idr = dp.executeQuery2(strSQL, parameters))
            {
                if (idr.Read())
                {
                    User user = new User(txtUserId, null, null, null, idr.GetInt32(idr.GetOrdinal("roleId")));
                    ExamCode examCode = new ExamCode(txtExamCode, DateTime.Now, DateTime.Now, true, idr.GetDateTime(idr.GetOrdinal("startTime")), idr.GetDateTime(idr.GetOrdinal("endTime")));
                    //user = idr.GetString(2); //0 --> 1 --> 2
                    examInstance.user = user;
                    examInstance.examCode = examCode;
                    examInstance.operationSystem = Environment.OSVersion.ToString();
                    return examInstance;
                }

                return null;
            }
        }

        private bool IsAdministrator()
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(currentUser);
            if (windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void PlayFromUrl(string url)
        {
            using (var player = new SoundPlayer(url))
            {
                player.Play();
            }
        }

        private void linklblCheckSound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (!File.Exists("checkSound.wav"))
            //{
            //    int num = (int)MessageBox.Show("Audio file ghosts.mp3 cannot be found!", "Check sound");
            //}
            //else
            //    this.PlayFromUrl("checkSound.wav");
            using (var player = new SoundPlayer(EOSClientClone.ResourceEOSClientClone.checkSound))
            {
                player.Play();
            }
        }

        private void linklblCheckFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmCheckFontInstance == null || this.frmCheckFontInstance.IsDisposed)
                this.frmCheckFontInstance = new frmCheckFont();
            this.frmCheckFontInstance.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtExamCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please provide an Exam code", "Login");
            }
            else if (this.txtUsername.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please provide an username", "Login");
            }
            else if (this.txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please provide a password", "Login");
            }
            else if (this.txtDomain.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please provide a domain address", "Login");
            }
            else
            {
                ExamInstance examInstance = IsValidAccess(txtUsername.Text, txtPassword.Text, txtExamCode.Text);
                if (examInstance == null)
                {
                    MessageBox.Show("Sai thông tin đăng nhập", "Login");
                }
                else
                {

                    if (this.frmGuiTestingInstance == null || this.frmGuiTestingInstance.IsDisposed)
                    {
                        this.frmGuiTestingInstance = new frmGuiTesting(examInstance);
                        this.Hide();
                        this.frmGuiTestingInstance.Show();

                    }

                }

            }
        }
    }
}
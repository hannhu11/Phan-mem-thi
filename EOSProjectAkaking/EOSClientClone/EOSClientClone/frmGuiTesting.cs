using CipherHelper;
using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace EOSClientClone
{
    public partial class frmGuiTesting : Form
    {
        Dictionary<string, Question> paperExam;
        Dictionary<string, Question> processExam = new Dictionary<string, Question>();
        Button LastButton;
        private String finishMessage;
        private List<String> listFont;
        private DateTime endTime;
        private ExamInstance examInstance;
        private Socket socket;
        private Dictionary<int, Button> dictQuesButton = new Dictionary<int, Button>();
        private string responseFromServer = "";

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        private string decodeKey = "AKAKING55178xxxx";

        private int processWork = 0; //chưa làm câu nào
        private int allWork = 1;
        private int totalMark = 0;


        public frmGuiTesting(ExamInstance examInstance)
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.Icon = EOSClientClone.ResourceEOSClientClone.FptEOSClient;
            this.examInstance = examInstance;
            Font currentFont = incQuestion.Font;
            listFont = new List<String>() {
            "Microsoft Sans Serif",
            "Arial",
            "Segoe UI",
            "MS Mincho"
            };
            cboFont.DataSource = listFont;
            incSize.Value = (decimal)currentFont.Size;
            socket.Connect("103.179.172.211", 55178);
        }

        private void loadExamInfo(ExamInstance examInstance)
        {
            incMachine.Text = examInstance.operationSystem;
            incStudent.Text = examInstance.user.id.ToUpper();
            incExamCode.Text = examInstance.examCode.examCode;
            DateTime startTime = examInstance.examCode.startTime;
            endTime = examInstance.examCode.endTime;
            TimeSpan durationTime = endTime.Subtract(startTime);
            DateTime nowTime = DateTime.Now;
            TimeSpan leftTime = endTime.Subtract(nowTime);
            //MessageBox.Show(leftTime.ToString() + " = " + endTime.ToString() + " - " + nowTime.ToString());
            incDuration.Text = durationString(durationTime);

            timerCountdown.Start();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkFinishExam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinishExam.Checked)
            {
                btnFinish.Enabled = true;
            }
            else
            {
                btnFinish.Enabled = false;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            float finishRate = ((float)processWork / allWork);
            if (finishRate != 1)
            {
                finishMessage = $"Bạn chưa hoàn thành hết câu hỏi! (Còn {allWork - processWork} câu chưa làm) Bạn có muốn nộp bài thi?";
            }
            else
            {
                finishMessage = "Bạn đã hoàn thành 100% tiến độ bài thi! Bạn có muốn nộp bài thi?";
            }


            DialogResult drFinish = MessageBox.Show(finishMessage, "Finish confirmation", MessageBoxButtons.YesNo);

            switch (drFinish)
            {
                case (DialogResult.Yes):
                    {
                        finishExam();
                        break;
                    }
                case (DialogResult.No):
                    {
                        break;
                    }
            }
        }

        private void disconnectToServer(Socket socket)
        {
            socket.Close();
            socket.Dispose();
        }

        private void incQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void incQuestion_SelectionChanged(object sender, EventArgs e)
        {
            incQuestion.SelectionLength = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cboFont_SelectedValueChanged(object sender, EventArgs e)
        {
            Font currentFont = incQuestion.Font;
            incQuestion.Font = new Font(cboFont.SelectedItem.ToString(), currentFont.Size, currentFont.Style);
        }

        private void frmGuiTesting_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra nếu Alt và phím F4 được nhấn cùng nhau
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt && e.CloseReason == CloseReason.UserClosing)
            {
                // Từ chối đóng ứng dụng
                e.Cancel = true;
            }
            else
            {
                disconnectToServer(socket);
            }
        }

        private void incSize_ValueChanged(object sender, EventArgs e)
        {
            Font currentFont = incQuestion.Font;
            incQuestion.Font = new Font(currentFont.FontFamily, (float)incSize.Value, currentFont.Style);
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            TimeSpan leftTime = endTime.Subtract(DateTime.Now);
            lblCountDownTime.Text = countdownString();

            if (countdownString().Equals("00:00:00"))
            {
                finishExam();
            }
        }

        private void finishExam()
        {
            //nộp bài thi
            string jsonFinishExamPaperString = JsonConvert.SerializeObject(paperExam);
            byte[] ecryptedExamPaperByte = Encoding.UTF8.GetBytes(jsonFinishExamPaperString);

            string examCode = examInstance.examCode.examCode.ToUpper();
            string studentId = examInstance.user.id.ToUpper();
            bool success = CipherData.SaveEncryptDataToFile($"{examCode}_{studentId}.DAT", ecryptedExamPaperByte, "AKAKING55178xxxx");

            frmGuiTesting.ActiveForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmGuiTesting.ActiveForm.WindowState = FormWindowState.Normal;

            incQuestionChoosing.Controls.Clear();
            tabCtrl.Controls.Clear();
            btnFinish.Enabled = false;
            chkFinishExam.Enabled = false;
            btnExit.Enabled = true;
            ControlBox = false;

            timerCountdown.Stop();
            lblCountDownTime.ForeColor = Color.Crimson;

            lblNotify.Text = "Hết giờ làm bài!";
            lblGrade.Text = "Điểm của bạn là: 8.6";
        }

        private String countdownString()
        {
            TimeSpan leftTime = endTime.Subtract(DateTime.Now);
            if (leftTime.TotalMilliseconds < 0)
            {
                return "00:00:00";
            }
            return leftTime.Hours.ToString().PadLeft(2, '0') + ":" + leftTime.Minutes.ToString().PadLeft(2, '0') + ":" + leftTime.Seconds.ToString().PadLeft(2, '0');

        }

        private String durationString(TimeSpan durationTime)
        {
            String durationTimeString = "";
            int hour = (int)durationTime.Hours;
            int minute = (int)durationTime.Minutes;
            int second = (int)durationTime.Seconds;

            if (hour > 0)
            {
                durationTimeString = durationTimeString + hour + "h";
            }
            if (minute > 0)
            {
                durationTimeString = durationTimeString + " " + minute + "m";
            }
            if (second > 0)
            {
                durationTimeString = durationTimeString + " " + minute + "s";
            }
            return durationTimeString.Trim().Replace(" ", "_");
        }

        private static TData DeserializeFromString<TData>(string settings)
        {
            byte[] b = Convert.FromBase64String(settings);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (TData)formatter.Deserialize(stream);
            }
        }
        private void frmGuiTesting_Load(object sender, EventArgs e)
        {
            //Làm đen màn hình khi làm bài
            SetWindowDisplayAffinity(this.Handle, 1);
            //socket.Connect("127.0.0.1", 55178);



            //load thông tin exam instance và chuẩn bị sẵn giấy in
            loadExamInfo(examInstance);
            string paperString = "";
            paperExam = new Dictionary<string, Question>();

            //Gửi yêu cầu lấy đề thi
            while (!responseFromServer.Equals("#ALLLOAD"))
                try
                {
                    string requestExam = "#DOEXAM_" + examInstance.examCode.examCode.ToUpper();
                    byte[] data = Encoding.UTF8.GetBytes(requestExam);
                    byte[] sizeInBytes = BitConverter.GetBytes(data.Length);
                    int dataSize = BitConverter.ToInt32(sizeInBytes, 0);
                    Debug.Print("CHECK_SIZE: " + dataSize);
                    Debug.Print("DATA LENGTH: " + data.Length.ToString());
                    socket.Send(sizeInBytes);
                    socket.Send(data);


                    byte[] sizeBuffer = new byte[4]; //The length of an Int32 is 4 bytes;
                    socket.Receive(sizeBuffer);
                    int dataxSize = BitConverter.ToInt32(sizeBuffer, 0); //Converts the byte array back to an Int32
                    byte[] receiveBuffer = new byte[dataxSize]; //Create a new buffer based on the real size                
                    socket.Receive(receiveBuffer);
                    responseFromServer = Encoding.UTF8.GetString(receiveBuffer);
                    if (responseFromServer.Length > 0)
                    {

                        //thực hiện lấy đề
                        if (responseFromServer.Equals("#DOEXAM"))
                        {
                            socket.Receive(sizeBuffer);
                            dataxSize = BitConverter.ToInt32(sizeBuffer, 0); //Converts the byte array back to an Int32
                            byte[] examPaper = new byte[dataxSize]; //Create a new buffer based on the real size                
                            socket.Receive(examPaper);
                            string jsonString = Encoding.UTF8.GetString(examPaper);
                            Debug.Print(jsonString);
                            paperExam = JsonConvert.DeserializeObject<Dictionary<string, Question>>(jsonString);
                            AfterGotExamPaper();
                            responseFromServer = "#ALLLOAD";
                        }

                        Debug.Print("Thông điệp từ server: " + responseFromServer);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print("Lỗi khi nhận thông điệp từ server: " + ex.Message);
                }





            //// localhost
            //byte[] examByte = CipherData.GetDecryptDataFromFile($"C:\\Users\\buidu\\OneDrive\\Desktop\\examBank\\{examInstance.examCode.examCode.ToUpper()}.dat", decodeKey);
            //string jsonString = Encoding.UTF8.GetString(examByte);
            //paperExam = JsonConvert.DeserializeObject<Dictionary<string, Question>>(jsonString);
            //hoàn thành bước tiếp nhận đề
        }

        private void AfterGotExamPaper()
        {
            //xáo trộn đề:
            paperExam = Shuffle(paperExam);


            //paperExam = XLSXtoExamPaperInstance();
            Dictionary<string, Question>.ValueCollection questions = paperExam.Values;

            incQuestionChoosing.Controls.Clear();

            int numOfButton = paperExam.Count;
            allWork = paperExam.Count;
            //for (int i = 1; i <= numOfButton; i++)
            //{

            //}

            //khoi tao nut
            int numOfInput = 1;
            foreach (Question question in questions)
            {

                totalMark += question.mark;
                //khoi tao student paper
                //question.questionOption


                //khoi tao nut
                Button btnCreate = new Button();

                btnCreate.Tag = question;

                btnCreate.Name = question.id;
                btnCreate.Size = new Size(35, 23);
                //btnCreate.TabIndex = i;
                btnCreate.Text = numOfInput.ToString();

                btnCreate.BackColor = Color.LightCyan;
                btnCreate.FlatStyle = FlatStyle.Popup;
                btnCreate.ForeColor = SystemColors.ControlText;
                btnCreate.Margin = new Padding(2);
                button1.UseVisualStyleBackColor = false;
                btnCreate.Click += BtnCreate_Click;
                //MessageBox.Show(btnCreate.Name);

                incQuestionChoosing.Controls.Add(btnCreate);
                dictQuesButton.Add(numOfInput, btnCreate);
                LastButton = btnCreate;
                numOfInput++;
            }


            incQuestionIndex.Text = "1";

            Button firstbutton = new Button();
            if (dictQuesButton.TryGetValue(1, out firstbutton))
            {
                BtnCreate_Click(firstbutton, null);
                firstbutton.Focus();

            }

            //Thread.Sleep(1000);
            //finishExam();
            incTotalMarks.Text = totalMark.ToString();
        }

        private Dictionary<string, Question>? Shuffle(Dictionary<string, Question>? paperExam)
        {
            List<KeyValuePair<string, Question>> shuffleQuesList = paperExam.ToList();

            foreach (KeyValuePair<string, Question> quesKVP in shuffleQuesList)
            {
                quesKVP.Value.questionOption = ShuffleOpt(quesKVP.Value.questionOption);

            }

            Random rng = new Random();
            int n = shuffleQuesList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                KeyValuePair<string, Question> value = shuffleQuesList[k];
                shuffleQuesList[k] = shuffleQuesList[n];
                shuffleQuesList[n] = value;
            }



            return shuffleQuesList.ToDictionary(item => item.Key, item => item.Value);
        }

        private Dictionary<string, QuestionOption> ShuffleOpt(Dictionary<string, QuestionOption> questionOption)
        {
            List<KeyValuePair<string, QuestionOption>> shuffleQuesOptList = questionOption.ToList();

            Random rng = new Random();
            int n = shuffleQuesOptList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                KeyValuePair<string, QuestionOption> value = shuffleQuesOptList[k];
                shuffleQuesOptList[k] = shuffleQuesOptList[n];
                shuffleQuesOptList[n] = value;
            }
            return shuffleQuesOptList.ToDictionary(item => item.Key, item => item.Value);
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {

                Question question = new Question();
                if (paperExam.TryGetValue(clickedButton.Name, out question))
                {
                    QuestionOption option = new QuestionOption();
                    Dictionary<string, QuestionOption> questionOption = question.questionOption;
                    incQuestionOptContainer.Controls.Clear();
                    int numOfQuestionOpt = 1;

                    //foreach(eachOpt in questionOption)
                    //{

                    //}
                    //MessageBox.Show(question.questionDescription + "\r\n" + clickedButton.Name);
                }

                incQMark.Text = question.mark.ToString();
                incQuestion.Text = extractFullQuestion(question, clickedButton);
                incQuestionIndex.Text = clickedButton.Text; //luu vi tri button

            }

            //xu ly nut next max
            if (int.Parse(incQuestionIndex.Text) == paperExam.Count)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }

            //xu ly nut back min
            if (int.Parse(incQuestionIndex.Text) == 1)
            {
                btnBack.Enabled = false;
            }
            else
            {
                btnBack.Enabled = true;
            }

            setIncQuesStatus();
        }

        private void setIncQuesStatus()
        {
            incQuestionStatus.Text = $"Multiple choices {incQuestionIndex.Text}/{paperExam.Count.ToString()}";
        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            Button button = new Button();
            if (dictQuesButton.TryGetValue(int.Parse(incQuestionIndex.Text) + 1, out button) && int.Parse(incQuestionIndex.Text) < paperExam.Count)
            {
                BtnCreate_Click(button, null);
                button.Focus();

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            if (dictQuesButton.TryGetValue(int.Parse(incQuestionIndex.Text) - 1, out button) && int.Parse(incQuestionIndex.Text) > 1)
            {
                BtnCreate_Click(button, null);
                button.Focus();

            }
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        private string extractFullQuestion(Question question, Button button)
        {
            incQMark.Text = question.mark.ToString();
            if (!question.image.Equals(""))
            {
                incQuestionImage.Image = Base64ToImage(question.image);
            }
            else
            {
                incQuestionImage.Image = null;
            }

            string extracted = "";
            int alphaNum = 65;
            string chainOpt = "";
            string chainOptRow = "";
            string alphaStr = "";
            incQuestionOptContainer.Controls.Clear();

            bool answeredButtonStatus = false;

            foreach (QuestionOption option in question.questionOption.Values)
            {
                //option.id
                alphaStr = ((char)alphaNum).ToString();
                chainOpt = chainOpt + alphaStr + ", ";
                chainOptRow = chainOptRow + "\r\n" + alphaStr + ". " + option.description;
                incQuestionOptContainer.Controls.Add(LoadChkOpt(option, alphaStr, question, button));

                if (option.isCorrect)
                {
                    answeredButtonStatus = true;
                }

                alphaNum++;
            }
            string choose = "(Choose 1 answer)";
            chainOpt = chainOpt.Substring(0, chainOpt.Length - 2);
            string gap = "\r\n";

            extracted = extracted + choose + gap + gap + $"Chọn trong {chainOpt} đáp án thích hợp:" + gap + gap + question.questionDescription + gap + chainOptRow;
            return extracted;

        }

        private bool LoadOptAgain(Question question)
        {
            bool answeredButtonStatus = false;

            foreach (QuestionOption option in question.questionOption.Values)
            {
                if (option.isCorrect)
                {
                    answeredButtonStatus = true;
                }
            }

            if (answeredButtonStatus)
            {
                if (!processExam.ContainsKey(question.id))
                {
                    processExam.Add(question.id, question);
                }


                processWork = processExam.Count;
            }
            else
            {
                processExam.Remove(question.id);
                processWork = processExam.Count;
            }
            UpdateProgressStatus();

            return answeredButtonStatus;
        }

        private void UpdateProgressStatus()
        {

            double percent = ((double)processWork / allWork) * 100;
            lblProgress.Text = percent.ToString() + "%";
            progressBar.Value = (int)percent;

            if (percent < 50)
            {
                lblProgress.ForeColor = Color.Crimson;
            }
            else if (percent < 100)
            {
                lblProgress.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                lblProgress.ForeColor = Color.DarkGreen;
            }
        }

        private void ChangeAnsweredButtonStatus(bool answeredButtonStatus, Button button)
        {
            if (answeredButtonStatus)
            {
                button.BackColor = Color.SeaGreen;
                button.FlatStyle = FlatStyle.Popup;
                button.ForeColor = SystemColors.ControlLightLight;
                button.Margin = new Padding(2);
                button.UseVisualStyleBackColor = false;


            }
            else
            {
                button.BackColor = Color.LightCyan;
                button.FlatStyle = FlatStyle.Popup;
                button.ForeColor = SystemColors.ControlText;
                button.Margin = new Padding(2);
                button.UseVisualStyleBackColor = false;


            }

        }

        private CheckBox LoadChkOpt(QuestionOption quesOpt, string chkName, Question question, Button button)
        {
            CheckBox chkOpt = new CheckBox();
            chkOpt.Tag = question;

            chkOpt.AutoSize = true;
            chkOpt.ForeColor = Color.DarkSlateGray;
            chkOpt.Location = new Point(3, 3);
            chkOpt.Name = quesOpt.id;
            chkOpt.Padding = new Padding(0, 2, 0, 2);
            chkOpt.Size = new Size(34, 23);
            chkOpt.TabIndex = 0;
            chkOpt.Text = chkName;
            chkOpt.UseVisualStyleBackColor = true;
            chkOpt.Checked = quesOpt.isCorrect;
            chkOpt.Click += chkOpt_Click;
            return chkOpt;
        }

        private void chkOpt_Click(object sender, EventArgs e)
        {

            if (sender is CheckBox clickedCheckbox)
            {
                if (clickedCheckbox.Checked)
                {
                    if (clickedCheckbox.Tag is Question question)
                    {

                        QuestionOption quesOpt = new QuestionOption();
                        if (question.questionOption.TryGetValue(clickedCheckbox.Name, out quesOpt))
                        {
                            quesOpt.isCorrect = true;
                        }
                    }
                }
                else
                {
                    if (clickedCheckbox.Tag is Question question)
                    {
                        QuestionOption quesOpt = new QuestionOption();
                        if (question.questionOption.TryGetValue(clickedCheckbox.Name, out quesOpt))
                        {
                            quesOpt.isCorrect = false;
                        }
                    }
                }

                bool answeredButtonStatus = false;
                if (clickedCheckbox.Tag is Question ques)
                {
                    answeredButtonStatus = LoadOptAgain(ques);
                }

                Button button = new Button();
                if (dictQuesButton.TryGetValue(int.Parse(incQuestionIndex.Text), out button))
                {
                    ChangeAnsweredButtonStatus(answeredButtonStatus, button);
                }

            }
        }

        private void frmGuiTesting_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmGuiTesting_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        MessageBox.Show("?");
                        Button button = new Button();
                        if (dictQuesButton.TryGetValue(int.Parse(incQuestionIndex.Text) - 1, out button) && int.Parse(incQuestionIndex.Text) < paperExam.Count)
                        {
                            BtnCreate_Click(button, null);
                            button.Focus();

                        }
                        break;
                    }
                case Keys.Right:
                    {
                        Button button = new Button();
                        if (dictQuesButton.TryGetValue(int.Parse(incQuestionIndex.Text) + 1, out button) && int.Parse(incQuestionIndex.Text) < paperExam.Count)
                        {
                            BtnCreate_Click(button, null);
                            button.Focus();

                        }
                        break;
                    }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using Newtonsoft.Json;

namespace ExamInstanceCreator
{
    public partial class frmExamInstanceCreator : Form
    {
        String examCodeInstance = "";
        bool isBlankPaper = false;
        Dictionary<string, Question> examPaperInstance = new Dictionary<string, Question>();
        string toJsonString = "";
        public frmExamInstanceCreator()
        {
            InitializeComponent();
        }

        private static string DecodeBase64ToString(string base64String)
        {
            byte[] data = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(data);
        }


        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog(this);

            ofd.InitialDirectory = "C:\\"; // Đặt thư mục mặc định để bắt đầu từ
            ofd.Filter = "Tập tin Excel (*.xlsx)|*.xlsx";
            ofd.FilterIndex = 1; // Đặt chỉ mục bộ lọc mặc định (ở đây là tập tin xlsx)
            ofd.RestoreDirectory = true; // Khôi phục thư mục hiện tại sau khi chọn tập tin

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtXLSXLocation.Text = ofd.FileName;

                XLSXtoJSON();

            }

        }

        private void XLSXtoJSON()
        {
            //XLSXtoQuestionInstance();             
            examPaperInstance = XLSXtoExamPaperInstance(isBlankPaper);

            toJsonString = JsonConvert.SerializeObject(examPaperInstance);
            //display
            rtbJson.Text = toJsonString;
        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDesLocation.Text = fbd.SelectedPath;
            }
        }

        private void btnCreateInstance_Click(object sender, EventArgs e)
        {
            if ((txtDesLocation.Text.Length == 0) || (txtXLSXLocation.Text.Length == 0))
            {
                MessageBox.Show("Lỗi!", "Chưa chọn đủ đường dẫn!", MessageBoxButtons.OK);
            }
            else
            {
                byte[] toJsonByteArray = Encoding.UTF8.GetBytes(toJsonString);              
                bool success = SaveEncryptDataToFile(txtDesLocation.Text + "\\" + examCodeInstance + ".DAT", toJsonByteArray, "AKAKING55178xxxx");
            }
        }

        private Dictionary<string, Question> XLSXtoExamPaperInstance(bool isBlankPaper)
        {
            Dictionary<string, Question> examPaper = new Dictionary<string, Question>();
            string xlsxPath = txtXLSXLocation.Text;

            DataTable dataXLSX = new DataTable();

            //Đọc dữ liệu vào dataXLSX
            using (XLWorkbook wb = new XLWorkbook(xlsxPath))
            {

                bool isFirstRow = true;
                var rows = wb.Worksheet(1).Rows();

                examCodeInstance = (string)wb.Worksheet(1).Cell(2, 13).Value;
                txtDebug.Text = examCodeInstance;

                foreach (var row in rows)
                {
                    Debug.Print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    if (isFirstRow)
                    {
                        foreach (IXLCell cell in row.Cells(false))
                        {
                            dataXLSX.Columns.Add(cell.Value.ToString());
                            //Debug.Print(cell.Value.ToString());
                        }

                        isFirstRow = false;
                    }
                    else
                    {
                        dataXLSX.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dataXLSX.Rows[dataXLSX.Rows.Count - 1][i++] = cell.Value.ToString();
                            // Debug.Print("+: " + cell.Value.ToString());
                        }

                    }
                }
            }
            Debug.Print("----------------");
            string opt1;
            string opt2;
            string opt3;
            string opt4;
            string opt5;
            string opt6;
            int correctAnswer;


            foreach (DataRow dr in dataXLSX.Rows)
            {
                Question question = new Question();
                //string getRowValue = dr[txtDebug.Text].ToString();
                question.id = Guid.NewGuid().ToString();
                question.questionDescription = dr["quesText"].ToString();
                question.questionType = dr["quesType"].ToString();
                question.mark = int.Parse(dr["questionMark"].ToString());

                string imgLink = dr["imgLink"].ToString();
                if (!imgLink.Equals("$null"))
                {
                    question.image = dr["imgLink"].ToString();
                }
                else
                {
                    question.image = "";
                }
                

                QuestionOption option1 = new QuestionOption();
                QuestionOption option2 = new QuestionOption();
                QuestionOption option3 = new QuestionOption();
                QuestionOption option4 = new QuestionOption();
                QuestionOption option5 = new QuestionOption();
                QuestionOption option6 = new QuestionOption();

                opt1 = dr["opt1"].ToString();
                opt2 = dr["opt2"].ToString();
                opt3 = dr["opt3"].ToString();
                opt4 = dr["opt4"].ToString();
                opt5 = dr["opt5"].ToString();
                opt6 = dr["opt6"].ToString();

                if (!isBlankPaper)
                {
                    correctAnswer = int.Parse(dr["correctAnswer"].ToString());
                    Debug.Print(correctAnswer.ToString());

                    if (correctAnswer == 1)
                    {
                        option1.isCorrect = true;
                    }
                    if (correctAnswer == 2)
                    {
                        option2.isCorrect = true;
                    }
                    if (correctAnswer == 3)
                    {
                        option3.isCorrect = true;
                    }
                    if (correctAnswer == 4)
                    {
                        option4.isCorrect = true;
                    }
                    if (correctAnswer == 5)
                    {
                        option5.isCorrect = true;
                    }
                    if (correctAnswer == 6)
                    {
                        option6.isCorrect = true;
                    }
                }

                Dictionary<string, QuestionOption> options = new Dictionary<string, QuestionOption>();

                option1.id = Guid.NewGuid().ToString();
                option2.id = Guid.NewGuid().ToString();
                option1.description = opt1;
                option2.description = opt2;

                options.Add(option1.id, option1);
                options.Add(option2.id, option2);


                if (!opt3.Equals("$null"))
                {
                    option3.id = Guid.NewGuid().ToString();
                    option3.description = opt3;
                    options.Add(option3.id, option3);
                }
                if (!opt4.Equals("$null"))
                {
                    option4.id = Guid.NewGuid().ToString();
                    option4.description = opt4;
                    options.Add(option4.id, option4);
                }
                if (!opt5.Equals("$null"))
                {
                    option5.id = Guid.NewGuid().ToString();
                    option5.description = opt5;
                    options.Add(option5.id, option5);
                }
                if (!opt6.Equals("$null"))
                {
                    option6.id = Guid.NewGuid().ToString();
                    option6.description = opt6;
                    options.Add(option3.id, option6);
                }

                question.questionOption = options;
                examPaper.Add(question.id, question);
            }


            return examPaper;
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

        private static string SerializeToString<TData>(TData settings)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, settings);
                stream.Flush();
                stream.Position = 0;
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static bool SaveEncryptDataToFile(string fileName, byte[] data, string keyString)
        {
            //chuyển key dạng string sang mảng byte
            byte[] key = Encoding.UTF8.GetBytes(keyString);

            try
            {
                if (data == null) { return false; }

                //sử dụng using để tự động giải phóng dữ liệu
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    //data là một mảng byte kết hợp bởi iv sau đó là encryptedData

                    //khởi tạo aes
                    using Aes aes = Aes.Create();
                    aes.Key = key;
                    aes.GenerateIV();

                    using ICryptoTransform encryptor = aes.CreateEncryptor();
                    byte[] encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length); //mã hóa data và truyền vào mảng byte

                    //vì dữ liệu mã hóa đầy đủ bao gồm IV và dữ liệu mã hóa
                    byte[] combinedData = new byte[aes.IV.Length + encryptedData.Length];


                    Array.Copy(aes.IV, 0, combinedData, 0, aes.IV.Length);
                    Array.Copy(encryptedData, 0, combinedData, aes.IV.Length, encryptedData.Length);

                    //ghi file dữ liệu mã hóa đã combine.
                    fileStream.Write(combinedData, 0, combinedData.Length);

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static byte[] GetDecryptDataFromFile(string fileName, string keyString)
        {
            //chuyển key dạng string sang mảng byte
            byte[] key = Encoding.UTF8.GetBytes(keyString);


            //sử dụng using để tự động giải phóng dữ liệu
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {

                //truyền dữ liệu từ fileStream sang byte[]
                byte[] data = new byte[fileStream.Length];
                int byteRead = fileStream.Read(data, 0, data.Length);

                //data là một mảng byte kết hợp bởi iv sau đó là encryptedData

                //khởi tạo aes
                using Aes aes = Aes.Create();
                aes.Key = key;

                //lấy dữ liệu từ data sang iv
                byte[] iv = new byte[aes.IV.Length];
                Array.Copy(data, 0, iv, 0, aes.IV.Length);
                aes.IV = iv;

                //lấy dữ liệu từ data sang encryptedData
                byte[] encryptedData = new byte[data.Length - aes.IV.Length];
                Array.Copy(data, aes.IV.Length, encryptedData, 0, encryptedData.Length);

                using ICryptoTransform decryptor = aes.CreateDecryptor();
                return decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }
        }

        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }

        public static object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            memoryStream.Write(arrBytes, 0, arrBytes.Length);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            return binaryFormatter.Deserialize(memoryStream);
        }

        private void SaveBinaryStringToDatFile(string filename, string desPath, string content)
        {
            string path = desPath + @"\" + filename + ".dat";

            if (!File.Exists(path))
            {
                FileStream myFile = File.Create(path);
                BinaryWriter binaryfile = new BinaryWriter(myFile);
                binaryfile.Write(content);
                binaryfile.Close();
                myFile.Close();
            }
        }

        private void chkIsBlankPaper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsBlankPaper.Checked)
            {
                isBlankPaper = true;
            }
            else
            {
                isBlankPaper = false;
            }

            XLSXtoJSON();
        }
    }
}




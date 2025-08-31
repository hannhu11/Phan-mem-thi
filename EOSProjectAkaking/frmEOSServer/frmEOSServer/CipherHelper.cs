using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace CipherHelper
{
    public class CipherData
    {

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
            byte[]key = Encoding.UTF8.GetBytes(keyString);


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

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptTextFile
{
   public class Encryption
    {
        protected void EncryptFile(string inputFile, string outputFile)
        {

            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fileStreamCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged cryptManager = new RijndaelManaged();

                CryptoStream cryptStream = new CryptoStream(fileStreamCrypt,
                    cryptManager.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fileStreamIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fileStreamIn.ReadByte()) != -1)
                    cryptStream.WriteByte((byte)data);


                fileStreamIn.Close();
                cryptStream.Close();
                fileStreamCrypt.Close();
            }
            catch
            {
                throw new ArgumentException("Encryption failed!");
            }
        }
        

        protected void DecryptFile(string inputFile, string outputFile)
        {

            {
                string password = @"myKey123"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fileStreamCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged cryptManager = new RijndaelManaged();

                CryptoStream cryptStream = new CryptoStream(fileStreamCrypt,
                    cryptManager.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fileStreamOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cryptStream.ReadByte()) != -1)
                    fileStreamOut.WriteByte((byte)data);

                fileStreamOut.Close();
                cryptStream.Close();
                fileStreamCrypt.Close();

            }
        }

        class Program 
        {
            static void Main()
            {
                var enc = new Encryption();
                string inputFileForEncrypt = "../../Input.txt";
                string encryptedFile = "../../Output.txt";
                enc.EncryptFile(inputFileForEncrypt, encryptedFile);

                string decryptedFile = "../../Dec.txt";

                enc.DecryptFile(encryptedFile, decryptedFile);
               

            }
        }
    }
}

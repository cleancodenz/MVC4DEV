using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
           // RSAEncrypt();
            //RSAEncrypt2();
            SymmetricEncription();
            Console.ReadLine();
        }

        static void RSAEncrypt()
        {
            UnicodeEncoding bytConvertor = new UnicodeEncoding();
            byte[] plainData = bytConvertor.GetBytes("Sample data");
            RSACryptoServiceProvider RSAServiceProvider = new RSACryptoServiceProvider();

            byte[] enData = Encrypt(plainData, RSAServiceProvider.ExportParameters(false));
            Console.WriteLine("Encrypted Output: {0}", bytConvertor.GetString(enData));

            byte[] deData = Decrypt(enData, RSAServiceProvider.ExportParameters(true));
            Console.WriteLine("Decrypted Output: {0}", bytConvertor.GetString(deData));
        }
        static private byte[] Encrypt(byte[] DataToEncrypt, RSAParameters keyInfo)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(keyInfo);
            return RSA.Encrypt(DataToEncrypt, false);
        }

        static private byte[] Decrypt(byte[] DataToDecrypt, RSAParameters keyInfo)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(keyInfo);
            return RSA.Decrypt(DataToDecrypt, false);
        }

        private static void RSAEncrypt2()
        {
            // RSA examples 
            RSA rsa = new RSA();

            RSACryptoServiceProvider serviceProvider =
                new RSACryptoServiceProvider();
            //Export the key information to an RSAParameters object. 
            //Pass false to export the public key information or pass 
            //true to export public and private key information.
            //RSAParameters RSAParams = RSA.ExportParameters(false);

            //Encrypt data
            UnicodeEncoding bytConvertor = new UnicodeEncoding();
            byte[] plainData = bytConvertor.GetBytes("Sample data");

            byte[] enData = rsa.Encrypt(plainData, serviceProvider.ExportParameters(false));
            Console.WriteLine("Encrypted Output: {0}", bytConvertor.GetString(enData));

            byte[] deData = rsa.Decrypt(enData, serviceProvider.ExportParameters(true));
            Console.WriteLine("Decrypted Output: {0}", bytConvertor.GetString(deData));
        }

        static void SymmetricEncription()
        {
            UnicodeEncoding bytConvertor = new UnicodeEncoding();
            
      

            byte[] key ;

            byte[] iv ;

            byte[] enData;

            string deData;

            using (Rijndael myRijndael = Rijndael.Create())
            {
               key = myRijndael.Key;

               iv = myRijndael.IV;
            }

            using (Rijndael rijndael1 = Rijndael.Create())
            {


                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor1 = rijndael1.CreateEncryptor(key, iv);

                enData = SymmetricEncryptData(encryptor1,"My SAmple Data");
                Console.WriteLine("Encrypted Output: {0}", bytConvertor.GetString(enData));
            }

            using (Rijndael rijndael2 = Rijndael.Create())
            {

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor2 = rijndael2.CreateDecryptor(key, iv);
                

                deData = SymmetricDecryptData(encryptor2, enData);
                Console.WriteLine("Decrypted Output: {0}", deData);
            }
        }

        static byte[] SymmetricEncryptData(ICryptoTransform cryptor, string data)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream encStream = new CryptoStream(memoryStream,
              cryptor, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(encStream);

            sw.WriteLine(data);
            sw.Close();
            encStream.Close();

            byte[] buffer = memoryStream.ToArray();
            memoryStream.Close();

            return buffer;
        }

        static string SymmetricDecryptData(ICryptoTransform cryptor, byte[] data)
        {
            MemoryStream memoryStream = new MemoryStream(data);

            CryptoStream encStream = new CryptoStream(memoryStream,
              cryptor, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(encStream);

            string val = sr.ReadLine();
            sr.Close();
            encStream.Close();
            memoryStream.Close();

            return val;
        }

        private static void SymmetricEncription2()
        {
            DESCryptoServiceProvider cryptic1 = new DESCryptoServiceProvider();

            cryptic1.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
            cryptic1.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");

            byte[] enData;

            string deData;
            enData = SymmetricEncryptData(cryptic1.CreateEncryptor(), "My Sample Data");

            DESCryptoServiceProvider cryptic2 = new DESCryptoServiceProvider();

            cryptic2.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
            cryptic2.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");

            deData = SymmetricDecryptData(cryptic2.CreateDecryptor(), enData);

        }
    }
}

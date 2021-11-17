using System;
using System.IO;
using Chilkat;

namespace Lab5
{
    class Program
    {
        const string filepath = @"D:\4 курс 1 семестр\Захист Інформації\Лаб5\";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Name");
            string file = filepath+ Console.ReadLine()+".txt";
            Console.WriteLine("Enter Key (ASCII)");
            string key = Console.ReadLine();
            Console.WriteLine("Enter Iv (ASCII)");
            string iv = Console.ReadLine();

            string text = File.ReadAllText(file);

            string decryptedText = Decrypt(key, iv, text);

            Console.WriteLine("Show back encryption");
            Encrypt(key,iv,decryptedText);

        }
        private static string Encrypt(string key, string iv, string text)
        {
            Crypt2 symAlg = new Crypt2();
            symAlg.CryptAlgorithm = "aes";
            symAlg.CipherMode = "ctr";
            symAlg.KeyLength = 128;
            symAlg.EncodingMode = "base64";
            symAlg.SetEncodedIV(iv,"ascii");
            symAlg.SetEncodedKey(key, "ascii");
            string result = symAlg.EncryptStringENC(text);
            Console.WriteLine(result);
            return result;
        }
        private static string Decrypt(string key, string iv, string text)
        {
            Crypt2 symAlg = new Crypt2();
            symAlg.CryptAlgorithm = "aes";
            symAlg.CipherMode = "ctr";
            symAlg.KeyLength = 128;
            symAlg.EncodingMode = "base64";
            symAlg.SetEncodedIV(iv, "ascii");
            symAlg.SetEncodedKey(key, "ascii");
            string result = symAlg.DecryptStringENC(text);
            Console.WriteLine(result);
            return result;
        }

    }
}

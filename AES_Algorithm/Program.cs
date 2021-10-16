using System;

namespace AES_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoAES aesAlgorithm = new DemoAES();

            Console.Write($"Write the TEXT: ");
            string text = Console.ReadLine();

            string dText = aesAlgorithm.Encrypt(text);

            string eText = aesAlgorithm.Decrypt(dText);
            
            Console.WriteLine($"Encrypted TEXT = {dText}\nDecrypted TEXT = {eText}");

            Console.Read();
        }
    }
}

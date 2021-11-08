
using System;
using System.IO;
using System.Text;

namespace demostreams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("stream implementation");
            string path = @"c:\temp\MyTest.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream Fs = File.Create(path))
            {
                AddText(Fs, "my name is priya");
                AddText(Fs, "secret is my fav book,");
                AddText(Fs, "\r\nand this is on a new line");
                AddText(Fs, "\r\n\r\nThe following is a subset of characters:\r\n");

                for (int i = 1; i < 120; i++)
                {
                    AddText(Fs, Convert.ToChar(i).ToString());
                }
            }
            using (FileStream Fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (Fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

            static void AddText(FileStream Fs, string value)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(value);
                Fs.Write(info, 0, info.Length);
            }
        }
    }
}


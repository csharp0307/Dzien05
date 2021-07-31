using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlikiFoldery
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "C:/tmp/test.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //StreamWriter sw = File.CreateText(path);
            //sw.Close();
            File.CreateText(path).Close(); //tworzy plik o wielkości 0 bajtów

            File.WriteAllText(path, "Ala ma kota, a kot ma kleszcze");
            File.Copy(path, "C:/tmp/test2.txt");
            File.Move("C:/tmp/test2.txt", "C:/tmp/test3.txt");

            Console.WriteLine(File.ReadAllText(path));

            String folderName = "c:/tmp/alx";
            if (!Directory.Exists(folderName))
            {
                //tworzenie folderu
                Directory.CreateDirectory(folderName);
            }
            Directory.Move(folderName, "c:/tmp/csharp");
            Directory.Delete("c:/tmp/csharp", true);

            Console.ReadKey();
        }
    }
}

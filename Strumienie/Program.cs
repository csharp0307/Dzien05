using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strumienie
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"c:\tmp\test.txt");
            sw.AutoFlush = false;
            for (int i = 1; i <= 10; i++)
            {
                sw.WriteLine($"Linia nr {i}");
            }
            sw.Flush();
            sw.Close();

            // resource manager - using
            using (StreamWriter sw1 = new StreamWriter(@"c:\tmp\test1.txt"))
            {
                sw1.WriteLine("Dodatkowa linia");
                //sw1.Close(); - niepotrzebna
            } // -- using sam zamknie strumień

            // odczyt ze strumienia plikowego
            String s;
            String filename = @"c:\tmp\test.txt";
            
            FileStream fs = new FileStream(filename, FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Seek(2, SeekOrigin.Begin);
            fs.Read(data, 0, (int)fs.Length);

            // konwersja tablicy bajtow na string
            s = Encoding.UTF8.GetString(data);
            Console.WriteLine(s);

            fs.Close();

            // sekwencyjne odczytywanie pliku tekstowego
            using (StreamReader sr = new StreamReader("c:/tmp/test.txt"))
            {
                String line;
                do
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line); ;
                } while (line != null);
                
            }

            // metody I/O dla klasy File
            File.ReadAllText("c:/tmp/test.txt");
            File.WriteAllText("c:/tmp/test.txt", "AAA BBB CCC");
            File.ReadAllLines("c:/tmp/test.txt");

            Console.ReadKey();
        }
    }
}

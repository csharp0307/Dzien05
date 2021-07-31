using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyjatki
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    int p=10, q=0;
                    int t = p / q;
                } catch
                {
                    //throw;
                }

                int i = 10, j = 0, k = 0;
                //k = i / j;
                String s = Console.ReadLine();
                i = Int32.Parse(s);
                if (i < 0)
                    throw new Exception("mniejsze od zera");

                byte[] b = new byte[] { 1, 2, 3, 4, 5 };
                byte x = b[i];
            }
            
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine($"Zły indeks: {exc.Message}");
            }
            catch (FormatException exc)
            {
                Console.WriteLine($"Zły format: {exc.Message}");
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Wystapil wyjątek: {exc.Message}");
            }
            finally
            {
                // zawsze się wykona, nawet mimo wyjątku
                Console.WriteLine("Zawsze się wykona");
            }


            Console.ReadKey();
            
        }
    }
}

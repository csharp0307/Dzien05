using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Program
    {
        class Response
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }

        static void Main(string[] args)
        {
            Response resp = new Response()
            {
                Status = 200, Message = "OK"
            };
            Console.WriteLine(resp.Message);

            // krotka
            Tuple<int, string> tuple1 = new Tuple<int, string>(200, "OK");
            Console.WriteLine(tuple1.Item2);

            Tuple<Tuple<int, string>, Tuple<double, bool>> tuple2 =
                new Tuple<Tuple<int, string>, Tuple<double, bool>>( 
                    Tuple.Create(1,"OK") ,
                    Tuple.Create(1.2, true)  );
            Console.WriteLine(tuple2.Item1.Item2);
            //tuple2.Item1.Item2 = "AAAA"; krotka jest niemutowalna

            var person1 = (1, "Jan", "Kowalski");
            Console.WriteLine(person1.Item3);

            (int, string, string) person2 = (1, "Jan", "Kowalski");

            // Named Tuple
            var person3 = (Id: 1, FName: "Jan", LName: "Kowalski");
            Console.WriteLine(person3.LName);

            int _id = person3.Id;
            string _fname = person3.FName;
            string _lname = person3.LName;

            int dummy;
            (_id, _fname, _lname) = person3;
            (_, _fname, _lname) = person3;

        }
    }
}

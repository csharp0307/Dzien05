using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePrior
{
    class Program
    {

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }

            public override string ToString()
            {
                //return String.Format("[{0}] {1}", Priority, Name );
                return $"[{Priority}] {Name}";
            }
        }

        class QueuePrior
        {
            private List<Customer> customers = new List<Customer>();

            public int Size { get { return customers.Count(); } }

            public void Enqueqe(Customer customer)
            {
                customer.Id = Size + 1;
                customers.Add(customer);
            }

            public Customer Dequeue2()
            {
                Customer c = customers.OrderByDescending(x => x.Priority).ThenBy(x => x.Id).First();
                if (c != null)
                {
                    customers.Remove(c);
                }
                return c;
            }

            public Customer Dequeue1()
            {
                int foundIndex = -1; int maxPrior = -1;
                for (int i = 0; i < customers.Count(); i++)
                {
                    if (customers[i].Priority > maxPrior)
                    {
                        maxPrior = customers[i].Priority;
                        foundIndex = i;
                    }
                }

                if (foundIndex == -1) return null;

                Customer foundCustomer = customers[foundIndex];
                customers.RemoveAt(foundIndex);

                return foundCustomer;
            }

        }

        static void Main(string[] args)
        {
            QueuePrior qp = new QueuePrior();

            int SIZE = 1_000;
            //Customer c1 = new Customer();
            //c1.Name = "Jan Kowalski"; c1.Priority = 1;
            for (int i = 0; i < SIZE; i++)
            {
                qp.Enqueqe(new Customer() { Name = "Jan Kowalski", Priority = 1 });
                qp.Enqueqe(new Customer() { Name = "Sasin 70mln", Priority = 5 });
                qp.Enqueqe(new Customer() { Name = "Marian Kowalski", Priority = 1 });
                qp.Enqueqe(new Customer() { Name = "Jan Rokita", Priority = 3 });
                qp.Enqueqe(new Customer() { Name = "Nelly Rokita", Priority = 2 });
            }


            Stopwatch sw = new Stopwatch();
            sw.Start();
            int qs = qp.Size;
            for (int i = 0; i < qs; i++)
            {
                Customer currCustomer = qp.Dequeue1();
                //Console.WriteLine(currCustomer);
            }
            sw.Stop();
            Console.WriteLine($"Total FOR={sw.ElapsedMilliseconds}");

            // LINQ
            for (int i = 0; i < SIZE; i++)
            {
                qp.Enqueqe(new Customer() { Name = "Jan Kowalski", Priority = 1 });
                qp.Enqueqe(new Customer() { Name = "Sasin 70mln", Priority = 5 });
                qp.Enqueqe(new Customer() { Name = "Marian Kowalski", Priority = 1 });
                qp.Enqueqe(new Customer() { Name = "Jan Rokita", Priority = 3 });
                qp.Enqueqe(new Customer() { Name = "Nelly Rokita", Priority = 2 });
            }
            sw.Restart();
            qs = qp.Size;
            for (int i = 0; i < qs; i++)
            {
                Customer currCustomer = qp.Dequeue2();
                //Console.WriteLine(currCustomer);
            }
            sw.Stop();
            Console.WriteLine($"Total LINQ={sw.ElapsedMilliseconds}");

            Console.ReadKey();


        }
    }
}

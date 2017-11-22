using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue2();
            string name = "dfs";
            while (name != string.Empty)
            {
                name = Console.ReadLine();
                q.Enqueue(name);
            }

            while (!q.Empty)
            {
                string names = q.Dequeue();
                Console.WriteLine(names);
            }
            Console.ReadLine();
        }
    }
}

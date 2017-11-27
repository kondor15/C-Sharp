using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
      public static void Main(string[] args)
        {
            var q = new Queue();
            string name = "dfs";
            while (name !=string.Empty)
            {
                name = Console.ReadLine();
                q.Push(name);
            }

            while (!q.Empty)
            {
                string names = q.Pop();
                Console.WriteLine(names);
            }
            Console.ReadLine();
        }
        
        
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class Queue
    {
        private List<string> container;
        public Queue()
        {
            this.container = new List<string>();
        }
        public void Push(string val)
        { 
            this.container.Add(val);
        }
        public string Pop()
        {
            string popped = container[0];
            container.RemoveAt(0);
            return popped;
        }
        public bool Empty
        {
            get
            {
                return container.Count == 0;
            }
        }
    }
}

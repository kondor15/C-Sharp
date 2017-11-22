using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class QueueElement2
    {
       public  string value;
       public QueueElement2 prev, next;
    }

    public class Queue2
    {
        QueueElement2 head; // = null
        QueueElement2 tail; // = null

        public void Enqueue( string v)
        {
           if( head == null )
            {
                head = tail = new QueueElement2()
                {
                    value = v
                };
            }
           
           else
            {
                tail = new QueueElement2()
                {
                    value = v ,
                    prev = tail
                };
                tail.prev.next = tail;
            }
        }

        public string Dequeue()
        {
            if ( head == null)
            {
                throw new Exception("The queue is empty");
            }

            var v = head.value;
            if (head == tail)
                head = tail = null;
            else
            {
                head = head.next;
                head.prev = null;
            }
            return v;
                    
        }

        public bool Empty
        {
            get { return head == null; }
        }
    }
}

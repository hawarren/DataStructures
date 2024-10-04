using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Legacy
{
    class hwQueue
    {
        //ArrayQueue
        //enqueue
        //dequeue
        //peek
        //isEmpty
        //isFull

        public hwQueue(int size)
        {
            arrayQueue = new int?[size];
            head = 0;
            tail = 0;
        }
        private int?[] arrayQueue { get; set; }

        private int internalSize { get; set; }
        private int head { get; set; }
        private int tail { get; set; }

        public bool isEmpty()
        {
            if (internalSize != 0)
                return false;
            else return true;
        }
        private bool isFull()
        {
            if (internalSize == arrayQueue.Length)
                return true;
            else return false;
        }
        public void enqueue(int data)
        {
            if (!isFull())
            {
                arrayQueue[(tail + 1) % arrayQueue.Length] = data;
                tail = (tail + 1) % arrayQueue.Length; //move up a spot, wrap around to front of array if at end
                ++internalSize; //increment the count of items in the queue
            }
            else
            {
                Console.WriteLine("Sorry the queue is full");
            }
        }
        public int dequeue()
        {
            if (!isEmpty())
            {
                var removedItem = arrayQueue[head];
                arrayQueue[head] = null;
                internalSize--;

                head = (head + 1) % arrayQueue.Length; //move head to new first in line
                return (int)removedItem;
            }
            else throw new IndexOutOfRangeException("value is higher than this list length");
        }
        public int peek()
        {
            if (!isEmpty())
            {
                return head;
            }
            else throw new IndexOutOfRangeException("List is empty");
        }

    }
}



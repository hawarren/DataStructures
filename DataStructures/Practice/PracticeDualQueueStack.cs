using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    public class PracticeDualQueueStack
    {

        private readonly Queue<int> _leftQueue;
        private readonly Queue<int> _rightQueue;
        private  int _count = 0;
       public PracticeDualQueueStack()
        {
            _leftQueue = new Queue<int>();
            _rightQueue = new Queue<int>();
            _count = 0;
        }

        public void push(int newItem)
        {
            //add item to rightqueue, then add the rest of the items from leftQueue
            //add all from right back to leftr queue
            _rightQueue.Enqueue(newItem);
            _count++;
            while (_leftQueue.Count > 0)
            {
                _rightQueue.Enqueue(_leftQueue.Dequeue());
            }
            while (_rightQueue.Count > 0)
            {
                _leftQueue.Enqueue(_rightQueue.Dequeue());
            }
            Console.WriteLine($"{newItem} pushed to stack");

        }
        public int pop()
        {
            if (isEmpty())
            {
                return 0;
            }
            _count--;
            var removedItem = _leftQueue.Dequeue();
            Console.WriteLine($"{removedItem} popped off stack");
            return removedItem;
        }
        public int peek()
        {
            return _leftQueue.Peek();

        }
        public int size()
        {
            return _count;
        }
        public bool isEmpty()
        {
            return _count == 0;
        }
        public override string ToString()
        {
            return string.Join(",", _leftQueue.ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticePriorityQueue
    {
        public PracticePriorityQueue()
        {
            _internalArray = new int[5];
            _count = 0;

        }
        private int _head;
        private int _tail;
        private int _count;
        int[] _internalArray;

        public void enqueue(int item)
        {
            //start from tail + 1
            //if tail greater than item
            //move tail  to tail +1
            //if nextItem is greater than item, move to item + 1
            if (_count == 0)
            {
                _internalArray[0] = item;
                _head = 0;
                _tail = 0;
                _count++;
            }
            else
            {
                if (isFull())
                    resize();
                int i = ShiftItemsToInsert(item);
                _internalArray[i] = item;
                _tail++;
                _count++;
            }

            int ShiftItemsToInsert(int item)
            {
                int i = _tail;
                while (i >= 0)
                {
                    if (_internalArray[i] > item)
                    {
                        _internalArray[i + 1] = _internalArray[i]; //move item over
                        i--;
                    }
                    else
                    {
                        _internalArray[i + 1] = item;
                        break;
                    }
                }

                return i+1;
            }
        }
        public int dequeue() {
            var removedItem = _internalArray[_head];
            _internalArray[_head++] = 0;
            _count--;
            return removedItem;
        }
        public void resize()
        {
            int[] newArray = new int[_internalArray.Length * 2];
            for (var i = 0; i <= _count; i++)
            {
                newArray[i] = _internalArray[i];
            }
            _internalArray = newArray;
        }
        public bool isFull() {
            return _count == _internalArray.Length;
        }
        public override string ToString()
        {
            return _internalArray.ToString();
        }

    }
}

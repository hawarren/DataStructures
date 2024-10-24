using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class ArrayQueue
    {
        //enqueue
        //dequeue
        //peek
        //isEmpty
        //isFull
        private int[] _internalArray;
        private int _headPosition;
        private int _tailPosition;
        private int _count;
        public ArrayQueue()
        {
            _internalArray = new int[5];
            _headPosition = 0;
            _tailPosition = 0;
            _count = 0;
        }
        public void peek() { }
        public void enqueue(int item)
        {
            //if no items in queue, add item at index 0, set headPos to 0 and tailPos to 1 mod array.length
            //if at least 1 item, add item at tailPos and increment tailPos
            //if at least 1 item and removing, remove item at headPos and incrementHeadPos
            //if array is full before adding, then resize array or throw error
            if (isOutOfBounds(_headPosition))
                _headPosition = getIndex(_headPosition);

            if (isOutOfBounds(_tailPosition))
                _tailPosition = getIndex(_tailPosition);

            if (!isFull())
            {
                if (_count == 0)
                {
                    _internalArray[0] = item;
                    _headPosition = 0;
                    _tailPosition = _headPosition + 1;
                    _count++;
                    return;
                }
                if (_internalArray.Length > _tailPosition)
                {
                    if (_internalArray[_tailPosition] == 0)
                    {
                        _internalArray[_tailPosition] = item;
                        _tailPosition++;
                        _count++;
                        //fix this if condition
                    }
                }
            }
            else {
                Console.WriteLine($"The array is is Full {isFull()}");
            }
        }
        public bool isEmpty()
        {

            return _count == 0;
        }
        public int dequeue()
        {
            if (isOutOfBounds(_headPosition))
                _headPosition = getIndex(_headPosition);

            if (isOutOfBounds(_tailPosition))
                _tailPosition = getIndex(_tailPosition);

            var removedItem = -1;
            if (!isEmpty())
            {

                removedItem = _internalArray[_headPosition];
                _internalArray[_headPosition] = 0;
                _count--; 
                _headPosition++;
            }

            return removedItem;
        }
        public bool isFull()
        {

            return _count == _internalArray.Length;
        }
        private int getIndex(int item)
        {
            if (item >= _internalArray.Length)
            {
                return item % _internalArray.Length;
            }
            else if (item < 0)
            {
                return item + _internalArray.Length;
            }
            return item;
        }
        private bool isOutOfBounds(int index)
        {
            return index >= _internalArray.Length || index < 0;
        }

    }
}

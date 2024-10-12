using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticeMinStack
    {
        private int _count = 0;
        private int[] _internalArray = new int[5];
        private LinkedList<int> _internalSortedList = new();
        public void push(int item)
        {

            _internalArray[_count++] = item;

            if (_internalSortedList.First == null)
            {
                _internalSortedList.AddFirst(item);
                
            }
            else if (_internalSortedList.First.Value > item)
                _internalSortedList.AddFirst(item);
            else if (_internalSortedList.Last.Value < item)
                _internalSortedList.AddLast(item);
            else
            {
                //add to array at end
                //add to sortedList in order of position
                var nodeItem = new LinkedListNode<int>(item);
                var newList = new LinkedList<int>();

                var startingNode = _internalSortedList.First;
                var endingNode = _internalSortedList.First.Next;



                while (endingNode != null)
                {/// 1, 2, 5, insert 3
                    //iterate list and stop after value is greater than the new item
                    if (endingNode?.Value > item)
                    {

                        endingNode = endingNode.Next;
                    }
                    else
                    {
                        _internalSortedList.AddBefore(endingNode, item);
                    }

                }
            }

        }
        public int pop()
        {
            //remove from array at end
            //remove from sorted list at position
            var removedItem = _internalArray[_count - 1];
            _internalArray[_count - 1] = 0;
            _count--;
            _internalSortedList.Remove(_internalSortedList.Find(removedItem));
            return removedItem;
        }
        public int min()
        {
            //retrieve item from head  of linkedlist
            return _internalSortedList.First();
        }
    }

}

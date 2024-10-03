using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    public class PracticeLinkedList
    {
        private class PracticeNode
        {
            public int Value { get; set; }
            public PracticeNode Next { get; set; }
            public PracticeNode(int value)
            {
                this.Value = value;
            }
        }
        private PracticeNode _first { get; set; }
        private PracticeNode _last { get; set; }
        private int _size { get; set; }
        public PracticeLinkedList()
        {
        }

        public void addFirst(int newValue)
        {
            PracticeNode newNode = new PracticeNode(newValue);
            if (isEmpty())
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = this._first;
                this._first = newNode;

            }
            _size++;
        }
        public void addLast(int newValue)
        {
            PracticeNode newNode = new PracticeNode(newValue);
            if (isEmpty())
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                //point last to new node, then make newnode the last node
                _last.Next = newNode;
                _last = newNode;
            }
            _size++;

        }
        public void deleteFirst()
        {

            if (isEmpty())
            {
                throw new System.InvalidOperationException("The LinkedList is empty.");
            }
            if (_first == _last)
            {
                _first = _last = null;                
            }
            else
            {
                //find second value
                //save pointer to second value
                //make second value the first
                var second = this._first.Next;
                _first.Next = null;
                this._first = second;
            }
            _size--;
        }
        public void deleteLast()
        {

            if (isEmpty())
            {
                throw new System.InvalidOperationException("The LinkedList is empty.");
            }
            if (_first == _last)
            {
                _first = _last = null;
            }
            else
            {
                //find the 2nd to last node
                //delete the last node
                //set last  to prior 2ndToLast value
                var previous = getPrevious(_last);
                _last = previous;
                _last.Next = null;
            }
            _size--;
        }
        private PracticeNode getPrevious(PracticeNode node)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Next == node)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        public bool contains(int value)
        {
            return indexOf(value) != -1;
        }
        public int indexOf(int searchValue)
        {
            int index = 0;
            var startingNode = this._first;

            if (this._first.Value == searchValue)
            {
                return index;

            }

            while (startingNode.Next != null)
            {
                startingNode = startingNode.Next;
                index++;
                if (startingNode.Value == searchValue)
                    return index;
            };
            return -1;
        }
        private bool isEmpty()
        {
            return _first == null;
        }
        public int size()
        {
            return _size;
        }
        public int[] ToArray()
        {

            if (_size == 0)
                return null;

            int[] array = new int[_size];
            var current = _first;            
            array[0] = _first.Value;

            for (var index = 1; index < _size; index++)
            {
                current = current.Next;
                array[index] = current.Value;
            }

            return array;
        }

    }


}

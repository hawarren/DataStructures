﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            var index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }
        public void reverse()
        {
            //dig from first to last
            //maintain prev
            //null out prev.next, last.next = prev
            //dig from first to last again until next == null
            //save prev
            //....

            if (isEmpty())
                return;
            var current = _last;
            var prev = getPrevious(_last);
            while (getPrevious(current) != null)
            {
                //point the current node to the previous node (starting from first).
                //remove link from previous node to current node
                //get the next previous node, and move to the end of the last node (starting from last to first)
                current.Next = getPrevious(current);
                current.Next.Next = null;

                prev = getPrevious(current.Next);
                current = current.Next;
                //once no more nodes (ie we're at first node), switch first and last
                if (prev == null)
                {
                    var newFirst = _last;
                    var newLast = _first;
                    _first = newFirst;
                    _last = newLast;
                    break;
                }
            }

        }
        public int getKthFromTheEnd(int k)
        {

            if (k > _size || k <= 0)
                throw new NullReferenceException(); ;
            //use 2 pointers k-1 spaces apart
            //move both forward until the 1st is at the end
            var kMark = _first;
            var endMark = _first;
            //move leader k distance apart
            for (var i = 0; i < k - 1; i++)
            {
                endMark = endMark.Next;


            }

            while (endMark != _last)
            {
                endMark = endMark.Next;
                kMark = kMark.Next;

            }
            return kMark.Value;
        }
        public int?[] printMiddle()
        {
            if (_first == null)
                return [null, null]; //instead of throwing exception
            int?[] middleNumbers = new int?[2];
            var midMark1 = _first;
            PracticeNode midMark2 = null; //only needed if list is odd
            var endMark = _first.Next;

            //move endmark up 1 places, move midmark up 1 place.
            //if not at end, move endmark up 1 place. move 2mark up from midmark 
            //if at end, exit and return the number
            //when midmark hits the end, print midMark1
            while (endMark.Next != null)
            {
                midMark2 = null;
                endMark = endMark.Next;
                midMark1 = midMark1.Next;
                if (endMark.Next != null)
                {
                    endMark = endMark.Next;
                    midMark2 = midMark1.Next;
                }
            }
            middleNumbers[0] = midMark1.Value;

            middleNumbers[1] = midMark2 != null ? midMark2.Value : null;

            return middleNumbers;
        }

    }


}

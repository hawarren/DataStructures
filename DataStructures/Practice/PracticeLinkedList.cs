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
        private PracticeNode _first;
        private PracticeNode _last;

        public class PracticeNode
        {
            public int Value { get; set; }
            public PracticeNode Next { get; set; }
            public PracticeNode(int value)
            {
                this.Value = value;
            }
        }
        public PracticeNode first { get => _first; set => _first = value; }
        public PracticeNode last { get => _last; set => _last = value; }
        private int _size { get; set; }
        public PracticeLinkedList()
        {
        }
        public PracticeLinkedList(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                addLast(i);
            }
        }

        public void addFirst(int newValue)
        {
            PracticeNode newNode = new PracticeNode(newValue);
            if (isEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = this.first;
                this.first = newNode;

            }
            _size++;
        }
        public void addLast(int newValue)
        {
            PracticeNode newNode = new PracticeNode(newValue);
            if (isEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                //point last to new node, then make newnode the last node
                last.Next = newNode;
                last = newNode;
            }
            _size++;

        }
        public void deleteFirst()
        {

            if (isEmpty())
            {
                throw new System.InvalidOperationException("The LinkedList is empty.");
            }
            if (first == last)
            {
                first = last = null;
            }
            else
            {
                //find second value
                //save pointer to second value
                //make second value the first
                var second = this.first.Next;
                first.Next = null;
                this.first = second;
            }
            _size--;
        }
        public void deleteLast()
        {

            if (isEmpty())
            {
                throw new System.InvalidOperationException("The LinkedList is empty.");
            }
            if (first == last)
            {
                first = last = null;
            }
            else
            {
                //find the 2nd to last node
                //delete the last node
                //set last  to prior 2ndToLast value
                var previous = getPrevious(last);
                last = previous;
                last.Next = null;
            }
            _size--;
        }
        private PracticeNode getPrevious(PracticeNode node)
        {
            var current = first;
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
            var startingNode = this.first;

            if (this.first.Value == searchValue)
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
            return first == null;
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
            var current = first;
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
            var current = last;
            var prev = getPrevious(last);
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
                    var newFirst = last;
                    var newLast = first;
                    first = newFirst;
                    last = newLast;
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
            var kMark = first;
            var endMark = first;
            //move leader k distance apart
            for (var i = 0; i < k - 1; i++)
            {
                endMark = endMark.Next;


            }

            while (endMark != last)
            {
                endMark = endMark.Next;
                kMark = kMark.Next;

            }
            return kMark.Value;
        }
        public int?[] printMiddle()
        {
            if (first == null)
                return [null, null]; //instead of throwing exception
            int?[] middleNumbers = new int?[2];
            var midMark1 = first;
            PracticeNode midMark2 = null; //only needed if list is odd
            var endMark = first.Next;

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

        public bool hasLoop()
        {
            if (isEmpty())
                return true;
            var slow = first;
            var fast = first.Next;

            if (slow == fast)
                return true;


            //move slow 1, fast 2, then compare
            //stop when fast reaches slow (ie a loop)
            //stop checking when fast = null (ie it finished the loop)
            for (slow = first; fast != null && fast != slow; slow = slow.Next)
            {

                fast = fast.Next;
                if (fast != null)
                    fast = fast.Next;
                if (slow == fast)
                    return true;
            }
            return false;
        }
        public void AddLoop()
        {
            if (isEmpty())
                return;

            last.Next = first;

        }
        public void RemoveLoop()
        {
            last.Next = null;
        }

    }


}

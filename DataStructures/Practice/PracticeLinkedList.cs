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
        public PracticeNode first { get; set; }
        public PracticeNode last { get; set; }
        public PracticeLinkedList()
        {
        }

        public void addFirst(int newValue)
        {
            PracticeNode newNode = new PracticeNode(newValue);
            newNode.Next = this.first;
            this.first = newNode;
        }
        public void addLast(int newValue)
        {
            PracticeNode newNode = new PracticeNode(newValue);
            if (this.last != null)
            {
                //point last to new node, then make newnode the last node
                this.last.Next = newNode;

            }
            else
            {
                this.first.Next = newNode;
            }
            this.last = newNode;

        }
        public void deleteFirst()
        {
            //find second value
            //save pointer to second value
            //make second value the first
            var newFirst = this.first.Next;
            this.first = newFirst;
        }
        public bool contains(int value)
        {
            bool isFound = false;
            var startingNode = this.first;
            if (this.first.Value == value || this.last.Value == value)
                isFound = true;
            while (startingNode.Next != null)
            {
                startingNode = startingNode.Next;
                if (startingNode.Value != value)
                {
                    continue;
                }
                else
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }
        public int indexOf(int searchValue)
        {
            int index = -1;
            var startingNode = this.first;
                index++;
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
    }

    public class PracticeNode
    {

        public PracticeNode(int value)
        {
            Value = value;
            Next = null;
        }
        public int Value { get; set; }
        public PracticeNode Next { get; set; }
    }
}

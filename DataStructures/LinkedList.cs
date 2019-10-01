using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LinkedList
    {
        //this linked list will be a group of objects within the LinkedList object. Each LinkedListItem node will have a value, and a pointer to the next item.
        //Upon initialization, there will be no firstItem. The firstItem will automatically be the first node.
        //The firstItem is just an arbitrary item chosen as the "first" for access purposes. It can be changed at any time, to any item contained within the linkedList.
        //if the firstItem is removed, a new firstItem (the next item in the linkedlist) will be set by default.
        //this object has: addItem method, removeItem method, findItem method, and lastItem method.


        public int length { get; set; }
        public node head = null;

        public node firstItem { get; set; }
        //each item has a value, and a pointer to the next value
        internal class Node
        {
            internal int data;
            internal Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
            }
    }
    //public string thisItem { get; set; }
    //public string nextItem { get; set; }

    internal class SingleLinkedList {
        internal Node next;
    }
}


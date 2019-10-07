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
        public Node head = null;

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
        public void addNode(int newData)
        {
            if (head == null)
            {
                head = new Node(newData);
            }
            else
            {

            Node currentNode = head;
            while (currentNode.next != null)
            {
                //make the next value of the currentnode into the current node itself
                currentNode = currentNode.next;
            }
            Node newNode = new DataStructures.LinkedList.Node(newData);
            currentNode.next = newNode;
            }

        }
        public void printNodes()
        {
            Node currentNode = head;
            do
            {
                Console.WriteLine("First number is " + printNode(currentNode));
                currentNode = currentNode.next;

            }
            while (currentNode.next != null);
            Console.WriteLine("The last number is " + printNode(currentNode));

        }
        public int printNode(Node toPrint)
        {
            return toPrint.data;
        }

    }
}


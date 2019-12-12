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
        public int nodeLength = 0; //counter to keep track of the total length

        //each item has a value, and a pointer to the next value
        internal class Node
        {
            internal string data;
            internal Node next;
            public Node(string d)
            {
                data = d;
                next = null;
            }
        }
        //adds to the end of the linkedlist
        public void addNode(string newData)
        {
            if (head == null)
            {
                //if node added would be the only node
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
                nodeLength++;
            currentNode.next = newNode;
            }

        }
        public void addHead(string newData)
        {
            //get the head, create new node with pointer to old head, then assign that node to new head
            Node newHead = new Node(newData);
            newHead.next = head;
            head = newHead;

        }
        //remove Node at specified index
        public void removeNode(int index)
        {

            //traverse the node up to the the specified index (grab that and the prior)
            Node currentNode = head; //grab the head of the linkedlist
            Node tempNode = null;
            for (int i = 0; i < index; i++)
            {
                tempNode = currentNode; //this is the node pointing to the next node we want to delete
                currentNode = currentNode.next;
            }

            tempNode.next = currentNode.next; //save the next pointer for the deleted node
            currentNode = tempNode;
            tempNode = null;



        }

        public void printNodes()
        {
            Node currentNode = head;
            Console.WriteLine("The first number is " + printNode(currentNode));
            currentNode = currentNode.next;
            while (currentNode.next != null)
            {

                Console.WriteLine("The next number is " + printNode(currentNode));
                currentNode = currentNode.next;

            }
            Console.WriteLine("The last number is " + printNode(currentNode));

        }
        public string printNode(Node toPrint)
        {
            return toPrint.data;
        }

    }
}


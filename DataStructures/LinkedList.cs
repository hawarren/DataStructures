using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /*
     Mosh Coding Challenge:
     Build a linkedlist with: addFirst(), addLast(), deleteFirst(), deleteLast(), contains(), indexOf()
         */
    public class hwLinkedList
    {

        private class Node
        {
            public int? data { get; set; }
            public Node next { get; set; }

            public Node(int newData)
            {
                data = newData;
                next = null;
            }
        }
        private Node first { get; set; }
        private Node last { get; set; }
        public hwLinkedList()
        {
            first = null;
            last = null;
        }
        public hwLinkedList(int data)
        {
            first = new Node(data);
            last = null;
        }


        public bool isEmpty()
        {
            if (first == null)
                return true;
            else
                return false;
        }
        public void addFirst(int data)
        {
            Console.WriteLine("\r\nAdding {0} to the head of the linkedlist", data);
            if (isEmpty())
            {
                first = new Node(data);
                last = first;
            }
            else
            {
                Node newFirst = new Node(data);
                var trav = first;
                newFirst.next = first; // attach the head to the new first node
                first = newFirst;//the new node is now the head
            }
        }
        public void addLast(int data)
        {
            Console.WriteLine("\r\nAdding {0} to the end of the linkedlist", data);
            if (!isEmpty())
            {
                var trav = first;
                Node newNode = new Node(data);
                while (trav.next != null)
                {
                    trav = trav.next;
                }
                trav.next = newNode;//attach it at the end
                last = trav.next; //update our last node
            }
            else
                addFirst(data);

        }
        public void deleteFirst()
        {
            Console.WriteLine("\r\ndeleting {0} from the head of the linkedlist", indexOf((int)first.data));
            if (!isEmpty())
            {
                first = first.next; //overwrite the old first with the next node in the chain
            }
            else
                Console.WriteLine("Linkedlist is already empty");
        }
        public void deleteLast()
        {
            if (!isEmpty())
            {
                Console.WriteLine("\r\ndeleting {0} (index {1}) from the end of the linkedlist", last.data, indexOf((int)last.data));
                Node trav = getPrevious(last);

                trav.next = null; //we're at the 2m end, delete that value
                last = trav;

            }
        }
        public bool contains(int data)
        {
            Node trav = first;
            while (trav != null && trav.data != data)
            {
                trav = trav.next;
            }
            if (trav == null)
            {
                return false; //we reached the end without finding our value
            }
            else
                return true;
        }
        /*
         traverse the linkedlist starting from head
         -if the current value is not the one we want, move to the next and increment counter

             */

        public int indexOf(int data)
        {
            Node trav = first;
            int index = -1;
            int counter = -1; //will increment every time we move through linkedlist
            while (trav != null) //go until we reach the value or reach the end
            {
                counter++; //we're checking the next index
                if (trav.data != data)
                {
                    trav = trav.next;
                }
                else
                {
                    index = counter;
                    break;//we found our value so let's get out of the loop
                }
            }
            if (index == -1) //should probably throw an exception here
                Console.WriteLine("Value {0} not located in this linkedlist", data);

            return index;
        }
        private Node getPrevious(Node node)
        {
            var trav = first; //set trav to the first node
            if (first != node)
            {
                while (trav.next != node)
                {
                    if (trav == null)
                        throw new System.Data.DataException();
                    trav = trav.next;
                }
            }
            return trav; //we're just before the node we want to remove


        }
        public void printNodes()
        {
            if (!isEmpty())
            {

                Node currentNode = first;
                if (first != last)
                {
                    while (currentNode != last)
                    {

                        Console.WriteLine("The number at index {0} is {1}, ", indexOf((int)currentNode.data), printNode(currentNode));

                        currentNode = currentNode.next;
                    }
                    Console.WriteLine("The last number is at index {0} and value is {1}", indexOf((int)currentNode.data), printNode(currentNode));

                }
                else
                {
                    Console.WriteLine("The first, last, and only number is" + printNode(currentNode));
                }
            }

        }
        private int printNode(Node toPrint)
        {
            return (int)toPrint.data;
        }
        /* Exercise (16): Reversing a linked list
         * solution "create" a linkedlist by borrowing the head of the original list to be the tail
         * , use 2 markers to hold the newtail (what was the old head) and the new head (the next item in the linkedlist)
         * set first to last (this is the last time we touch the new "last node"
         * set trav1 = first
         * set trav2 first.next (save the node for when the link is broken
         * set trav1.next to first
         * set first to trav1
         * set trav1 to trav2 (move up a node)
         * when trav2.next is null, stop and declare
            */
        public void reverse()
        {
            Node trav1 = first;
            Node trav2 = first; //move up for later
            last = first; //the head is the new tail of our reversed linked list

            while (trav1 != null) //stop iterating when there isn't another node to move on to
            {
                if (trav2 != null) //trav 2 reaches end 1 round before trav1
                    trav2 = trav2.next; //move up for later
                trav1.next = first; //link to head
                first = trav1; //new head
                trav1 = trav2; // move up to our saved spot
            }
        }




    }







    /*
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
*/
}


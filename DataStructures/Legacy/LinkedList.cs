using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Legacy
{
    /*
     Mosh Coding Challenge:
     Build a linkedlist with: addFirst(), addLast(), deleteFirst(), deleteLast(), contains(), indexOf()
         */
    public class hwLinkedList
    {

        public class Node
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
            {
                Console.WriteLine("\r\nWarning: The list is empty");
                return true;
            }
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
            Console.WriteLine("\r\ndeleting {0} from the head of the linkedlist", (int)first.data);
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
                while (trav.next != node && trav.next != last)
                {
                    if (trav == null)
                        throw new System.Data.DataException();
                    trav = trav.next;
                }
            }
            else
            {
                return first; //there's only 1 node so first is also the last

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
            if (isEmpty())
            {
                return;
            }
            Node previous = first; //previous is the node we'll be attaching behind
            Node current = first.next; //move up for later (first link to be changed is doing the 2nd node and pointing to first


            while (current != null) //stop iterating when there isn't another node to move on to
            {
                //trav 2 reaches end 1 round before trav1

                Node next = current.next; //move up for later (need to do it before we break that link)
                current.next = previous; // connect to the previous node (this will be the temporary head right now)
                previous = current; // current become the new prior node (basically the temporary head)
                current = next; //the new current node is the placeholder that we made to keep going; (basically the new head of the original (unreversed but broken) linkedlist
            }
            last = first; //the head's data will become the new tail data of our reversed linked list
            last.next = null; //clean up the new tail, it still had the old head's pointer
            first = previous; //finished reversing, make sure to take care of the next

            //second approach. smh just call add first to all
        }
        /*Get kthFromtheEnd(k) : Get the kth value from the end in only 1 pass
         * solution: use 2 pointers, k-1 nodes apart (it's k-1 because the last pointer is on the last node, not after that
         *
         */

        public Node getKthFromtheEnd(int k)
        {
            if (!isEmpty())
            {
                Node trav1 = first;
                Node trav2 = first;
                for (int i = 0; i < k; i++) //move trav 2 up k-1 times
                {
                    trav2 = trav2.next;
                    if (trav2 == null)   //stop if trav2 reaches the end of the LL, because the LL is less than K nodes long
                    {
                        throw new ArgumentException("k is larger than linkedlist size", "trav2");

                    }
                }
                while (trav2 != last)
                {
                    trav2 = trav2.next; //move over 1
                    trav1 = trav1.next; //move over 1 to stay k-1 distance away from trav2
                }

                Console.WriteLine("The {0} Node from the end is {1}", k, (int)trav1.data);
                return trav1; //in case we need to pass it to another variable
            }
            else
                throw new ArgumentOutOfRangeException("value is higher than this list length", "getKthFromtheEnd");

        }

        /*
         20. Exercise: Find the middle of a linkedlist in one pass. If the list has an even number of nodes, there would be 2 middle nodes. (Note: Assume that you don't know the size ahead of time)
            Solution: use 2 pointer, make 1 go 1 node at a time, but the other go 2 nodes at a time.
            When the fast pointer reaches the end and tries (and fails to jump 2), the slow node is moved up and that's the middle value (the slow pointer will have moved 1 more time than the fast pointer)
            If the fast pointer's last jump only goes up  1 node, the slow pointer moves 1, but the middle is also the next 1
            if the middle pointer can only move up 1, the the
         */
        public void PrintMiddle()
        {
            if (!isEmpty())
            {
                Node trav1 = first; //Start both nodes at the first index
                Node trav2 = first;
                int? firstMiddle = null;
                int? secondMiddle = null; //there will be at most 2 middle values

                while (trav2.next != null)//stop when trav2 can't jump forward 2 nodes
                {
                    trav2 = trav2.next;
                    if (trav2.next != null)
                    {
                        trav2 = trav2.next; //jump 2nd time if possible
                    }
                    trav1 = trav1.next; //jump 1
                    //jump 2
                }

                firstMiddle = (int)trav1.data; //middle always has at least 1 value
                if (trav2.next != null)
                {
                    secondMiddle = (int)trav1.next.data;// because the list is even numbered so it has 2 middle values
                    Console.WriteLine("The middle values are {0} and {1}", firstMiddle, secondMiddle);
                }
                else
                {
                    Console.WriteLine("The middle value is  {0}", firstMiddle);
                }
            }

        }


        //this method breaks my linkedlist by adding a loop to it (connect the last node to the loopIndex node
        public void createLoop(int loopIndex)
        {
            Node loopNode = first;
            last.next = getKthFromtheEnd(loopIndex); //link the end to some other node to create a loop
            Console.WriteLine("\r\n Adding a loop from the last to the {0} node", indexOf((int)last.next.data));

        }
        /*Check if a linkedlist has a loop
         */
        public bool hasLoop()
        {
            Node trav1 = first;
            Node trav2 = first;
            bool hasLoop = false;
            while (trav2 != null)
            {
                trav1 = trav1.next; //move up a step
                trav2 = trav2.next;
                if (trav2 != null)
                    trav2 = trav2.next;
                if (trav1 == trav2)
                {
                    hasLoop = true; //the nodes ended up at the same place, should be impossible unless 1 is caught in a loop
                    return hasLoop;
                }
            }
            return hasLoop;
        }
    }
}


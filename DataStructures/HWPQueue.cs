using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class hwPQueue
    {
        /*Challenge: create a priority queue
         * Each inserted item needs to go in order from highest to lowest
         *
         */
        //ArrayQueue
        //enqueue
        //dequeue
        //peek
        //isEmpty
        //isFull

        public hwPQueue(int size)
        {
            arrayQueue = new int?[size];
            head = 0;
            tail = 0;
        }
        private int?[] arrayQueue { get; set; }

        private int internalSize { get; set; }
        private int head { get; set; }
        private int tail { get; set; } //last value before null or end

        public bool isEmpty()
        {
            if (internalSize != 0)
                return false;
            else return true;
        }
        private bool isFull()
        {
            if (internalSize == arrayQueue.Length)
                return true;
            else return false;
        }
        public void enqueue(int data)
        {
            if (!isFull())
            {
                int i;
                int newSpot = tail+1; //starting point of newspot
                if (isEmpty())
                {
                    arrayQueue[head] = data; //simplify this, relic of normal queue structure
                    internalSize++;
                    return; //adding first item to empty queue, tail stays 0 (and tail = head)
                }
                //if not empty,instead of inserting at end, first compare to the tail, then move each higher item up
                //until insertion point is reached.
                //when we reach the head, move it over and then assign it to the spot
                while (data < arrayQueue[newSpot-1])//go from tail to the head, may wrap around queue
                {
                    arrayQueue[(newSpot ) % arrayQueue.Length] = arrayQueue[newSpot-1]; //move higher value over
                    if (head == newSpot)
                        break; //we're at head, don't move over past the head, leave the loop
                    if (newSpot > 0)
                        --newSpot; //decrement so we can try the next cell compare
                    else
                        newSpot = arrayQueue.Length - 1;//if we reach the 0 index, wrap around Queue to last index in array;

                }
                if(head==newSpot)
                {
                    arrayQueue[newSpot+1] = data; //we found our insertion point (possibly at head), add data here


                }
                else
                {

                arrayQueue[newSpot] = data; //we found our insertion point (possibly at head), add data here
                }
                tail = (tail + 1) % arrayQueue.Length; //move right a spot, wrap around to front of array if at end
                ++internalSize; //increment the count of items in the queue
            }
            else
            {
                Console.WriteLine("Sorry the queue is full");
            }
        }
        public int dequeue()
        {
            if (!isEmpty())
            {
                var removedItem = arrayQueue[head];
                arrayQueue[head] = null;
                internalSize--;

                head = (head + 1) % arrayQueue.Length; //move head to new first in line
                return (int)removedItem;
            }
            else throw new System.IndexOutOfRangeException("value is higher than this list length");
        }
        public int peek()
        {
            if (!isEmpty())
            {
                return head;
            }
            else throw new System.IndexOutOfRangeException("List is empty");
        }

    }
}

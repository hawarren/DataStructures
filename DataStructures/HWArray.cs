using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /*this dynamic array should support
     * creation, insert(),removeAt(someIndex), isEmpty()
    */
    class HWArray
    {

        private int?[] internalArray { get; set; } //allow null values
        private int internalSize { get; set; }
        int lastIndex { get; set; }
        private bool isEmpty { get; set; }

        public HWArray()
        {
            internalArray = new int?[1];
            internalSize = 0;
            lastIndex = 0;

        }
        public void print()
        {
            for (int h = 0; h < internalSize; h++)
            {
                Console.WriteLine(internalArray[h]);
            }
        }
        public void insert(int newvalue)
        {

            internalArray[lastIndex] = newvalue;
            internalSize++;
            lastIndex++;

            if (internalSize == internalArray.Length)
            {
                int?[] bigArray = new int?[internalSize * 2]; //new array double the array size
                for (int j = 0; j < internalArray.Length; j++)
                { bigArray[j] = internalArray[j]; }

                internalArray = bigArray;
            }


        }


        public void removeAt(int thisIndex)
        {
            if (thisIndex < internalSize)
            {
                int? tempDeleted;
                tempDeleted = internalArray[thisIndex];
                internalArray[thisIndex] = null;
                for (int i = 0; i < internalSize -1; i++)
                {
                    if (internalArray[i] == null)
                    {
                        internalArray[i] = internalArray[i + 1];

                        internalArray[i + 1] = null;
                    }

                }
                --internalSize;
                --lastIndex;
                Console.WriteLine("removed {0}", tempDeleted);
            }
            else
            {
                Console.WriteLine("That index was out of bounds, dude");
            }
        }
        public void indexOf(int item)
        {
            int thisIndex =-1;
            for (int i = 0; i<internalSize; i++)
            {

                if (internalArray[i] == item)
                {
                    thisIndex = i;
                    i = internalSize;

                }
            }
                if (thisIndex == -1)
                {
                    Console.Write("Could not find this item in the array");
                }
                else
                Console.WriteLine("The index of {0} is {1}", item, thisIndex);
        }
        /*
         * Array Exercise 1
         Extend the Array class and add a new method to return the largest number. What is the runtime complexity of this method reverse the array.
         */
         //This method takes O(n) time to run, because it needs to iterate through the entire array to compare each item to the current largest value
        public int max()
        {
            int? largest = -1;
            //select the 1st value as the largest, then iterate, switching out new largest values if found
            for (int i = 0; i < internalSize; i++)
            {
                if (internalArray[i] > largest)
                {
                    largest = internalArray[i];
                }
            }
                return (int)largest;
        }


    }




}


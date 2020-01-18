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
        //int lastIndex { get; set; }
        private bool isEmpty { get; set; }

        public HWArray()
        {
            internalArray = new int?[1];
            internalSize = 0;
            // lastIndex = 0;

        }
        public HWArray(int size)
        {
            internalArray = new int?[size];
            internalSize = 0;
            // lastIndex = 0;

        }
        public HWArray(int[] newArray)
        {
            internalArray = new int?[newArray.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                this.insert(newArray[i]);
            }

        }

        public void print()
        {
            for (int h = 0; h < internalSize; h++)
            {
                Console.Write(internalArray[h]);
                if (h+1 != internalSize)
                    Console.Write(", ");
            }
        }
        public void insert(int newvalue)
        {
            if (internalSize == internalArray.Length)
            {
                int?[] bigArray = new int?[internalSize * 2]; //new array double the array size
                for (int j = 0; j < internalArray.Length; j++)
                { bigArray[j] = internalArray[j]; }

                internalArray = bigArray;
            }
            if (internalSize < internalArray.Length)
            {
                internalArray[internalSize] = newvalue;
                internalSize++;

            }



        }
        public int sizeOf()
        {
            if (internalSize > 0)
                return internalSize;
            else return -1;
        }


        public void removeAt(int thisIndex)
        {
            if (thisIndex < internalSize)
            {
                int? tempDeleted;
                tempDeleted = internalArray[thisIndex];
                internalArray[thisIndex] = null;
                for (int i = 0; i < internalSize - 1; i++) //stop 1 before last index
                {
                    if (internalArray[i] == null)
                    {
                        internalArray[i] = internalArray[i + 1];

                        internalArray[i + 1] = null;
                    }

                }
                --internalSize;

                Console.WriteLine("removed {0}", tempDeleted);
            }
            else
            {
                Console.WriteLine("That index was out of bounds, dude");
            }
        }
        public int? indexAt(int thisIndex) // gets the value at a given index
        {
            if (thisIndex < internalSize)
                return (int)internalArray[thisIndex];
            else return null;
        }
        public int indexOf(int item) //returns the index (location) of a given value
        {
            int thisIndex = -1;
            for (int i = 0; i < internalSize; i++)
            {

                if (internalArray[i] == item)
                {
                    thisIndex = i;
                    i = internalSize;

                }
            }
            //if (thisIndex == -1)
            //{
            //    Console.Write("\r\nError:Could not find this item in the array");
            //}
            //else
            //    Console.WriteLine("\r\nThe index of {0} is {1}", item, thisIndex);

            return thisIndex; //-1 if the value isn't in this array
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
        /*Extend the array class and add a method to return the common items in this array and another array.*/
        /*This method runs in O(n*m) time, where n is the size of the first array and M is the size of the second array)
         */
        public HWArray intersect(HWArray secondArray)
        {
            HWArray commonArray = new HWArray();
            //make commonArray as big as the larger of the 2 arrays
            if (internalSize < secondArray.sizeOf())
            {

                commonArray = new HWArray(secondArray.sizeOf());
            }
            else
            {
                commonArray = new HWArray(internalSize);
            }

            for (int i = 0; i < internalSize; i++)
            {
                if (secondArray.indexOf((int)internalArray[i]) != -1)
                {
                    commonArray.insert((int)internalArray[i]);


                }
            }


            return commonArray;
        }



    }




}


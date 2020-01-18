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
            Console.Write("\r\nThe array is as follows:");
            for (int h = 0; h < internalSize; h++)
            {
                Console.Write(internalArray[h]);
                if (h + 1 != internalSize)
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

        /*3-Extend the Array class and add a method to reverse the array. For example, if the array includes [1,2,3,4], after reversing and printing it, we should see [4,3,2,1].
         * Solution Array.reverse()
         * Sort in place: Starting at index 0, swap with value at array.length
         * The space complexity is O(n) linear time if swapping the values
         * The time complexity is O(n) linear time as well
         */
        public void reverse()
        {
            int swapper;
            for (int i = 0; i < internalSize / 2; i++)
            {
                swapper = (int)internalArray[(internalSize - 1) - i]; //save the value before taking it out, internalsize index is null, so 1 before that 1
                internalArray[(internalSize - 1) - i] = internalArray[i]; //put the first value in place of the vacated last value
                internalArray[i] = swapper; //take the last value and put in place of the vacated first value
            }
            print();
        }
        /*4- Extend the array class and add a new method to insert an item at a given index
         * Solution: move item at internalsize -1 to internal size, and then the move the next, if we reach the insertion index, add the value
         */
        public void insertAt(int item, int index)
        {
            if (index < internalSize)
            {
                Console.Write("\r\nInserting {0} at index {1} ", item, index);

                for (int i = internalSize; i > index; i--)//start at end of array and work backwards, moving each index value to the right
                {
                    internalArray[i] = internalArray[i - 1];

                }
                internalArray[index] = item; //once we've made room, add the item
                internalSize++; //make sure to increment the size once we've added the item
            }
            else
                Console.WriteLine("Can't insert at {0}. This array is only {1} items long!", index, internalSize);
        }
    }




}


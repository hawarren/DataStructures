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
            for (int h = 0; h <= internalSize; h++)
            {
                Console.WriteLine(internalArray[h]);
            }
        }
        public void insert(int newvalue)
        {

            internalArray[lastIndex] = newvalue;
                    internalSize++;
            lastIndex++; 
            
                /*if (internalArray[i] != null)
                {
                    continue;

                }
                else if (internalArray[i] == lastIndex)
                {
                    internalArray[i] = newvalue;
                    i = internalArray.Length;

                    
                }
                */




            
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
                for (int i = 0; i < internalSize; i++)
                {
                    if (internalArray[i] == null)
                    {
                        internalArray[i] = internalArray[i + 1];

                        internalArray[i+1] = null;
                    }

                }
                internalSize--;
                lastIndex--;
                Console.WriteLine("removed {0}", tempDeleted);
            }
            else
            {
                Console.WriteLine("That index was out of bounds, dude");
            }
        }
    }




}


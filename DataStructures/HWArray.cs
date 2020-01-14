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
        private bool isEmpty { get; set; }

        public HWArray()
        {
            internalArray = new int?[1];
            internalSize = 0;


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


            for (int i = 0; i <= internalArray.Length - 1; i++)

            {
                if (internalArray[i] != null)
                {
                    continue;
                    
                }
                else if (internalArray[i] == null)
                {
                    internalArray[i] = newvalue;
                    i = internalArray.Length;

                    internalSize++;
                }




            }
                    if (internalSize == internalArray.Length)
                    {
                        int?[] bigArray = new int?[internalSize * 2]; //new array double the array size

                        for (int j = 0; j < internalArray.Length; j++)
                        { bigArray[j] = internalArray[j]; }

                        internalArray = bigArray;
                    }


        }
    }




}


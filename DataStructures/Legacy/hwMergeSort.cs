using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Legacy
{
    class hwMergeSort
    {
        /*
         binary sort starts at middle of array
         sets midpoint m and compares the searchvalue with the midpoint
         if m == searchvalue that's the value
         if m < searchvalue, search left (set midpiont of l to m-1, and set
         if m > searchvalue search rght (set l to be m+1)
         */

        //mergesort uses a merge() and a mergesort. Mergesort calls itself twice recursively, for the left array and the right side of the array
        //it then calls merge() after the 2 recursive calls come back.
        //given an array,
        //find the midpoint (m) of the array
        //create 2 arrays: a left array from "l" to m, and m to r
        //recursively run mergesort on the left array and then the right array

        //For the merge, loop through both the left and right arrays and compare values
        //add the lowest value to the mergesorted array
        //when the end of 1 of the arrays is reached, then add the remaining values to the mergesorted array
        public void MergeSort(int[] arr, int l, int r)
        {
            //get the midpoint, left, and right index of the array
            ; //left index is NOT always 0
            if (l < r)
            {
                int m = (l + r) / 2; // midpoint of this array
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r); //sort the right array
                merge(arr, l, m, r); //the merge combines the 2 arrays in sorted order
            }


        }

        //this method splits the array into 2 arrays, then uses a double for loop to compare values and add to a new array
        public void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1; //length of the left side of the array
            int n2 = r - m; //the right length
            int[] lArray = new int[n1]; //to hold split arrays
            int[] rArray = new int[n2];


            int k = l; //to iterate merged array, start at the low index

            int i = 0; int j = 0;


            for (int ii = 0; ii < n1; ii++)//populate the larray
            { lArray[ii] = arr[l + ii]; }
            for (int jj = 0; jj < n2; jj++)//populate the rArray
            { rArray[jj] = arr[m + 1 + jj]; }
            //right array starts 1 over from the middle,increment starting there
            while (i < n1 && j < n2)//keep running until one of the split arrays runs out of cells
            {
                //if left array is greater or equal, add it to the new array. Else add the rarray index and move to the next index
                if (lArray[i] <= rArray[j])
                {
                    arr[k] = lArray[i];
                    i++;

                }
                else
                {
                    arr[k] = rArray[j];
                    j++;
                }
                k++;



            }
            while (i < n1) //add the leftovers from this array (only one of the arrays will be empty)
            {
                arr[k] = lArray[i];
                k++;
                i++;
            }
            while (j < n2)
            {
                arr[k] = rArray[j];
                k++;
                j++;
            }



        }

    }
}

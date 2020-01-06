﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class hwMergeSort
    {
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
            int n1 = m -l+1; //length of the left side of the array
            int n2 = r-m; //the right length
            int[] lArray = new int[n1]; //to hold split arrays
            int[] rArray = new int[n2];

            int[] mergedArray = new int[n1 + n2]; //placeholder for merged array
            int k = l; //to iterate merged array, start at the low index



            for (int ii = 0; ii < m; ii++)
                lArray[ii] = arr[ii];
            for (int jj = 0; jj < r; jj++)
                rArray[jj] = arr[m + 1 + j]; //right array starts at the middle plus 1, but it's 0 indexed in the new rArray
            int i = 0; int j = 0;
            while (i < n1 && j < n2)//keep running until one of the split arrays runs out of cells
            {
                //if left array is greater or equal, add it to the new array. Else add the rarray index
                if (lArray[i] >= rArray[j])
                {
                    mergedArray[k] = lArray[i];
                    i++;
                    k++;
                }
                else {
                    mergedArray[k] = rArray[j];
                    j++;
                    k++;
                }

                while (i < n1) //add the leftovers from this array (only one of the arrays will be empty)
                {
                    mergedArray[k] = lArray[i];
                    k++;
                }
                while (j < n2)
                {
                    mergedArray[k] = rArray[k];
                    k++;
                }

            }




        }

    }
}

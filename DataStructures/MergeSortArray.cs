using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MergeSortArray
    {
        public MergeSortArray()
        {

        }

        public void MergeSort(int[] arrayToSplit, int left, int right)
        {
            if (left < right) //ie the array is size 2, has a separate left and right side
            {
                int mid = (left + right) / 2; // Find the midpoint of the array
                MergeSort(arrayToSplit, left, mid); // recursively sort the left half
                MergeSort(arrayToSplit, mid + 1, right); //recursively sort the right half
                Merge(arrayToSplit, left, mid, right); //combine the sorted blocks in proper order

            }
        }

        public void Merge(int[] arrayToSort, int leftSide, int mid, int rightSide)
        {
            int lLength = mid - leftSide + 1; // length of the left side of the array
            int rLength = rightSide - mid; // length of the right side

            int[] lArray = new int[lLength];
            int[] rArray = new int[rLength];

            int k = leftSide; //to iterage the merged array, start at the lowest index
            int i = 0;
            int j = 0;

            for (int ii = 0; ii < lLength; ii++)
            {
                lArray[ii] = arrayToSort[leftSide + ii];
            }
            for (int jj = 0; jj < rLength; jj++)
            {
                rArray[jj] = arrayToSort[mid + 1 + jj]; //adjust for 1 off the midpoint, 
            }

            //right array starts 1 off from the middle
            while (i < lLength && j < rLength) //keep running until either one of the split arrays runs out of cells
            {
                if (lArray[i] <= rArray[j]) //if left element is smaller or equal to right element
                {
                    arrayToSort[k] = lArray[i];
                    i++; //compare next left to same right
                }
                else
                {
                    arrayToSort[k] = rArray[j]; //right side is smaller
                    j++;
                }
                k++; // next cell to be populated (by either left or right)
            }
            while (i < lLength)
            {
                arrayToSort[k] = lArray[i];
                i++; //fill up array with remaining left side
                k++;
            }
            while (j < rLength)
            {
                arrayToSort[k] = rArray[j]; //fill up array from leftover right side
                j++;
                k++;
            }
        }

    }
}

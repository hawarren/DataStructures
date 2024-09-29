﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures.Practice
{
    public class PracticeArray
    {
        public PracticeArray(int arraySize)
        {
            _internalArray = new int[arraySize];
            _itemsCount = 0;
        }
        //create internal array
        private int[] _internalArray;
        private int _itemsCount;


        public int insert(int newItem)
        {
            int newIndex = 0;
            if (isFull())
            {
                _internalArray = resizeArray();

            }


            if (_internalArray[_itemsCount] == 0)
            {
                _internalArray[_itemsCount] = newItem;
                newIndex = _itemsCount;
                _itemsCount++;
            }

            return newIndex;
        }
        public int removeAt(int indexToRemove)
        {
            var deletedNumber = 0;
            if (_internalArray.Length > indexToRemove)
            {
                deletedNumber = _internalArray[indexToRemove];
                _internalArray[indexToRemove] = 0;
                _itemsCount--;

                repackArrayAfterRemove(indexToRemove);
            }
            return deletedNumber;
        }
        //return -1 if not found
        public int IndexOf(int itemToFind)
        {
            var index = -1;
            for (var i = 0; i < _internalArray.Length; i++)
            {
                if (_internalArray[i] == itemToFind)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void print()
        {
            Console.WriteLine("Here is the array");

            for (var i = 0; i < _itemsCount; i++)
                if (_internalArray[0] != 0)
                {
                    Console.WriteLine("The index {0} : {1} ", i, _internalArray[i]);
                }
        }
        private void repackArrayAfterRemove(int deletedIndex = 0)

        {
            for (var i = deletedIndex; i < _itemsCount; i++)
            {
                _internalArray[i] = _internalArray[i + 1];
                _internalArray[i + 1] = 0;
            }
        }

        private int[] resizeArray()
        {
            //double the size when full
            int multiplier = 2;
            

            int[] newArray = new int[_internalArray.Length * multiplier];
            for (int i = 0; i < _internalArray.Length; i++)
            {
                newArray[i] = _internalArray[i];
            }
            return newArray;
        }
        private bool isFull()
        {
            return _internalArray.Length == _itemsCount;
        }

        public int max()
        {
            int higherNumber = 0;
            for (int i = 0; i < _internalArray.Count(); i++) {
                if (_internalArray[i] > higherNumber)
                {
                    higherNumber = _internalArray[i];
                }
            }
            return higherNumber;
        }
    }
}

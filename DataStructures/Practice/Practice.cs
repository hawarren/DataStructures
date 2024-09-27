using System;
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
        for (int i = 0; i < _internalArray.Length; i++)
        {
            if (_internalArray[i] == 0)
            {
                _internalArray[i] = newItem;
                    newIndex = i;
                    _itemsCount++;
                    break;
            }
            else
            {
                continue;
            }
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
                _internalArray = resizeArray();
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

            for (var i = 0; i < _internalArray.Length; i++)
    if (_internalArray[0] != 0)
		{
            Console.WriteLine("The index {0} : {1} ", i, _internalArray[i]); 
        }
    }

    private int[] resizeArray()
    {
        int arrayOffset = 0;
       
                //double the size when full
        int multiplier = 1;
        if (_internalArray.Length == _itemsCount)
        {
            multiplier = 2;
        }

        int[] newArray = new int[_internalArray.Length * multiplier];
        for (int i = 0; i < _internalArray.Length; i++)
        {
            if (_internalArray[i] != 0)
            {
                newArray[i + arrayOffset] = _internalArray[i];
            }
            else
            {
                arrayOffset--;
            }
        }
            return newArray;
       
       
    }
    private bool isFull()
    {
        return _internalArray.Length == _itemsCount;
    }
}
}

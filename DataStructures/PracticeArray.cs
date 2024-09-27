using System;

namespace DataStructures

public class PracticeArray
{
	public PracticeArray(int arraySize)
	{
        _internalArray = new Array(arraySize);
		_itemsCount = 0;
    }
	//create internal array
	private Array _internalArray;
	private int _itemsCount;


	public int insert(int newItem) {
		if (isFull())
		{ 
			_internalArray = resizeArray()
		}
		for (int i = 0; i < _internalArray.Length; i++) {
			if (_internalArray[i] is null)
			{
				_internalArray[i] = newItem;
			}
			else
			{
				continue;
			}
		}
	}
	public int removeAt(int indexToRemove)
    {
    }
	//return -1 if not found
	public int indexOf(int itemToFind)
    {
    }
	public void print()
	{ 
		Console.WriteLine("Here is the array")
			for (var i = 0; i < _internalArray.Length; i++; in _internalArray)
		{
			Console.WriteLine("The index {0} : {1} ", i, _internalArray[i[]);
		}
	}

	private Array resizeArray() {
		int arrayOffset = 0;
		if (_itemsCount == _internalArray.Length)
		{
			//double the size when full
			Array newArray = new Array(_internalArray.Length*2);
			for (int i = 0; i < _internalArray.Length, i++) {
				if (_internalArray[i] is not null)
				{
					newArray[i+arrayOffset] = _internalArray[i];
				}
				else
				{
					arrayOffset--;
				}
				return newArray;
			}
		}
	}
	private bool isFull() {
		return _internalArray.Length == _itemsCount;
	}
}

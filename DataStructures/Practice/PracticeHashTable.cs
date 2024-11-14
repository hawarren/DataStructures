using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticeHashTable
    {
        public PracticeHashTable()
        {
            _InternalArray = new LinkedList<Entry>[5];
        }
        private LinkedList<Entry>[] _InternalArray;
        public void put(int key, string value)
        {
            var newPostion = getEntryPosition(key);
            Entry newEntry = new Entry
            { key = key, value = value };
            LinkedListNode<Entry> newNode = new LinkedListNode<Entry>(newEntry);
            LinkedList<Entry> newList = new LinkedList<Entry>();

            var pointer = newPostion;
            //check if item exists at that position.
            // if not null, check next item
            //if null, put item as position.next
            if (_InternalArray[newPostion] == null)
            {
                newList.AddLast(newNode);
                _InternalArray[newPostion] = newList;
            }
            //check linkedlist at index and look for existing key
            var bucket = _InternalArray[newPostion];
            foreach (var entry in bucket)
            {
                if (entry.key == key)
                {
                    entry.value = value;
                    return;
                }
            }
            //if no key found above, add new entry to the end
            var chainPointer = _InternalArray[newPostion];
            chainPointer.AddLast(newNode);
        }
        public string get(int key)
        {
            var myEntry = _InternalArray[getEntryPosition(key)];
            if (myEntry != null)
            {
                foreach (var entry in myEntry)
                {
                    if (entry.key == key)
                        return entry.value;
                }
            }
            Console.WriteLine($"Unable to locate value for key {key}");
            return null;

        }
        public LinkedListNode<Entry> getNode(int key)
        {
            var headPos = _InternalArray[getEntryPosition(key)];
            var startingNode = headPos.First;
            if (startingNode.Value.key == key)
                return startingNode;
            //check every item starting at linkedlist head for matching key
            while (startingNode.Value.key != key)
            {
                if (startingNode.Value.key != key)
                    startingNode = startingNode.Next;
                else
                {
                    return startingNode;
                }
            }
            return null;
        }
        public Entry remove(int key)
        {
            var index = getEntryPosition(key);
            var bucket = _InternalArray[getEntryPosition(key)];
            if (bucket == null)
            {
                throw new Exception("Item not found");
            }
            foreach (var item in bucket)
            {
                if (item.key == key)
                {
                    bucket.Remove(item);
                    return item;
                }
            }
            throw new Exception("Item not found");

        }


        public int getEntryPosition(int key)
        {
            return Math.Abs(key) % _InternalArray.Length;
        }
        public int mostFrequent(int[] testArray)
        {
            Dictionary<int, int> myDict = new Dictionary<int, int>();
            foreach (var item in testArray)
            { //check if in dictionary, if so then increment value
                //if not then add 1
                if (myDict.TryGetValue(item, out int value))
                {
                    myDict[item] = value + 1;
                }
                else
                {
                    myDict.Add(item, 1);
                }
            }
            //iterate thru keys and check the quantity (value)
            //if value is higher than existing candidate, then replace it
            //otherwise continue
            int candidateKey = testArray[0];
            foreach (var item in myDict.Keys.OrderDescending())
            {
                if (myDict[item] > myDict[candidateKey])
                    candidateKey = item;
            }

            return candidateKey;
        }
        public int countPairsWithDiff(int[] array, int gap)
        {
            //sort array lowest to highest
            //make a dictionary of all possible entry combinations, using array's lower number as key
            Array.Sort(array);
            int pairCount = 0;
            Dictionary<int, int> arrayDictionary = new();
            foreach (var item in array)
            {
                if (!arrayDictionary.TryGetValue(item, out int value))
                {
                    arrayDictionary.Add(item, item + gap);
                }
            }
            //loop thru array and check if item+2 is in the dictionary
            //if present, increment pairCount
            foreach (var item in arrayDictionary.Keys)
            {
                if (arrayDictionary.TryGetValue(item + gap, out int value))
                {
                    pairCount++;
                }
            }


            return pairCount;
        }
        public void twoSum(int[] array, int target)
        {
            Dictionary<int, int> twoSumDictionary = new();
            Dictionary<int, int> indexDictionary = new();
            //make dictionary with key = arrayindex, value = target - arrayindex
            //loop thru array, 
            //if the value at the key is also a key, return that value, else continue
            for (var item = 0; item < array.Length; item++)
            {
                twoSumDictionary.Add(array[item], target - array[item]);
                indexDictionary.Add(array[item], item);
                if (twoSumDictionary.TryGetValue(array[item], out int value))
                {
                    //check if match is there already
                    if (twoSumDictionary.TryGetValue(value, out int value2))
                    {
                        Console.WriteLine($"Found matching values at {indexDictionary[value]} and {indexDictionary[value2]}");
                        return;
                    }
                }
            }
        }

    }
    public class Entry
    {
        public int key;
        public string value;
    }
}

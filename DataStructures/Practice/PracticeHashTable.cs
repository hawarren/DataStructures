using System;
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

    }
    public class Entry
    {
        public int key;
        public string value;
    }
}

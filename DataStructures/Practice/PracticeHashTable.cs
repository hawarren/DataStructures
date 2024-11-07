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
            else
            {
                var chainPointer = _InternalArray[newPostion];
                chainPointer.AddLast(newNode);
            }
        }
        public Entry get(int key)
        {
            var myEntry = getNode(key);

            return myEntry.Value;
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
            var myEntry = getNode(key);
           _InternalArray[getEntryPosition(key)].Remove(myEntry);

            return null;
        }


        public int getEntryPosition(int key)
        {
            return key % _InternalArray.Length;
        }
        
    }
    public class Entry
    {
        public int key;
        public string value;
    }
}

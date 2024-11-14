using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticeHashMap
    {
        private HashEntry[] _internalArray;
        private int _count;
        public PracticeHashMap()
        {
            _internalArray = new HashEntry[5];
        }

        public int getHashLocation(int value)
        {
            var potentialHash = value % (_internalArray.Length - 1);
            return potentialHash;
        }
        public int getByLinearProbe(int value)
        {
            var potentialHash = (value + 1) % (_internalArray.Length);
            return potentialHash;
        }

        //put(int, String)
        public void put(int index, string value)
        {
            if (_count == _internalArray.Length)
                resize();
            var potentialHash = getHashLocation(index);
            while (_internalArray[potentialHash] != null)
            {
                if (_internalArray[potentialHash].key == index)
                {
                    _internalArray[potentialHash].value = value;
                    return;
                }
                //check if we got the original value again, which means we have a loop
                var probeHash = getByLinearProbe(potentialHash);
                if (potentialHash == probeHash)
                {
                    throw new Exception($"hashing loop detected for index {value}");
                }
                else
                {
                    potentialHash = probeHash;
                    if (potentialHash == getHashLocation(index))
                        throw new Exception("loop detected");
                }
            }
            _internalArray[potentialHash] = new HashEntry { key = index, value = value };
            _count++;
        }

        //get(int)
        public string get(int key)
        {
            var potentialHash = findIndex(key);
            return _internalArray[potentialHash].value;
        }
        public int findIndex(int key)
        {
            //check initial hashlocation
            //if has value and key does NOT match, then try linearProbe.
            //repeat linear probing until we reach initial hash location (meaning we checked until we found a loop)
            //if loop found, throw error
            //else when key matches, return the value of that entry
            int potentialHash = getHashLocation(key);
            while (_internalArray[potentialHash] != null)
            {
                if (_internalArray[potentialHash].key == key) //FOUND OUR VALUE
                {
                    return potentialHash;
                }
                //check if we got the original value again, which means we have a loop
                var probeHash = getByLinearProbe(potentialHash);
                if (potentialHash == probeHash)
                {
                    throw new Exception($"hashing loop detected for index {key}");
                }
                else
                {
                    potentialHash = probeHash;
                }
            }

            return -1;
        }

        //remove(int)
        public void remove(int key)
        {
            //get location of item to remove
            //set location to null
            var index = findIndex(key);
            if (index == -1)
                throw new ArgumentOutOfRangeException(key.ToString());
            _internalArray[index] = null;
            _count--;
        }

        //size();
        public int size()
        {
            return _count;
        }
        public void resize()
        {
            HashEntry[] newArray = new HashEntry[_internalArray.Length * 2];
            HashEntry[] tempArray = _internalArray;
            _internalArray = newArray;
            foreach (var item in tempArray)
            {
                if (item != null)
                    put(item.key, item.value);

            }
        }
        public class HashEntry
        {
            public int key;
            public string value;
        }
    }

}

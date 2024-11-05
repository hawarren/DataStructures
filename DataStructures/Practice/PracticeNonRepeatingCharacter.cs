using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticeNonRepeatingCharacter
    {
        string _myString;
        public PracticeNonRepeatingCharacter(string myString)
        { 
        }
        public char CheckForNonRepeat(string mystring)
        {
            Dictionary<char, int?> myDictionary = new Dictionary<char, int?>();
            //add all characters to dictionary
            // increment by 1 for each letter
            foreach (var item in mystring)
            {
                myDictionary[item] = myDictionary.TryGetValue(item, out int? value) ? value + 1 : 1;
            }
            for (var i = 0; i <= mystring.Length; i++)
            {
                if (myDictionary[mystring[i]] == 1)
                    return mystring[i];
                i++;
            }

            return ("").ToCharArray()[0];
        }
    }
}

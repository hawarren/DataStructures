using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    public class PracticeStack
    {
        public PracticeStack()
        { }


        //write a method to check if an expression is balanced
        //if item is [{(< , push onto stack
        //if item is closing >)}] AND the top stack item is the opener, pop from stack
        public bool checkIfBalanced(string str)
        {

            Dictionary<char, char> reference = new Dictionary<char, char>{
                {'[', ']' },
                { '(', ')' },
                { '{', '}' },

            };
            Stack<char> Checker = new();
            if (!string.IsNullOrEmpty(str))
            {
                foreach (var item in str)
                {
                    if (reference.ContainsKey(item))
                    {
                        Checker.Push(item);
                    }
                    else if (reference.ContainsValue(item))
                    {
                        if (reference[Checker.Peek()] == item)
                            Checker.Pop();
                        else return false;
                    }
                }
            }
            return true;
        }

    }
}

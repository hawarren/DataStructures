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
                    if (isRightBracket(reference,item))  //check left brackets
                    {
                        Checker.Push(item);
                    }
                    else if (isLeftBracket(reference,item))
                    {
                        if (Checker.Count == 0)
                            return false;

                        if (bracketsMatch(reference, Checker, item))
                            Checker.Pop();
                        else return false;
                    }
                }
            }
            return Checker.Count == 0;
        }

        public bool isRightBracket(Dictionary<char,char> reference, char item) {
            
            return reference.ContainsKey(item);
        }
        public bool isLeftBracket(Dictionary<char, char> reference, char item)
        {
            return reference.ContainsValue(item);
        }
        public bool bracketsMatch(Dictionary<char, char> reference, Stack<char> Checker, char item) {
            return reference[Checker.Peek()] == item;
        }
    }
}

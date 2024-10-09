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
            PracticeArray referenceLeft = new PracticeArray(['[', '(', '{']);
            PracticeArray referenceRight = new PracticeArray([']', ')', '}']);

            Stack<char> Checker = new();
            if (!string.IsNullOrEmpty(str))
            {
                foreach (var item in str)
                {
                    if (isLeftBracket(referenceLeft, item))  //check left brackets
                    {
                        Checker.Push(item);
                    }
                    else if (isRightBracket(referenceRight, item))
                    {
                        if (Checker.Count == 0)
                            return false;

                        if (bracketsMatch(referenceLeft, referenceRight, Checker, item))
                            Checker.Pop();
                    }
                }
            }
            return Checker.Count == 0;
        }

        public bool isRightBracket(PracticeArray reference, char item)
        {
            return reference.IndexOf((char)item) != -1;
        }
        public bool isLeftBracket(PracticeArray reference, char item)
        {
            return reference.IndexOf((char)item) != -1;

        }
        public bool bracketsMatch(PracticeArray referenceLeft, PracticeArray referenceRight, Stack<char> Checker, char item)
        {
            return referenceLeft.IndexOf(Checker.Peek()) == referenceRight.IndexOf(item) && referenceLeft.IndexOf(Checker.Peek()) != -1;
        }
    }
}

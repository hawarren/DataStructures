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
        {
            _internalArray = new int[1];
            _count = 0;

        }

        private int _count;
        private int[] internalArray;
        private int[] _internalArray { get => internalArray; set => internalArray = value; }
        public int Count { get => _count; set => _count = value; }


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
        public void push(int item) {
            if (_internalArray.Length == Count && Count > 0)
                resizeArray();
            if (_internalArray != null)
            {
                _internalArray[Count] = item;
                Count++;
            }
        }
        public int pop() {
            if (_internalArray == null || Count == 0)
            {                
                return -1;
            }

            var retrievedValue = _internalArray[Count - 1];
            _internalArray[Count - 1] = 0;
            Count--;
            return retrievedValue;

        }
        public void resizeArray()
        {
            int[] bigArray = new int[_internalArray.Length * 2];
            for (var i = 0; i < Count; i++) {
                bigArray[i] = _internalArray[i];
            }
            _internalArray = bigArray;
        }
        public int peek() {
            if (_internalArray == null || Count == 0)
            {
                return -1;
            }
            var retrievedValue = _internalArray[Count - 1];
            return retrievedValue;
        }
        public bool isEmpty()
        {

            return Count <= 0;
        }
        public void printStack() {
            Console.WriteLine("Printing the stack");
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine(_internalArray[i]);
            }
            string resultsString = string.Join(",", _internalArray).Replace("0", "");
            Console.WriteLine(resultsString);
            Console.WriteLine("Stack printed");
        }

    }
}

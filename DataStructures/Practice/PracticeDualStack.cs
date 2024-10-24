using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures.Practice
{
    public class PracticeDualStack
    {
        public PracticeDualStack()
        {
            _internalArray = new int[5];
            _leftCount = 0;
            _rightCount = _internalArray.Length - 1;

        }

        private int _leftCount;
        private int _rightCount;

        private int[] internalArray;
        
        private int[] _internalArray { get => internalArray; set => internalArray = value; }
        public int LeftCount { get => _leftCount; set => _leftCount = value; }
        public int RightCount { get => _rightCount; set => _rightCount = value; }



        public void push1(int item) {
            if (isFull1())
                throw new StackOverflowException("Left stack is full");
           
                _internalArray[LeftCount] = item;
                LeftCount++;
           
        }
        public void push2(int item)
        {
            if (isFull2())
                throw new StackOverflowException("Right stack is full");
            
                _internalArray[RightCount] = item;
                RightCount--;
           
        }
        public int pop1() {
            if (isEmpty1())
            {
                // throw new ArgumentException();
                return -1;
            }

            var retrievedValue = _internalArray[LeftCount - 1];
            _internalArray[LeftCount - 1] = 0;
            LeftCount--;
            return retrievedValue;

        }
        public int pop2()
        {
            if (isEmpty2())
            {
                throw new ArgumentException();
            }

            var retrievedValue = _internalArray[RightCount - 1];
            _internalArray[RightCount - 1] = 0;
            RightCount--;
            return retrievedValue;

        }
       
        public int peek1() {
            if (_internalArray == null || LeftCount == 0)
            {
                throw new Exception("Cannot peek at empty left array");
            }
            
            return _internalArray[LeftCount - 1]; 
        }
        public int peek2()
        {
            if (_internalArray == null || RightCount == _internalArray.Length)
            {
                throw new Exception("Cannot peek at empty right array");
            }

            return _internalArray[RightCount - 1];
        }
        public bool isEmpty1()
        {

            return LeftCount == 0;
        }
        public bool isEmpty2()
        {

            return RightCount == _internalArray.Length-1;
        }
        public void printStack() {
            Console.WriteLine("Printing the stack");
            Console.WriteLine(this.ToString());

        }
        public bool isFull1() {
            return RightCount == LeftCount  ;
        }
        public bool isFull2()
        {
            return LeftCount == RightCount ;
        }
        public override string ToString()
        {
            return string.Join(",", _internalArray).Replace("0", "").Replace(",,","");
        }
        
//        1- Implement two stacks in one array.Support these operations:
//push1() // to push in the first stack
//push2() // to push in the second stack
//pop1()
//pop2()
//isEmpty1()
//isEmpty2()
//isFull1()
//isFull2()
//Make sure your implementation is space efficient. (hint: do not allocate
//the same amount of space by dividing the array in half.)
    }
}

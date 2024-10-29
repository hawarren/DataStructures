using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class StackQueue
    {
        private Stack<int> _headstack;
        private Stack<int> _tailStack;
        public StackQueue() {
            _headstack = new Stack<int>();
            _tailStack = new Stack<int>();
        }
        public void enqueue(int item) {
            _headstack.Push(item);
        }

        public int dequeue() {
            //use pointer, start at 0,
            // pop item from stack and assign to pointer
            //assign pointer to _tailstack;
            //if there's another item on the stack, replace pointer with that item
            //if there's no other item , do not push to tailstack;
            //push all of tail back to head

            var pointer = 0;
            while (isEmpty())
            {
                pointer = _headstack.Pop();
                if (_headstack.Count != 0)
                  _tailStack.Push(pointer);
            }
            while (_tailStack.Count != 0)
            {
                _headstack.Push(_tailStack.Pop());
            }
            return pointer;
        }
        public bool isEmpty() {
            return _headstack.Count == 0;
        }
        public override string ToString()
        {

            return String.Join(",", _headstack.ToArray());
        }
    }
}

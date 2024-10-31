using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticeQueueReverser
    {
        public Queue<int> _oldQueue;        
        public Stack<int> _reversingPad;
        private int _numbersToReverse;
        public PracticeQueueReverser() {
            _oldQueue = new Queue<int>(new[] { 10, 20, 30, 40, 50 });
            _reversingPad = new();
        }

        public Queue<int> reverse(int numbersToReverse) {
            Queue<int> _tempQueue = new();
            for (int i = 0; i < numbersToReverse; i++)
            {
                //dequeue and push first k items onto stack
                //push remainder onto new queue
                //then pop and enqueue stack onto queue
                //dequeue new queue onto queue
                _reversingPad.Push(_oldQueue.Dequeue());
            }
            while (_oldQueue.Count != 0)
            {
                _tempQueue.Enqueue(_oldQueue.Dequeue());
            }
            while (_reversingPad.Count > 0)
                _oldQueue.Enqueue(_reversingPad.Pop());
            while (_tempQueue.Count > 0)
                _oldQueue.Enqueue(_tempQueue.Dequeue());

            return _tempQueue;
        }
        public override string ToString()
        {

            return String.Join(",",_oldQueue);
        }

    }
}

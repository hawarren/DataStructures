using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice
{
    internal class PracticeLinkedListQueue
    {
        PracticeLinkedList _llQueue = new PracticeLinkedList();
        int _count = new int();


        public void enqueue(int item){            
            //add to tail
            _llQueue.addLast(item);
            _count++;
        }
        public int dequeue(){
            //remove from head
            int removeditem = _llQueue.first.Value;
            _llQueue.deleteFirst();
            _count--;
            return removeditem;
        }

        public int peek(){
            return _llQueue.first.Value;
        
        }

        public int size()
        {
            return _count;
        }

    }
}

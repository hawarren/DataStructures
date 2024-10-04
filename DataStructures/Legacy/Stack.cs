using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Legacy
{
    class Stack //implementation using a linkedlist
    {
        public Stack()
        {

            first = null;
        }

        Node first { get; set; }
        class Node
        {
            public Node()
            {
                string data = null;
                next = null;
            }

            public string data { get; set; }
            public Node next { get; set; }
        }
        public void push(string newData)
        {
            char[] charData = newData.ToCharArray(); //convert string to chararray
            for (int i = 0; i < newData.Length; i++)
            {
                if (first == null)
                {
                    first = new Node();
                    first.data = charData[i].ToString();
                    first.next = null;
                }
                else
                {
                    Node newfirst = new Node();
                    newfirst.data = charData[i].ToString();
                    newfirst.next = first;
                    first = newfirst;
                }
            }
        }
        public string pop()
        {
            string popChar = "";
            while (first != null)
            {
                popChar += first.data;
                first = first.next;
            }


            return popChar;

        }

    }
    //method to reverse a string (exercise 5)
    class StringReverser
    {
        public string newString { get; set; }
        public StringReverser(string thisString)
        {
            Stack<char> stack = new Stack<char>();
            char[] charString = thisString.ToCharArray();
            foreach (var item in charString)
            {
                stack.Push(item);
            }
            string newString = "";
            while (stack.Count != 0)
            { newString += stack.Pop(); }
            Console.WriteLine("constructing {0}", newString);

        }


    }


}

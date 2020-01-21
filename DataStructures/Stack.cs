﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
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
                    first = new DataStructures.Stack.Node();
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
}

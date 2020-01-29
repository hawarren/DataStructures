﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class hwTree
    {
        /*Add the following numbers to a binary search tree. Remember, in a binary search tree
         * left < parent
         * right > parent
        */

        public hwTree(int[] initialArray)
        {
            foreach (int item in initialArray)
            {
                addNode(item);

            }


        }
        public class Node
        {
            public int data { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int data)
            {
                this.data = data;
            }
            public override string ToString()
            {
                return "Node=" + this.data.ToString();
            }
        }


        public Node root { get; set; } //the root of our tree


        public void addNode(int newData)
        {
            Node newNode = new Node(newData);
            Node currentNode = root;
            if (root == null)
            {
                root = newNode;
                return;
            }
            else if (currentNode != null) //traverse the node until we reach the parent with a null leaf insertion point
            {
                while (true) //we'll tell it when to break out of the loop
                {
                    if (newData < currentNode.data)
                    {
                        //digLeft();
                        if (currentNode.left == null)

                        {
                            currentNode.left = new Node(newData); //we found our leaf, add it here
                            break;
                        }
                        else
                            currentNode = digLeft(currentNode); //find
                    }


                    if (newData >= currentNode.data)
                    {
                        //digRight();
                        if (currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            break;
                        }
                        else
                            currentNode = digRight(currentNode);
                    }

                }



            }
        }
        public Node digLeft(Node startNode)
        {
            return startNode.left;
        }
        public Node digRight(Node startNode)
        {
            return startNode.right;
        }

        //public void printNode(string order)
        //{
        //    if (order == "InOrder")
        //    {
        //        Node current = root;
        //        while (current != null)
        //        {
        //            while (current.left != null)
        //            {
        //                current = digLeft(current);
        //            }
        //            Console.WriteLine(current.data);
        //            while (current.right != null)
        //            {
        //                current = digRight(current);
        //            }
        //        }

        //    }

        //    Console.WriteLine("Print not implemented yet");
        //}

    }
}

using System;
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

            public Node(int newData)
            {
                data = newData;
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

            }
            else if (currentNode != null) //traverse the node until we reach the parent with a null leaf insertion point
            {
                while (newNode.data < currentNode.data)
                {
                    //digLeft();
                    if (currentNode.left != null)
                        currentNode = digLeft(currentNode);
                    else
                        break;
                }

                while (newNode.data >= currentNode.data)
                {
                    //digRight();
                    if (currentNode.right != null)
                        currentNode = digRight(currentNode);
                    else
                        break;
                }
            if (newNode.data < currentNode.data)//we're at the parent of insertion point, add node to the left if appropriate
            currentNode.left = newNode; //we found our leaf, add it here
            if (newNode.data >= currentNode.data)
                currentNode.right = newNode;
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

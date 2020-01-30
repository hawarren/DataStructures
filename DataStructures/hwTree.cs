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
        public hwTree()
        {
            root = null;
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
                            Console.WriteLine("Adding {0} to left node of parent {1}", newData, currentNode.ToString());
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
                            Console.WriteLine("Adding {0} to left node of parent {1}", newData, currentNode.ToString());
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
        public Boolean find(int newData)
        {
            Node currentNode = root;
            bool isPresent = false;
            while (currentNode != null) //keep going until we've reached a null leaf
            {
                if (newData == currentNode.data)
                {
                    isPresent = true;
                    break; //we found our value
                }
                if (newData < currentNode.data)
                {
                    currentNode = digLeft(currentNode);
                    continue;
                }

                if (newData > currentNode.data)
                {
                    currentNode = digRight(currentNode);
                    continue;
                }
            }
            return isPresent;

        }
        public void traversePreOrder()
        {
            traversePreOrder(root);
        }
        public void traverseInOrder() {
            traverseInOrder(root);
        }
        public void traversePostOrder() {
            traversePostOrder(root);
        }
        //preorder traversal is root, left, right
        private void traversePreOrder(Node root)
        {
            //base condition
            if (root == null)
                return;
            Console.WriteLine(root.data);
            traversePreOrder(root.left);
            traversePreOrder(root.right);
        }
        //inorder traversal is left, root, right
        private void traverseInOrder(Node root)
        {
            if (root == null) //base condition
                return;
            traverseInOrder(root.left);
            Console.WriteLine(root.data);
            traverseInOrder(root.right);
        }
        //postOrder traversal is left, right, root
        private void traversePostOrder(Node root) {
            if (root == null)
                return;
            traversePostOrder(root.left);
            traversePostOrder(root.right);
            Console.WriteLine(root.data);
        }
        //public void traverseLevelOrder(Node root) {

        //}

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

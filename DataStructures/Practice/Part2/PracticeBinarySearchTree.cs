using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice.Part2
{
    internal class PracticeBinarySearchTree
    {
        //root
        //node(value, leftchild,rightchild
        //insert(value)
        //find(value)
        private PracticeNode root;
        public void insert(int value)
        {
            PracticeNode valueNode = new PracticeNode(value);
            if (root == null)
            {
                root = valueNode;
                return;
            }
            var current = root;
            //if value is less than current and current.left is null,put value there, else move to leftchild, 
            //if value is more than current, if current.right is null, put value there. Else move to rightChild
            bool foundLocation = false;
            while (!foundLocation)
            {
                if (value <= current.value)
                {
                    if (current.leftChild != null)
                    {
                        current = current.leftChild;
                    }
                    else
                    {
                        current.leftChild = valueNode;
                        foundLocation = true;
                    }
                }
                if (value > current.value)
                {
                    if (current.rightChild != null)
                    {
                        current = current.rightChild;
                    }
                    else
                    {
                        current.rightChild = valueNode;
                        foundLocation = true;
                    }
                }
            }
        }
        public bool find(int value)
        {
            if (root == null)
                return false;
            //if currentvalue matches value, return true
            //else if currentvalue is less than value, dig left
            //else if currentvalue is more than value, dig right
            bool foundLocation = false;
            var current = root;
            while (current != null)
            {

                if (value < current.value)
                {

                    current = current.leftChild;
                }
                else if (value > current.value)
                {
                    current = current.rightChild;
                }
                else
                {
                    return true;
                }
            }
            return foundLocation;
        }
        public void traversePreOrder(PracticeNode root)
        {
            if (root == null)
                return;
            //root print
            Console.WriteLine(root);
            traversePreOrder(root.leftChild);
            traversePreOrder(root.rightChild);

        }
        public void traversePreOrder()
        {
            traversePreOrder(root);
        }
        public void traversePostOrder(PracticeNode root)
        {
            if (root == null)
                return;

            traversePostOrder(root.leftChild);
            traversePostOrder(root.rightChild);
            Console.WriteLine(root);
        }

        public void traversePostOrder()
        {
            traversePostOrder(root);
        }
        public void traverseInOrder(PracticeNode root)
        {
            if (root == null)
                return;
            traverseInOrder(root.leftChild);
            Console.WriteLine(root);
            traverseInOrder(root.rightChild);
        }
        public void traverseInOrder()
        {
            traverseInOrder(root);
        }

        public class PracticeNode
        {
            public int value { get; set; }
            public PracticeNode leftChild { get; set; }
            public PracticeNode rightChild { get; set; }
            public PracticeNode(int value)
            {
                this.value = value;
            }
            public override string ToString()
            {
                return "Node" + value;
            }

        }
    }
}
//tree traversal algorithms
//pre order (root, left, right) 20, 10, 6,3,8,14,30,24,26,30
//in order:left, root, right : 3,6,8,10,14,20,24,26,30
//post order (left, right, root) 3, 8, 6, 14, 10, 26, 24,30, 20
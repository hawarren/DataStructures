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
        public bool equals(PracticeBinarySearchTree newTree)
        {

            if (newTree == null)
                return false;

            return equals(root,newTree.root);
        }
        public bool equals(PracticeNode oldNode, PracticeNode newNode)
        {   
            if (oldNode == null && newNode == null)
                return true;
            //compare old root to newroot, oldleft to newleft, then oldright to newright
            if (oldNode != null || newNode != null)
            return oldNode.value == newNode.value &&
                equals(oldNode.leftChild, newNode.leftChild) && equals(oldNode.rightChild, newNode.rightChild);

            return false;
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

        public int height()
        {
            return height(root);
        }

        private int height(PracticeNode root)
        {
            if (root == null)
            { return -1; }
            if (root.leftChild == null && root.rightChild == null)
                return 0;

            return 1 + Math.Max(height(root.leftChild), height(root.rightChild));

        }
        public int min() {
            return min(root);
        }
        private int min(PracticeNode root)
        {
            if (isLeaf(root))
                return root.value;

            var left = min(root.leftChild);
            var right = min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }
        public int minSearchTree() {
            if (root == null)
                return -1;

            var current = root;
            var last = current;
            while (current != null) {
                last = current;
                current = current.leftChild;
            }

            return last.value;
        }
        private bool isLeaf(PracticeNode node)
        {
            return node.leftChild == null && node.rightChild == null;
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
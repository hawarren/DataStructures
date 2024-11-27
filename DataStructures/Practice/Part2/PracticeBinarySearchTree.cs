using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        private PracticeNode _root;
        public void insert(int value)
        {
            PracticeNode valueNode = new PracticeNode(value);
            if (_root == null)
            {
                _root = valueNode;
                return;
            }
            var current = _root;
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
            if (_root == null)
                return false;
            //if currentvalue matches value, return true
            //else if currentvalue is less than value, dig left
            //else if currentvalue is more than value, dig right
            bool foundLocation = false;
            var current = _root;
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
            traversePreOrder(_root);
        }
        public bool equals(PracticeBinarySearchTree newTree)
        {

            if (newTree == null)
                return false;

            return equals(_root, newTree._root);
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
            traversePostOrder(_root);
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
            traverseInOrder(_root);
        }

        public int height()
        {
            return height(_root);
        }

        private int height(PracticeNode root)
        {
            if (root == null)
            { return -1; }
            if (root.leftChild == null && root.rightChild == null)
                return 0;

            return 1 + Math.Max(height(root.leftChild), height(root.rightChild));

        }
        public int min()
        {
            return min(_root);
        }
        private int min(PracticeNode root)
        {
            if (isLeaf(root))
                return root.value;

            var left = min(root.leftChild);
            var right = min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }
        public int minSearchTree()
        {
            if (_root == null)
                return -1;

            var current = _root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }

            return last.value;
        }
        private bool isLeaf(PracticeNode node)
        {
            return node.leftChild == null && node.rightChild == null;
        }
        public void swapNodes()
        {
            int left = _root.leftChild.value;

            _root.leftChild.value = _root.rightChild.value;
            _root.rightChild.value = left;
        }
        public bool isBinarySearchTree()
        {
            return isBinarySearchTree(_root, int.MinValue, int.MaxValue);
        }
        public bool isBinarySearchTree(PracticeNode root, int min, int max)
        {
            //check root node
            //check left node is in range < parent
            //check if right node is in range > parent
            if (root == null)
                return true;

            //stop if the root is higher or lower than range
            if (min > root.value || root.value > max)
            {
                return false; //root is in main
            }


            return isBinarySearchTree(root.leftChild, min, root.value - 1) &&
            isBinarySearchTree(root.rightChild, root.value + 1, max);


        }


        public List<int> getNodesAtDistance(int k)
        {
            List<int> list = new List<int>();
            if (_root != null)
                list = getNodesAtDistance(_root, k, list);
            return list;
            //Console.WriteLine(String.Join(",", list));


        }
        public int countLeaves()
        {
            List<PracticeNode> leaves = new();
            var countOfLeaf = 0;
            var leafs = countLeaves(_root, height(), leaves);
            return leafs.Count;
        }
        public List<PracticeNode> countLeaves(PracticeNode root, int k, List<PracticeNode> leaves)
        {
            var count = 0;
            var currentNode = root;
            var distance = k;
            //base condition, node has no left or right children, add to count
            //digleft recursively
            //digright

            if (root.leftChild == null && root.rightChild == null)
                leaves.Add(root);
            
            if (root.leftChild != null)
               countLeaves(root.leftChild, k - 1, leaves);
            if (root.rightChild != null)
                countLeaves(root.rightChild, k - 1, leaves);
            return leaves;
        }
        public List<int> getNodesAtDistance(PracticeNode root, int k, List<int> list)
        {
            //print node if kth distance from root
            //if not, call printkthNode on left and decrement distance
            //call printkthnode on right and decrement distance
            var currentNode = root;
            if (currentNode == null)
                currentNode = _root;

            var distance = k;
            if (distance == 0)
            {
                Console.WriteLine($"{k}th node from root: {currentNode.value}");
                list.Add(currentNode.value);
            }
            if (currentNode.leftChild != null)
                getNodesAtDistance(currentNode.leftChild, k - 1, list);
            if (currentNode.rightChild != null)
                getNodesAtDistance(currentNode.rightChild, k - 1, list);

            return list;
        }
        public void traverseNodes()
        {
            for (var i = 0; i <= height(); i++)
            {
                List<int> list = getNodesAtDistance(i);
                Console.WriteLine(String.Join(",", list));
            }
        }
        public int size()
        {
            int total = 0;
            //use level order traversal, gather all nodes
            for (int i = 0; i <= height(); i++)
            {
                List<int> list = getNodesAtDistance(i);
                total += list.Count;
            }

            return total;
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
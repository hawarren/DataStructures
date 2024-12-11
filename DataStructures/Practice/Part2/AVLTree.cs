using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures.Practice.Part2
{
    internal class AVLTree
    {
        private AVLNode _root;
        private int height;
        public AVLTree()
        {
        }

        internal AVLNode Root { get => _root; set => _root = value; }
        public void insert(int newValue)
        {
            if (_root == null)
            {
                _root = new AVLNode(newValue);
                return;
            }
            var current = _root;
            //if it's a leaf, insert there
            //if it's less than current, dig left
            // if it's more than current, dig right
            if (current.nodeValue == 0) // Updated condition to check if nodeValue is 0
            {
                _root.nodeValue = newValue;
            }
            insert(newValue, current);
        }
        private AVLNode insert(int newValue, AVLNode newRoot)
        {
            var current = newRoot;
            //if it's a leaf, insert there
            //if it's less than current, dig left
            // if it's more than current, dig right
            //if this node is empty, then insert object here and return to previous step
            if (newRoot == null)
            {
                return new AVLNode(newValue);
            }
            else if (newValue < current.nodeValue)
            {
               newRoot.leftNode = insert(newValue, current.leftNode);
            }
            else if (newValue > current.nodeValue)
            {
                newRoot.rightNode = insert(newValue, current.rightNode);
            }
            newRoot._height = getHeight(newRoot);
            return newRoot;
        }
        public int getHeight()
        {
            //check if it's a leaf node
            //if so return the height of that root from the node
            //if not recurse:
            //left if smaller
            //right if larger

            return getHeight(_root);
        }
        private int getHeight(AVLNode nodeToCheck)
        {
            //check if it's a leaf node
            //if so return the height of that root from the node
            //if not recurse:
            //left if smaller
            //right if larger
            if (nodeToCheck == null)
                return -1;
            if (isLeaf(nodeToCheck))
                return 0;

            return 1 + Math.Max(getHeight(nodeToCheck.leftNode), getHeight(nodeToCheck.rightNode));           
            
        }
        private bool isLeaf(AVLNode nodeToCheck) {
            return nodeToCheck.leftNode == null && nodeToCheck.rightNode == null;

        }
        
    }
    internal class AVLNode
    {
        private int _nodeValue;
        private AVLNode _leftNode;
        private AVLNode _rightNode;
        public int _height;

        public int nodeValue { get => _nodeValue; set => _nodeValue = value; }
        public AVLNode leftNode { get => _leftNode; set => _leftNode = value; }
        public AVLNode rightNode { get => _rightNode; set => _rightNode = value; }

        public AVLNode(int value)
        {
            _nodeValue = value;
        }
        public override string ToString()
        {
            return "Node=" + nodeValue.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Practice.Part2
{
    internal class AVLTree
    {
        private AVLNode _root;
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
        private void insert(int newValue, AVLNode newRoot)
        {
            var current = newRoot;
            //if it's a leaf, insert there
            //if it's less than current, dig left
            // if it's more than current, dig right
            if (current.nodeValue == 0) // Updated condition to check if nodeValue is 0
            {
                current.nodeValue = newValue;
            }
            if (newValue < current.nodeValue)
            {
                insert(newValue, current.leftNode);
            }
            else if (newValue > current.nodeValue)
            {
                insert(newValue, current.rightNode);
            }
        }
    }
    internal class AVLNode
    {
        private int _nodeValue;
        private AVLNode _leftNode;
        private AVLNode _rightNode;

        public int nodeValue { get => _nodeValue; set => _nodeValue = value; }
        public AVLNode leftNode { get => _leftNode; set => _leftNode = value; }
        public AVLNode rightNode { get => _rightNode; set => _rightNode = value; }

        public AVLNode(int value)
        {
            _nodeValue = value;
        }
    }
}

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
        public PracticeNode root;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreesDataStructureInfo
    {
        ///Hierachical structure.
        /// Binary tree is a type of tree with a few rules like each node can only have zero,
        /// one or two nodes each child can only have parent. A perfect binary tree is a
        /// binary tree where each leaf node has two leaf child and fully filled. Each level is double
        /// its previous level. All the nodes but the child leaf + 1 makes the total number of child
        /// leafs. *Number of Nodes = ((2^height/level)- 1)*. *log nodes = height*
        /// 
        /// A full binary tree is a binary tree where no leaf node has one leaf child. Either
        /// zero or two children but never one child..
        ///
        /// BigO(log N)  i.e - lookup = O(log N), - insert = O(log N), - delete = O(log N)
        ///
        /// Binary Search Tree - Great for comparing things. Great for preserving comparison
        /// relationships. All child nodes in the tree to the right must be greater than the parent
        /// node and vice versa. A node can only have up to 2 children. Searching and lookup are
        /// easier.  There are balanced and unbalanced binary search tree. The unbalancced binary
        /// tree is bad because then you wouldn't be a log N, because it will become a linked list and
        /// thus have to loop through evertything becoming a BigO(n).
        ///
        /// Pros - Better than BigO(n), Ordered, Flexible Size
        /// Cons - No O(1) operations
        ///
        /// Binary Heaps - In a binary heap, every child has a parent node with values higher
        /// than them(the child node). This is a max heap. There is also a main hep which is vice
        /// versa. And can be used in any algorithm where ordering is used. In binary heaps, Lookups
        /// are BigO(n) unlike trees that have BigO(log N). This is because, unlike trees, the child
        /// nodes are not arranged as per any specifications. Binary heaps are great for comparative
        /// operations. BigO(log N)  i.e - lookup = O(n), - insert = O(log N), - delete = O(log N)
        ///  Binary heaps have some advantages over trees which are; since the parents are
        /// always greater than the children, its more memory efficient and also more compact
        /// thus no  need to balance the heap at any point in time and are best for priority queues.
        /// Priority Queue are queues witha twist where some items have more priority over
        /// the others. Forexample, an emergency room where all patients are being treated
        /// per regular queues until more severe cases arrive and they become priority.
        ///
        /// so even with slower lookups, binary heaps can be necessary for fast inserts, a flexible size,
        /// priority situations and are generally considered better than BigO(n).
        ///
        /// Tries - Best used for strings. A specialized tree used in search most often for text and
        /// in most cases, can outperform other data structures. Can have multiple children
        /// unlike binary trees. Best for autocompletions. Best for speed and space.
        /// In strings, the BigO  of the trie is O(length of word).
    }

    public class Nodes
    {
        public Nodes leftChild;
        public Nodes rightChild;
        public int value;

        public Nodes(int data)
        {
            this.value = data;
            this.rightChild = null;
            this.leftChild = null;
        }
        public Nodes()
        {
        }
    }

    public class Tree
    {
        private Nodes root;

        public Tree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            if (root == null)
            {
                root = new Nodes(data);
            }
            else
            {
                Nodes parent = root;
                while (data != null)
                {
                    if (parent.value == data)
                    {
                        Console.WriteLine("Duplicate values detected.!!!");
                        return;
                        //data = null;
                    }
                    else if (parent.value > data)
                    {
                        if (parent.leftChild == null)
                        {
                            parent.leftChild = new Nodes(data);
                            return;
                            //data = null;
                        }
                        else
                        {
                            parent = parent.leftChild;
                        }
                    }
                    else
                    {
                        if (parent.rightChild == null)
                        {
                            parent.rightChild = new Nodes(data);
                            //data = null;
                            return;
                        }
                        else
                        {
                            parent = parent.rightChild;
                        }
                    }
                }
            }
        }

        public List<int> InorderTraversal()
        {
            List<int> elements = new List<int>();
            Stack<Nodes> stack = new Stack<Nodes>();
            
            Nodes curr_node = root;
            while (curr_node != null || stack.Count > 0)
            {
                if (curr_node != null)
                {
                    stack.Push(curr_node);
                    curr_node = curr_node.leftChild;
                }
                else
                {
                    curr_node = stack.Pop();
                    elements.Add(curr_node.value);
                    curr_node = curr_node.rightChild;
                }
            }
            return elements;
        }

        public bool Lookup(int value)
        {
            Nodes current = root;

            while (current != null)
            {
                if (current.value == value)
                {
                    return true; //value found
                }
                else if (current.value > value)
                {
                    current = current.leftChild; //move to left subtree
                }
                else
                {
                    current = current.rightChild; //move to right subtree
                }
            }
            return false; // value not found
        }

        public bool Remove(int value)
        {
            Nodes parent = null;
            Nodes current = root;
            
            //Find the node to remove
            while (current != null)
            {
                if (current.value > value)
                {
                    parent = current;
                    current = current.leftChild;
                }
                else if (current.value < value)
                {
                    parent = current;
                    current = current.rightChild;
                }
                else if (current.value == value)
                {
                    break;
                }
                
                //Case 1: Node has no children
                if (current.leftChild == null && current.rightChild == null)
                {
                    if (current == root)
                    {
                        root = null;
                    }
                    else if (parent.leftChild == current)
                    {
                        parent.leftChild = null;
                    }
                    else
                    {
                        parent.rightChild = null;
                    }
                }
                
                //Node has one child
                else if (current.leftChild == null || current.rightChild == null)
                {
                    Nodes child = (current.leftChild != null) ? current.leftChild : current.rightChild;

                    if (current == root)
                    {
                        root = child;
                    }
                    else if(parent.leftChild == current)
                    {
                        parent.leftChild = child;
                    }
                    else
                    {
                        parent.rightChild = child;
                    }
                }

                //Node has two children
                else
                {
                    Nodes successor = current.rightChild;
                    Nodes successorParent = current;

                    while (successor.leftChild != null)
                    {
                        successorParent = successor;
                        successor = successor.leftChild;
                    }
                    current.value = successor.value;

                    if (successorParent.leftChild == successor)
                    {
                        successorParent.leftChild = successor.rightChild;
                    }
                    else
                    {
                        successorParent.rightChild = successor.rightChild;
                    }
                }
            }
            return true;
        }
    }
}
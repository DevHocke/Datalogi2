using System;
using System.Collections.Generic;

namespace Datalogi2
{
    class BinaryTree
    {
        class Node
        {
            /// <summary>
            /// The node data.
            /// </summary>
            public Search Data { get; set; }

            /// <summary>
            /// The nodes left child.
            /// </summary>
            public Node LeftChild { get; set; } = null;

            /// <summary>
            /// The nodes right child.
            /// </summary>
            public Node RightChild { get; set; } = null;

            public Node(Search data)
            {
                Data = data;
            }
        }

        /// <summary>
        /// The first node in the binary tree. 
        /// </summary>
        private Node root = null;

        /// <summary>
        /// Is used to insert into the binary tree in level order.
        /// Every node that gets added to the tree also gets
        /// added to the queue. When both child nodes of the first node in the queue
        /// has been added, the first node in the queue is dequeued.
        /// </summary>
        private Queue<Node> queue = new Queue<Node>();

        /// <summary>
        /// Adds a new search to the binary tree.
        /// </summary>
        /// <param name="search">The search to add to the binary tree.</param>
        public void Add(Search search)
        {
            var newNode = new Node(search);

            // If the binary tree is empty then the search is added as the root.
            // Otherwise we use the queue to find where to add the new search.
            if (root == null)
            {
                root = newNode;
                queue.Enqueue(newNode);
            }
            else
            {
                var node = queue.Peek();
                if (node.LeftChild == null)
                {
                    node.LeftChild = newNode;
                    queue.Enqueue(newNode);
                    return;
                }

                if (node.RightChild == null)
                {
                    node.RightChild = newNode;
                    queue.Enqueue(newNode);
                    queue.Dequeue();
                    return;
                }
            }
        }

        /// <summary>
        /// Prints out the entire binary tree to the console.
        /// </summary>
        public void Traverse()
        {
            if (root == null)
            {
                Console.WriteLine("\n\tThe binary tree is empty.");
            }
            else
            {
                InorderTraverse(root);
            }
        }

        /// <summary>
        /// Finds the leaf furthest to the left, prints that node to the console.
        /// Then prints the parent node and then the right leaf. This continues
        /// throughout the entire tree. We used recurtion for this method because
        /// it is a very effective way to traverse through the tree.
        /// </summary>
        /// <param name="node"></param>
        private void InorderTraverse(Node node)
        {
            if (node == null)
            {
                return;
            }

            InorderTraverse(node.LeftChild);
            node.Data.Print();
            InorderTraverse(node.RightChild);
        }
    }
}

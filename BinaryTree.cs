using System;
using System.Collections.Generic;

namespace Datalogi2
{
    class BinaryTree
    {
        class Node
        {
            public Search Data { get; set; } // Nodens vikt.
            public Node LeftChild { get; set; } = null;
            public Node RightChild { get; set; } = null;

            public Node(Search data)
            {
                Data = data;
            }
        }

        private Node root = null;

        private Queue<Node> q = new Queue<Node>();

        public void Add(Search search)
        {
            var newNode = new Node(search);

            if (root == null) // Om trädet är tomt så ge roten värdet av första sökningen.
            {
                root = newNode;
                q.Enqueue(newNode);
            }
            else
            {
                var node = q.Peek();
                if (node.LeftChild == null)
                {
                    node.LeftChild = newNode;
                    q.Enqueue(newNode);
                    return;
                }

                if (node.RightChild == null)
                {
                    node.RightChild = newNode;
                    q.Enqueue(newNode);
                    q.Dequeue();
                    return;
                }
            }
        }

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

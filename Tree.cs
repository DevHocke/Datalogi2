using System;
using System.Collections.Generic;
using System.Text;

namespace Datalogi2
{
    class Tree
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

        public void Add(Search search)
        {
            if (root == null) // Om trädet är tomt så ge roten värdet av första sökningen.
            {
                root = new Node(search);
            }
            else
            {
                Add(search, root);
            }
        }

        private void Add(Search search, Node node)
        {
            if (node.LeftChild == null)
            {
                node.LeftChild = new Node(search);
                return;
            }

            if (node.RightChild == null)
            {
                node.RightChild = new Node(search);
                return;
            }

            

        }
    }
}

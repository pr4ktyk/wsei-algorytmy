using System;
using System.Collections.Generic;

namespace lab10
{
    class Node<T>
    {
        public T Value { get; set; }
        //public List<Node<T>> children;
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

    class BinaryTree<T>
    {
        public Node<T> Root { get; set; }

        public void PreorderTraversal(Action<Node<T>> action)
        {
            Preorder(Root, action);
        }
        private void Preorder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null) return;

            action.Invoke(node);
            Preorder(node.Left, action);
            Preorder(node.Right, action);
        }

        public void InorderTraversal(Action<Node<T>> action)
        {
            Inorder(Root, action);
        }

        private void Inorder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null) return;

            Inorder(node.Left, action);
            action.Invoke(node);
            Inorder(node.Right, action);
        }

        public void PostOrderTraversal(Action<Node<T>> action)
        {
            Inorder(Root, action);
        }

        private void Postorder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null) return;

            Postorder(node.Left, action);
            Postorder(node.Right, action);
            action.Invoke(node);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "+" };
            node.Left = new Node<string>() { Value = "*" };
            node.Right = new Node<string>() { Value = "3" };
            node.Left.Left = new Node<string>() { Value = "7" };
            node.Left.Right = new Node<string>() { Value = "9" };

            BinaryTree<string> tree = new BinaryTree<string>() { Root = node };
            tree.InorderTraversal((n) => Console.Write(n.Value));
            Console.WriteLine();
            tree.PostOrderTraversal((n) => Console.Write(n.Value));
            Console.WriteLine();
            tree.PreorderTraversal((n) => Console.Write(n.Value));
        }
    }
}
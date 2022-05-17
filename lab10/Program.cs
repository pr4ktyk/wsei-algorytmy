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
            PostOrder(Root, action);
        }

        private void PostOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null) return;


            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action.Invoke(node);
        }

        public void LevelTraversal(Action<Node<T>> action)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (q.Count > 0)
            {
                Node<T> node = q.Dequeue();
                action.Invoke(node);
                if (node.Left != null) q.Enqueue(node.Left);
                if (node.Right != null) q.Enqueue(node.Right);
            }
        }

    }
    class Expression : BinaryTree<string>
    {
        public double Evaluate()
        {
            return EvaluateNode(Root);
        }

        private double EvaluateNode(Node<string> node)
        {
            switch (node.Value)
            {
                case "+":
                    return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                case "-":
                    return EvaluateNode(node.Left) - EvaluateNode(node.Right);
                case "*":
                    return EvaluateNode(node.Left) * EvaluateNode(node.Right);
                case "/":
                    return EvaluateNode(node.Left) / EvaluateNode(node.Right);
                case "^":
                    return Math.Pow(EvaluateNode(node.Left), EvaluateNode(node.Right));
                default:
                    return double.Parse(node.Value);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "+" };
            node.Left = new Node<string>() { Value = "*" };
            node.Right = new Node<string>() { Value = "^" };
            node.Left.Left = new Node<string>() { Value = "7" };
            node.Left.Right = new Node<string>() { Value = "9" };
            node.Right.Left = new Node<string>() { Value = "2" };
            node.Right.Right = new Node<string>() { Value = "4" };
            Expression tree = new Expression() { Root = node };

            tree.InorderTraversal(a => Console.Write(a.Value));
            Console.WriteLine();
            tree.PostOrderTraversal(a => Console.Write(a.Value));
            Console.WriteLine();
            tree.PreorderTraversal(a => Console.Write(a.Value));
            Console.WriteLine();
            Console.WriteLine(tree.Evaluate());
            Console.WriteLine();
            tree.LevelTraversal(n => Console.WriteLine(n.Value));

        }
    }
}
using System;
using System.Collections;

namespace lab8
{
	class Program
	{
		record Student(string Name, int Ects);

		class TreeNode<T>
		{
			public T Value { get; set; }
			public TreeNode<T> Left { get; set; }
			public TreeNode<T> Right { get; set; }
		}

		static void Main(string[] args)
		{
			int[] arr = { 5, 4, 1, 7, 9, 0, 3, 6, 2, 8 };
			Array.Sort(arr);
			int index = Array.BinarySearch(arr, 9);
			Console.WriteLine($"Index: {index} Szukana: 9");

			Student[] students =
			{
				new Student("Adam", 30),
				new Student("Michał", 20),
				new Student("Jan", 10),
				new Student("Ewa", 40),
				new Student("Monika", 60),
				new Student("Anna", 70)
			};


			Array.Sort(students, (a,b) =>
			{
				return a.Ects.CompareTo(b.Ects);
			});
			index = Array.BinarySearch(students, new Student("Ewa", 40), new StudentComparer());
			Console.WriteLine($"Index: {index} Szukana: Ewa 40ECTS");

			TreeNode<int> root = new TreeNode<int> { Value = 16 };
			root.Left = new TreeNode<int> { Value = 8 };
			root.Right = new TreeNode<int> { Value = 24 };
			root.Left.Left = new TreeNode<int> { Value = 4 };
			root.Left.Right = new TreeNode<int> { Value = 12 };
			root.Right.Left = new TreeNode<int> { Value = 20 };
			root.Right.Right = new TreeNode<int> { Value = 28 };
			BST<int> tree = new BST<int>() { Root = root };
            Console.WriteLine(tree.Contains(28));
			tree.Insert(5);
			Console.WriteLine(tree.Contains(5));
		}

		class BST<T> where T: IComparable<T>
        {
			public TreeNode<T> Root { get; init; }


			public bool Contains(T value)
            {
				return Search(Root, value);
            }

			public bool Insert(T value)
            {
				return InsertNode(Root, value);
            }

			private bool Search(TreeNode<T> node, T value)
            {
				if (node == null) return false;
				int compare = value.CompareTo(node.Value);
				if (compare == 0) return true;
				if (compare < 0) return Search(node.Left, value);
				else return Search(node.Right, value);
            }

			private bool InsertNode(TreeNode<T> node, T value)
			{
				int compare = value.CompareTo(node.Value);
				if (compare == 0) return false;
				if (compare < 0)
				{
					if (node.Left != null) return InsertNode(node.Left, value);
					else
                    {
						node.Left = new TreeNode<T> { Value = value };
						return true;
                    }
				}
				else
				{
					if (node.Right != null) return InsertNode(node.Right, value);
					else
					{
						node.Right = new TreeNode<T> { Value = value };
						return true;
					}
				};
			}
		}

		class StudentComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				Student a = (Student)x;
				Student b = (Student)y;
				return a.Ects.CompareTo(b.Ects);
			}
		}
	}
}

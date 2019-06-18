﻿//Create a Tree class that implements the binary search tree(BST) methods shown below, and stores objects
//of class Student. You need to implement a Student class that stores name, major, and state of origin.The
//students should be sorted alphabetically by names in the tree:

//[20 points] Insert(a new value into the tree while maintaining the BST structure): void insert(str studName, str major, str originState)

//[20 points] Insert(a new value into the tree while maintaining the BST structure): void insert(Student newStudent)

//[10 points] Traversal: PrintInOrder, PrintPreOrder, PrintPostOrder

//[10 points] Search (for a value in the tree) : bool search(str studName)

//[20 points] Height of Binary Tree:  int height()

//[20 points] Number of leaf nodes: int numLeafNodes()

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Charles = new Student("Charles", "Economics", "IL");
            Student Mike = new Student("Mike", "Computer Science", "WA");
            Student Alice = new Student("Alice", "Math", "WA");
            Student Jennifer = new Student("Jennifer", "Health and Science", "WA");

            BST myTree = new BST();
            myTree.insert(Charles);
            myTree.insert(Mike);
            myTree.insert(Alice);
            myTree.insert(Jennifer);
            //myTree.insert("Carl", "Liberal Arts", "HI");

            Console.WriteLine(myTree.search("Carl"));
            Console.WriteLine(myTree.search("Jennifer"));

            myTree.printInOrder();
            Console.WriteLine(" ");
            myTree.printPreOrder();
            Console.WriteLine(" ");
            myTree.printPostOrder();
        }
    }

    class Student //Create a student class with name, major, and origin state.
    {
        public Student(string name, string major, string originState)
        {
            this.name = name;
            this.major = major;
            this.originState = originState;
        }

        public string name { get; set; }
        public string major { get; set; }
        public string originState { get; set; }
    }

    class BST
    {
        public class Node
        {
            public Student value;
            public Node left, right;

            public Node(Student newStudent)
            {
                value = newStudent;
            }

            public Node(string name, string major, string originState)
            {
                this.name = name;
                this.major = major;
                this.originState = originState;
            }
            public string name { get; set; }
            public string major { get; set; }
            public string originState { get; set; }
        }

        Node root;

        public bool isEmpty()
        {
            return root == null;
        }

        
        public void insert(Student newStudent)
        {
            Node newNode = new Node(newStudent);

            if (isEmpty())
            {
                root = newNode;
            }
            else
            {
                Node current = root;

                while (true)
                {
                    if (string.Compare(newStudent.name, current.value.name) < 0)
                    {
                        if (current.left != null)
                        {
                            current = current.left;
                        }
                        else
                        {
                            current.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        if (current.right != null)
                        {
                            current = current.right;
                        }
                        else
                        {
                            current.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public bool search(string key)
        {
            if (isEmpty())
            {
                return false;
            }
            else
            {
                Node current = root;

                while (current != null)
                {
                    if (key == current.value.name)
                    {
                        return true;
                    }
                    else if (string.Compare(key, current.value.name) < 0)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current = current.right;
                    }
                }

                return false;
            }
        }

        public void printPreOrder()
        {
            preOrderHelper(root);
        }

        public void preOrderHelper(Node current)
        {
            if (current != null)
            {
                Console.WriteLine(current.value.name + " ");
                preOrderHelper(current.left);
                preOrderHelper(current.right);
            }
        }

        public void printInOrder()
        {
            inOrderHelper(root);
        }

        public void inOrderHelper(Node current)
        {
            if (current != null)
            {
                inOrderHelper(current.left);
                Console.WriteLine(current.value.name + " ");
                inOrderHelper(current.right);
            }
        }

        public void printPostOrder()
        {
            postOrderHelper(root);
        }

        public void postOrderHelper(Node current)
        {
            if (current != null)
            {
                preOrderHelper(current.left);
                preOrderHelper(current.right);
                Console.WriteLine(current.value.name + " ");
            }
        }

        public BST()
        {
            root = null;
        }
    }
}

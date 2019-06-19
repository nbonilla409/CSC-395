//Create a Tree class that implements the binary search tree(BST) methods shown below, and stores objects
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
            //New students from the students class are created.
            BST.Student Charles = new BST.Student("Charles", "Economics", "IL");
            BST.Student Mike = new BST.Student("Mike", "Computer Science", "WA");
            BST.Student Alice = new BST.Student("Alice", "Math", "WA");
            BST.Student Jennifer = new BST.Student("Jennifer", "Health and Science", "WA");

            //Instantiate the tree and insert the student nodes.
            BST myTree = new BST();                             //              Charles
            myTree.insert(Charles);                             //              /     \
            myTree.insert(Mike);                                //          Alice      Mike
            myTree.insert(Alice);                               //              \     /
            myTree.insert(Jennifer);                            //            Carl    Jennifer
            myTree.insert("Carl", "Liberal Arts", "HI");
            //Search for students(output is boolean value).
            Console.WriteLine(myTree.search("Carl"));
            Console.WriteLine(myTree.search("Carlos"));

            //Traverse the tree.
            myTree.printInOrder(); //LNR
            Console.WriteLine(" ");
            myTree.printPreOrder(); //NLR
            Console.WriteLine(" ");
            myTree.printPostOrder(); //LRN
            Console.WriteLine(" ");

            //Output the Height and Number of Leaves on the the tree.
            Console.WriteLine(myTree.printHeight()); //Output: 3
            Console.WriteLine(" ");
            Console.WriteLine(myTree.printNumLeafNodes()); //Output 2

        }
    }



    public class BST
    {
        public class Student //Create a student class with name, major, and origin state.
        {
            //Properties
            public string name { get; set; }
            public string major { get; set; }
            public string originState { get; set; }
            public Student left, right;

            public Student(string name, string major, string originState)
            {
                //Parameters
                this.name = name;
                this.major = major;
                this.originState = originState;
            }

        }

        Student root;

        public bool isEmpty()
        {
            return root == null;
        }

        //Insert a student and specify parameters directly into the tree.
        public void insert(string name, string major, string originState)
        {
            Student newStudent = new Student(name, major, originState);
            
            if (isEmpty()) //If tree is empty, the student becomes the root of the tree.
            {
                root = newStudent;
            }
            else //Place the student in appropriate location in accordance with BST format.
            {
                Student current = root;

                while (true)
                {
                    //Compare the new student against current nodes.
                    if (string.Compare(newStudent.name, current.name) < 0) //If student's name belongs before current node..
                    { 
                        if (current.left != null) //.. and a node exists on the left..
                        {
                            current = current.left; //.. move to that node and compare values.
                        }
                        else //.. and the left node is empty..
                        {
                            current.left = newStudent; //.. place the node on the left.
                            break;
                        }
                    }
                    else //If student's name belongs after current node..
                    {
                        if (current.right != null) //.. and a node exists on the right..
                        {
                            current = current.right; //.. move to that node and compare values.
                        }
                        else //.. and the right node is empty..
                        {
                            current.right = newStudent; //.. place the node on the right.
                            break;
                        }
                    }
                }
            }
        }

        //Insert a student when student's parameters have already been specified from the students class.
        public void insert(Student newStudent)
        {
            if (isEmpty())
            {
                root = newStudent;
            }
            else
            {
                Student current = root;

                while (true)
                {
                    if (string.Compare(newStudent.name, current.name) < 0)
                    {
                        if (current.left != null)
                        {
                            current = current.left;
                        }
                        else
                        {
                            current.left = newStudent;
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
                            current.right = newStudent;
                            break;
                        }
                    }
                }
            }
        }

        //Check if a student exists on the tree.
        public bool search(string key)
        {
            if (isEmpty()) //Student does not exist on the tree if it is empty.
            {
                return false;
            }
            else
            {
                Student current = root;

                while (current != null)
                {
                    if (key == current.name)
                    {
                        return true;
                    }
                    else if (string.Compare(key, current.name) < 0) //Compare student name and current node..
                    {
                        current = current.left; //If name comes before current node, move left.
                    }
                    else
                    {
                        current = current.right; //If name comes after current node, move right.
                    }
                }

                return false; //Student does not exist on the tree.
            }
        }

        public void printPreOrder() //NLR
        {
            preOrderHelper(root);
        }

        public void preOrderHelper(Student current)
        {
            if (current != null)
            {
                Console.WriteLine(current.name + " ");
                preOrderHelper(current.left);
                preOrderHelper(current.right);
            }
        }

        public void printInOrder() //LNR
        {
            inOrderHelper(root);
        }

        public void inOrderHelper(Student current)
        {
            if (current != null)
            {
                inOrderHelper(current.left);
                Console.WriteLine(current.name + " ");
                inOrderHelper(current.right);
            }
        }

        public void printPostOrder() //LRN
        {
            postOrderHelper(root);
        }

        public void postOrderHelper(Student current)
        {
            if (current != null)
            {
                preOrderHelper(current.left);
                preOrderHelper(current.right);
                Console.WriteLine(current.name + " ");
            }
        }

        public int printHeight() //Find the height of the tree.
        {
            return height(root);
        }

        public int height(Student current)
        {
            if (isEmpty())
            {
                throw new Exception("The tree height is 0");
            }
            else if(current == null)
            {
                return 0;
            }
            else
            {
                int lDepth = height(current.left);  //Recursively call the method to easily find
                int rDepth = height(current.right); //the height of both sides of the tree.

                if (lDepth > rDepth) //Return the side with the highest value to get the height of tree.
                {
                    return lDepth + 1;
                }
                else
                {
                    return rDepth + 1;
                }

            }

        }

        public int printNumLeafNodes() //Find the number of leaf nodes on the tree.
        {
            return numLeafNodes(root);
        }

        public int numLeafNodes(Student current)
        {
            if (isEmpty())
            {
                throw new Exception("Number of nodes = 0");
            }
            else if (current == null)
            {
                return 0;
            }
            else
            {
                if (current.left == null && current.right == null) 
                {
                    return 1; //If there is no left and right node, it is a leaf.
                }
                else
                {
                    return numLeafNodes(current.left) + numLeafNodes(current.right);
                }
            }
        }

        public BST()
        {
            root = null;
        }
    }
}

//Problem 1 [25 points] Let Q be a non-empty queue, and let S be an empty stack.
//    Write a C# program that reverses the order of the elements in Q, using S.
//    For example, if initially the order of the objects in Q is 1,2,3,4,5,6, then after reversing the objects,
//    the order of the objects in Q is 6,5,4,3,2,1.

//Problem 2 [25 points] Write a program that opens a text file (“input.txt”) and reads its contents.
//    Then using a stack it reverses the lines of the file and saves them into another file(“output.txt”).
//    Hint: use System.IO.File.WriteAllLines and System.IO.File.ReadAllLines,

//Problem 3 [50 points] Implement a Queue class using two stacks(use the side images as hints - see the class notes). 
//    What is the running time for enqueue() and dequeue()?

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesNStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the input file, Queue and Stack.
            string[] input = System.IO.File.ReadAllLines("input.txt");

            Queue<string> Q = new Queue<string>();
            Stack<string> S = new Stack<string>();

            //Enqueue data into the collection.
            Q.Enqueue("one");
            Q.Enqueue("two");
            Q.Enqueue("three");
            Q.Enqueue("four");

            //Print the items in the Queue.
            foreach (string item in Q)
            {
                Console.WriteLine("Q = " + item);
            }

            //foreach (string item in S)
            //{
            //    Console.WriteLine("S = " + item);
            //}

            //Take the items out of the Queue and place them in the stack.
            while (Q.Count > 0)
            {
                S.Push(Q.First());
                Q.Dequeue();
            }

            //foreach (string item in Q)
            //{
            //    Console.WriteLine("Q = " + item);
            //}

            Console.WriteLine(" ");

            //Print the reversed items in the Stack.
            foreach (string item in S)
            {
                Console.WriteLine("S = " + item);
            }
            
            //User file runs through ReverseInput method.
            ReverseInput(input);

            //The Queue class is utilized.
            Queue Staqueue = new Queue();
        }

        //ReverseInput takes a user's file and prints the lines in reverse order.
        static void ReverseInput(string[] arr)
        {
            //A new stack is initialized.
            Stack<string> reverseStack = new Stack<string>();

            //string[] input = System.IO.File.ReadAllLines("input.txt");

            //Run through each line of the array and push them into a stack.
            foreach (var item in arr)
            {
                Console.WriteLine(item);
                reverseStack.Push(item);
            }
            
            //Print the stack.
            foreach (var item in reverseStack)
            {
                Console.WriteLine(item);
            }

            //Write the new reversed stack into a file.
            System.IO.File.WriteAllLines("reverseStack.txt", reverseStack);
        }

        //Queue class utilizes two stacks to simulate a Queue Collection.
        public class Queue
        {
            //Initialize the stacks.
            Stack mainStack = new Stack();
            Stack secondaryStack = new Stack();

            public Queue()
            {
                //Add data to the "Queue"
                Enqueue("one");
                Enqueue("two");
                Enqueue("three");
                Enqueue("four");
                Enqueue("five");
                Dequeue();

                //Print the "Queue"
                foreach (string collection in mainStack)
                {
                    Console.WriteLine(collection);
                }
            }
            
            //Enqueue method simulates the Collections.Enqueue method.
            void Enqueue(string item) //Runtime = O(2n) -> O(n)
            {
                //Go through the main stack and transfer each item into the secondary stack.
                int mainStackCount = mainStack.Count;
                for (int i = 0; i < mainStackCount; i++)
                {
                    secondaryStack.Push(mainStack.Pop());
                }
                mainStack.Push(item);

                //Go through the secondary stack and transfer each item into the main stack.
                int secondaryStackCount = secondaryStack.Count;
                for (int i = 0; i < secondaryStackCount; i++)
                {
                    mainStack.Push(secondaryStack.Pop());
                }
            }
             
            //Dequeue method simulates the Collections.Dequeue method.
            void Dequeue() //Runtime = O(1)
            {
                //Pop the item in the main stack.
                mainStack.Pop();
            }
        }
    }
}

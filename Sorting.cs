//[15 points] Modify the bubble sort algorithm seen in class so it works with an array of strings AND the array will have the values sorted in reverse.
//    Also add a local variable count(use long count) of the number of comparisons that were performed. Display it before exiting this method.
//        Call it:  static void bubbleReverseSort(string[] arr)

//[15 points] Modify the selection sort algorithm seen in class so it works with an array of strings AND the array will have the values sorted in reverse.
//    Also add a local variable count(use long count) of the number of comparisons that were performed. Display it before exiting this method.
//        Call it:  static void selectionReverseSort(string[] arr)

//[15 points] Modify the merge sort algorithm seen in class so it works with an array of strings AND the array will have the values sorted in reverse.
//    Also add a local variable count(use long count) of the number of comparisons that were performed. Display it before exiting this method.
//        Call it:  static void mergeReverseSort(string[] arr)

//[15 points] Modify the quick sort algorithm seen in class so it works with an array of strings AND the array will have the values sorted in reverse.
//    Also add a local variable count(use long count) of the number of comparisons that were performed. Display it before exiting this method.
//        Call it:  static void quickReverseSort(string[] arr)

//[40 points] In Main read the entries from file given below, input.txt(one line per entry) and store them into an array.Make four copies of it.
//    Then, on each copy call bubbleReverseSort, selectionReverseSort, mergeReverseSort, quickReverseSort.For each of these measure the execution time
//        (how long it took to run the reverse sorting) and display this time. Hint for measuring execution (see the class notes!)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines("input.txt");
            Console.WriteLine("BEFORE sorting: ");
            foreach (var word in input)
            {
                Console.Write(word + " ");
            }

            //Reverse Bubble Sort
            var timeBubbleSort = System.Diagnostics.Stopwatch.StartNew();
            bubbleReverseSort(input);
            timeBubbleSort.Stop();
            var timeElapsedBubbleSort = timeBubbleSort.ElapsedMilliseconds;
            Console.WriteLine("Time Elapsed = " + timeElapsedBubbleSort + "ms");
            
            //Reverse Selection Sort
            var timeSelectionSort = System.Diagnostics.Stopwatch.StartNew();
            selectionReverseSort(input);
            timeSelectionSort.Stop();
            var timeElapsedSelectionSort = timeSelectionSort.ElapsedMilliseconds;
            Console.WriteLine("Time Elapsed = " + timeElapsedSelectionSort + "ms");

            //Reverse Merge Sort
            var timeMergeSort = System.Diagnostics.Stopwatch.StartNew();
            mergeReverseSort(input);
            timeMergeSort.Stop();
            var timeElapsedMergeSort = timeMergeSort.ElapsedMilliseconds;
            Console.WriteLine("Time Elapsed = " + timeElapsedMergeSort + "ms");

            //Reverse Quick Sort
            var timeQuickSort = System.Diagnostics.Stopwatch.StartNew();
            quickReverseSort(input);
            timeQuickSort.Stop();
            var timeElapsedQuickSort = timeQuickSort.ElapsedMilliseconds;
            Console.WriteLine("Time Elapsed = " + timeElapsedMergeSort + "ms");

            Console.ReadLine();
        }
        
        static void bubbleReverseSort(string[] arr)
        { 
            string tmp;
            bool flag;
            long count = 0;

            string[] bubbleSort = arr;
            if (bubbleSort != null)
            {
                //Traverse through the array from beginning to end comparing the values.
                for (int j = bubbleSort.Length - 1; j > 0; j--)
                {
                    flag = false;
                    for (int i = 0; i < j; i++)
                    {
                        //Compare the current element and next element.
                        if (string.Compare(bubbleSort[i], bubbleSort[i + 1], StringComparison.CurrentCulture) < 0)
                        {
                            //Swap if elements are out of order.
                            tmp = bubbleSort[i];
                            bubbleSort[i] = bubbleSort[i + 1];
                            bubbleSort[i + 1] = tmp;
                            flag = true;
                            count++;
                        }
                    }
                    // If array is sorted, break loop.
                    if (flag == false)
                        break;
                }
                Console.WriteLine("\n \n BubbleReverseSort AFTER sorting: ");
                foreach (var word in bubbleSort)
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine("\n# of comparisons made = " + count);
                //Runtime:
                    //Worst Case: O(n^2)
                    //Best Case: O(n)
            }
        }

        static void selectionReverseSort(string[] arr)
        {
            string[] selectionSort = arr;
            long count = 0;
            string tmp;
            if (selectionSort != null)
            {
                for (int i = 0; i < selectionSort.Length - 1; i++)
                {
                    int minPos = i;

                    for (int j = i + 1; j < selectionSort.Length; j++)
                    {
                        if (string.Compare(selectionSort[j], selectionSort[minPos], StringComparison.CurrentCulture) > 0)
                        {
                            minPos = j;
                            count = i++;
                        }
                    }
                    
                    tmp = selectionSort[i];
                    selectionSort[i] = selectionSort[minPos];
                    selectionSort[minPos] = tmp;
                    count = i++;
                }
                Console.WriteLine("\n \n SelectionReverseSort AFTER sorting: ");
                foreach (var word in selectionSort)
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine("\n# of comparisons made = " + count);
            }
        }

        static void mergeReverseSort(string[] arr)
        {
            string[] mergeSort = arr;
            long count = 0;
            if (mergeSort != null)
            {
                string[] tmp = new string[mergeSort.Length];
                MergeReverseSortHelper(mergeSort, 0, mergeSort.Length - 1, tmp, ref count);
                
            }
            Console.WriteLine("\n \n MergeReverseSort AFTER sorting: ");

            foreach (var word in mergeSort)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n# of comparisons made = " + count);
        }

        public static void MergeReverseSortHelper(string[] mergeSort, int first, int last, string[] tmp, ref long count)
        {
            if (first < last)
            {
                int mid = (first + last) / 2;
                MergeReverseSortHelper(mergeSort, first, mid, tmp, ref count);
                MergeReverseSortHelper(mergeSort, mid + 1, last, tmp, ref count);
                Merge(mergeSort, first, mid + 1, last, tmp, ref count);
            }
        }

        public static void Merge(string[] mergeSort, int first, int mid, int last, string[] tmp, ref long count)
        {
            int i = first;
            int j = mid;
            int k = first;

            while (i < mid && j <= last)
            {
                if (string.Compare(mergeSort[i], mergeSort[j], StringComparison.CurrentCulture) > 0)
                {
                    tmp[k] = mergeSort[i];
                    k++;
                    i++;
                }
                else
                {
                    tmp[k] = mergeSort[j];
                    j++;
                    k++;
                }
                count++;
            }
            
            while (i < mid)
            {
                tmp[k] = mergeSort[i];
                k++;
                i++;
            }

            while (j <= last)
            {
                tmp[k] = mergeSort[j];
                j++;
                k++;
            }
            
            for (int p = first; p <= last; p++)
                mergeSort[p] = tmp[p];
        }

        static void quickReverseSort(string[] arr)
        {
            string[] quickSort = arr;
            long count = 0;
            if (quickSort != null)
            {
                QuickReverseSortHelper(quickSort, 0, quickSort.Length - 1, ref count);
            }
            Console.WriteLine("\n \n QuickReverseSort AFTER sorting: ");

            foreach (var word in quickSort)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n# of comparisons made = " + count);
        }

        public static void QuickReverseSortHelper(string[] quickSort, int left, int right, ref long count)
        {
            if (left < right)
            {
                int partIdx = Partition(quickSort, left, right, ref count);
                QuickReverseSortHelper(quickSort, left, partIdx - 1, ref count);
                QuickReverseSortHelper(quickSort, partIdx + 1, right, ref count);
            }
        }

        static public int Partition(string[] quickSort, int left, int right, ref long count)
        {
            int lessIndex = (left - 1);
            string tmp;
            string tmp1;
            
            for (int j = left; j < right; j++)
            {
                if (string.Compare(quickSort[j], quickSort[right], StringComparison.CurrentCulture) > 0)
                {
                    lessIndex++;
                    tmp = quickSort[lessIndex];
                    quickSort[lessIndex] = quickSort[j];
                    quickSort[j] = tmp;
                    count++;
                }

            }
            
            tmp1 = quickSort[lessIndex + 1];
            quickSort[lessIndex + 1] = quickSort[right];
            quickSort[right] = tmp1;
            return lessIndex + 1;
        }
    }
}

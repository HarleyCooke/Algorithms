using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlgorithimTask
{
    class Program
    {

        public static int[] LinearSearch(int[] numbers)
        {
            List<int> fifteenHundredthNums = new List<int>();
            var Start = DateTime.Now;
            Console.WriteLine("Linear Search | Time Started: " + Start.ToString("h:mm:ss.fff tt"));
            int bigNum = 0;
            int counter = 0;
            foreach (var num in numbers)
            {
                counter++;
                if (num > bigNum)
                {
                    bigNum = num;
                }
                if (counter % 1500 == 0)
                {
                    fifteenHundredthNums.Add(num);
                    Console.WriteLine(counter + "th number: " + num);
                }
            }
            var End = DateTime.Now;
            var Time = End - Start;
            Console.WriteLine("Linear Search | Time Ended: " + End.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Linear Search | Duration: " + Time.TotalMilliseconds + " ms.");
            return fifteenHundredthNums.ToArray();
        }

        public static object BinarySearch(int[] numbers, int key)
        {

            int min = 0;
            int max = numbers.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == numbers[mid])
                {
                    return numbers[mid];
                }
                else if (key < numbers[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return "Nil";
        }

        public static int[] InsertionSort(int[] inputArray)
        {
            var Start = DateTime.Now;
            Console.WriteLine("Insetion Sort | Time Started: " + Start.ToString("h:mm:ss.fff tt"));


            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }

            var End = DateTime.Now;
            var Time = End - Start;
            Console.WriteLine("Insetion Sort | Time Ended: " + End.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Insetion Sort | Duration: " + Time.TotalMilliseconds + " ms.");

            return inputArray;
        }

        public static void shellSort(int[] arr, int array_size)
        {
            var Start = DateTime.Now;
            Console.WriteLine("Shell Sort | Time Started: " + Start.ToString("h:mm:ss.fff tt"));

            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array_size; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }

            var End = DateTime.Now;
            var Time = End - Start;
            Console.WriteLine("Shell Sort | Time Ended: " + End.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Shell Sort | Duration: " + Time.TotalMilliseconds + " ms.");
        }

        static void Main(string[] args)
        {

        var csvArray = File.ReadAllLines(@"C:/Users/Owner/Documents/Diploma Weekly Task 13/unsorted_numbers.csv");

        List<int> nums = new List<int>();
        foreach (var num in csvArray)
        {
            int i = int.Parse(num);
            nums.Add(i);
        }

        int[] sortedArray = InsertionSort(nums.ToArray());
            

        List<string> stringInsertionNums = new List<string>();
        foreach (var num in sortedArray)
        {
                stringInsertionNums.Add(num.ToString());
        }

        File.WriteAllLines(@"C:/Users/Owner/Documents/Diploma Weekly Task 13/insertion_sorted_numbers.txt", stringInsertionNums.ToArray());

            Console.WriteLine("Ween" + Environment.NewLine);

        int[] shellArray = nums.ToArray();
         
            shellSort(shellArray, shellArray.Length);

            List<string> stringShellNums = new List<string>();
            foreach (var num in shellArray)
            {
                stringShellNums.Add(num.ToString());
            }

        File.WriteAllLines(@"C:/Users/Owner/Documents/Diploma Weekly Task 13/shell_sorted_numbers.txt", stringShellNums.ToArray());

            Console.WriteLine("Ween" + Environment.NewLine);

            int[] WeenNumbers = LinearSearch(nums.ToArray());

            Console.WriteLine("Ween" + Environment.NewLine);

            var Start = DateTime.Now;
            Console.WriteLine("Binary Search | Time Started: " + Start.ToString("h:mm:ss.fff tt"));
            int counter = 0;
            foreach (var numb in WeenNumbers)
            {
                counter++;
                Console.WriteLine(counter * 1500 + "th number: " + BinarySearch(shellArray.ToArray(), numb));
            }

            var End = DateTime.Now;
            var Time = End - Start;
            Console.WriteLine("Binary Search | Time Ended: " + End.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Binary Search | Duration: " + Time.TotalMilliseconds + " ms.");




            Console.ReadLine();

        }
    }
}

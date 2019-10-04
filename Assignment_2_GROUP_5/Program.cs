using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_GROUP_5
{
    class Program
    {
        static void Main(string[] args)
        {

            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));
            Console.WriteLine("\n");

            int[] nums1 = { 1, 2, 2, 1, 2 };
            int[] nums2 = { 2, 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));
            Console.WriteLine("\n");
            Console.ReadLine();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                string[] the_array = nums.Select(i => i.ToString()).ToArray();
                var index = -1;
                var last = nums.Last();
                string target1 = target.ToString();
                if (target > last)
                {
                    index = nums.Length + 1;
                }
                for (int i = 0; i < the_array.Length; i++)
                {
                    if (the_array[i].Contains(target1))
                    {
                        index = i;
                        break;
                    }
                    if (target < nums[i])
                    {
                        index = i;
                        break;
                    }
                }
                return index;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }
            return 0;
        }

        public static int LargestUniqueNumber(int[] A)
        {
            //sort
            Array.Sort(A);
            // reverse array 
            Array.Reverse(A);
            try
            {
                for (int i = 0; i < A.Length; i++)
                {
                    int j;
                    for (j = 0; j < A.Length; j++)
                    {
                        if (i != j && A[i] == A[j])
                        {
                            break;
                        }
                    }
                    if (j == A.Length)
                    {
                        return A[i];
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }
            return -1;
        }

        private static void DisplayArray(int[] intersect)
        {
            try
            {
                Console.WriteLine("[{0}]", string.Join(", ", intersect));

            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while computing DisplayArray()");
            }
        }
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                var count = new Dictionary<int, int>();
                foreach (var num in nums1)
                {
                    if (!count.ContainsKey(num))
                        count[num] = 0;
                    count[num]++;
                }
                var output = new List<int>();
                foreach (var number in nums2)
                {
                    if (count.ContainsKey(number) && count[number] > 0)
                    {
                        output.Add(number);
                        count[number]--;
                    }
                }
                return output.ToArray();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }
            return new int[] { };
        }

        public static int CalculateTime(string keyboard, string word)
        {
            int output = 0;
            int presentPosition = 0;
            foreach (var num in word)
            {
                int x = keyboard.IndexOf(num);
                output = output + Math.Abs(presentPosition - x);
                presentPosition = x;
            }
            return output;
        }
    }
}

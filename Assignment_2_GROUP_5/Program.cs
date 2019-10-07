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
            //Console.ReadLine(); 

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }

           
            Console.ReadLine();
        }
        //Added by Pradeep on 10/04/2019
        //This method is used to insert a specific element
        public static int SearchInsert(int[] nums, int target)
        {
            try
            { 
                ////Declaration 
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
        //added by pradeep 10/03/2019
        //This method is to find the largest unique number
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
        //Added by Julian on 10/07/2019
        // This method is to find the intersect 
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

        //Added by Alysson on 10/07/2019
        // This method is used to get the CalculateTime program
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

        //Added by Pradeep on 10/05/2019
        // This method is used to calculate the flipandimage program
        public static int[,] FlipAndInvertImage(int[,] A)
        {

            int i = A.GetLength(0);
            int j = A.GetLength(1);
            int[,] invertedArray = new int[i, j];
            int x = 0;
            int y = 0;
            int nrow = i - 1;
            int ncol = i - 1;
            int value;
            int invertedValue;

            try
            {
                //reverse each row

                //rows
                for (x = 0; x <= i - 1 ; x++)
                {
                    //columns
                    for (y = 0; y <= j - 1; y++)
                    {
                        value = A[x, y];
                        if (value == 1)
                        {
                            invertedValue = 0;
                        }
                        else
                        {
                            invertedValue = 1;
                        }

                        invertedArray.SetValue(invertedValue, x, ncol);
                        ncol--;
                    }
                    ncol = i - 1;
                }// end of reverse each row and invert image
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return invertedArray;
        } // end of exercise 5 - FlipAndInvertImage

        private static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        //Added by Alysson on 10/06/2019
        // This method calculates sorted Squares 
        private static int[] SortedSquares(int[] arr)
        {
            int size = arr.GetLength(0);
            int [] squares = new int [size];
            int value;
            int j = 0;
            

            try
            {
                Array.Sort(arr);
                foreach (int i in arr)
                {
                    value = (int) Math.Pow(i, 2);
                    squares.SetValue(value, j);
                    j++;
                }
                Array.Sort(squares);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return squares;
        }

        //Added by Julian on 10/06/2019
        //This method calculates the Valid Palindrome question
        private static bool ValidPalindrome(string s)
        {
            int len = s.Length;
            string alfa;
            string beta;
            int i;

            try
            {
                if (len >= 1 && len <= 50000)
                {
                    for (i = 0; i <= len - 1; i++)
                    {
                        // o except deleta todas as letras a de uma vez. em vez disso fazer um concatenar de dois substrings
                        alfa = s.Substring(0, i);
                        beta = s.Substring(i + 1, len - 1 - i);
                        var subset = alfa + beta;
                        char[] rev = subset.ToCharArray();
                        Array.Reverse(rev);
                        string rev2 = new string(rev);

                        if (subset == rev2)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
        //added by alysson on 10/06/2019
        //This method calculates the minumun requered rooms 
        public static int MinMeetingRooms(int[,] intervals)
        {

            List<int> startList = new List<int>();
            List<int> endList = new List<int>();
            int max = 0;
            int temp = 0;
            int sLoop = 0;
            int eLoop = 0;
            try
            {
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    startList.Add(intervals[i, 0]);
                    endList.Add(intervals[i, 1]);
                }
                startList.Sort();
                endList.Sort();
                while (sLoop < startList.Count && eLoop < startList.Count)
                {


                    if (startList[sLoop] <= endList[eLoop])
                    {

                        temp++;
                        if (temp > max)
                        {
                            max = temp;
                        }
                        sLoop++;
                    }
                    else
                    {
                        temp--;
                        eLoop++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }
            return max;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Finds Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // Self-Reflection: This problem helped me understand how to use an array's index as a marker to efficiently find missing numbers.
        // Code Comment: The approach modifies the array to mark visited numbers as negative. Missing indices correspond to positive values.

        public static IList<int> FindMissingNumbers(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

        // Question 2: Sort Array by Parity
        // Self-Reflection: This task was insightful in applying two-pointer techniques to solve problems efficiently.
        // Code Comment: Two-pointer technique is used to move even numbers to the front and odd numbers to the back.

        public static int[] SortArrayByParity(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] % 2 > nums[right] % 2)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                }

                if (nums[left] % 2 == 0) left++;
                if (nums[right] % 2 == 1) right--;
            }
            return nums;
        }

        // Question 3: Two Sum (Find Two Numbers that Add to Target)
        // Self-Reflection: Implementing this solution allowed me to understand the benefits of hash maps for quick lookups.
        // Code Comment: Use a dictionary to find two indices that sum up to the target value efficiently.

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            return new int[0];
        }

        // Question 4: Find Maximum Product of Three Numbers
        // Self-Reflection: This problem emphasized the importance of considering both positive and negative numbers when looking for maximum products.
        // Code Comment: Sort the array and consider the two possible maximum products involving both small negative numbers and large positive numbers.

        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);

        }

        // Question 5: Decimal to Binary Conversion
        // Self-Reflection: This exercise reinforced my understanding of number systems and conversions.
        // Code Comment: Utilize the built-in `Convert.ToString` method to convert a decimal number to binary.

        public static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";
            string binary = "";
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary;
                decimalNumber /= 2;
            }
            return binary;
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // Self-Reflection: Implementing a binary search solution for this problem improved my understanding of searching in rotated arrays.
        // Code Comment: Binary search is used to find the minimum in a rotated sorted array by checking which half is sorted.

        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return nums[left];
        }

        // Question 7: Palindrome Number
        // Self-Reflection: This problem was straightforward but highlighted the importance of careful handling of negative inputs.
        // Code Comment: Reverse the number and compare it to the original to determine if it is a palindrome.

        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int original = x, reversed = 0;
            while (x != 0)
            {
                int digit = x % 10;
                reversed = reversed * 10 + digit;
                x /= 10;
            }
            return original == reversed;

        }

        // Question 8: Fibonacci Number
        // Self-Reflection: This exercise was a good refresher on the iterative approach to computing Fibonacci numbers, avoiding recursion.
        // Code Comment: Calculate Fibonacci numbers iteratively to avoid the inefficiencies of recursion.

        public static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            int a = 0, b = 1, sum = 0;
            for (int i = 2; i <= n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }
            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1855
{
    public class Test1855
    {
        public void Test()
        {
            Interface1855 solution = new Solution1855();
            int[] nums1, nums2;
            int result, answer;
            int id = 0;

            // 1. 
            nums1 = [55, 30, 5, 4, 2]; nums2 = [100, 20, 10, 10, 5];
            answer = 2;
            result = solution.MaxDistance(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums1 = [2, 2, 2]; nums2 = [10, 10, 1];
            answer = 1;
            result = solution.MaxDistance(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums1 = [30, 29, 19, 5]; nums2 = [25, 25, 25, 25, 25];
            answer = 2;
            result = solution.MaxDistance(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

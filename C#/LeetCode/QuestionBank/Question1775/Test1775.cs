using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1775
{
    public class Test1775
    {
        public void Test()
        {
            Interface1775 solution = new Solution1775();
            int[] nums1, nums2;
            int result, answer;
            int id = 0;

            // 1. 
            nums1 = new int[] { 1, 2, 3, 4, 5, 6 }; nums2 = new int[] { 1, 1, 2, 2, 2, 2 };
            answer = 3; result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums1 = new int[] { 1, 1, 1, 1, 1, 1, 1 }; nums2 = new int[] { 6 };
            answer = -1; result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums1 = new int[] { 6, 6 }; nums2 = new int[] { 1 };
            answer = 3; result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums1 = new int[] { 5, 6, 4, 3, 1, 2 }; nums2 = new int[] { 6, 3, 3, 1, 4, 5, 3, 4, 1, 3, 4 };
            answer = 3; result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

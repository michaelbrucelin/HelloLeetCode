using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1035
{
    public class Test1035
    {
        public void Test()
        {
            Interface1035 solution = new Solution1035();
            int[] nums1, nums2;
            int result, answer;
            int id = 0;

            // 1. 
            nums1 = [1, 4, 2]; nums2 = [1, 2, 4];
            answer = 2;
            result = solution.MaxUncrossedLines(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums1 = [2, 5, 1, 2, 5]; nums2 = [10, 5, 2, 1, 5, 2];
            answer = 3;
            result = solution.MaxUncrossedLines(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums1 = [1, 3, 7, 1, 7, 5]; nums2 = [1, 9, 2, 5, 1];
            answer = 2;
            result = solution.MaxUncrossedLines(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

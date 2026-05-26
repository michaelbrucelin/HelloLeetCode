using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3724
{
    public class Test3724
    {
        public void Test()
        {
            Interface3724 solution = new Solution3724();
            int[] nums1, nums2;
            long result, answer;
            int id = 0;

            // 1. 
            nums1 = [2, 8]; nums2 = [1, 7, 3];
            answer = 4;
            result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums1 = [1, 3, 6]; nums2 = [2, 4, 5, 3];
            answer = 4;
            result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums1 = [2]; nums2 = [3, 4];
            answer = 3;
            result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums1 = [1, 100000]; nums2 = [100000, 1, 50000];
            answer = 199999;
            result = solution.MinOperations(nums1, nums2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

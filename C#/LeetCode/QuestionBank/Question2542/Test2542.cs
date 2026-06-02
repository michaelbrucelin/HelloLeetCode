using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2542
{
    public class Test2542
    {
        public void Test()
        {
            Interface2542 solution = new Solution2542();
            int[] nums1, nums2; int k;
            long result, answer;
            int id = 0;

            // 1. 
            nums1 = [1, 3, 3, 2]; nums2 = [2, 1, 3, 4]; k = 3;
            answer = 12;
            result = solution.MaxScore(nums1, nums2, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}"); ;

            // 2. 
            nums1 = [4, 2, 3, 1, 1]; nums2 = [7, 5, 10, 9, 6]; k = 1;
            answer = 30;
            result = solution.MaxScore(nums1, nums2, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}"); ;
        }
    }
}

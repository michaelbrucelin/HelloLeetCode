using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0373
{
    public class Test0373
    {
        public void Test()
        {
            Interface0373 solution = new Solution0373();
            int[] nums1, nums2; int k;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            nums1 = [1, 7, 11]; nums2 = [2, 4, 6]; k = 3;
            answer = [[1, 2], [1, 4], [1, 6]];
            result = solution.KSmallestPairs(nums1, nums2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            nums1 = [1, 1, 2]; nums2 = [1, 2, 3]; k = 2;
            answer = [[1, 1], [1, 1]];
            result = solution.KSmallestPairs(nums1, nums2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            nums1 = [1, 2, 4, 5, 6]; nums2 = [3, 5, 7, 9]; k = 3;
            answer = [[1, 3], [2, 3], [1, 5]];
            result = solution.KSmallestPairs(nums1, nums2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            nums1 = [1, 2, 4, 5, 6]; nums2 = [3, 5, 7, 9]; k = 20;
            answer = [[1, 3], [2, 3], [1, 5], [2, 5], [4, 3], [1, 7], [5, 3], [2, 7], [4, 5], [6, 3], [1, 9], [5, 5], [2, 9], [4, 7], [6, 5], [5, 7], [4, 9], [6, 7], [5, 9], [6, 9]];
            result = solution.KSmallestPairs(nums1, nums2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

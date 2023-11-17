using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2736
{
    public class Test2736
    {
        public void Test()
        {
            Interface2736 solution = new Solution2736_2();
            int[] nums1, nums2; int[][] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums1 = [4, 3, 1, 2]; nums2 = [2, 4, 9, 5]; queries = Utils.Str2NumArray_2d<int>("[[4,1],[1,3],[2,5]]");
            answer = [6, 10, 7];
            result = solution.MaximumSumQueries(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums1 = [3, 2, 5]; nums2 = [2, 3, 4]; queries = Utils.Str2NumArray_2d<int>("[[4,4],[3,2],[1,1]]");
            answer = [9, 9, 9];
            result = solution.MaximumSumQueries(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums1 = [2, 1]; nums2 = [2, 3]; queries = Utils.Str2NumArray_2d<int>("[[3,3]]");
            answer = [-1];
            result = solution.MaximumSumQueries(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

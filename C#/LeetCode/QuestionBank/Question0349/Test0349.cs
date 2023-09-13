using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0349
{
    public class Test0349
    {
        public void Test()
        {
            Interface0349 solution = new Solution0349_3();
            int[] nums1, nums2;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums1 = new int[] { 1, 2, 2, 1 }; nums2 = new int[] { 2, 2 };
            answer = new int[] { 2 };
            result = solution.Intersection(nums1, nums2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums1 = new int[] { 4, 9, 5 }; nums2 = new int[] { 9, 4, 9, 8, 4 };
            answer = new int[] { 9, 4 };
            result = solution.Intersection(nums1, nums2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums1 = new int[] { 9, 3, 7 }; nums2 = new int[] { 6, 4, 1, 0, 0, 4, 4, 8, 7 };
            answer = new int[] { 7 };
            result = solution.Intersection(nums1, nums2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0088
{
    public class Test0088
    {
        public void Test()
        {
            Interface0088 solution = new Solution0088_5();
            int[] nums1, nums2; int m, n;
            int[] answer;
            int id = 0;

            // 1. 
            nums1 = new int[] { 1, 2, 3, 0, 0, 0 }; m = 3; nums2 = new int[] { 2, 5, 6 }; n = 3;
            answer = new int[] { 1, 2, 2, 3, 5, 6 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums1 = new int[] { 1, 8, 9, 0, 0, 0 }; m = 3; nums2 = new int[] { 2, 5, 6 }; n = 3;
            answer = new int[] { 1, 2, 5, 6, 8, 9 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums1 = new int[] { 1 }; m = 1; nums2 = new int[] { }; n = 0;
            answer = new int[] { 1 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            nums1 = new int[] { 0 }; m = 0; nums2 = new int[] { 1 }; n = 1;
            answer = new int[] { 1 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            nums1 = new int[] { -1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 }; m = 5; nums2 = new int[] { -1, -1, 0, 0, 1, 2 }; n = 6;
            answer = new int[] { -1, -1, -1, 0, 0, 0, 0, 0, 1, 2, 3 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");

            // 6. 
            nums1 = new int[] { -9, -9, -9, -6, -6, -5, -1, 1, 8, 0 }; m = 9; nums2 = new int[] { 7 }; n = 1;
            answer = new int[] { -9, -9, -9, -6, -6, -5, -1, 1, 7, 8 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");

            // 7. 
            nums1 = new int[] { -50, -49, -49, -48, -47, -45, -43, -41, -41, -41, -40, -40, -39, -39, -38, -37, -37, -36, -36, -35, -35, -33, -33, -32, -31, -31, -30, -30, -29, -28, -25, -24, -21, -19, -18, -18, -14, -13, -10, -10, -9, -9, -9, -6, -6, -5, -1, 1, 7, 10, 10, 11, 13, 14, 14, 15, 20, 21, 21, 22, 23, 25, 26, 27, 30, 30, 31, 32, 33, 35, 36, 38, 40, 40, 41, 41, 42, 44, 46, 46, 46, 46, 46, 47, 48, 0 };
            m = 85; nums2 = new int[] { 33 }; n = 1;
            answer = new int[] { -50, -49, -49, -48, -47, -45, -43, -41, -41, -41, -40, -40, -39, -39, -38, -37, -37, -36, -36, -35, -35, -33, -33, -32, -31, -31, -30, -30, -29, -28, -25, -24, -21, -19, -18, -18, -14, -13, -10, -10, -9, -9, -9, -6, -6, -5, -1, 1, 7, 10, 10, 11, 13, 14, 14, 15, 20, 21, 21, 22, 23, 25, 26, 27, 30, 30, 31, 32, 33, 33, 35, 36, 38, 40, 40, 41, 41, 42, 44, 46, 46, 46, 46, 46, 47, 48 };
            solution.Merge(nums1, m, nums2, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums1, answer) + ",",-6} result: {Utils.ArrayToString(nums1)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

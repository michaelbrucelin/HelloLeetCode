using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1764
{
    public class Test1764
    {
        public void Test()
        {
            Interface1764 solution = new Solution1764_3();
            int[][] groups; int[] nums;
            bool result, answer;
            int id = 0;

            // 1. 
            groups = new int[][] { new int[] { 1, -1, -1 }, new int[] { 3, -2, 0 } }; nums = new int[] { 1, -1, 0, 1, -1, -1, 3, -2, 0 };
            answer = true; result = solution.CanChoose(groups, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            groups = new int[][] { new int[] { 10, -2 }, new int[] { 1, 2, 3, 4 } }; nums = new int[] { 1, 2, 3, 4, 10, -2 };
            answer = false; result = solution.CanChoose(groups, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            groups = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 4 } }; nums = new int[] { 7, 7, 1, 2, 3, 4, 7, 7 };
            answer = false; result = solution.CanChoose(groups, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            groups = new int[][] { new int[] { 2, 1 } }; nums = new int[] { 12, 1 };
            answer = false; result = solution.CanChoose(groups, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            groups = new int[][] { new int[] { -5, 0 } }; nums = new int[] { 2, 0, -2, 5, -1, 2, 4, 3, 4, -5, -5 };
            answer = false; result = solution.CanChoose(groups, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            groups = new int[][] { new int[] { 30, 31, 32 }, new int[] { 60, 61, 62 }, new int[] { 90, 91, 92 } }; nums = Enumerable.Range(0, 100).ToArray();
            answer = true; result = solution.CanChoose(groups, nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

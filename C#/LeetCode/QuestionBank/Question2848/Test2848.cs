using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2848
{
    public class Test2848
    {
        public void Test()
        {
            Interface2848 solution = new Solution2848_3();
            IList<IList<int>> nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[][] { new int[] { 3, 6 }, new int[] { 1, 5 }, new int[] { 4, 7 } };
            answer = 7;
            result = solution.NumberOfPoints(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[][] { new int[] { 1, 3 }, new int[] { 5, 8 } };
            answer = 7;
            result = solution.NumberOfPoints(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[][] { new int[] { 2, 3 }, new int[] { 3, 9 }, new int[] { 5, 7 }, new int[] { 4, 10 }, new int[] { 9, 10 } };
            answer = 9;
            result = solution.NumberOfPoints(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1595
{
    public class Test1595
    {
        public void Test()
        {
            Interface1595 solution = new Solution1595();
            IList<IList<int>> cost;
            int result, answer;
            int id = 0;

            // 1. 
            cost = new int[][] { new int[] { 15, 96 }, new int[] { 36, 2 } };
            answer = 17;
            result = solution.ConnectTwoGroups(cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            cost = new int[][] { new int[] { 1, 3, 5 }, new int[] { 4, 1, 1 }, new int[] { 1, 5, 3 } };
            answer = 4;
            result = solution.ConnectTwoGroups(cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            cost = new int[][] { new int[] { 2, 5, 1 }, new int[] { 3, 4, 7 }, new int[] { 8, 1, 2 }, new int[] { 6, 2, 4 }, new int[] { 3, 8, 8 } };
            answer = 10;
            result = solution.ConnectTwoGroups(cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            cost = new int[][] {
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            answer = 12;
            result = solution.ConnectTwoGroups(cost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

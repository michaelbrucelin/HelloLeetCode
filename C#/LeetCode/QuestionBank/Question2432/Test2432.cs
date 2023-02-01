using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2432
{
    public class Test2432
    {
        public void Test()
        {
            Interface2432 solution = new Solution2432();
            int n; int[][] logs;
            int result, answer;
            int id = 0;

            // 1. 
            logs = new int[][] { new int[] { 0, 3 }, new int[] { 2, 5 }, new int[] { 0, 9 }, new int[] { 1, 15 } };
            n = 10; answer = 1;
            result = solution.HardestWorker(n, logs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            logs = new int[][] { new int[] { 1, 1 }, new int[] { 3, 7 }, new int[] { 2, 12 }, new int[] { 7, 17 } };
            n = 26; answer = 3;
            result = solution.HardestWorker(n, logs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            logs = new int[][] { new int[] { 0, 10 }, new int[] { 1, 20 } };
            n = 2; answer = 0;
            result = solution.HardestWorker(n, logs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

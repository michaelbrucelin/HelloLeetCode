using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0743
{
    public class Test0743
    {
        public void Test()
        {
            Interface0743 solution = new Solution0743_2();
            int[][] times; int n, k;
            int result, answer;
            int id = 0;

            // 1. 
            times = [[2, 1, 1], [2, 3, 1], [3, 4, 1]]; n = 4; k = 2;
            answer = 2;
            result = solution.NetworkDelayTime(times, n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            times = [[1, 2, 1]]; n = 2; k = 1;
            answer = 1;
            result = solution.NetworkDelayTime(times, n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            times = [[1, 2, 1]]; n = 2; k = 2;
            answer = -1;
            result = solution.NetworkDelayTime(times, n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            times = [[1, 2, 1], [2, 3, 2], [1, 3, 4]]; n = 3; k = 1;
            answer = 3;
            result = solution.NetworkDelayTime(times, n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

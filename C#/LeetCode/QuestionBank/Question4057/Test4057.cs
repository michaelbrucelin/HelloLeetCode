using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4057
{
    public class Test4057
    {
        public void Test()
        {
            Interface4057 solution = new Solution4057();
            int[][] intervals;
            long result, answer;
            int id = 0;

            // 1. 
            intervals = [[1, 2], [2, 3], [3, 4]];
            answer = 2;
            result = solution.CountIntersectingIntervals(intervals);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            intervals = [[1, 5], [2, 4], [3, 6]];
            answer = 3;
            result = solution.CountIntersectingIntervals(intervals);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            intervals = [[1, 2], [3, 4], [5, 6]];
            answer = 0;
            result = solution.CountIntersectingIntervals(intervals);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            intervals = [[59, 83], [34, 62], [87, 92], [98, 98]];
            answer = 1;
            result = solution.CountIntersectingIntervals(intervals);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

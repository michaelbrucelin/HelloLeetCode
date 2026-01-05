using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0149
{
    public class Test0149
    {
        public void Test()
        {
            Interface0149 solution = new Solution0149_2();
            int[][] points;
            int result, answer;
            int id = 0;

            // 1. 
            points = [[1, 1], [2, 2], [3, 3]];
            answer = 3;
            result = solution.MaxPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = [[1, 1], [3, 2], [5, 3], [4, 1], [2, 3], [1, 4]];
            answer = 4;
            result = solution.MaxPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

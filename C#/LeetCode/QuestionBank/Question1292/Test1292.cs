using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1292
{
    public class Test1292
    {
        public void Test()
        {
            Interface1292 solution = new Solution1292();
            int[][] mat; int threshold;
            int result, answer;
            int id = 0;

            // 1. 
            mat = [[1, 1, 3, 2, 4, 3, 2], [1, 1, 3, 2, 4, 3, 2], [1, 1, 3, 2, 4, 3, 2]]; threshold = 4;
            answer = 2;
            result = solution.MaxSideLength(mat, threshold);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            mat = [[2, 2, 2, 2, 2], [2, 2, 2, 2, 2], [2, 2, 2, 2, 2], [2, 2, 2, 2, 2], [2, 2, 2, 2, 2]]; threshold = 1;
            answer = 0;
            result = solution.MaxSideLength(mat, threshold);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            mat = [[18, 70], [61, 1], [25, 85], [14, 40], [11, 96], [97, 96], [63, 45]]; threshold = 40184;
            answer = 2;
            result = solution.MaxSideLength(mat, threshold);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

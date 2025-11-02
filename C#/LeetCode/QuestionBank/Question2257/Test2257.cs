using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2257
{
    public class Test2257
    {
        public void Test()
        {
            Interface2257 solution = new Solution2257();
            int m, n; int[][] guards, walls;
            int result, answer;
            int id = 0;

            // 1. 
            m = 4; n = 6; guards = [[0, 0], [1, 1], [2, 3]]; walls = [[0, 1], [2, 2], [1, 4]];
            answer = 7;
            result = solution.CountUnguarded(m, n, guards, walls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 3; n = 3; guards = [[1, 1]]; walls = [[0, 1], [1, 0], [2, 1], [1, 2]];
            answer = 4;
            result = solution.CountUnguarded(m, n, guards, walls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

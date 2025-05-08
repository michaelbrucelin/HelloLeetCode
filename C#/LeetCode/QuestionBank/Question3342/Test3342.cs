using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3342
{
    public class Test3342
    {
        public void Test()
        {
            Interface3342 solution = new Solution3342();
            int[][] moveTime;
            int result, answer;
            int id = 0;

            // 1. 
            moveTime = [[0, 4], [4, 4]];
            answer = 7;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            moveTime = [[0, 0, 0, 0], [0, 0, 0, 0]];
            answer = 6;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            moveTime = [[0, 1], [1, 2]];
            answer = 4;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

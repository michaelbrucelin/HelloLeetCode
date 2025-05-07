using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3341
{
    public class Test3341
    {
        public void Test()
        {
            Interface3341 solution = new Solution3341();
            int[][] moveTime;
            int result, answer;
            int id = 0;

            // 1. 
            moveTime = [[0, 4], [4, 4]];
            answer = 6;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            moveTime = [[0, 0, 0], [0, 0, 0]];
            answer = 3;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            moveTime = [[0, 1], [1, 2]];
            answer = 3;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            moveTime = [[15, 58], [67, 4]];
            answer = 60;
            result = solution.MinTimeToReach(moveTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

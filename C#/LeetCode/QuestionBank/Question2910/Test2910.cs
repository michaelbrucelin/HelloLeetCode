using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2910
{
    public class Test2910
    {
        public void Test()
        {
            Interface2910 solution = new Solution2910();
            int[] balls;
            int result, answer;
            int id = 0;

            // 1. 
            balls = [3, 2, 3, 2, 3];
            answer = 2;
            result = solution.MinGroupsForValidAssignment(balls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            balls = [10, 10, 10, 3, 1, 1];
            answer = 4;
            result = solution.MinGroupsForValidAssignment(balls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            balls = [3, 2, 2, 1, 1, 1, 2];
            answer = 5;
            result = solution.MinGroupsForValidAssignment(balls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            balls = [1, 1, 3, 3, 1, 1, 2, 2, 3, 1, 3, 2];
            answer = 5;
            result = solution.MinGroupsForValidAssignment(balls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            balls = [1, 1, 2, 1, 1, 1, 3, 1, 2, 3];
            answer = 4;
            result = solution.MinGroupsForValidAssignment(balls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            balls = [1, 1, 1, 3, 3, 3, 1, 2, 1, 1, 1, 2, 1];
            answer = 5;
            result = solution.MinGroupsForValidAssignment(balls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

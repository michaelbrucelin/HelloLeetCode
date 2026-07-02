using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3286
{
    public class Test3286
    {
        public void Test()
        {
            Interface3286 solution = new Solution3286();
            IList<IList<int>> grid; int health;
            bool result, answer;
            int id = 0;

            // 1. 
            grid = [[0, 1, 0, 0, 0], [0, 1, 0, 1, 0], [0, 0, 0, 1, 0]]; health = 1;
            answer = true;
            result = solution.FindSafeWalk(grid, health);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0, 1, 1, 0, 0, 0], [1, 0, 1, 0, 0, 0], [0, 1, 1, 1, 0, 1], [0, 0, 1, 0, 1, 0]]; health = 3;
            answer = false;
            result = solution.FindSafeWalk(grid, health);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 1, 1], [1, 0, 1], [1, 1, 1]]; health = 5;
            answer = true;
            result = solution.FindSafeWalk(grid, health);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[1, 1, 1, 1]]; health = 4;
            answer = false;
            result = solution.FindSafeWalk(grid, health);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3661
{
    public class Test3661
    {
        public void Test()
        {
            Interface3661 solution = new Solution3661();
            int[] robots, distance, walls;
            int result, answer;
            int id = 0;

            // 1. 
            robots = [4]; distance = [3]; walls = [1, 10];
            answer = 1;
            result = solution.MaxWalls(robots, distance, walls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2 . 
            robots = [10, 2]; distance = [5, 1]; walls = [5, 2, 7];
            answer = 3;
            result = solution.MaxWalls(robots, distance, walls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            robots = [1, 2]; distance = [100, 1]; walls = [10];
            answer = 0;
            result = solution.MaxWalls(robots, distance, walls);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

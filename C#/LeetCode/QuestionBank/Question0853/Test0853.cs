using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0853
{
    public class Test0853
    {
        public void Test()
        {
            Interface0853 solution = new Solution0853();
            int target; int[] position, speed;
            int result, answer;
            int id = 0;

            // 1. 
            target = 12; position = [10, 8, 0, 5, 3]; speed = [2, 4, 1, 1, 3];
            answer = 3;
            result = solution.CarFleet(target, position, speed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            target = 10; position = [3]; speed = [3];
            answer = 1;
            result = solution.CarFleet(target, position, speed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            target = 100; position = [0, 2, 4]; speed = [4, 2, 1];
            answer = 1;
            result = solution.CarFleet(target, position, speed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

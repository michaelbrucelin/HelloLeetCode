using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1954
{
    public class Test1954
    {
        public void Test()
        {
            Interface1954 solution = new Solution1954();
            long neededApples;
            long result, answer;
            int id = 0;

            // 1. 
            neededApples = 1;
            answer = 8;
            result = solution.MinimumPerimeter(neededApples);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            neededApples = 13;
            answer = 16;
            result = solution.MinimumPerimeter(neededApples);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            neededApples = 1000000000;
            answer = 5040;
            result = solution.MinimumPerimeter(neededApples);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            neededApples = 1000000000000000;
            answer = 503968;
            result = solution.MinimumPerimeter(neededApples);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

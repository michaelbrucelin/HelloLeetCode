using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1478
{
    public class Test1478
    {
        public void Test()
        {
            Interface1478 solution = new Solution1478();
            int[] houses; int k;
            int result, answer;
            int id = 0;

            // 1. 
            houses = [1, 4, 8, 10, 20]; k = 3;
            answer = 5;
            result = solution.MinDistance(houses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            houses = [2, 3, 5, 12, 18]; k = 2;
            answer = 9;
            result = solution.MinDistance(houses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            houses = [7, 4, 6, 1]; k = 1;
            answer = 8;
            result = solution.MinDistance(houses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            houses = [3, 6, 14, 10]; k = 4;
            answer = 0;
            result = solution.MinDistance(houses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

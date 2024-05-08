using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2079
{
    public class Test2079
    {
        public void Test()
        {
            Interface2079 solution = new Solution2079();
            int[] plants; int capacity;
            int result, answer;
            int id = 0;

            // 1. 
            plants = [2, 2, 3, 3]; capacity = 5;
            answer = 14;
            result = solution.WateringPlants(plants, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            plants = [1, 1, 1, 4, 2, 3]; capacity = 4;
            answer = 30;
            result = solution.WateringPlants(plants, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            plants = [7, 7, 7, 7, 7, 7, 7]; capacity = 8;
            answer = 49;
            result = solution.WateringPlants(plants, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

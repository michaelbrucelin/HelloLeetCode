using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2332
{
    public class Test2332
    {
        public void Test()
        {
            Interface2332 solution = new Solution2332();
            int[] buses, passengers; int capacity;
            int result, answer;
            int id = 0;

            // 1. 
            buses = [10, 20]; passengers = [2, 17, 18, 19]; capacity = 2;
            answer = 16;
            result = solution.LatestTimeCatchTheBus(buses, passengers, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            buses = [20, 30, 10]; passengers = [19, 13, 26, 4, 25, 11, 21]; capacity = 2;
            answer = 20;
            result = solution.LatestTimeCatchTheBus(buses, passengers, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            buses = [3]; passengers = [2, 4]; capacity = 2;
            answer = 3;
            result = solution.LatestTimeCatchTheBus(buses, passengers, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            buses = [3]; passengers = [2]; capacity = 1;
            answer = 1;
            result = solution.LatestTimeCatchTheBus(buses, passengers, capacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3100
{
    public class Test3100
    {
        public void Test()
        {
            Interface3100 solution = new Solution3100();
            int numBottles, numExchange;
            int result, answer;
            int id = 0;

            // 1. 
            numBottles = 13; numExchange = 6;
            answer = 15;
            result = solution.MaxBottlesDrunk(numBottles, numExchange);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            numBottles = 10; numExchange = 3;
            answer = 13;
            result = solution.MaxBottlesDrunk(numBottles, numExchange);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

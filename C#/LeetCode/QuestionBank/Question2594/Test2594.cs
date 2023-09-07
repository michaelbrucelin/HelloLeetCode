using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2594
{
    public class Test2594
    {
        public void Test()
        {
            Interface2594 solution = new Solution2594();
            int[] ranks; int cars;
            long result, answer;
            int id = 0;

            // 1. 
            ranks = new int[] { 4, 2, 3, 1 }; cars = 10;
            answer = 16;
            result = solution.RepairCars(ranks, cars);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            ranks = new int[] { 5, 1, 8 }; cars = 6;
            answer = 16;
            result = solution.RepairCars(ranks, cars);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

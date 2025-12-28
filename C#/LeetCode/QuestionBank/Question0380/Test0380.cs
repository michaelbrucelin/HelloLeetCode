using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0380
{
    public class Test0380
    {
        public void Test()
        {
            Interface0380 solution;
            bool result, answer;
            int id;

            // 1. 
            id = 0;
            solution = new RandomizedSet();
            answer = true; result = solution.Insert(1);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = false; result = solution.Remove(2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = true; result = solution.Insert(2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.GetRandom();
            answer = true; result = solution.Remove(1);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = false; result = solution.Insert(2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.GetRandom();

            // 2. 
            id = 0;
            solution = new RandomizedSet();
            answer = false; result = solution.Remove(0);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = false; result = solution.Remove(0);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = true; result = solution.Insert(0);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.GetRandom();
            answer = true; result = solution.Remove(0);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = true; result = solution.Insert(0);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1625
{
    public class Test1625
    {
        public void Test()
        {
            Interface1625 solution;
            int result, answer;
            int id = 0;

            // 1. 
            solution = new LRUCache(2);
            solution.Put(1, 1);
            solution.Put(2, 2);
            answer = 1;
            result = solution.Get(1);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Put(3, 3);
            answer = -1;
            result = solution.Get(2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Put(4, 4);
            answer = -1;
            result = solution.Get(1);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 3;
            result = solution.Get(3);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 4;
            result = solution.Get(4);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

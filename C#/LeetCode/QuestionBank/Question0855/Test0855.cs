using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0855
{
    public class Test0855
    {
        public void Test()
        {
            Interface0855 solution;
            int result, answer;
            int id = 0, id1;

            solution = new ExamRoom_3(10);
            id++; id1 = 0;
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 9;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 4;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 2;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(4);
            result = solution.Seat(); answer = 5;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            solution = new ExamRoom_3(1000000000);
            id++; id1 = 0;
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);

            solution = new ExamRoom_3(10);
            id++; id1 = 0;
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 9;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 4;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            solution.Leave(4);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 4;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 2;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 6;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 1;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 3;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 5;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 7;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 8;
            Console.WriteLine($"{id}-{++id1,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
        }
    }
}

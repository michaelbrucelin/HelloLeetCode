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
            Interface0855 solution = new ExamRoom_2(10);
            int result, answer;
            int id = 0;

            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 9;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 4;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Seat(); answer = 2;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(4);
            result = solution.Seat(); answer = 5;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            solution = new ExamRoom_2(1000000000);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
            result = solution.Seat(); answer = 0;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Leave(0);
        }
    }
}

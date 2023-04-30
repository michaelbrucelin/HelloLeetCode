using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0682
{
    public class Test0682
    {
        public void Test()
        {
            Interface0682 solution = new Solution0682();
            string[] operations;
            int result, answer;
            int id = 0;

            // 1. 
            operations = new string[] { "5", "2", "C", "D", "+" }; answer = 30;
            result = solution.CalPoints(operations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            operations = new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" }; answer = 27;
            result = solution.CalPoints(operations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            operations = new string[] { "1" }; answer = 1;
            result = solution.CalPoints(operations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

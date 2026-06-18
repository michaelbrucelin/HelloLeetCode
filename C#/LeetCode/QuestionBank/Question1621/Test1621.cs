using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1621
{
    public class Test1621
    {
        public void Test()
        {
            Interface1621 solution = new Solution1621();
            int n, k;
            int result, answer;
            int id = 0;

            // 1. 
            n = 4; k = 2;
            answer = 5;
            result = solution.NumberOfSets(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; k = 1;
            answer = 3;
            result = solution.NumberOfSets(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 30; k = 7;
            answer = 796297179;
            result = solution.NumberOfSets(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 5; k = 3;
            answer = 7;
            result = solution.NumberOfSets(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 3; k = 2;
            answer = 1;
            result = solution.NumberOfSets(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

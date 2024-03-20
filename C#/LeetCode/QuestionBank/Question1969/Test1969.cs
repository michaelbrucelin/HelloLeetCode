using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1969
{
    public class Test1969
    {
        public void Test()
        {
            Interface1969 solution = new Solution1969();
            int p;
            int result, answer;
            int id = 0;

            // 1. 
            p = 1;
            answer = 1;
            result = solution.MinNonZeroProduct(p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            p = 2;
            answer = 6;
            result = solution.MinNonZeroProduct(p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            p = 3;
            answer = 1512;
            result = solution.MinNonZeroProduct(p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            p = 60;
            answer = 813987236;
            result = solution.MinNonZeroProduct(p);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

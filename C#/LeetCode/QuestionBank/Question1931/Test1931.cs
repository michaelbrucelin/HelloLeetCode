using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1931
{
    public class Test1931
    {
        public void Test()
        {
            Interface1931 solution = new Solution1931();
            int m, n;
            int result, answer;
            int id = 0;

            // 1. 
            m = 1; n = 1;
            answer = 3;
            result = solution.ColorTheGrid(m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 1; n = 2;
            answer = 6;
            result = solution.ColorTheGrid(m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            m = 5; n = 5;
            answer = 580986;
            result = solution.ColorTheGrid(m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            m = 2; n = 37;
            answer = 478020091;
            result = solution.ColorTheGrid(m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            m = 5; n = 1000;
            answer = 408208448;
            result = solution.ColorTheGrid(m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

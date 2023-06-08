using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1240
{
    public class Test1240
    {
        public void Test()
        {
            Interface1240 solution = new Solution1240();
            int n, m;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; m = 3; answer = 3;
            result = solution.TilingRectangle(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; m = 8; answer = 5;
            result = solution.TilingRectangle(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 11; m = 13; answer = 6;
            result = solution.TilingRectangle(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

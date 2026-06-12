using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3699
{
    public class Test3699
    {
        public void Test()
        {
            Interface3699 solution = new Solution3699();
            int n, l, r;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; l = 4; r = 5;
            answer = 2;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; l = 1; r = 3;
            answer = 10;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 44; l = 566; r = 1643;
            answer = 60589915;
            result = solution.ZigZagArrays(n, l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

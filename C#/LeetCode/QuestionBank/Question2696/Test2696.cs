using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2696
{
    public class Test2696
    {
        public void Test()
        {
            Interface2696 solution = new Solution2696();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "ABFCACDB";
            answer = 2;
            result = solution.MinLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "ACBBD";
            answer = 5;
            result = solution.MinLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

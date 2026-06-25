using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2222
{
    public class Test2222
    {
        public void Test()
        {
            Interface2222 solution = new Solution2222_2();
            string s;
            long result, answer;
            int id = 0;

            // 1. 
            s = "001101";
            answer = 6;
            result = solution.NumberOfWays(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "11100";
            answer = 0;
            result = solution.NumberOfWays(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2767
{
    public class Test2767
    {
        public void Test()
        {
            Interface2767 solution = new Solution2767();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "1011";
            answer = 2;
            result = solution.MinimumBeautifulSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "111";
            answer = 3;
            result = solution.MinimumBeautifulSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "0";
            answer = -1;
            result = solution.MinimumBeautifulSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "10110111111011";
            answer = 4;
            result = solution.MinimumBeautifulSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

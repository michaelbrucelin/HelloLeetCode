using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2380
{
    public class Test2380
    {
        public void Test()
        {
            Interface2380 solution = new Solution2380_oth();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "0110101";
            answer = 4;
            result = solution.SecondsToRemoveOccurrences(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "11100";
            answer = 0;
            result = solution.SecondsToRemoveOccurrences(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "001011";
            answer = 4;
            result = solution.SecondsToRemoveOccurrences(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "1001111111110001011001110000000110101";
            answer = 20;
            result = solution.SecondsToRemoveOccurrences(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

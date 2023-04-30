using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0290
{
    public class Test0290
    {
        public void Test()
        {
            Interface0290 solution = new Solution0290_2();
            string pattern, s;
            bool result, answer;
            int id = 0;

            // 1. 
            pattern = "abba"; s = "dog cat cat dog"; answer = true;
            result = solution.WordPattern(pattern, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            pattern = "abba"; s = "dog cat cat fish"; answer = false;
            result = solution.WordPattern(pattern, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            pattern = "aaaa"; s = "dog cat cat dog"; answer = false;
            result = solution.WordPattern(pattern, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            pattern = "abba"; s = "dog dog dog dog"; answer = false;
            result = solution.WordPattern(pattern, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3306
{
    public class Test3306
    {
        public void Test()
        {
            Interface3306 solution = new Solution3306_2();
            string word; int k;
            long result, answer;
            int id = 0;

            // 1. 
            word = "aeioqq"; k = 1;
            answer = 0;
            result = solution.CountOfSubstrings(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "aeiou"; k = 0;
            answer = 1;
            result = solution.CountOfSubstrings(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "ieaouqqieaouqq"; k = 1;
            answer = 3;
            result = solution.CountOfSubstrings(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

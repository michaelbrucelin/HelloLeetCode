using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2062
{
    public class Test2062
    {
        public void Test()
        {
            Interface2062 solution = new Solution2062_2();
            string word;
            int result, answer;
            int id = 0;

            // 1. 
            word = "aeiouu"; answer = 2;
            result = solution.CountVowelSubstrings(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "unicornarihan"; answer = 0;
            result = solution.CountVowelSubstrings(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "cuaieuouac"; answer = 7;
            result = solution.CountVowelSubstrings(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            word = "bbaeixoubb"; answer = 0;
            result = solution.CountVowelSubstrings(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

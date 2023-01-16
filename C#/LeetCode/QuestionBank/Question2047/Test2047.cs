using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2047
{
    public class Test2047
    {
        public void Test()
        {
            Interface2047 solution = new Solution2047_2();
            string sentence;
            int result, answer;
            int id = 0;

            // 1. 
            sentence = "cat and  dog"; answer = 3;
            result = solution.CountValidWords(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            sentence = "!this  1-s b8d!"; answer = 0;
            result = solution.CountValidWords(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            sentence = "alice and  bob are playing stone-game10"; answer = 5;
            result = solution.CountValidWords(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            sentence = "a-b-c"; answer = 0;
            result = solution.CountValidWords(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

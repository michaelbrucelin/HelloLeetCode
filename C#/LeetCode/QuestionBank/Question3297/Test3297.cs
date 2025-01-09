using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3297
{
    public class Test3297
    {
        public void Test()
        {
            Interface3297 solution = new Solution3297();
            string word1, word2;
            long result, answer;
            int id = 0;

            // 1. 
            word1 = "bcca"; word2 = "abc";
            answer = 1;
            result = solution.ValidSubstringCount(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word1 = "abcabc"; word2 = "abc";
            answer = 10;
            result = solution.ValidSubstringCount(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word1 = "abcabc"; word2 = "aaabc";
            answer = 0;
            result = solution.ValidSubstringCount(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            word1 = "bbbb"; word2 = "b";
            answer = 10;
            result = solution.ValidSubstringCount(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

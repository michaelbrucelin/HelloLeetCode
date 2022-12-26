using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1754
{
    public class Test1754
    {
        public void Test()
        {
            Interface1754 solution = new Solution1754();
            string word1, word2;
            string result, answer;
            int id = 0;

            // 1.
            word1 = "cabaa"; word2 = "bcaaa"; answer = "cbcabaaaaa";
            result = solution.LargestMerge(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            word1 = "abcabc"; word2 = "abdcaba"; answer = "abdcabcabcaba";
            result = solution.LargestMerge(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            word1 = "bacabc"; word2 = "badcaba"; answer = "bbadcacabcaba";
            result = solution.LargestMerge(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

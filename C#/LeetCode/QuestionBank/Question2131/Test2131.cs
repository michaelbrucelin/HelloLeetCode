using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2131
{
    public class Test2131
    {
        public void Test()
        {
            Interface2131 solution = new Solution2131();
            string[] words;
            int result, answer;
            int id = 0;

            // 1. 
            words = ["lc", "cl", "gg"];
            answer = 6;
            result = solution.LongestPalindrome(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = ["ab", "ty", "yt", "lc", "cl", "ab"];
            answer = 8;
            result = solution.LongestPalindrome(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            words = ["cc", "ll", "xx"];
            answer = 2;
            result = solution.LongestPalindrome(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            words = ["dd", "aa", "bb", "dd", "aa", "dd", "bb", "dd", "aa", "cc", "bb", "cc", "dd", "cc"];
            answer = 22;
            result = solution.LongestPalindrome(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            words = ["zb", "bb", "zy", "bz", "yb", "yz", "zz", "zy", "zb", "zz", "by", "by", "bb", "bz", "bz", "yy", "bz", "zz", "bz", "yy", "yz", "yz", "zz", "zy", "by", "zy", "bb", "yz", "yy",
                     "by", "zy", "yz", "yy", "by", "zz", "bb", "yb", "by", "yy", "zb", "bb", "yz", "yb", "zz", "by", "yb", "zy", "bb", "yz", "zb", "zy", "yy", "bb", "by", "yb", "yb", "bb", "bb"];
            answer = 110;
            result = solution.LongestPalindrome(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

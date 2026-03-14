using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0139
{
    public class Test0139
    {
        public void Test()
        {
            Interface0139 solution = new Solution0139();
            string s; IList<string> wordDict;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "leetcode"; wordDict = ["leet", "code"];
            answer = true;
            result = solution.WordBreak(s, wordDict);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "applepenapple"; wordDict = ["apple", "pen"];
            answer = true;
            result = solution.WordBreak(s, wordDict);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "catsandog"; wordDict = ["cats", "dog", "sand", "and", "cat"];
            answer = false;
            result = solution.WordBreak(s, wordDict);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

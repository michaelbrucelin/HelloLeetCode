using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0140
{
    public class Test0140
    {
        public void Test()
        {
            Interface0140 solution = new Solution0140_3();
            string s; IList<string> wordDict;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            s = "catsanddog"; wordDict = ["cat", "cats", "and", "sand", "dog"];
            answer = ["cats and dog", "cat sand dog"];
            result = solution.WordBreak(s, wordDict);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "pineapplepenapple"; wordDict = ["apple", "pen", "applepen", "pine", "pineapple"];
            answer = ["pine apple pen apple", "pineapple pen apple", "pine applepen apple"];
            result = solution.WordBreak(s, wordDict);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            s = "catsandog"; wordDict = ["cats", "dog", "sand", "and", "cat"];
            answer = [];
            result = solution.WordBreak(s, wordDict);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2707
{
    public class Test2707
    {
        public void Test()
        {
            Interface2707 solution = new Solution2707();
            string s; string[] dictionary;
            int result, answer;
            int id = 0;

            // 1. 
            s = "leetscode"; dictionary = new string[] { "leet", "code", "leetcode" };
            answer = 1;
            result = solution.MinExtraChar(s, dictionary);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "sayhelloworld"; dictionary = new string[] { "hello", "world" };
            answer = 3;
            result = solution.MinExtraChar(s, dictionary);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

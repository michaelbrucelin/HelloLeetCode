using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0953
{
    public class Test0953
    {
        public void Test()
        {
            Interface0953 solution = new Solution0953();
            string[] words; string order;
            bool result, answer;
            int id = 0;

            // 1. 
            words = new string[] { "hello", "leetcode" }; order = "hlabcdefgijkmnopqrstuvwxyz"; answer = true;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = new string[] { "word", "world", "row" }; order = "worldabcefghijkmnpqstuvxyz"; answer = false;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");


            // 3. 
            words = new string[] { "apple", "app" }; order = "abcdefghijklmnopqrstuvwxyz"; answer = false;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

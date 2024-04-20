using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0034
{
    public class Test0034
    {
        public void Test()
        {
            Interface0034 solution = new Solution0034();
            string[] words; string order;
            bool result, answer;
            int id = 0;

            // 1. 
            words = ["hello", "leetcode"]; order = "hlabcdefgijkmnopqrstuvwxyz";
            answer = true;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = ["word", "world", "row"]; order = "worldabcefghijkmnpqstuvxyz";
            answer = false;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            words = ["apple", "app"]; order = "abcdefghijklmnopqrstuvwxyz";
            answer = false;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            words = ["hello", "hello"]; order = "abcdefghijklmnopqrstuvwxyz";
            answer = true;
            result = solution.IsAlienSorted(words, order);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

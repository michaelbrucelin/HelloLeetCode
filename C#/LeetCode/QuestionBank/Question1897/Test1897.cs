using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1897
{
    public class Test1897
    {
        public void Test()
        {
            Interface1897 solution = new Solution1897_2();
            string[] words;
            bool result, answer;
            int id = 0;

            // 1. 
            words = new string[] { "abc", "aabc", "bc" };
            answer = true;
            result = solution.MakeEqual(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = new string[] { "ab", "a" };
            answer = false;
            result = solution.MakeEqual(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

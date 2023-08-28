using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0520
{
    public class Test0520
    {
        public void Test()
        {
            Interface0520 solution = new Solution0520();
            string word;
            bool result, answer;
            int id = 0;

            // 1. 
            word = "USA"; answer = true;
            result = solution.DetectCapitalUse(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "FlaG"; answer = false;
            result = solution.DetectCapitalUse(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "Leetcode"; answer = true;
            result = solution.DetectCapitalUse(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

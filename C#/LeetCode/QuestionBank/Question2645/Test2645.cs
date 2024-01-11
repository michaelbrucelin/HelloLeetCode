using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2645
{
    public class Test2645
    {
        public void Test()
        {
            Interface2645 solution = new Solution2645();
            string word;
            int result, answer;
            int id = 0;

            // 1. 
            word = "b";
            answer = 2;
            result = solution.AddMinimum(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "aaa";
            answer = 6;
            result = solution.AddMinimum(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "abc";
            answer = 0;
            result = solution.AddMinimum(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            word = "bcbcbbbcaaabacaacbcccaacbbcbcaaccccbbbcabcbbbbcbac";
            answer = 52;
            result = solution.AddMinimum(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

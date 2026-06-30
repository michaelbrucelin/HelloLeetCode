using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0820
{
    public class Test0820
    {
        public void Test()
        {
            Interface0820 solution = new Solution0820();
            string[] words;
            int result, answer;
            int id = 0;

            // 1. 
            words = ["time", "me", "bell"];
            answer = 10;
            result = solution.MinimumLengthEncoding(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = ["t"];
            answer = 2;
            result = solution.MinimumLengthEncoding(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            words = ["time", "me"];
            answer = 5;
            result = solution.MinimumLengthEncoding(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

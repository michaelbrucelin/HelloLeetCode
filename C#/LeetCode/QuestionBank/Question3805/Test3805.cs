using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3805
{
    public class Test3805
    {
        public void Test()
        {
            Interface3805 solution = new Solution3805_2();
            string[] words;
            long result, answer;
            int id = 0;

            // 1. 
            words = ["fusion", "layout"];
            answer = 1;
            result = solution.CountPairs(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = ["ab", "aa", "za", "aa"];
            answer = 2;
            result = solution.CountPairs(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

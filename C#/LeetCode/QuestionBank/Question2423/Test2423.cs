using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2423
{
    public class Test2423
    {
        public void Test()
        {
            Interface2423 solution = new Solution2423();
            string word;
            bool result, answer;
            int id = 0;

            // 1. 
            word = "abcc"; answer = true;
            result = solution.EqualFrequency(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "aazz"; answer = false;
            result = solution.EqualFrequency(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "bac"; answer = true;
            result = solution.EqualFrequency(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

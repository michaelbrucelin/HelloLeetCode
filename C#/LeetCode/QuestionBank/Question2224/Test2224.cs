using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2224
{
    public class Test2224
    {
        public void Test()
        {
            Interface2224 solution = new Solution2224();
            string current, correct;
            int result, answer;
            int id = 0;

            // 1. 
            current = "02:30"; correct = "04:35"; answer = 3;
            result = solution.ConvertTime(current, correct);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            current = "11:00"; correct = "11:01"; answer = 1;
            result = solution.ConvertTime(current, correct);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            current = "00:00"; correct = "23:59"; answer = 32;
            result = solution.ConvertTime(current, correct);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

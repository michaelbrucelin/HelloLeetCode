using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2283
{
    public class Test2283
    {
        public void Test()
        {
            Interface2283 solution = new Solution2283_2();
            string num;
            bool result, answer;
            int id = 0;

            // 1. 
            num = "1210"; answer = true;
            result = solution.DigitCount(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = "030"; answer = false;
            result = solution.DigitCount(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

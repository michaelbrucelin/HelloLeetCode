using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0043
{
    public class Test0043
    {
        public void Test()
        {
            Interface0043 solution = new Solution0043();
            string num1, num2;
            string result, answer;
            int id = 0;

            // 1. 
            num1 = "2"; num2 = "3";
            answer = "6";
            result = solution.Multiply(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num1 = "123"; num2 = "456";
            answer = "56088";
            result = solution.Multiply(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

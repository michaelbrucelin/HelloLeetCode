using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2719
{
    public class Test2719
    {
        public void Test()
        {
            Interface2719 solution = new Solution2719();
            string num1, num2; int min_sum, max_sum;
            int result, answer;
            int id = 0;

            // 1. 
            num1 = "1"; num2 = "12"; min_sum = 1; max_sum = 8;
            answer = 11;
            result = solution.Count(num1, num2, min_sum, max_sum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num1 = "1"; num2 = "5"; min_sum = 1; max_sum = 5;
            answer = 5;
            result = solution.Count(num1, num2, min_sum, max_sum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num1 = "4179205230"; num2 = "7748704426"; min_sum = 8; max_sum = 46;
            answer = 883045899;
            result = solution.Count(num1, num2, min_sum, max_sum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num1 = "1479192516"; num2 = "5733987233"; min_sum = 36; max_sum = 108;
            answer = 519488312;
            result = solution.Count(num1, num2, min_sum, max_sum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

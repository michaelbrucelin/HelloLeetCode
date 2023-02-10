using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0415
{
    public class Test0415
    {
        public void Test()
        {
            Interface0415 solution = new Solution0415_2();
            string num1, num2;
            string result, answer;
            int id = 0;

            // 1. 
            num1 = "11"; num2 = "123"; answer = "134";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num1 = "456"; num2 = "77"; answer = "533";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num1 = "0"; num2 = "0"; answer = "0";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num1 = "1"; num2 = "9"; answer = "10";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            num1 = "11111111111111111111111111111111"; num2 = "999999999999999999999999999999"; answer = "10";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

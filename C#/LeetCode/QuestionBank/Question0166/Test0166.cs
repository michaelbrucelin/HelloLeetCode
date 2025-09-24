using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0166
{
    public class Test0166
    {
        public void Test()
        {
            Interface0166 solution = new Solution0166_2();
            int numerator, denominator;
            string result, answer;
            int id = 0;

            // 1. 
            numerator = 1; denominator = 2;
            answer = "0.5";
            result = solution.FractionToDecimal(numerator, denominator);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            numerator = 2; denominator = 1;
            answer = "2";
            result = solution.FractionToDecimal(numerator, denominator);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            numerator = 4; denominator = 333;
            answer = "0.(012)";
            result = solution.FractionToDecimal(numerator, denominator);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            numerator = -1; denominator = -2147483648;
            answer = "0.0000000004656612873077392578125";
            result = solution.FractionToDecimal(numerator, denominator);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            numerator = -2147483648; denominator = -1;
            answer = "2147483648";
            result = solution.FractionToDecimal(numerator, denominator);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            numerator = 7; denominator = 24000;
            answer = "0.000291(6)";
             result = solution.FractionToDecimal(numerator, denominator);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

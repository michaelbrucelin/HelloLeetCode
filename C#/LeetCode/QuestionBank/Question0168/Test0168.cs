using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0168
{
    public class Test0168
    {
        public void Test()
        {
            Interface0168 solution = new Solution0168();
            int columnNumber;
            string result, answer;
            int id = 0;

            // 1. 
            columnNumber = 1; answer = "A";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            columnNumber = 26; answer = "Z";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            columnNumber = 28; answer = "AB";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            columnNumber = 676; answer = "YZ";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            columnNumber = 701; answer = "ZY";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            columnNumber = 703; answer = "AAA";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            columnNumber = 731; answer = "ABC";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            columnNumber = 17576; answer = "YYZ";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 9. 
            columnNumber = 2147483647; answer = "FXSHRXW";
            result = solution.ConvertToTitle(columnNumber);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

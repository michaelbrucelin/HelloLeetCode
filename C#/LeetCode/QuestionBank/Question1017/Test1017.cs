using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1017
{
    public class Test1017
    {
        public void Test()
        {
            Interface1017 solution = new Solution1017_2();
            int n;
            string result, answer;
            int id = 0;

            // 1. 
            n = 2; answer = "110";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; answer = "111";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 4; answer = "100";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 0; answer = "0";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 8; answer = "11000";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 12; answer = "11100";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            n = 24; answer = "1101000";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            n = 28; answer = "1101100";
            result = solution.BaseNeg2(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

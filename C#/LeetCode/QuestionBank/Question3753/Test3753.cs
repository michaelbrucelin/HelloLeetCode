using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3753
{
    public class Test3753
    {
        public void Test()
        {
            Interface3753 solution = new Solution3753_tle();
            long num1, num2;
            long result, answer;
            int id = 0;

            // 1. 
            num1 = 120; num2 = 130;
            answer = 3;
            result = solution.TotalWaviness(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num1 = 198; num2 = 202;
            answer = 3;
            result = solution.TotalWaviness(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num1 = 4848; num2 = 4848;
            answer = 2;
            result = solution.TotalWaviness(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num1 = 2549294942; num2 = 5067104447;
            answer = 11661365485;
            result = solution.TotalWaviness(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

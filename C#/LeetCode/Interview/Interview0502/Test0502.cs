using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0502
{
    public class Test0502
    {
        public void Test()
        {
            Interface0502 solution = new Solution0502();
            double num;
            string result, answer;
            int id = 0;

            // 1. 
            num = 0.625; answer = "0.101";
            result = solution.PrintBin(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 0.1; answer = "ERROR";
            result = solution.PrintBin(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 0.11651; answer = "ERROR";
            result = solution.PrintBin(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

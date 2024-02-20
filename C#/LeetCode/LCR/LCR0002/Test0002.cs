using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0002
{
    public class Test0002
    {
        public void Test()
        {
            Interface0002 solution = new Solution0002();
            string a, b;
            string result, answer;
            int id = 0;

            // 1. 
            a = "11"; b = "10";
            answer = "101";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            a = "1010"; b = "1011";
            answer = "10101";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            a = "11"; b = "1";
            answer = "100";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            a = "100"; b = "110010";
            answer = "110110";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

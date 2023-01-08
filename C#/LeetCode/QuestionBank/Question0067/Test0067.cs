using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0067
{
    public class Test0067
    {
        public void Test()
        {
            Interface0067 solution = new Solution0067_2();
            string a, b;
            string result, answer;
            int id = 0;

            // 1. 
            a = "11"; b = "1"; answer = "100";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            a = "10"; b = "1"; answer = "11";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            a = "1010"; b = "1011"; answer = "10101";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            a = "1111"; b = "1111"; answer = "11110";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            a = "101111"; b = "10"; answer = "110001";
            result = solution.AddBinary(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

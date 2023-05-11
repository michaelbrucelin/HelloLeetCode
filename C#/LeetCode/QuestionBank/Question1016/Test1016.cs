using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1016
{
    public class Test1016
    {
        public void Test()
        {
            Interface1016 solution = new Solution1016_2();
            string s; int n;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "0110"; n = 3; answer = true;
            result = solution.QueryString(s, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "0110"; n = 4; answer = false;
            result = solution.QueryString(s, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "011010101010111101010101011111111111111111111111111111111110000000000000011111101010101001010101010101010101010101111010101010111111111111111111111111111111111100000000000000111111010101010010101010101010101010100";
            n = 1000000000; answer = false;
            result = solution.QueryString(s, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

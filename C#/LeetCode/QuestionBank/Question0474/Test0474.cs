using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0474
{
    public class Test0474
    {
        public void Test()
        {
            Interface0474 solution = new Solution0474();
            string[] strs; int m, n;
            int result, answer;
            int id = 0;

            // 1. 
            strs = ["10", "0001", "111001", "1", "0"]; m = 5; n = 3;
            answer = 4;
            result = solution.FindMaxForm(strs, m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            strs = ["10", "0", "1"]; m = 1; n = 1;
            answer = 2;
            result = solution.FindMaxForm(strs, m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            strs = ["11", "11", "0", "0", "10", "1", "1", "0", "11", "1", "0", "111", "11111000", "0", "11", "000", "1", "1", "0", "00", "1", "101", "001", "000", "0", "00", "0011", "0", "10000"]; m = 90; n = 66;
            answer = 29;
            result = solution.FindMaxForm(strs, m, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1876
{
    public class Test1876
    {
        public void Test()
        {
            Interface1876 solution = new Solution1876_3();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "xyzzaz"; answer = 1;
            result = solution.CountGoodSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aababcabc"; answer = 4;
            result = solution.CountGoodSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "abcabcabc"; answer = 7;
            result = solution.CountGoodSubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

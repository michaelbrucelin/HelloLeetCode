using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0014
{
    public class Test0014
    {
        public void Test()
        {
            Interface0014 solution = new Solution0014_2();
            string[] strs;
            string result, answer;
            int id = 0;

            // 1. 
            strs = ["flower", "flow", "flight"];
            answer = "fl";
            result = solution.LongestCommonPrefix(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            strs = ["dog", "racecar", "car"];
            answer = "";
            result = solution.LongestCommonPrefix(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            strs = ["", "b"];
            answer = "";
            result = solution.LongestCommonPrefix(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

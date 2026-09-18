using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1520
{
    public class Test1520
    {
        public void Test()
        {
            Interface1520 solution = new Solution1520_err();
            string s;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            s = "adefaddaccc";
            answer = ["e", "f", "ccc"];
            result = solution.MaxNumOfSubstrings(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "abbaccd";
            answer = ["d", "bb", "cc"];
            result = solution.MaxNumOfSubstrings(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            s = "abab";
            answer = ["abab"];
            result = solution.MaxNumOfSubstrings(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

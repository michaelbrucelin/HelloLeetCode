using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1071
{
    public class Test1071
    {
        public void Test()
        {
            Interface1071 solution = new Solution1071();
            string str1, str2;
            string result, answer;
            int id = 0;

            // 1. 
            str1 = "ABCABC"; str2 = "ABC"; answer = "ABC";
            result = solution.GcdOfStrings(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            str1 = "ABABAB"; str2 = "ABAB"; answer = "AB";
            result = solution.GcdOfStrings(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            str1 = "LEET"; str2 = "CODE"; answer = "";
            result = solution.GcdOfStrings(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

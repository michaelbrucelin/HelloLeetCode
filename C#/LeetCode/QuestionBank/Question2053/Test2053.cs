using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution = LeetCode.QuestionBank.Question2053.Solution2053;

namespace LeetCode.QuestionBank.Question2053
{
    public class Test2053
    {
        public void Test()
        {
            Interface2053 solution = new Solution();
            Func<string[], int, string> func = ((Solution)solution).KthDistinct2;
            string[] arr; int k;
            string result, answer;
            int id = 0;

            // 1. 
            arr = new string[] { "d", "b", "c", "b", "c", "a" }; k = 2; answer = "a";
            result = func(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new string[] { "aaa", "aa", "a" }; k = 1; answer = "aaa";
            result = func(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new string[] { "a", "b", "a" }; k = 3; answer = "";
            result = func(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

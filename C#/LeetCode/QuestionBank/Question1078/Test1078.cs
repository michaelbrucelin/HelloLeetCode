using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1078
{
    public class Test1078
    {
        public void Test()
        {
            Interface1078 solution = new Solution1078();
            string text, first, second;
            string[] result, answer;
            int id = 0;

            // 1. 
            text = "alice is a good girl she is a good student"; first = "a"; second = "good";
            answer = new string[] { "girl", "student" };
            result = solution.FindOcurrences(text, first, second);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            text = "we will we will rock you"; first = "we"; second = "will";
            answer = new string[] { "we", "rock" };
            result = solution.FindOcurrences(text, first, second);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");


            // 3. 
            text = "we we we we we we we we"; first = "we"; second = "we";
            answer = new string[] { "we", "we", "we", "we", "we", "we" };
            result = solution.FindOcurrences(text, first, second);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

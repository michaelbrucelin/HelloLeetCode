using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0301
{
    public class Test0301
    {
        public void Test()
        {
            Interface0301 solution = new Solution0301();
            string s;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            s = "()())()";
            answer = ["(())()", "()()()"];
            result = solution.RemoveInvalidParentheses(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "(a)())()";
            answer = ["(a())()", "(a)()()"];
            result = solution.RemoveInvalidParentheses(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            s = ")(";
            answer = [""];
            result = solution.RemoveInvalidParentheses(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            s = "()())()())";
            answer = ["(()()())", "(())(())", "(())()()", "()(()())", "()()(())", "()()()()"];
            result = solution.RemoveInvalidParentheses(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

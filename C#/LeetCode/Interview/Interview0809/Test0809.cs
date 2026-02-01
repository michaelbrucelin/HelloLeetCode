using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0809
{
    public class Test0809
    {
        public void Test()
        {
            Interface0809 solution = new Solution0809();
            int n;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            n = 3;
            answer = ["((()))", "(()())", "(())()", "()(())", "()()()"];
            result = solution.GenerateParenthesis(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

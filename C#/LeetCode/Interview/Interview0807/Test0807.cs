using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0807
{
    public class Test0807
    {
        public void Test()
        {
            Interface0807 solution = new Solution0807_2();
            string S;
            string[] result, answer;
            int id = 0;

            // 1. 
            S = "qwe";
            answer = ["qwe", "qew", "wqe", "weq", "ewq", "eqw"];
            result = solution.Permutation(S);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            S = "ab";
            answer = ["ab", "ba"];
            result = solution.Permutation(S);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1238
{
    public class Test1238
    {
        public void Test()
        {
            Interface1238 solution = new Solution1238_2();
            int n, start;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            n = 2; start = 3;
            answer = new List<int>() { 3, 2, 0, 1 };
            result = solution.CircularPermutation(n, start);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            n = 3; start = 2;
            answer = new List<int>() { 2, 6, 7, 5, 4, 0, 1, 3 };
            result = solution.CircularPermutation(n, start);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

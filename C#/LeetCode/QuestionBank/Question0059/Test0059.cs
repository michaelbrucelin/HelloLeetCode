using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0059
{
    public class Test0059
    {
        public void Test()
        {
            Interface0059 solution = new Solution0059();
            int n;
            int[][] result, answer;
            int id = 0;

            // 1. 
            n = 3;
            answer = [[1, 2, 3], [8, 9, 4], [7, 6, 5]];
            result = solution.GenerateMatrix(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            n = 1;
            answer = [[1]];
            result = solution.GenerateMatrix(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

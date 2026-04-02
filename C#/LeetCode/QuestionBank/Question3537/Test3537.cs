using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3537
{
    public class Test3537
    {
        public void Test()
        {
            Interface3537 solution = new Solution3537();
            int n;
            int[][] result, answer;
            int id = 0;

            // 1. 
            n = 0;
            answer = [[0]];
            result = solution.SpecialGrid(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            n = 1;
            answer = [[3, 0], [2, 1]];
            result = solution.SpecialGrid(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            n = 2;
            answer = [[15, 12, 3, 0], [14, 13, 2, 1], [11, 8, 7, 4], [10, 9, 6, 5]];
            result = solution.SpecialGrid(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

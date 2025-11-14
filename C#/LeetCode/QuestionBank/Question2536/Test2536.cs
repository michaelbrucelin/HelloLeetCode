using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2536
{
    public class Test2536
    {
        public void Test()
        {
            Interface2536 solution = new Solution2536();
            int n; int[][] queries;
            int[][] result, answer;
            int id = 0;

            // 1. 
            n = 3; queries = [[1, 1, 2, 2], [0, 0, 1, 1]];
            answer = [[1, 1, 0], [1, 2, 1], [0, 1, 1]];
            result = solution.RangeAddQueries(n, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            n = 2; queries = [[0, 0, 1, 1]];
            answer = [[1, 1], [1, 1]];
            result = solution.RangeAddQueries(n, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

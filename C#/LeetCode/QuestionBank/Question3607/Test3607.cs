using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3607
{
    public class Test3607
    {
        public void Test()
        {
            Interface3607 solution = new Solution3607();
            int c; int[][] connections, queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            c = 5; connections = [[1, 2], [2, 3], [3, 4], [4, 5]]; queries = [[1, 3], [2, 1], [1, 1], [2, 2], [1, 2]];
            answer = [3, 2, 3];
            result = solution.ProcessQueries(c, connections, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            c = 3; connections = []; queries = [[1, 1], [2, 1], [1, 1]];
            answer = [1, -1];
            result = solution.ProcessQueries(c, connections, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

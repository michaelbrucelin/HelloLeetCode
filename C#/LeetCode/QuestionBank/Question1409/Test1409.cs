using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1409
{
    public class Test1409
    {
        public void Test()
        {
            Interface1409 solution = new Solution1409_2();
            int[] queries; int m;
            int[] result, answer;
            int id = 0;

            // 1. 
            queries = [3, 1, 2, 1]; m = 5;
            answer = [2, 1, 2, 1];
            result = solution.ProcessQueries(queries, m);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            queries = [4, 1, 2, 2]; m = 4;
            answer = [3, 1, 2, 0];
            result = solution.ProcessQueries(queries, m);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            queries = [7, 5, 5, 8, 3]; m = 8;
            answer = [6, 5, 0, 7, 5];
            result = solution.ProcessQueries(queries, m);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

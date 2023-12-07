using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1466
{
    public class Test1466
    {
        public void Test()
        {
            Interface1466 solution = new Solution1466_3();
            int n; int[][] connections;
            int result, answer;
            int id = 0;

            // 1. 
            n = 6; connections = Utils.Str2NumArray_2d<int>("[[0,1],[1,3],[2,3],[4,0],[4,5]]");
            answer = 3;
            result = solution.MinReorder(n, connections);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; connections = Utils.Str2NumArray_2d<int>("[[1,0],[1,2],[3,2],[3,4]]");
            answer = 2;
            result = solution.MinReorder(n, connections);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3; connections = Utils.Str2NumArray_2d<int>("[[1,0],[2,0]]");
            answer = 0;
            result = solution.MinReorder(n, connections);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

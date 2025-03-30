using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2360
{
    public class Test2360
    {
        public void Test()
        {
            Interface2360 solution = new Solution2360_2();
            int[] edges;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [3, 3, 4, 2, 3];
            answer = 3;
            result = solution.LongestCycle(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [2, -1, 3, 1];
            answer = -1;
            result = solution.LongestCycle(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

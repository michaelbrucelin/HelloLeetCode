using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0051
{
    public class Test0051
    {
        public void Test()
        {
            Interface0051 solution = new Solution0051_2();
            int[] materials; int[][] cookbooks, attribute; int limit;
            int result, answer;
            int id = 0;

            // 1. 
            materials = [3, 2, 4, 1, 2]; cookbooks = [[1, 1, 0, 1, 2], [2, 1, 4, 0, 0], [3, 2, 4, 1, 0]]; attribute = [[3, 2], [2, 4], [7, 6]]; limit = 5;
            answer = 7;
            result = solution.PerfectMenu(materials, cookbooks, attribute, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            materials = [10, 10, 10, 10, 10]; cookbooks = [[1, 1, 1, 1, 1], [3, 3, 3, 3, 3], [10, 10, 10, 10, 10]]; attribute = [[5, 5], [6, 6], [10, 10]]; limit = 1;
            answer = 11;
            result = solution.PerfectMenu(materials, cookbooks, attribute, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

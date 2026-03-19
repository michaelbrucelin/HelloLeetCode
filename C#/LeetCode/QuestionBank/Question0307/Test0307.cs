using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _NumArray = LeetCode.QuestionBank.Question0307.NumArray_2;

namespace LeetCode.QuestionBank.Question0307
{
    public class Test0307
    {
        public void Test()
        {
            Interface0307 solution;
            string[] opts; int[][] args; int n;
            int result; string[] answer;
            int id = 0, id1;

            // 1. 
            id++; id1 = 1;
            opts = ["NumArray", "sumRange", "update", "sumRange"];
            args = [[1, 3, 5], [0, 2], [1, 2], [0, 2]];
            answer = ["null", "9", "null", "8"];
            n = opts.Length;
            solution = new _NumArray(args[0]);
            for (int i = 1; i < n; i++) switch (opts[i])
                {
                    case "update": solution.Update(args[i][0], args[i][1]); break;
                    case "sumRange":
                        result = solution.SumRange(args[i][0], args[i][1]);
                        Console.WriteLine($"{id,2}-{id1++,2}: {(result == Convert.ToInt32(answer[i])) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default: break;
                }

            // 2. 
            Console.WriteLine();
            id++; id1 = 1;
            opts = ["NumArray", "update", "update", "update", "sumRange", "update", "sumRange", "update", "sumRange", "sumRange", "update"];
            args = [[7, 2, 7, 2, 0], [4, 6], [0, 2], [0, 9], [4, 4], [3, 8], [0, 4], [4, 1], [0, 3], [0, 4], [0, 4]];
            answer = ["null", "null", "null", "null", "6", "null", "32", "null", "26", "27", "null"];
            n = opts.Length;
            solution = new _NumArray(args[0]);
            for (int i = 1; i < n; i++) switch (opts[i])
                {
                    case "update": solution.Update(args[i][0], args[i][1]); break;
                    case "sumRange":
                        result = solution.SumRange(args[i][0], args[i][1]);
                        Console.WriteLine($"{id,2}-{id1++,2}: {(result == Convert.ToInt32(answer[i])) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default: break;
                }
        }
    }
}

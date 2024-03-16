using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2684
{
    public class Test2684
    {
        public void Test()
        {
            Interface2684 solution = new Solution2684_3();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = Utils.Str2NumArray_2d<int>("[[2,4,3,5],[5,4,9,3],[3,4,2,11],[10,9,13,15]]");
            answer = 3;
            result = solution.MaxMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = Utils.Str2NumArray_2d<int>("[[3,2,4],[2,1,9],[1,1,7]]");
            answer = 0;
            result = solution.MaxMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = Utils.Str2NumArray_2d<int>("[[187,167,209,251,152,236,263,128,135],[267,249,251,285,73,204,70,207,74],[189,159,235,66,84,89,153,111,189],[120,81,210,7,2,231,92,128,218],[193,131,244,293,284,175,226,205,245]]");
            answer = 3;
            result = solution.MaxMoves(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1260
{
    public class Test1260
    {
        public void Test()
        {
            Interface1260 solution = new Solution1260_3();
            int[][] grid; int k;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            grid = Utils.Str2NumArray_2d<int>("[[1,2,3],[4,5,6],[7,8,9]]");
            k = 1;
            answer = Utils.Str2NumArray_2d<int>("[[9,1,2],[3,4,5],[6,7,8]]");
             result = solution.ShiftGrid(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            grid = Utils.Str2NumArray_2d<int>("[[3,8,1,9],[19,7,2,5],[4,6,11,10],[12,0,21,13]]");
            k = 4;
            answer = Utils.Str2NumArray_2d<int>("[[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]]");
            result = solution.ShiftGrid(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            grid = Utils.Str2NumArray_2d<int>("[[1,2,3],[4,5,6],[7,8,9]]");
            k = 9;
            answer = Utils.Str2NumArray_2d<int>("[[1,2,3],[4,5,6],[7,8,9]]");
            result = solution.ShiftGrid(grid, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0073
{
    public class Test0073
    {
        public void Test()
        {
            Interface0073 solution = new Solution0073_2();
            int[][] matrix;
            int[][] result, answer;
            int id = 0;

            // 1. 
            matrix = Utils.Str2NumArray_2d<int>("[[1,1,1],[1,0,1],[1,1,1]]");
            answer = Utils.Str2NumArray_2d<int>("[[1,0,1],[0,0,0],[1,0,1]]");
            solution.SetZeroes(matrix); result = matrix;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            matrix = Utils.Str2NumArray_2d<int>("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]");
            answer = Utils.Str2NumArray_2d<int>("[[0,0,0,0],[0,4,5,0],[0,3,1,0]]");
            solution.SetZeroes(matrix); result = matrix;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0566
{
    public class Test0566
    {
        public void Test()
        {
            Interface0566 solution = new Solution0566();
            int[][] mat; int r, c;
            int[][] result, answer;
            int id = 0;

            // 1. 
            mat = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2],[3,4]]"); r = 1; c = 4;
            answer = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2,3,4]]");
            result = solution.MatrixReshape(mat, r, c);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 2. 
            mat = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2],[3,4]]"); r = 2; c = 4;
            answer = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2],[3,4]]");
            result = solution.MatrixReshape(mat, r, c);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");
        }
    }
}

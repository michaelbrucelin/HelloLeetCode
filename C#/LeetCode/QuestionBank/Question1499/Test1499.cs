using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1499
{
    public class Test1499
    {
        public void Test()
        {
            Interface1499 solution = new Solution1499();
            int[][] points; int k;
            int result, answer;
            int id = 0;

            // 1. 
            points = UtilsLeetCode.Str2NumArray_2d<int>("[[1,3],[2,0],[5,10],[6,-10]]");
            k = 1; answer = 4;
            result = solution.FindMaxValueOfEquation(points, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = UtilsLeetCode.Str2NumArray_2d<int>("[[0,0],[3,0],[9,2]]");
            k = 3; answer = 3;
            result = solution.FindMaxValueOfEquation(points, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

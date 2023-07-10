using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1893
{
    public class Test1893
    {
        public void Test()
        {
            Interface1893 solution = new Solution1893_3();
            int[][] ranges; int left, right;
            bool result, answer;
            int id = 0;

            // 1. 
            ranges = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2],[3,4],[5,6]]"); left = 2; right = 5;
            answer = true;
            result = solution.IsCovered(ranges, left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            ranges = UtilsLeetCode.Str2NumArray_2d<int>("[[1,10],[10,20]]"); left = 21; right = 21;
            answer = false;
            result = solution.IsCovered(ranges, left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            ranges = UtilsLeetCode.Str2NumArray_2d<int>("[[3,3],[1,1]]"); left = 3; right = 3;
            answer = true;
            result = solution.IsCovered(ranges, left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

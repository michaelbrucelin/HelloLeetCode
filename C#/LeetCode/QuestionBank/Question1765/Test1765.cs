using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1765
{
    public class Test1765
    {
        public void Test()
        {
            Interface1765 solution = new Solution1765();
            int[][] isWater;
            int[][] result, answer;
            int id = 0;

            // 1. 
            isWater = [[0, 1], [0, 0]];
            answer = [[1, 0], [2, 1]];
            result = solution.HighestPeak(isWater);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            isWater = [[0, 0, 1], [1, 0, 0], [0, 0, 0]];
            answer = [[1, 1, 0], [0, 1, 1], [1, 2, 2]];
            result = solution.HighestPeak(isWater);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

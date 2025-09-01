using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1792
{
    public class Test1792
    {
        public void Test()
        {
            Interface1792 solution = new Solution1792_2();
            int[][] classes; int extraStudents;
            double result, answer;
            int id = 0;

            // 1. 
            classes = [[1, 2], [3, 5], [2, 2]];
            extraStudents = 2; answer = 0.78333;
            result = solution.MaxAverageRatio(classes, extraStudents);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            classes = [[2, 4], [3, 9], [4, 5], [2, 10]];
            extraStudents = 4; answer = 0.53485;
            result = solution.MaxAverageRatio(classes, extraStudents);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

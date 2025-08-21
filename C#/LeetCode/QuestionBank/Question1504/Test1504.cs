using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1504
{
    public class Test1504
    {
        public void Test()
        {
            Interface1504 solution = new Solution1504_2();
            int[][] mat;
            int result, answer;
            int id = 0;

            // 1. 
            mat = [[1, 0, 1], [1, 1, 0], [1, 1, 0]];
            answer = 13;
            result = solution.NumSubmat(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            mat = [[0, 1, 1, 0], [0, 1, 1, 1], [1, 1, 1, 0]];
            answer = 24;
            result = solution.NumSubmat(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            mat = [[1, 0, 1], [0, 1, 0], [1, 0, 1]];
            answer = 5;
            result = solution.NumSubmat(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            mat = [[0, 0, 0], [0, 0, 0], [0, 1, 1], [1, 1, 0], [0, 1, 1]];
            answer = 12;
            result = solution.NumSubmat(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

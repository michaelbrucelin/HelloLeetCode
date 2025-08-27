using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3459
{
    public class Test3459
    {
        public void Test()
        {
            Interface3459 solution = new Solution3459_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[2, 2, 1, 2, 2], [2, 0, 2, 2, 0], [2, 0, 1, 1, 0], [1, 0, 2, 2, 2], [2, 0, 0, 2, 2]];
            answer = 5;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[2, 2, 2, 2, 2], [2, 0, 2, 2, 0], [2, 0, 1, 1, 0], [1, 0, 2, 2, 2], [2, 0, 0, 2, 2]];
            answer = 4;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[1, 2, 2, 2, 2], [2, 2, 2, 2, 0], [2, 0, 0, 0, 0], [0, 0, 2, 2, 2], [2, 0, 0, 2, 0]];
            answer = 5;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = [[1]];
            answer = 1;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            grid = [[1, 1, 1, 2, 0, 0], [0, 0, 0, 0, 1, 2]];
            answer = 2;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            grid = [[2, 0, 1, 1, 0, 1, 0], [2, 2, 1, 1, 1, 0, 0], [2, 1, 0, 2, 2, 2, 0]];
            answer = 3;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            string question = "3459", testcase = "07";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_grid.txt"));
            answer = 500;
            result = solution.LenOfVDiagonal(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

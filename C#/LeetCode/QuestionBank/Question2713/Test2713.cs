using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2713
{
    public class Test2713
    {
        public void Test()
        {
            Interface2713 solution = new Solution2713_3();
            int[][] mat;
            int result, answer;
            int id = 0;

            // 1. 
            mat = [[3, 1], [3, 4]];
            answer = 2;
            result = solution.MaxIncreasingCells(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            mat = [[1, 1], [1, 1]];
            answer = 1;
            result = solution.MaxIncreasingCells(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            mat = [[3, 1, 6], [-9, 5, 7]];
            answer = 4;
            result = solution.MaxIncreasingCells(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2713", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            mat = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_mat.txt"));
            answer = 100000;
            result = solution.MaxIncreasingCells(mat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

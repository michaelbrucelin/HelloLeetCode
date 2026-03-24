using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2906
{
    public class Test2906
    {
        public void Test()
        {
            Interface2906 solution = new Solution2906_3();
            int[][] grid;
            int[][] result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 2], [3, 4]];
            answer = [[24, 12], [8, 6]];
            result = solution.ConstructProductMatrix(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            grid = [[12345], [2], [1]];
            answer = [[2], [0], [0]];
            result = solution.ConstructProductMatrix(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            string question = "2906", testcase = "03", arg = "grid";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.ConstructProductMatrix(grid);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)[0..8]}, answer: {Utils.ToString(answer, false)[0..8]}");
        }
    }
}

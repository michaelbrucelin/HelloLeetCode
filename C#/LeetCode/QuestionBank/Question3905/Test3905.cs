using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3905
{
    public class Test3905
    {
        public void Test()
        {
            Interface3905 solution = new Solution3905();
            int n, m; int[][] sources;
            int[][] result, answer;
            int id = 0;

            // 1. 
            n = 3; m = 3; sources = [[0, 0, 1], [2, 2, 2]];
            answer = [[1, 1, 2], [1, 2, 2], [2, 2, 2]];
            result = solution.ColorGrid(n, m, sources);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            n = 3; m = 3; sources = [[0, 1, 3], [1, 1, 5]];
            answer = [[3, 3, 3], [5, 5, 5], [5, 5, 5]];
            result = solution.ColorGrid(n, m, sources);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            n = 2; m = 2; sources = [[1, 1, 5]];
            answer = [[5, 5], [5, 5]];
            result = solution.ColorGrid(n, m, sources);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            string question = "3905", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            n = 316; m = 316; sources = [[0, 0, 777]];
            answer = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.ColorGrid(n, m, sources);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)[..10]}, answer: {Utils.ToString(answer, false)[..10]}");
        }
    }
}

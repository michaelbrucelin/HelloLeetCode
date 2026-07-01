using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2812
{
    public class Test2812
    {
        public void Test()
        {
            Interface2812 solution = new Solution2812_2();
            IList<IList<int>> grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = [[1, 0, 0], [0, 0, 0], [0, 0, 1]];
            answer = 0;
            result = solution.MaximumSafenessFactor(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = [[0, 0, 1], [0, 0, 0], [0, 0, 0]];
            answer = 2;
            result = solution.MaximumSafenessFactor(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = [[0, 0, 0, 1], [0, 0, 0, 0], [0, 0, 0, 0], [1, 0, 0, 0]];
            answer = 2;
            result = solution.MaximumSafenessFactor(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2812", testcase = "04", arg = "grid";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            grid = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 0;
            result = solution.MaximumSafenessFactor(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

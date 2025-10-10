using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0417
{
    public class Test0417
    {
        public void Test()
        {
            Interface0417 solution = new Solution0417();
            int[][] heights;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            heights = [[1, 2, 2, 3, 5], [3, 2, 3, 4, 4], [2, 4, 5, 3, 1], [6, 7, 1, 4, 5], [5, 1, 1, 2, 4]];
            answer = [[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]];
            result = solution.PacificAtlantic(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            heights = [[2, 1], [1, 2]];
            answer = [[0, 0], [0, 1], [1, 0], [1, 1]];
            result = solution.PacificAtlantic(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            string question = "0417", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            heights = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_heights.txt"));
            answer = [[0, 29], [1, 28], [2, 27], [2, 28], [3, 27], [34, 2], [35, 2], [35, 3], [36, 1], [36, 2], [37, 0], [37, 2], [37, 3], [38, 0], [38, 2]];
            result = solution.PacificAtlantic(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

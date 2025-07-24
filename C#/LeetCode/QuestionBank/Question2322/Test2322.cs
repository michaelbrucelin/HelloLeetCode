using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2322
{
    public class Test2322
    {
        public void Test()
        {
            Interface2322 solution = new Solution2322();
            int[] nums; int[][] edges;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 5, 5, 4, 11]; edges = [[0, 1], [1, 2], [1, 3], [3, 4]];
            answer = 9;
            result = solution.MinimumScore(nums, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [5, 5, 2, 4, 4, 2]; edges = [[0, 1], [1, 2], [5, 2], [4, 3], [1, 3]];
            answer = 0;
            result = solution.MinimumScore(nums, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2322", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            answer = 173292;
            result = solution.MinimumScore(nums, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

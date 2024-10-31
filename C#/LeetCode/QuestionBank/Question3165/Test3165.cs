using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3165
{
    public class Test3165
    {
        public void Test()
        {
            Interface3165 solution = new Solution3165_2();
            int[] nums; int[][] queries;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [3, 5, 9]; queries = [[1, -2], [0, -3]];
            answer = 21;
            result = solution.MaximumSumSubsequence(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [0, -1]; queries = [[0, -5]];
            answer = 0;
            result = solution.MaximumSumSubsequence(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [0, 1, 1, -1, -1, 1, 0]; queries = [[4, 0], [6, 0], [4, 1], [4, -1], [6, -1], [6, -1]];
            answer = 12;
            result = solution.MaximumSumSubsequence(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3165", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = 888579379;
            result = solution.MaximumSumSubsequence(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            testcase = "05";
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = 989589632;
            result = solution.MaximumSumSubsequence(nums, queries);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

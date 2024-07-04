using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3086
{
    public class Test3086
    {
        public void Test()
        {
            Interface3086 solution = new Solution3086();
            int[] nums; int k, maxChanges;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, 1, 0, 0, 0, 1, 1, 0, 0, 1]; k = 3; maxChanges = 1;
            answer = 3;
            result = solution.MinimumMoves(nums, k, maxChanges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [0, 0, 0, 0]; k = 2; maxChanges = 3;
            answer = 4;
            result = solution.MinimumMoves(nums, k, maxChanges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [0, 0, 1]; k = 3; maxChanges = 2;
            answer = 4;
            result = solution.MinimumMoves(nums, k, maxChanges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3086", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 23886; maxChanges = 15694;
            answer = 33169542;
            result = solution.MinimumMoves(nums, k, maxChanges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3976
{
    public class Test3976
    {
        public void Test()
        {
            Interface3976 solution = new Solution3976_err();
            int[] nums; int k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [1, -2, 3, 4, -5]; k = 2;
            answer = 14;
            result = solution.MaxSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [-5, -4, -3]; k = 2;
            answer = -1;
            result = solution.MaxSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "3976", testcase = "03", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 117;
            result = solution.MaxSubarraySum(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

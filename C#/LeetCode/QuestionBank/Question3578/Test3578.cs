using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3578
{
    public class Test3578
    {
        public void Test()
        {
            Interface3578 solution = new Solution3578_2();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [9, 4, 1, 3, 7]; k = 4;
            answer = 6;
            result = solution.CountPartitions(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 3, 4]; k = 0;
            answer = 2;
            result = solution.CountPartitions(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "3578", testcase = "03", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 20000000;
            answer = 146460428;
            result = solution.CountPartitions(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

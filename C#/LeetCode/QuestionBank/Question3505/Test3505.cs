using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3505
{
    public class Test3505
    {
        public void Test()
        {
            Interface3505 solution = new Solution3505();
            int[] nums; int x, k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [5, -2, 1, 3, 7, 3, 6, 4, -1]; x = 3; k = 2;
            answer = 8;
            result = solution.MinOperations(nums, x, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [9, -2, -2, -2, 1, 5]; x = 2; k = 2;
            answer = 3;
            result = solution.MinOperations(nums, x, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "3505", testcase = "03", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            x = 4041; k = 1;
            answer = 2024837420;
            result = solution.MinOperations(nums, x, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

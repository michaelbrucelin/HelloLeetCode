using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3117
{
    public class Test3117
    {
        public void Test()
        {
            Interface3117 solution = new Solution3117_2();
            int[] nums, andValues;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 4, 3, 3, 2]; andValues = [0, 3, 3, 2];
            answer = 12;
            result = solution.MinimumValueSum(nums, andValues);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 3, 5, 7, 7, 7, 5]; andValues = [0, 7, 5];
            answer = 17;
            result = solution.MinimumValueSum(nums, andValues);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 3, 4]; andValues = [2];
            answer = -1;
            result = solution.MinimumValueSum(nums, andValues);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [32, 114, 114, 105, 61, 37, 49, 49, 122, 60, 38, 55, 114, 110, 37, 96, 62, 34, 122, 97, 98, 122, 49, 106, 99, 54, 57, 32, 125, 38, 36, 48,
                    62, 105, 41, 119, 33, 54, 125, 96, 126, 127, 124, 40, 50, 57, 47, 62, 97, 42, 58, 34, 119, 44, 58, 40, 60, 47, 63, 117, 35, 124, 41, 116,
                    53, 127, 48, 52, 33, 99, 98, 100, 56, 54, 61, 61, 104, 42, 110, 39, 53, 38, 101, 49, 50, 123, 40, 32, 123, 56, 115, 33, 63, 99, 99, 100, 61, 47, 99, 57];
            andValues = [32, 32, 32, 32, 32, 32, 33];
            answer = 266;
            result = solution.MinimumValueSum(nums, andValues);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "3117", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            andValues = [2, 2, 2, 2, 2, 2, 2, 2, 2, 2];
            answer = 20;
            result = solution.MinimumValueSum(nums, andValues);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

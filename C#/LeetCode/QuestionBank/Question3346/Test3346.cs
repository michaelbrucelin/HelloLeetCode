using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3346
{
    public class Test3346
    {
        public void Test()
        {
            Interface3346 solution = new Solution3346();
            int[] nums; int k, numOperations;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 4, 5]; k = 1; numOperations = 2;
            answer = 2;
            result = solution.MaxFrequency(nums, k, numOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [5, 11, 20, 20]; k = 5; numOperations = 1;
            answer = 2;
            result = solution.MaxFrequency(nums, k, numOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 90]; k = 76; numOperations = 1;
            answer = 1;
            result = solution.MaxFrequency(nums, k, numOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [2, 49]; k = 97; numOperations = 0;
            answer = 1;
            result = solution.MaxFrequency(nums, k, numOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = [37, 30, 37]; k = 26; numOperations = 1;
            answer = 3;
            result = solution.MaxFrequency(nums, k, numOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            string question = "3346", testcase = "06";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 2284; numOperations = 96392;
            answer = 4761;
            result = solution.MaxFrequency(nums, k, numOperations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

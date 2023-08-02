using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2681
{
    public class Test2681
    {
        public void Test()
        {
            Interface2681 solution = new Solution2681_3();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 2, 1, 4 };
            answer = 141;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 1, 1 };
            answer = 7;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 76, 24, 96, 82, 97 };
            answer = 13928461;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 1, 1, 1, 1 };
            answer = 15;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1000000000, 1000000000, 1000000000, 1000000000, 1000000000, 1000000000, 1000000000, 1000000000, 1000000000, 1000000000 };
            answer = 999649118;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6.
            string question = "2681", testcase = "06";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = UtilsLeetCode.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            answer = 228045986;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            testcase = "07";
            nums = UtilsLeetCode.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            answer = 869933065;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            testcase = "08";
            nums = UtilsLeetCode.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            answer = 458701799;
            result = solution.SumOfPower(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

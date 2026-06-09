using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1959
{
    public class Test1959
    {
        public void Test()
        {
            Interface1959 solution = new Solution1959();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [10, 20]; k = 0;
            answer = 10;
            result = solution.MinSpaceWastedKResizing(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [10, 20, 30]; k = 1;
            answer = 10;
            result = solution.MinSpaceWastedKResizing(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [10, 20, 15, 30, 20]; k = 2;
            answer = 15;
            result = solution.MinSpaceWastedKResizing(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1959", testcase = "04", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 97;
            answer = 13265;
            result = solution.MinSpaceWastedKResizing(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            testcase = "05";
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 199;
            answer = 0;
            result = solution.MinSpaceWastedKResizing(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

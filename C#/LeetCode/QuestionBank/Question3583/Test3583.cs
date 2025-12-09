using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3583
{
    public class Test3583
    {
        public void Test()
        {
            Interface3583 solution = new Solution3583();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [6, 3, 6];
            answer = 1;
            result = solution.SpecialTriplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [0, 1, 0, 0];
            answer = 1;
            result = solution.SpecialTriplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [8, 4, 2, 8, 4];
            answer = 2;
            result = solution.SpecialTriplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3583", testcase = "04", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 665533373;
            result = solution.SpecialTriplets(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0952
{
    public class Test0952
    {
        public void Test()
        {
            Interface0952 solution = new Solution0952();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [4, 6, 15, 35];
            answer = 4;
            result = solution.LargestComponentSize(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [20, 50, 9, 63];
            answer = 2;
            result = solution.LargestComponentSize(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [2, 3, 6, 7, 4, 12, 21, 39];
            answer = 8;
            result = solution.LargestComponentSize(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [83, 99, 39, 11, 19, 30, 31];
            answer = 4;
            result = solution.LargestComponentSize(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "0952", testcase = "05", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 18631;
            result = solution.LargestComponentSize(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

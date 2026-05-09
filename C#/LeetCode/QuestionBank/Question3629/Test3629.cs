using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3629
{
    public class Test3629
    {
        public void Test()
        {
            Interface3629 solution = new Solution3629();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 4, 6];
            answer = 2;
            result = solution.MinJumps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [2, 3, 4, 7, 9];
            answer = 2;
            result = solution.MinJumps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [4, 6, 5, 8];
            answer = 3;
            result = solution.MinJumps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = [5, 7, 9, 5, 1];
            answer = 2;
            result = solution.MinJumps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "3629", testcase = "05", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 96;
            result = solution.MinJumps(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

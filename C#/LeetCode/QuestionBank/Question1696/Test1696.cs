using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1696
{
    public class Test1696
    {
        public void Test()
        {
            Interface1696 solution = new Solution1696_2();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, -1, -2, 4, -7, 3 }; k = 2;
            answer = 7;
            result = solution.MaxResult(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 10, -5, -2, 4, 0, 3 }; k = 3;
            answer = 17;
            result = solution.MaxResult(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, -5, -20, 4, -1, 3, -6, -3 }; k = 2;
            answer = 0;
            result = solution.MaxResult(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1696", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 743;
            answer = 1082034;
            result = solution.MaxResult(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

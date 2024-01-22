using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0410
{
    public class Test0410
    {
        public void Test()
        {
            Interface0410 solution = new Solution0410_5();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 7, 2, 5, 10, 8 }; k = 2;
            answer = 18;
            result = solution.SplitArray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 2, 3, 4, 5 }; k = 2;
            answer = 9;
            result = solution.SplitArray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 4, 4 }; k = 3;
            answer = 4;
            result = solution.SplitArray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "0410", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 50;
            answer = 950;
            result = solution.SplitArray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

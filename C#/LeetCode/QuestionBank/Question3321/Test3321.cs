using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3321
{
    public class Test3321
    {
        public void Test()
        {
            Interface3321 solution = new Solution3321();
            int[] nums; int k, x;
            long[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 1, 2, 2, 3, 4, 2, 3]; k = 6; x = 2;
            answer = [6, 10, 12];
            result = solution.FindXSum(nums, k, x);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [3, 8, 7, 8, 7, 5]; k = 2; x = 2;
            answer = [11, 15, 15, 15, 12];
            result = solution.FindXSum(nums, k, x);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [1000000000, 1000000000, 1000000000, 1000000000, 1000000000, 1000000000]; k = 6; x = 1;
            answer = [6000000000];
            result = solution.FindXSum(nums, k, x);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [946704961, 958990951, 958990951, 946704961, 741349584, 948653717, 22725670, 948653717, 712688682, 946704961, 948653717, 948653717]; k = 7; x = 3;
            answer = [4760045541, 4761994297, 3803003346, 4532066940, 4534015696, 5454008511];
            result = solution.FindXSum(nums, k, x);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            string question = "3321", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 2519; x = 1320;
            answer = Utils.Str2NumArray<long>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.FindXSum(nums, k, x);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[0..3])}, answer: {Utils.ToString(answer[0..3])}");
        }
    }
}

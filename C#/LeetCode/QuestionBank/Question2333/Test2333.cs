using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2333
{
    public class Test2333
    {
        public void Test()
        {
            Interface2333 solution = new Solution2333();
            int[] nums1, nums2; int k1, k2;
            long result, answer;
            int id = 0;

            // 1. 
            nums1 = [1, 2, 3, 4]; nums2 = [2, 10, 20, 19]; k1 = 0; k2 = 0;
            answer = 579;
            result = solution.MinSumSquareDiff(nums1, nums2, k1, k2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums1 = [1, 4, 10, 12]; nums2 = [5, 8, 6, 9]; k1 = 1; k2 = 1;
            answer = 43;
            result = solution.MinSumSquareDiff(nums1, nums2, k1, k2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2333", testcase = "03", arg1 = "nums1", arg2 = "nums2";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums1 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg1}.txt"));
            nums2 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg2}.txt"));
            k1 = 232033071; k2 = 63097260;
            answer = 32388109196317;
            result = solution.MinSumSquareDiff(nums1, nums2, k1, k2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            testcase = "04";
            nums1 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg1}.txt"));
            nums2 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg2}.txt"));
            k1 = 1000000000; k2 = 1000000000;
            answer = 180000000000000;
            result = solution.MinSumSquareDiff(nums1, nums2, k1, k2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

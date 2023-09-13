using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2569
{
    public class Test2569
    {
        public void Test()
        {
            Interface2569 solution = new Solution2569();
            int[] nums1, nums2; int[][] queries;
            long[] result, answer;
            int id = 0;

            // 1. 
            nums1 = new int[] { 1, 0, 1 }; nums2 = new int[] { 0, 0, 0 }; queries = Utils.Str2NumArray_2d<int>("[[1,1,1],[2,1,0],[3,0,0]]");
            answer = new long[] { 3 };
            result = solution.HandleQuery(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums1 = new int[] { 1 }; nums2 = new int[] { 5 }; queries = Utils.Str2NumArray_2d<int>("[[2,0,0],[3,0,0]]");
            answer = new long[] { 5 };
            result = solution.HandleQuery(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "2569", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}");
            nums1 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_nums1.txt"));
            nums2 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_nums2.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_queries.txt"));
            answer = Utils.Str2NumArray<long>(File.ReadAllText($"{path}_answer.txt"));
            result = solution.HandleQuery(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: [ ... ... ], answer: [ ... ... ]");

            // 4. 
            testcase = "04";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}");
            nums1 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_nums1.txt"));
            nums2 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_nums2.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_queries.txt"));
            answer = Utils.Str2NumArray<long>(File.ReadAllText($"{path}_answer.txt"));
            result = solution.HandleQuery(nums1, nums2, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: [ ... ... ], answer: [ ... ... ]");
        }
    }
}

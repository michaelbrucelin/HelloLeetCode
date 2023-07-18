using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1851
{
    public class Test1851
    {
        public void Test()
        {
            Interface1851 solution = new Solution1851();
            int[][] intervals; int[] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            intervals = UtilsLeetCode.Str2NumArray_2d<int>("[[1,4],[2,4],[3,6],[4,4]]");
            queries = new int[] { 2, 3, 4, 5 };
            answer = new int[] { 3, 3, 1, 4 };
            result = solution.MinInterval(intervals, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            intervals = UtilsLeetCode.Str2NumArray_2d<int>("[[2,3],[2,5],[1,8],[20,25]]");
            queries = new int[] { 2, 19, 5, 22 };
            answer = new int[] { 2, -1, 4, 6 };
            result = solution.MinInterval(intervals, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            string question = "1851", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Directory.GetParent(path).Parent.Parent.FullName;
            intervals = UtilsLeetCode.Str2NumArray_2d<int>(File.ReadAllText(Path.Combine(path, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_intervals.txt")));
            queries = UtilsLeetCode.Str2NumArray<int>(File.ReadAllText(Path.Combine(path, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_queries.txt")));
            answer = UtilsLeetCode.Str2NumArray<int>(File.ReadAllText(Path.Combine(path, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt")));
            result = solution.MinInterval(intervals, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: [ ... ... ], answer: [ ... ... ]");
        }
    }
}

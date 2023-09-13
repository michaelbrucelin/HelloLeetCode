using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1782
{
    public class Test1782
    {
        public void Test()
        {
            Interface1782 solution = new Solution1782();
            int n; int[][] edges; int[] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 4; edges = Utils.Str2NumArray_2d<int>("[[1,2],[2,4],[1,3],[2,3],[2,1]]"); queries = new int[] { 2, 3 };
            answer = new int[] { 6, 5 };
            result = solution.CountPairs(n, edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 5; edges = Utils.Str2NumArray_2d<int>("[[1,5],[1,5],[3,4],[2,5],[1,3],[5,1],[2,3],[2,5]]"); queries = new int[] { 1, 2, 3, 4, 5 };
            answer = new int[] { 10, 10, 9, 8, 6 };
            result = solution.CountPairs(n, edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "1782", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            n = 20000; queries = new int[] { 10, 15, 20, 30, 51, 60, 63, 70, 78, 83, 99, 100, 300, 700, 1000, 10000 };
            answer = new int[] { 85797188, 14561825, 8064294, 7919801, 7906702, 1513097, 355016, 80635, 79800, 79800, 79767, 79187, 0, 0, 0, 0 };
            result = solution.CountPairs(n, edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

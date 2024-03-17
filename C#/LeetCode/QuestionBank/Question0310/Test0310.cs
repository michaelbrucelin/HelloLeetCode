using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0310
{
    public class Test0310
    {
        public void Test()
        {
            Interface0310 solution = new Solution0310_3();
            int n; int[][] edges;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            n = 4; edges = Utils.Str2NumArray_2d<int>("[[1,0],[1,2],[1,3]]");
            answer = new List<int>() { 1 };
            result = solution.FindMinHeightTrees(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 6; edges = Utils.Str2NumArray_2d<int>("[[3,0],[3,1],[3,2],[3,4],[5,4]]");
            answer = new List<int>() { 3, 4 };
            result = solution.FindMinHeightTrees(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "0310", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            n = 20000;
            answer = new List<int>() { 3425 };
            result = solution.FindMinHeightTrees(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            testcase = "04";
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            n = 20000;
            answer = new List<int>() { 9999, 10000 };
            result = solution.FindMinHeightTrees(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

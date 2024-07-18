using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3112
{
    public class Test3112
    {
        public void Test()
        {
            Interface3112 solution = new Solution3112();
            int n; int[][] edges; int[] disappear;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 3; edges = [[0, 1, 2], [1, 2, 1], [0, 2, 4]]; disappear = [1, 1, 5];
            answer = [0, -1, 4];
            result = solution.MinimumTime(n, edges, disappear);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 3; edges = [[0, 1, 2], [1, 2, 1], [0, 2, 4]]; disappear = [1, 3, 5];
            answer = [0, 2, 3];
            result = solution.MinimumTime(n, edges, disappear);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 2; edges = [[0, 1, 1]]; disappear = [1, 1];
            answer = [0, -1];
            result = solution.MinimumTime(n, edges, disappear);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            n = 7; edges = [[1, 4, 3], [3, 4, 2], [2, 5, 5], [3, 3, 10]]; disappear = [10, 1, 13, 1, 7, 1, 19];
            answer = [0, -1, -1, -1, -1, -1, -1];
            result = solution.MinimumTime(n, edges, disappear);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            n = 9; edges = [[7, 0, 10], [0, 1, 4], [8, 8, 4], [1, 6, 1], [1, 0, 7], [8, 4, 9], [1, 7, 1], [1, 0, 10]]; disappear = [6, 15, 20, 10, 7, 11, 5, 14, 13];
            answer = [0, 4, -1, -1, -1, -1, -1, 5, -1];
            result = solution.MinimumTime(n, edges, disappear);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 6. 
            string question = "3112", testcase = "06";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            n = 427;
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            disappear = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_disappear.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.MinimumTime(n, edges, disappear);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[0..10])}... ..., answer: {Utils.ToString(answer[0..10])}... ...");
        }
    }
}

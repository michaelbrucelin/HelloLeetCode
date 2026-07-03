using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3620
{
    public class Test3620
    {
        public void Test()
        {
            Interface3620 solution = new Solution3620();
            int[][] edges; bool[] online; long k;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [[0, 1, 5], [1, 3, 10], [0, 2, 3], [2, 3, 4]]; online = [true, true, true, true]; k = 10;
            answer = 3;
            result = solution.FindMaxPathScore(edges, online, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [[0, 1, 7], [1, 4, 5], [0, 2, 6], [2, 3, 6], [3, 4, 2], [2, 4, 6]]; online = [true, true, true, false, true]; k = 12;
            answer = 6;
            result = solution.FindMaxPathScore(edges, online, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "3620", testcase = "03", arg1 = "edges", arg2 = "online";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg1}.txt"));
            online = Utils.Str2BoolArray(File.ReadAllText($"{path}_{testcase}_{arg2}.txt"));
            k = 8604;
            answer = 909;
            result = solution.FindMaxPathScore(edges, online, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

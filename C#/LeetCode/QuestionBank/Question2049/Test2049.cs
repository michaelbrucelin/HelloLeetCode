using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2049
{
    public class Test2049
    {
        public void Test()
        {
            Interface2049 solution = new Solution2049();
            int[] parents;
            int result, answer;
            int id = 0;

            // 1. 
            parents = [-1, 2, 0, 2, 0];
            answer = 3;
            result = solution.CountHighestScoreNodes(parents);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            parents = [-1, 2, 0];
            answer = 2;
            result = solution.CountHighestScoreNodes(parents);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2049", testcase = "03", arg = "parents";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            parents = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 1;
            result = solution.CountHighestScoreNodes(parents);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

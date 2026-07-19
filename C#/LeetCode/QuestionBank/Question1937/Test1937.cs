using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1937
{
    public class Test1937
    {
        public void Test()
        {
            Interface1937 solution = new Solution1937_2();
            int[][] points;
            long result, answer;
            int id = 0;

            // 1. 
            points = [[1, 2, 3], [1, 5, 1], [3, 1, 1]];
            answer = 9;
            result = solution.MaxPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = [[1, 5], [2, 3], [4, 2]];
            answer = 11;
            result = solution.MaxPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "1937", testcase = "03", arg = "points";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            points = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 83;
            result = solution.MaxPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

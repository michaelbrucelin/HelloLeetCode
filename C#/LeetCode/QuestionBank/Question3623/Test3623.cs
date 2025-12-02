using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3623
{
    public class Test3623
    {
        public void Test()
        {
            Interface3623 solution = new Solution3623();
            int[][] points;
            int result, answer;
            int id = 0;

            // 1. 
            points = points = [[1, 0], [2, 0], [3, 0], [2, 2], [3, 2]];
            answer = 3;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = [[0, 0], [1, 0], [0, 1], [2, 1]];
            answer = 1;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "3623", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            points = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_points.txt"));
            answer = 704392695;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

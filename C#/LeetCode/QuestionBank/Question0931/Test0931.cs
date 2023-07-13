using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0931
{
    public class Test0931
    {
        public void Test()
        {
            Interface0931 solution = new Solution0931_3();
            int[][] matrix;
            int result, answer;
            int id = 0;

            // 1. 
            matrix = UtilsLeetCode.Str2NumArray_2d<int>("[[2,1,3],[6,5,4],[7,8,9]]");
            answer = 13;
            result = solution.MinFallingPathSum(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            matrix = UtilsLeetCode.Str2NumArray_2d<int>("[[-19,57],[-40,-5]]");
            answer = -59;
            result = solution.MinFallingPathSum(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            matrix = UtilsLeetCode.Str2NumArray_2d<int>("[[17,82],[1,-44]]");
            answer = -27;
            result = solution.MinFallingPathSum(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "0931", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            matrix = UtilsLeetCode.Str2NumArray_2d<int>(File.ReadAllText(path));
            answer = -1428;
            result = solution.MinFallingPathSum(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

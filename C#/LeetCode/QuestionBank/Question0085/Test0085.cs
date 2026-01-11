using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0085
{
    public class Test0085
    {
        public void Test()
        {
            Interface0085 solution = new Solution0085();
            char[][] matrix;
            int result, answer;
            int id = 0;

            // 1. 
            matrix = [['1', '0', '1', '0', '0'], ['1', '0', '1', '1', '1'], ['1', '1', '1', '1', '1'], ['1', '0', '0', '1', '0']];
            answer = 6;
            result = solution.MaximalRectangle(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            matrix = [['0']];
            answer = 0;
            result = solution.MaximalRectangle(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            matrix = [['1']];
            answer = 1;
            result = solution.MaximalRectangle(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "0085", testcase = "04", arg = "matrix";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            matrix = Utils.Str2CharArray_2d(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 114;
            result = solution.MaximalRectangle(matrix);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

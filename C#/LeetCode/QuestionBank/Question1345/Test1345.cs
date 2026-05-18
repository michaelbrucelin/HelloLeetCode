using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1345
{
    public class Test1345
    {
        public void Test()
        {
            Interface1345 solution = new Solution1345();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [100, -23, -23, 404, 100, 23, 23, 23, 3, 404];
            answer = 3;
            result = solution.MinJumps(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [7];
            answer = 0;
            result = solution.MinJumps(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [7, 6, 9, 6, 9, 6, 9, 7];
            answer = 1;
            result = solution.MinJumps(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [11, 22, 7, 7, 7, 7, 7, 7, 7, 22, 13];
            answer = 3;
            result = solution.MinJumps(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            // 51 --> 64 --> -15 --> -15 --> -63
            arr = [51, 64, -15, 58, 98, 31, 48, 72, 78, -63, 92, -5, 64, -64, 51, -48, 64, 48, -76, -86, -5, -64, -86, -47, 92, -41, 58, 72, 31, 78, -15,
                   -76, 72, -5, -97, 98, 78, -97, -41, -47, -86, -97, 78, -97, 58, -41, 72, -41, 72, -25, -76, 51, -86, -65, 78, -63, 72, -15, 48, -15,
                   -63, -65, 31, -41, 95, 51, -47, 51, -41, -76, 58, -81, -41, 88, 58, -81, 88, 88, -47, -48, 72, -25, -86, -41, -86, -64, -15, -63];
            answer = 4;
            result = solution.MinJumps(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            string question = "1345", testcase = "06", arg = "arr";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            arr = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 2;
            result = solution.MinJumps(arr);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1191
{
    public class Test1191
    {
        public void Test()
        {
            Interface1191 solution = new Solution1191();
            int[] arr; int k;
            int result, answer;
            int id = 0;

            // 1. 
            arr = [1, 2]; k = 3;
            answer = 9;
            result = solution.KConcatenationMaxSum(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = [1, -2, 1]; k = 5;
            answer = 2;
            result = solution.KConcatenationMaxSum(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = [-1, -2]; k = 7;
            answer = 0;
            result = solution.KConcatenationMaxSum(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = [-5, -2, 0, 0, 3, 9, -2, -5, 4]; k = 5;
            answer = 20;
            result = solution.KConcatenationMaxSum(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1191", testcase = "05", arg = "arr";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            arr = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 2;
            answer = 999999993;
            result = solution.KConcatenationMaxSum(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

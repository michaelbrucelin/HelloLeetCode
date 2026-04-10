using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1649
{
    public class Test1649
    {
        public void Test()
        {
            Interface1649 solution = new Solution1649_2();
            int[] instructions;
            int result, answer;
            int id = 0;

            // 1. 
            instructions = [1, 5, 6, 2];
            answer = 1;
            result = solution.CreateSortedArray(instructions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            instructions = [1, 2, 3, 6, 5, 4];
            answer = 3;
            result = solution.CreateSortedArray(instructions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            instructions = [1, 3, 3, 3, 2, 4, 2, 1, 2];
            answer = 4;
            result = solution.CreateSortedArray(instructions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            instructions = [12, 1, 17, 21, 10, 42, 15, 40, 27, 19, 39, 34, 14, 11, 22, 43, 5, 6, 3, 30, 38, 23, 33, 41, 16, 29, 8, 49, 47, 20, 9, 50, 7, 28, 46, 31, 25, 32, 24, 36, 4, 2, 44, 37, 13, 26, 51, 48, 35, 45, 18];
            answer = 278;
            result = solution.CreateSortedArray(instructions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1649", testcase = "05", arg = "instructions";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            instructions = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 449985000;
            result = solution.CreateSortedArray(instructions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            testcase = "06";
            instructions = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 188426454;
            result = solution.CreateSortedArray(instructions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

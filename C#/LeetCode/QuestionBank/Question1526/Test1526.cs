using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1526
{
    public class Test1526
    {
        public void Test()
        {
            Interface1526 solution = new Solution1526_2_wait();
            int[] target;
            int result, answer;
            int id = 0;

            // 1. 
            target = [1, 2, 3, 2, 1];
            answer = 3;
            result = solution.MinNumberOperations(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            target = [3, 1, 1, 2];
            answer = 4;
            result = solution.MinNumberOperations(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            target = [3, 1, 5, 4, 2];
            answer = 7;
            result = solution.MinNumberOperations(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            target = [1, 1, 1, 1];
            answer = 1;
            result = solution.MinNumberOperations(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1526", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            target = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_target.txt"));
            answer = 70198;
            result = solution.MinNumberOperations(target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

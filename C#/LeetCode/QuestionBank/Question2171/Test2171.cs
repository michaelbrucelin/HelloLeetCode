using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2171
{
    public class Test2171
    {
        public void Test()
        {
            Interface2171 solution = new Solution2171_2();
            int[] beans;
            long result, answer;
            int id = 0;

            // 1. 
            beans = new int[] { 4, 1, 6, 5 };
            answer = 4;
            result = solution.MinimumRemoval(beans);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            beans = new int[] { 2, 10, 3, 2 };
            answer = 7;
            result = solution.MinimumRemoval(beans);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 溢出
            string question = "2171", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            beans = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_beans.txt"));
            answer = 1297386659;
            result = solution.MinimumRemoval(beans);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 溢出
            testcase = "04";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            beans = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_beans.txt"));
            answer = 2230114688;
            result = solution.MinimumRemoval(beans);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            testcase = "05";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            beans = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_beans.txt"));
            answer = 0;
            result = solution.MinimumRemoval(beans);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

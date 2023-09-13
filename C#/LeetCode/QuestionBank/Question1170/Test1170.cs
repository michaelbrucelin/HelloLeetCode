using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1170
{
    public class Test1170
    {
        public void Test()
        {
            Interface1170 solution = new Solution1170_off();
            string[] queries, words;
            int[] result, answer;
            int id = 0;

            // 1. 
            queries = new string[] { "cbd" }; words = new string[] { "zaaaz" };
            answer = new int[] { 1 };
            result = solution.NumSmallerByFrequency(queries, words);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            queries = new string[] { "bbb", "cc" }; words = new string[] { "a", "aa", "aaa", "aaaa" };
            answer = new int[] { 1, 2 };
            result = solution.NumSmallerByFrequency(queries, words);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "1170", testcase = "03", path, _path;
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_queries.txt");
            queries = File.ReadAllText(_path)[2..^2].Split("\",\"");
            _path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_words.txt");
            words = File.ReadAllText(_path)[2..^2].Split("\",\"");
            _path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt");
            answer = File.ReadAllText(_path)[1..^1].Split(',').Select(int.Parse).ToArray();
            result = solution.NumSmallerByFrequency(queries, words);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

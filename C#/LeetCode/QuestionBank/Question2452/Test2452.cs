using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2452
{
    public class Test2452
    {
        public void Test()
        {
            Interface2452 solution = new Solution2452_2();
            string[] queries, dictionary;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            queries = ["word", "note", "ants", "wood"]; dictionary = ["wood", "joke", "moat"];
            answer = ["word", "note", "wood"];
            result = solution.TwoEditWords(queries, dictionary);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            queries = ["yes"]; dictionary = ["not"];
            answer = [];
            result = solution.TwoEditWords(queries, dictionary);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "2452", testcase = "03", arg = "queries";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            queries = Utils.Str2StrArray(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            dictionary = Utils.Str2StrArray(File.ReadAllText($"{path}_{testcase}_dictionary.txt"));
            answer = Utils.Str2StrList(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.TwoEditWords(queries, dictionary);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

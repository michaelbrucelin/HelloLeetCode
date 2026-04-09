using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0117
{
    public class Test0117
    {
        public void Test()
        {
            Interface0117 solution = new Solution0117_2();
            string[] strs;
            int result, answer;
            int id = 0;

            // 1. 
            strs = ["tars", "rats", "arts", "star"];
            answer = 2;
            result = solution.NumSimilarGroups(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            strs = ["omv", "ovm"];
            answer = 1;
            result = solution.NumSimilarGroups(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "0117", testcase = "03", arg = "strs";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"LCR\LCR{question}\TestCases\TestCase{question}");
            strs = Utils.Str2StrArray(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 53;
            result = solution.NumSimilarGroups(strs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

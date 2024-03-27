using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2580
{
    public class Test2580
    {
        public void Test()
        {
            Interface2580 solution = new Solution2580_2();
            int[][] ranges;
            int result, answer;
            int id = 0;

            // 1. 
            ranges = Utils.Str2NumArray_2d<int>("[[6,10],[5,15]]");
            answer = 2;
            result = solution.CountWays(ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            ranges = Utils.Str2NumArray_2d<int>("[[1,3],[10,20],[2,5],[4,8]]");
            answer = 4;
            result = solution.CountWays(ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2580", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            ranges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_ranges.txt"));
            answer = 464775507;
            result = solution.CountWays(ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

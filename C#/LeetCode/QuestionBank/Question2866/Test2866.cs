using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2866
{
    public class Test2866
    {
        public void Test()
        {
            Interface2866 solution = new Solution2866();
            IList<int> maxHeights;
            long result, answer;
            int id = 0;

            // 1. 
            maxHeights = new List<int>() { 5, 3, 4, 1, 1 };
            answer = 13;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            maxHeights = new List<int>() { 6, 5, 3, 9, 2, 7 };
            answer = 22;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            maxHeights = new List<int>() { 3, 2, 5, 5, 2, 3 };
            answer = 18;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            maxHeights = new List<int>() { 1, 1, 5, 6, 2, 2, 3 };
            answer = 19;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "2866", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            maxHeights = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_maxHeights.txt"));
            answer = 49968730424618;
            result = solution.MaximumSumOfHeights(maxHeights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

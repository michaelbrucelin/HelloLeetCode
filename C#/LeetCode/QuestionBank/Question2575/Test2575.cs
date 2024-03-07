using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2575
{
    public class Test2575
    {
        public void Test()
        {
            Interface2575 solution = new Solution2575();
            string word; int m;
            int[] result, answer;
            int id = 0;

            // 1. 
            word = "998244353"; m = 3;
            answer = new int[] { 1, 1, 0, 0, 0, 1, 1, 0, 0 };
            result = solution.DivisibilityArray(word, m);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            word = "1010"; m = 10;
            answer = new int[] { 0, 1, 0, 1 };
            result = solution.DivisibilityArray(word, m);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "2575", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            word = File.ReadAllText($"{path}_{testcase}_word.txt")[1..^1];
            m = 1000000000;
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.DivisibilityArray(word, m);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[0..10])}... ..., answer: {Utils.ToString(answer[0..10])}... ...");
        }
    }
}

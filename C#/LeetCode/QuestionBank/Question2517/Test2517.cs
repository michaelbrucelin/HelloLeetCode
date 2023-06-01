using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2517
{
    public class Test2517
    {
        public void Test()
        {
            Interface2517 solution = new Solution2517_2();
            int[] price; int k;
            int result, answer;
            int id = 0;

            // 1. 
            price = new int[] { 13, 5, 1, 8, 21, 2 }; k = 3; answer = 8;
            result = solution.MaximumTastiness(price, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            price = new int[] { 1, 3, 1 }; k = 2; answer = 2;
            result = solution.MaximumTastiness(price, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            price = new int[] { 7, 7, 7, 7 }; k = 2; answer = 0;
            result = solution.MaximumTastiness(price, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2517", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_price.txt");
            price = File.ReadAllText(path)[1..^1].Split(',').Select(int.Parse).ToArray();
            k = 32192; answer = 565;
            result = solution.MaximumTastiness(price, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

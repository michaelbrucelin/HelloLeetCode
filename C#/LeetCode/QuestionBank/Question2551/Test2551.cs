using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2551
{
    public class Test2551
    {
        public void Test()
        {
            Interface2551 solution = new Solution2551();
            int[] weights; int k;
            long result, answer;
            int id = 0;

            // 1. 
            weights = [1, 3, 5, 1]; k = 2;
            answer = 4;
            result = solution.PutMarbles(weights, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            weights = [1, 3]; k = 2;
            answer = 0;
            result = solution.PutMarbles(weights, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            weights = [46, 37, 46, 17, 40, 50, 54, 11, 1, 25, 43, 21, 31, 29, 58, 49, 73, 54, 5, 52, 73, 54, 6, 22, 58, 9, 34, 21, 58, 68, 63]; k = 30;
            answer = 119;
            result = solution.PutMarbles(weights, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2551", testcase = "04", arg = "weights";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            weights = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            k = 8836;
            answer = 6721160993674;
            result = solution.PutMarbles(weights, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

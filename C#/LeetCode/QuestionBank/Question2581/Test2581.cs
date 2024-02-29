using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2581
{
    public class Test2581
    {
        public void Test()
        {
            Interface2581 solution = new Solution2581_3_2();
            int[][] edges, guesses; int k;
            int result, answer;
            int id = 0;

            // 1. 
            edges = Utils.Str2NumArray_2d<int>("[[0,1],[1,2],[1,3],[4,2]]"); guesses = Utils.Str2NumArray_2d<int>("[[1,3],[0,1],[1,0],[2,4]]"); k = 3;
            answer = 3;
            result = solution.RootCount(edges, guesses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = Utils.Str2NumArray_2d<int>("[[0,1],[1,2],[2,3],[3,4]]"); guesses = Utils.Str2NumArray_2d<int>("[[1,0],[3,4],[2,1],[3,2]]"); k = 1;
            answer = 5;
            result = solution.RootCount(edges, guesses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2581", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            guesses = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_guesses.txt"));
            k = 3196;
            answer = 0;
            result = solution.RootCount(edges, guesses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            testcase = "04";
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            guesses = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_guesses.txt"));
            k = 50000;
            answer = 50000;
            result = solution.RootCount(edges, guesses, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // // n. 
            // edges = Utils.Str2NumArray_2d<int>(""); guesses = Utils.Str2NumArray_2d<int>(""); k = -1;
            // answer = -1;
            // result = solution.RootCount(edges, guesses, k);
            // Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

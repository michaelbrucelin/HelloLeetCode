using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3970
{
    public class Test3970
    {
        public void Test()
        {
            Interface3970 solution = new Solution3970();
            int n; int[][] edges; string labels; int k;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; edges = [[0, 1, 1], [1, 2, 1], [0, 2, 3]]; labels = "aab"; k = 1;
            answer = 3;
            result = solution.ShortestPath(n, edges, labels, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; edges = [[0, 1, 1], [1, 2, 1], [0, 2, 3]]; labels = "aab"; k = 2;
            answer = 2;
            result = solution.ShortestPath(n, edges, labels, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3; edges = [[0, 1, 1], [1, 2, 1]]; labels = "aaa"; k = 2;
            answer = -1;
            result = solution.ShortestPath(n, edges, labels, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3970", testcase = "04", arg = "edges";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            n = 19; labels = "abababababababababa"; k = 9;
            answer = 85;
            result = solution.ShortestPath(n, edges, labels, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            testcase = "05";
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            labels = File.ReadAllText($"{path}_{testcase}_labels.txt")[1..^1];
            n = 5000; k = 2;
            answer = 527;
            result = solution.ShortestPath(n, edges, labels, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 4; edges = [[0, 1, 1], [0, 2, 12], [1, 2, 2], [2, 3, 3]]; labels = "aaaa"; k = 3;
            answer = 15;
            result = solution.ShortestPath(n, edges, labels, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

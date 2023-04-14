using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1971
{
    public class Test1971
    {
        public void Test()
        {
            Interface1971 solution = new Solution1971_3_2();
            int n; int[][] edges; int source, destination;
            bool result, answer;
            int id = 0;

            // 1. 
            edges = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } };
            n = 3; source = 0; destination = 2; answer = true;
            result = solution.ValidPath(n, edges, source, destination);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 3, 5 }, new int[] { 5, 4 }, new int[] { 4, 3 } };
            n = 6; source = 0; destination = 5; answer = false;
            result = solution.ValidPath(n, edges, source, destination);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            edges = new int[][] { new int[] { 4, 3 }, new int[] { 1, 4 }, new int[] { 4, 8 }, new int[] { 1, 7 }, new int[] { 6, 4 }, new int[] { 4, 2 }, new int[] { 7, 4 }, new int[] { 4, 0 }, new int[] { 0, 9 }, new int[] { 5, 4 } };
            n = 10; source = 5; destination = 9; answer = true;
            result = solution.ValidPath(n, edges, source, destination);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            List<int[]> _edges = new List<int[]>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1971\TestCases\TestCase1971_04.txt");
            // Console.WriteLine(path);
            using (StreamReader reader = new StreamReader(path))
            {
                foreach (string line in reader.MyLines())
                {
                    string[] strs = line.Substring(1, line.Length - 2).Split(',');
                    _edges.Add(new int[] { Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]) });
                }
            }
            edges = _edges.ToArray();
            n = 50; source = 40; destination = 3; answer = true;
            result = solution.ValidPath(n, edges, source, destination);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            _edges = new List<int[]>();
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1971\TestCases\TestCase1971_05.txt");
            using (StreamReader reader = new StreamReader(path))
            {
                foreach (string line in reader.MyLines())
                {
                    string[] strs = line.Substring(1, line.Length - 2).Split(',');
                    _edges.Add(new int[] { Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]) });
                }
            }
            edges = _edges.ToArray();
            n = 30000; source = 18473; destination = 26690; answer = true;
            result = solution.ValidPath(n, edges, source, destination);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

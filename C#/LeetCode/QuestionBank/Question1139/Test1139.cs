using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1139
{
    public class Test1139
    {
        public void Test()
        {
            Interface1139 solution = new Solution1139_2();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1. 
            grid = new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
            answer = 9;
            result = solution.Largest1BorderedSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            grid = new int[][] { new int[] { 1, 1, 0, 0 } };
            answer = 1;
            result = solution.Largest1BorderedSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            grid = new int[][] { new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 } };
            answer = 0;
            result = solution.Largest1BorderedSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            grid = new int[100][];
            for (int i = 0; i < 100; i++)
            {
                grid[i] = new int[100]; for (int j = 0; j < 100; j++) grid[i][j] = (i + j) & 1;
            }
            // Console.WriteLine(Utils.ArrayToString(grid, true));
            answer = 1;
            result = solution.Largest1BorderedSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1139", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            grid = File.ReadAllText(path).Split("],[").Select(s => s.Trim("[]".ToCharArray()).Split(',').Select(str => int.Parse(str)).ToArray()).ToArray();
            answer = 16;
            result = solution.Largest1BorderedSquare(grid);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

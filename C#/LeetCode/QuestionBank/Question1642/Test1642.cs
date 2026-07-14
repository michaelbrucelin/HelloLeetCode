using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1642
{
    public class Test1642
    {
        public void Test()
        {
            Interface1642 solution = new Solution1642_2();
            int[] heights; int bricks, ladders;
            int result, answer;
            int id = 0;

            // 1. 
            heights = [4, 2, 7, 6, 9, 14, 12]; bricks = 5; ladders = 1;
            answer = 4;
            result = solution.FurthestBuilding(heights, bricks, ladders);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            heights = [4, 12, 2, 7, 3, 18, 20, 3, 19]; bricks = 10; ladders = 2;
            answer = 7;
            result = solution.FurthestBuilding(heights, bricks, ladders);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            heights = [14, 3, 19, 3]; bricks = 17; ladders = 0;
            answer = 3;
            result = solution.FurthestBuilding(heights, bricks, ladders);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1642", testcase = "04", arg = "heights";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            heights = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            bricks = 33671263; ladders = 108;
            answer = 589;
            result = solution.FurthestBuilding(heights, bricks, ladders);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

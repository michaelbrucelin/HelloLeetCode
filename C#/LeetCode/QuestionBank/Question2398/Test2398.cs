using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2398
{
    public class Test2398
    {
        public void Test()
        {
            Interface2398 solution = new Solution2398_3();
            int[] chargeTimes, runningCosts; long budget;
            int result, answer;
            int id = 0;

            // 1. 
            chargeTimes = [3, 6, 1, 3, 4]; runningCosts = [2, 1, 3, 4, 5]; budget = 25;
            answer = 3;
            result = solution.MaximumRobots(chargeTimes, runningCosts, budget);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            chargeTimes = [11, 12, 19]; runningCosts = [10, 8, 7]; budget = 19;
            answer = 0;
            result = solution.MaximumRobots(chargeTimes, runningCosts, budget);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2398", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            chargeTimes = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_chargeTimes.txt"));
            runningCosts = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_runningCosts.txt"));
            budget = 100000000000000;
            answer = 31622;
            result = solution.MaximumRobots(chargeTimes, runningCosts, budget);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

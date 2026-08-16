using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2029
{
    public class Test2029
    {
        public void Test()
        {
            Interface2029 solution = new Solution2029();
            int[] stones;
            bool result, answer;
            int id = 0;

            // 1. 
            stones = [2, 1];
            answer = true;
            result = solution.StoneGameIX(stones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            stones = [2];
            answer = false;
            result = solution.StoneGameIX(stones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            stones = [5, 1, 2, 4, 3];
            answer = false;
            result = solution.StoneGameIX(stones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2029", testcase = "04", arg = "stones";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            stones = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = true;
            result = solution.StoneGameIX(stones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

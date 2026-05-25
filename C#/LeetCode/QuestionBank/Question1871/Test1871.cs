using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1871
{
    public class Test1871
    {
        public void Test()
        {
            Interface1871 solution = new Solution1871_2();
            string s; int minJump, maxJump;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "011010"; minJump = 2; maxJump = 3;
            answer = true;
            result = solution.CanReach(s, minJump, maxJump);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "01101110"; minJump = 2; maxJump = 3;
            answer = false;
            result = solution.CanReach(s, minJump, maxJump);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "1871", testcase = "03", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            minJump = 1; maxJump = 99999;
            answer = false;
            result = solution.CanReach(s, minJump, maxJump);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            testcase = "04";
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            minJump = 3; maxJump = 7;
            answer = true;
            result = solution.CanReach(s, minJump, maxJump);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "00111010"; minJump = 3; maxJump = 5;
            answer = false;
            result = solution.CanReach(s, minJump, maxJump);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

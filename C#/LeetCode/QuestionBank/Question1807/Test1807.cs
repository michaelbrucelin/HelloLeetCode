using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Test1807
    {
        public void Test()
        {
            Interface1807 solution = new Solution1807_6();
            string s; IList<IList<string>> knowledge;
            string result, answer;
            int id = 0;

            // 1. 
            s = "(name)is(age)yearsold"; knowledge = [["name", "bob"], ["age", "two"]];
            answer = "bobistwoyearsold";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "hi(name)"; knowledge = [["a", "b"]];
            answer = "hi?";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "(a)(a)(a)aaa"; knowledge = [["a", "yes"]];
            answer = "yesyesyesaaa";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "(name)is(age)yearsold(name)(name)"; knowledge = [["name", "bob"], ["age", "two"]];
            answer = "bobistwoyearsoldbobbob";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "(name)is(age)yearsold(name)(noname)"; knowledge = [["name", "bob"], ["age", "two"]];
            answer = "bobistwoyearsoldbob?";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s = "bobistwoyearsold"; knowledge = [["name", "bob"], ["age", "two"]];
            answer = "bobistwoyearsold";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            s = "(fy)(kj)(ege)r"; knowledge = [["uxhhkpvp", "h"], ["nriroroa", "m"], ["wvhiycvo", "z"], ["qsmfeing", "s"], ["hbcyqulf", "q"], ["xwgfjnrf", "b"], ["kfipazun", "s"], ["wnkrtxui", "u"], ["abwlsese", "e"], ["iimsmftc", "h"], ["pafqkquo", "v"], ["kj", "tzv"], ["fwwxotcd", "t"], ["yzgjjwjr", "l"]];
            answer = "?tzv?r";
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path_s = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1807\TestCases\TestCase1807_08_s.txt");
            s = File.ReadAllText(path_s);
            string path_knowledge = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1807\TestCases\TestCase1807_08_knowledge.txt");
            string knowledge_s = File.ReadAllText(path_knowledge);
            knowledge = knowledge_s.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(s => s.Split(',', StringSplitOptions.RemoveEmptyEntries))
                                   .ToArray();
            string path_answer = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1807\TestCases\TestCase1807_08_answer.txt");
            answer = File.ReadAllText(path_answer);
            result = solution.Evaluate(s, knowledge);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result.Substring(0, 10)}..., answer: {answer.Substring(0, 10)}...");
        }
    }
}

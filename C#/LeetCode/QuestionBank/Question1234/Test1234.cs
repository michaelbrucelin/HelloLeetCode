using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1234
{
    public class Test1234
    {
        public void Test()
        {
            Interface1234 solution = new Solution1234_3();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "QWER"; answer = 0;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "QQWE"; answer = 1;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "QQQW"; answer = 2;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "QQQQ"; answer = 3;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "QQQQQWWWWEER"; answer = 3;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s = "QQQQQEERWWWW"; answer = 6;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            s = "REEQEREREQWQWWQQWRQWRRWREREQEQWEEEEEREREQEQEQWWWWRRRQWQRRWQWRWRWRQWEQEWRWERRQEQQQERWQEWEEREWWQQWWQREREQEEQERWQQRQQWREQWWRWERRQREREREQRQEERQERQEEQWQEWQWQWQEQREWRRRWQERRWQWQWRQQQWRWRRQWREQRRRRQRWEEQWQWRERERWRQQWRRREWWEWREWRWERQQRQEQRRQQEWRRRWREWQWQREREWRQRREQQWEWEERWWWEQEEWRWQEREWERWQQWEEQRQWWEQQRRREWERWRRRQWWEREWRWQRRQQEREQRRQREQEREQQEQRQERRRWWWEEQQEEQRQRRRWRWQWERWEEQQERQEERWEEERRRERQRRERRQQQWRWEREQQQQERQRWWQWWQEQEREQQQWQQQRWQEEWWRRQQRRQEWRRWWWEWEQQRWERQQWRWQERRWQRRQEEQQQRREQWQEWQEWEEQRRWREQWEEWQRERWEEQWWREEQWRERWRWWEEWWEQREEQEWQRWEERERRRRQWEQRQRQEREWEEEWRRERQREERREWWRQEEREQRWWQEQQRQQQEWWEWWRRWRQQEREQREEEQWQEWEWRQQWEEWQQWRQWEEEEWWWQRWWQWQEQREREWWWWWRWWERWQQQWRERERWERQREEQQQERQEWWEQREEREWWWEWQWQWEWWQEQEWRRRWEEQWRWRERWREQQEWQQRREQRWRRREEQEWRRQREWWWWWWEWWQWRWWERREWRWRWWREWWQWEREQRQEWERQQQEQRWEWEQRRWRRQRQEEERQEQWWEWQRQEWWWERQRQRQRERWWRQRWREERWWEEWREREWREQWQQWWERREWRRWQRERQREQWRQRQQWRQREEEQRQWRERRQQQWEEREQQREEWWRRQWRRQEREQREWWWRQQRRWQWQWQWREQQEEREEWRRWQQRERQQEWRQRWQWWRWERWWWQWEWWQQEEWEWQEQEEWQWWRRRQREWWQQQQEQRQQRQRWWRWQQREERQEWWEERRQRQWWEWRERREQWRWRQEWWRREQEWQWERRRQREWEERERWRQERWRWQRERWEWRQWEWQQWWWRQRQQRRREEQWQREWWQEERRRREWRRWEREWWWEEWQWQRQRWQWRRQWWWREQWEWEWRQEWQEREEERERRWQWEERQEEEWEQRWRQWREEWQEEQERQEEQQQWQWWEQQQEQRRQRQEQQ";
            answer = 52;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            string question = "1234", testcase = "08";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            s = File.ReadAllText(path);
            answer = 130;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 9. 
            question = "1234"; testcase = "09";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            s = File.ReadAllText(path);
            answer = 818;
            result = solution.BalancedString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

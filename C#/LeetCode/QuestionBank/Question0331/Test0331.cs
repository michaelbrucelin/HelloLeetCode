using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0331
{
    public class Test0331
    {
        public void Test()
        {
            Interface0331 solution = new Solution0331_oth_2();
            string preorder;
            bool result, answer;
            int id = 0;

            // 1. 
            preorder = "9,3,4,#,#,1,#,#,2,#,6,#,#";
            answer = true;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            preorder = "1,#";
            answer = false;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            preorder = "9,#,#,1";
            answer = false;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            preorder = "1,#,2,#,3,#,#";
            answer = true;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            preorder = "1,2,3,#,#,#,#";
            answer = true;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            preorder = @"3,1,7,5,9,3,#,2,#,#,7,7,4,#,#,1,2,0,#,3,#,#,3,9,9,#,#,#,6,3,#,#,0,#,#,4,5,#,#,8,2,#,#,
3,9,#,3,#,#,3,#,#,0,4,#,#,#,3,7,0,#,#,#,9,#,7,#,#,2,0,5,#,#,#,6,#,1,4,9,2,#,#,8,#,#,#,7,#,5,#,#,2,2,9,4,1,7,0,
0,#,#,4,1,6,9,#,#,#,#,1,#,#,3,8,9,#,6,#,#,4,#,#,8,#,#,#,#,3,#,#,7,0,#,#,9,2,#,#,3,#,#,8,0,8,7,#,#,#,#,#,0,#,#,
2,8,9,#,0,2,#,#,#,6,#,0,#,#,4,9,5,#,#,#,7,#,#,5,5,#,3,#,8,9,6,3,2,7,#,#,#,#,3,#,#,#";
            answer = false;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            string question = "0331", testcase = "07";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            preorder = File.ReadAllText($"{path}_{testcase}_preorder.txt");
            answer = false;
            result = solution.IsValidSerialization(preorder);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

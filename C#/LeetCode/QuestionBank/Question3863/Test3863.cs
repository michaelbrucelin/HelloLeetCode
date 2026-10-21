using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3863
{
    public class Test3863
    {
        public void Test()
        {
            Interface3863 solution = new Solution3863();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "dog";
            answer = 1;
            result = solution.MinOperations(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "card";
            answer = 2;
            result = solution.MinOperations(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "gf";
            answer = -1;
            result = solution.MinOperations(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "edc";
            answer = 3;
            result = solution.MinOperations(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2810
{
    public class Test2810
    {
        public void Test()
        {
            Interface2810 solution = new Solution2810_err();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "string";
            answer = "rtsng";
            result = solution.FinalString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "poiinter";
            answer = "ponter";
            result = solution.FinalString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "viwif";
            answer = "wvf";
            result = solution.FinalString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

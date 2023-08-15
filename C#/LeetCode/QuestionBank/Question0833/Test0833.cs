using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0833
{
    public class Test0833
    {
        public void Test()
        {
            Interface0833 solution = new Solution0833_2();
            string s; int[] indices; string[] sources, targets;
            string result, answer;
            int id = 0;

            // 1. 
            s = "abcd"; indices = new int[] { 0, 2 }; sources = new string[] { "a", "cd" }; targets = new string[] { "eee", "ffff" };
            answer = "eeebffff";
            result = solution.FindReplaceString(s, indices, sources, targets);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "abcd"; indices = new int[] { 0, 2 }; sources = new string[] { "ab", "ec" }; targets = new string[] { "eee", "ffff" };
            answer = "eeecd";
            result = solution.FindReplaceString(s, indices, sources, targets);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "vmokgggqzp"; indices = new int[] { 3, 5, 1 }; sources = new string[] { "kg", "ggq", "mo" }; targets = new string[] { "s", "so", "bfr" };
            answer = "vbfrssozp";
            result = solution.FindReplaceString(s, indices, sources, targets);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

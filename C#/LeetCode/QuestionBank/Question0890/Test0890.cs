using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0890
{
    public class Test0890
    {
        public void Test()
        {
            Interface0890 solution = new Solution0890();
            string[] words; string pattern;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            words = ["abc", "deq", "mee", "aqq", "dkd", "ccc"]; pattern = "abb";
            answer = ["mee", "aqq"];
            result = solution.FindAndReplacePattern(words, pattern);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

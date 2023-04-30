using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0103
{
    public class Test0103
    {
        public void Test()
        {
            Interface0103 solution = new Solution0103();
            string S; int length;
            string result, answer;
            int id = 0;

            // 1. 
            S = "Mr John Smith    "; length = 13; answer = "Mr%20John%20Smith";
            result = solution.ReplaceSpaces(S, length);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            S = "               "; length = 5; answer = "%20%20%20%20%20";
            result = solution.ReplaceSpaces(S, length);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            S = "ds sdfs afs sdfa dfssf asdf             "; length = 27; answer = "ds%20sdfs%20afs%20sdfa%20dfssf%20asdf";
            result = solution.ReplaceSpaces(S, length);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

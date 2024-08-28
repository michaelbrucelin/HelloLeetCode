using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3144
{
    public class Test3144
    {
        public void Test()
        {
            Interface3144 solution = new Solution3144_4();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "fabccddg";
            answer = 3;
            result = solution.MinimumSubstringsInPartition(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "abababaccddb";
            answer = 2;
            result = solution.MinimumSubstringsInPartition(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "xwjhpcyyyyrppppppppcccsqqqrrrssxxxfnnnhhjqnrsrnnnttt";
            answer = 1;
            result = solution.MinimumSubstringsInPartition(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

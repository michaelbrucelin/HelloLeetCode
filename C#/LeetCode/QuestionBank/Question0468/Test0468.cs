using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0468
{
    public class Test0468
    {
        public void Test()
        {
            Interface0468 solution = new Solution0468();
            string queryIP;
            string result, answer;
            int id = 0;

            // 1. 
            queryIP = "172.16.254.1";
            answer = "IPv4";
            result = solution.ValidIPAddress(queryIP);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            queryIP = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            answer = "IPv6";
            result = solution.ValidIPAddress(queryIP);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            queryIP = "256.256.256.256";
            answer = "Neither";
            result = solution.ValidIPAddress(queryIP);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            queryIP = "2001:0db8:85a3:0:0:8A2E:0370:7334:";
            answer = "Neither";
            result = solution.ValidIPAddress(queryIP);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

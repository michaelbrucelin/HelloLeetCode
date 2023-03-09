using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution = LeetCode.剑指_Offer.剑指_Offer_0058_1.Solution0058_2;

namespace LeetCode.剑指_Offer.剑指_Offer_0058_1
{
    public class Test0058
    {
        public void Test()
        {
            Interface0058 solution = new Solution();
            Func<string, string> func = ((Solution)solution).ReverseWords;
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "the sky is blue"; answer = "blue is sky the";
            result = func(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "  hello world!  "; answer = "world! hello";
            result = func(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "a good   example"; answer = "example good a";
            result = func(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "   another  good     example   "; answer = "example good another";
            result = func(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

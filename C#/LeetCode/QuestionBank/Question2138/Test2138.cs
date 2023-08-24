using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2138
{
    public class Test2138
    {
        public void Test()
        {
            Interface2138 solution = new Solution2138();
            string s; int k; char fill;
            string[] result, answer;
            int id = 0;

            // 1. 
            s = "abcdefghi"; k = 3; fill = 'x';
            answer = new string[] { "abc", "def", "ghi" };
            result = solution.DivideString(s, k, fill);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            s = "abcdefghij"; k = 3; fill = 'x';
            answer = new string[] { "abc", "def", "ghi", "jxx" };
            result = solution.DivideString(s, k, fill);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

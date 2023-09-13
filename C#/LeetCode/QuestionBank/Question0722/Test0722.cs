using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0722
{
    public class Test0722
    {
        public void Test()
        {
            Interface0722 solution = new Solution0722_api();
            string[] source;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            source = new string[] { "/*Test program */", "int main()", "{ ", "  // variable declaration ", "int a, b, c;", "/* This is a test", "   multiline  ", "   comment for ", "   testing */", "a = b + c;", "}" };
            answer = new List<string>() { "int main()", "{ ", "  ", "int a, b, c;", "a = b + c;", "}" };
            result = solution.RemoveComments(source);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            source = new string[] { "a/*comment", "line", "more_comment*/b" };
            answer = new List<string>() { "ab" };
            result = solution.RemoveComments(source);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            source = new string[] { "void func(int k) {", "// this function does nothing /*", "   k = k*2/4;", "   k = k/2;*/", "}" };
            answer = new List<string>() { "void func(int k) {", "   k = k*2/4;", "   k = k/2;*/", "}" };
            result = solution.RemoveComments(source);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

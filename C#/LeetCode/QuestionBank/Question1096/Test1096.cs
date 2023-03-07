using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1096
{
    public class Test1096
    {
        public void Test()
        {
            Interface1096 solution = new Solution1096();
            string expression;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            expression = "{a,b}{c,{d,e}}"; answer = new List<string>() { "ac", "ad", "ae", "bc", "bd", "be" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            expression = "{{a,z},a{b,c},{ab,z}}"; answer = new List<string>() { "a", "ab", "ac", "z" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            expression = "a"; answer = new List<string>() { "a" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            expression = "{a,b,c}"; answer = new List<string>() { "a", "b", "c" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            expression = "{{a,b},{b,c}}"; answer = new List<string>() { "a", "b", "c" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 6. 
            expression = "{a,b}{c,d}"; answer = new List<string>() { "ac", "ad", "bc", "bd" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 7. 
            expression = "a{b,c,d}"; answer = new List<string>() { "ab", "ac", "ad" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 8. 
            expression = "a{b,c}{d,e}f{g,h}"; answer = new List<string>() { "abdfg", "abdfh", "abefg", "abefh", "acdfg", "acdfh", "acefg", "acefh" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 9. 
            expression = "{a,b}{c,{d,e}{f,g}}"; answer = new List<string>() { "ac", "adf", "adg", "aef", "aeg", "bc", "bdf", "bdg", "bef", "beg" };
            result = solution.BraceExpansionII(expression);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

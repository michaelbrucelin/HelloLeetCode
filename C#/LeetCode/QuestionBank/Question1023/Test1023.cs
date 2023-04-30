using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1023
{
    public class Test1023
    {
        public void Test()
        {
            Interface1023 solution = new Solution1023_api();
            string[] queries; string pattern;
            IList<bool> result, answer;
            int id = 0;

            // 1. 
            queries = new string[] { "FooBar", "FooBarTest", "FootBall", "FrameBuffer", "ForceFeedBack" }; pattern = "FB";
            answer = new bool[] { true, false, true, true, false };
            result = solution.CamelMatch(queries, pattern);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            queries = new string[] { "FooBar", "FooBarTest", "FootBall", "FrameBuffer", "ForceFeedBack" }; pattern = "FoBa";
            answer = new bool[] { true, false, true, false, false };
            result = solution.CamelMatch(queries, pattern);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            queries = new string[] { "FooBar", "FooBarTest", "FootBall", "FrameBuffer", "ForceFeedBack" }; pattern = "FoBaT";
            answer = new bool[] { false, true, false, false, false };
            result = solution.CamelMatch(queries, pattern);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            queries = new string[] { "FooBar", "aFooBar", "FooBarTest", "FootBall", "FrameBuffer", "ForceFeedBack" }; pattern = "FBr";
            answer = new bool[] { true, true, false, false, true, false };
            result = solution.CamelMatch(queries, pattern);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

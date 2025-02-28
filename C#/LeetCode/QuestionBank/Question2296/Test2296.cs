using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2296
{
    public class Test2296
    {
        public void Test()
        {
            Interface2296 solution;
            string result_str, answer_str;
            int result_int, answer_int;

            // 1. 
            solution = new TextEditor();
            solution.AddText("leetcode");
            answer_int = 4;
            result_int = solution.DeleteText(4);
            Console.WriteLine($"{(result_int == answer_int) + ",",-6} result: {result_int}, answer: {answer_int}");
            solution.AddText("practice");
            answer_str = "etpractice";
            result_str = solution.CursorRight(3);
            Console.WriteLine($"{(result_str == answer_str) + ",",-6} result: {result_str}, answer: {answer_str}");
            answer_str = "leet";
            result_str = solution.CursorLeft(8);
            Console.WriteLine($"{(result_str == answer_str) + ",",-6} result: {result_str}, answer: {answer_str}");
            answer_int = 4;
            result_int = solution.DeleteText(10);
            Console.WriteLine($"{(result_int == answer_int) + ",",-6} result: {result_int}, answer: {answer_int}");
            answer_str = "";
            result_str = solution.CursorLeft(2);
            Console.WriteLine($"{(result_str == answer_str) + ",",-6} result: {result_str}, answer: {answer_str}");
            answer_str = "practi";
            result_str = solution.CursorRight(6);
            Console.WriteLine($"{(result_str == answer_str) + ",",-6} result: {result_str}, answer: {answer_str}");

            // ["TextEditor", "addText",   "deleteText", "addText",    "cursorRight", "cursorLeft", "deleteText", "cursorLeft", "cursorRight"]
            // [[],          ["leetcode"], [4],          ["practice"], [3],           [8],          [10],          [2],         [6]]
            // [null,        null,         4,             null,        "etpractice",  "leet",       4,             "",          "practi"]
        }

        private string LinkedList2String(LinkedList<char> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in list)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1859
{
    public class Test1859
    {
        public void Test()
        {
            Interface1859 solution = new Solution1859_api();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "is2 sentence4 This1 a3";
            answer = "This is a sentence";
            result = solution.SortSentence(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "Myself2 Me1 I4 and3";
            answer = "Me Myself and I";
            result = solution.SortSentence(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "QcGZ4 TFJStgu3 HvsRImLBfHd8 PaGqsPNo9 mZwxlrYzanuVOUZoyNjt1 fzhdtYIen6 mV7 LKuaOtefsixxo5 pwdEK2";
            answer = "mZwxlrYzanuVOUZoyNjt pwdEK TFJStgu QcGZ LKuaOtefsixxo fzhdtYIen mV HvsRImLBfHd PaGqsPNo";
            result = solution.SortSentence(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

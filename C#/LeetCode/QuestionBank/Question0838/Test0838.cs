using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0838
{
    public class Test0838
    {
        public void Test()
        {
            Interface0838 solution = new Solution0838_2();
            string dominoes;
            string result, answer;
            int id = 0;

            // 1. 
            dominoes = "RR.L";
            answer = "RR.L";
            result = solution.PushDominoes(dominoes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            dominoes = ".L.R...LR..L..";
            answer = "LL.RR.LLRRLL..";
            result = solution.PushDominoes(dominoes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            dominoes = "R";
            answer = "R";
            result = solution.PushDominoes(dominoes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            dominoes = ".R";
            answer = ".R";
            result = solution.PushDominoes(dominoes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            dominoes = ".L.R.";
            answer = "LL.RR";
            result = solution.PushDominoes(dominoes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

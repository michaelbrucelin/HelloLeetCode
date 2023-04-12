using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1147
{
    public class Test1147
    {
        public void Test()
        {
            Interface1147 solution = new Solution1147();
            string text;
            int result, answer;
            int id = 0;

            // 1. 
            text = "ghiabcdefhelloadamhelloabcdefghi"; answer = 7;
            result = solution.LongestDecomposition(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            text = "merchant"; answer = 1;
            result = solution.LongestDecomposition(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            text = "antaprezatepzapreanta"; answer = 11;
            result = solution.LongestDecomposition(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            text = "elvtoelvto"; answer = 2;
            result = solution.LongestDecomposition(text);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

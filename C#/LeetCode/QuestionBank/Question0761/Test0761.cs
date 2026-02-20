using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0761
{
    public class Test0761
    {
        public void Test()
        {
            Interface0761 solution = new Solution0761_err();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "11011000";
            answer = "11100100";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "10";
            answer = "10";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "11100010";
            answer = "11100010";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "1010101100";
            answer = "1100101010";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "101110110011010000";
            answer = "111101001100100010";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s = "1011010011010010";
            answer = "1101001101001010";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            s = "11101001111001010000110010";
            answer = "11111001010001101000110010";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            s = "110101101000111100100111010000";
            answer = "111101000111001000111010010100";
            result = solution.MakeLargestSpecial(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1616
{
    public class Test1616
    {
        public void Test()
        {
            Interface1616 solution = new Solution1616_2();
            string a, b;
            bool result, answer;
            int id = 0;

            // 1. 
            a = "x"; b = "y"; answer = true;
            result = solution.CheckPalindromeFormation(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            a = "abdef"; b = "fecab"; answer = true;
            result = solution.CheckPalindromeFormation(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            a = "ulacfd"; b = "jizalu"; answer = true;
            result = solution.CheckPalindromeFormation(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            a = "xycbdbcaz"; b = "abyyyyyyx"; answer = true;
            result = solution.CheckPalindromeFormation(a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

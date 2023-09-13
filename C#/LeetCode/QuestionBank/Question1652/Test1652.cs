using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1652
{
    public class Test1652
    {
        public void Test()
        {
            Interface1652 solution = new Solution1652();
            int[] code; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            code = new int[] { 5, 7, 1, 4 }; k = 3; answer = new int[] { 12, 10, 16, 13 };
            result = solution.Decrypt(code, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            code = new int[] { 1, 2, 3, 4 }; k = 0; answer = new int[] { 0, 0, 0, 0 };
            result = solution.Decrypt(code, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            code = new int[] { 2, 4, 9, 3 }; k = -2; answer = new int[] { 12, 5, 6, 13 };
            result = solution.Decrypt(code, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

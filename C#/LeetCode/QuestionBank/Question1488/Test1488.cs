using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Test1488
    {
        public void Test()
        {
            Interface1488 solution = new Solution1488();
            int[] rains;
            int[] result, answer;
            int id = 0;

            // 1. 
            rains = new int[] { 1, 2, 3, 4 };
            answer = new int[] { -1, -1, -1, -1 };
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            rains = new int[] { 1, 2, 0, 0, 2, 1 };
            answer = new int[] { -1, -1, 2, 1, -1, -1 };
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            rains = new int[] { 1, 2, 0, 1, 2 };
            answer = new int[] { };
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            rains = new int[] { 0, 1, 1 };
            answer = new int[] { };
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            rains = new int[] { 1, 0, 2, 0, 3, 0, 2, 0, 0, 0, 1, 2, 3 };
            answer = new int[] { -1, 1, -1, 2, -1, 3, -1, 2, 1, 1, -1, -1, -1 };
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

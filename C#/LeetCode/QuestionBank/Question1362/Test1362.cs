using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1362
{
    public class Test1362
    {
        public void Test()
        {
            Interface1362 solution = new Solution1362();
            int num;
            int[] result, answer;
            int id = 0;

            // 1. 
            num = 8;
            answer = [3, 3];
            result = solution.ClosestDivisors(num);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            num = 123;
            answer = [5, 25];
            result = solution.ClosestDivisors(num);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            num = 999;
            answer = [40, 25];
            result = solution.ClosestDivisors(num);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            num = 969265652;
            answer = [434, 2233331];
            result = solution.ClosestDivisors(num);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

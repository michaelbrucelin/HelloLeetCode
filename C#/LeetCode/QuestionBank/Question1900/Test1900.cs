using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1900
{
    public class Test1900
    {
        public void Test()
        {
            Interface1900 solution = new Solution1900_2();
            int n, firstPlayer, secondPlayer;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 11; firstPlayer = 2; secondPlayer = 4;
            answer = [3, 4];
            result = solution.EarliestAndLatest(n, firstPlayer, secondPlayer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 5; firstPlayer = 1; secondPlayer = 5;
            answer = [1, 1];
            result = solution.EarliestAndLatest(n, firstPlayer, secondPlayer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 14; firstPlayer = 2; secondPlayer = 5;
            answer = [3, 4];
            result = solution.EarliestAndLatest(n, firstPlayer, secondPlayer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

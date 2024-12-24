using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1705
{
    public class Test1705
    {
        public void Test()
        {
            Interface1705 solution = new Solution1705_2();
            int[] apples, days;
            int result, answer;
            int id = 0;

            // 1. 
            apples = [1, 2, 3, 5, 2]; days = [3, 2, 1, 4, 2];
            answer = 7;
            result = solution.EatenApples(apples, days);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            apples = [3, 0, 0, 0, 0, 2]; days = [3, 0, 0, 0, 0, 2];
            answer = 5;
            result = solution.EatenApples(apples, days);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            apples = [2, 1, 1, 4, 5]; days = [10, 10, 6, 4, 2];
            answer = 8;
            result = solution.EatenApples(apples, days);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

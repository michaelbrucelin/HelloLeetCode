using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2682
{
    public class Test2682
    {
        public void Test()
        {
            Interface2682 solution = new Solution2682();
            int n, k;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 5; k = 2;
            answer = new int[] { 4, 5 };
            result = solution.CircularGameLosers(n, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            n = 4; k = 4;
            answer = new int[] { 2, 3, 4 };
            result = solution.CircularGameLosers(n, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

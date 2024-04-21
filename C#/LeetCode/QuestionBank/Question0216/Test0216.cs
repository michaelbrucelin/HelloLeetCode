using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0216
{
    public class Test0216
    {
        public void Test()
        {
            Interface0216 solution = new Solution0216_2();
            int k, n;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            k = 3; n = 7;
            answer = [[1, 2, 4]];
            result = solution.CombinationSum3(k, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            k = 3; n = 9;
            answer = [[1, 2, 6], [1, 3, 5], [2, 3, 4]];
            result = solution.CombinationSum3(k, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            k = 4; n = 1;
            answer = [];
            result = solution.CombinationSum3(k, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            k = 9; n = 45;
            answer = [[1, 2, 3, 4, 5, 6, 7, 8, 9]];
            result = solution.CombinationSum3(k, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

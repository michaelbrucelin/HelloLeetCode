using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0989
{
    public class Test0989
    {
        public void Test()
        {
            Interface0989 solution = new Solution0989();
            int[] num; int k;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            num = new int[] { 1, 2, 0, 0 }; k = 34; answer = new int[] { 1, 2, 3, 4 };
            result = solution.AddToArrayForm(num, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            num = new int[] { 2, 7, 4 }; k = 181; answer = new int[] { 4, 5, 5 };
            result = solution.AddToArrayForm(num, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            num = new int[] { 2, 1, 5 }; k = 806; answer = new int[] { 1, 0, 2, 1 };
            result = solution.AddToArrayForm(num, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            num = new int[] { 1 }; k = 9; answer = new int[] { 1, 0 };
            result = solution.AddToArrayForm(num, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

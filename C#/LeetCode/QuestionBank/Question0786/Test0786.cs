using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0786
{
    public class Test0786
    {
        public void Test()
        {
            Interface0786 solution = new Solution0786_err();
            int[] arr; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            arr = [1, 2, 3, 5]; k = 3;
            answer = [2, 5];
            result = solution.KthSmallestPrimeFraction(arr, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            arr = [1, 7]; k = 1;
            answer = [1, 7];
            result = solution.KthSmallestPrimeFraction(arr, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            arr = [1, 13, 17, 59]; k = 6;
            answer = [13, 17];
            result = solution.KthSmallestPrimeFraction(arr, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            arr = [1, 7, 23, 29, 47]; k = 8;
            answer = [23, 47];
            result = solution.KthSmallestPrimeFraction(arr, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

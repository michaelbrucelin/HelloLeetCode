using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0033
{
    public class Test0033
    {
        public void Test()
        {
            Interface0033 solution = new Solution0033();
            int[] bucket, vat;
            int result, answer;
            int id = 0;

            // 1. 
            bucket = new int[] { 1, 3 }; vat = new int[] { 6, 8 };
            answer = 4;
            result = solution.StoreWater(bucket, vat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            bucket = new int[] { 9, 0, 1 }; vat = new int[] { 0, 2, 2 };
            answer = 3;
            result = solution.StoreWater(bucket, vat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            bucket = new int[] { 1, 3 }; vat = new int[] { 6, 9 };
            answer = 4;
            result = solution.StoreWater(bucket, vat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            bucket = new int[] { 0 }; vat = new int[] { 0 };
            answer = 0;
            result = solution.StoreWater(bucket, vat);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

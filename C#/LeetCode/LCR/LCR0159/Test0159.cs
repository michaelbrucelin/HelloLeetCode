using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0159
{
    public class Test0159
    {
        public void Test()
        {
            Interface0159 solution = new Solution0159_3();
            int[] stock; int cnt;
            int[] result, answer;
            int id = 0;

            // 1. 
            stock = [2, 5, 7, 4]; cnt = 1;
            answer = [2];
            result = solution.InventoryManagement(stock, cnt);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            stock = [0, 2, 3, 6]; cnt = 2;
            answer = [0, 2];
            result = solution.InventoryManagement(stock, cnt);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            stock = [0, 0, 2, 3, 3, 5, 6, 0, 3, 4, 4, 4, 3, 0, 9, 14, 4, 17, 6, 4, 10, 18, 21, 13, 8, 4, 12, 6, 19, 11, 8, 12, 14, 7, 16, 34, 19, 18, 15, 14, 22,
                     41, 32, 23, 27, 37, 2, 30, 14, 12, 23, 41, 39, 2, 21, 32, 22, 1, 12, 25, 6, 46, 7, 61, 13, 64, 54, 56, 29, 41, 51, 2, 9, 65, 17, 28, 34, 41,
                     1, 62, 23, 14, 60, 14, 22, 17, 67, 86, 81, 45, 78, 9, 27, 17, 30, 54, 35, 42, 72, 94];
            cnt = 21;
            answer = [0, 0, 0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5];
            result = solution.InventoryManagement(stock, cnt);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

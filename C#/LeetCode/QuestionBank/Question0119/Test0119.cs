using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0119
{
    public class Test0119
    {
        public void Test()
        {
            Interface0119 solution = new Solution0119_3();
            int rowIndex;
            IList<int> result, answer;
            int id = 0;

            // 1.
            rowIndex = 0; answer = new List<int>() { 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2.
            rowIndex = 1; answer = new List<int>() { 1, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3.
            rowIndex = 2; answer = new List<int>() { 1, 2, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4.
            rowIndex = 3; answer = new List<int>() { 1, 3, 3, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            rowIndex = 4; answer = new List<int>() { 1, 4, 6, 4, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 6. 
            rowIndex = 5; answer = new List<int>() { 1, 5, 10, 10, 5, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 7. 
            rowIndex = 10; answer = new List<int>() { 1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 8. 
            rowIndex = 33; answer = new List<int>() { 1, 33, 528, 5456, 40920, 237336, 1107568, 4272048, 13884156, 38567100, 92561040, 193536720, 354817320, 573166440, 818809200, 1037158320, 1166803110, 1166803110, 1037158320, 818809200, 573166440, 354817320, 193536720, 92561040, 38567100, 13884156, 4272048, 1107568, 237336, 40920, 5456, 528, 33, 1 };
            result = solution.GetRow(rowIndex);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

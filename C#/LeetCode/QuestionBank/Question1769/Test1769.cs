using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1769
{
    public class Test1769
    {
        public void Test()
        {
            Interface1769 solution = new Solution1769();
            string boxes;
            int[] result, answer;
            int id = 0;

            // 1. 
            boxes = "110"; answer = new int[] { 1, 1, 3 };
            result = solution.MinOperations(boxes);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            boxes = "001011"; answer = new int[] { 11, 8, 5, 4, 3, 4 };
            result = solution.MinOperations(boxes);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3.
            boxes = "101010101010101010101010111010100100101010101";
            answer = new int[] { 498, 477, 456, 437, 418, 401, 384, 369, 354, 341, 328, 317, 306, 297, 288, 281, 274, 269, 264, 261, 258, 257, 256, 257, 258, 261, 266, 273, 280, 289, 298, 309, 320, 331, 344, 357, 370, 385, 400, 417, 434, 453, 472, 493, 514 };
            result = solution.MinOperations(boxes);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

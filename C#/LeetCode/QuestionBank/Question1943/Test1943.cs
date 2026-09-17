using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1943
{
    public class Test1943
    {
        public void Test()
        {
            Interface1943 solution = new Solution1943();
            int[][] segments;
            IList<IList<long>> result, answer;
            int id = 0;

            // 1. 
            segments = [[1, 4, 5], [4, 7, 7], [1, 7, 9]];
            answer = [[1, 4, 14], [4, 7, 16]];
            result = solution.SplitPainting(segments);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            segments = [[1, 7, 9], [6, 8, 15], [8, 10, 7]];
            answer = [[1, 6, 9], [6, 7, 24], [7, 8, 15], [8, 10, 7]];
            result = solution.SplitPainting(segments);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            segments = [[1, 4, 5], [1, 4, 7], [4, 7, 1], [4, 7, 11]];
            answer = [[1, 4, 12], [4, 7, 12]];
            result = solution.SplitPainting(segments);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            segments = [[4, 16, 12], [9, 10, 15], [18, 19, 13], [3, 13, 20], [12, 16, 3], [2, 10, 10], [3, 11, 4], [13, 16, 6]];
            answer = [[2, 3, 10], [3, 4, 34], [4, 9, 46], [9, 10, 61], [10, 11, 36], [11, 12, 32], [12, 13, 35], [13, 16, 21], [18, 19, 13]];
            result = solution.SplitPainting(segments);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

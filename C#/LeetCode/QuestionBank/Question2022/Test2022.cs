using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2022
{
    public class Test2022
    {
        public void Test()
        {
            Interface2022 solution = new Solution2022();
            int[] original; int m, n;
            int[][] result, answer;
            int id = 0;

            // 1. 
            original = new int[] { 1, 2, 3, 4 }; m = 2; n = 2;
            answer = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
            result = solution.Construct2DArray(original, m, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 2. 
            original = new int[] { 1, 2, 3 }; m = 1; n = 3;
            answer = new int[][] { new int[] { 1, 2, 3 } };
            result = solution.Construct2DArray(original, m, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 3. 
            original = new int[] { 1, 2 }; m = 1; n = 1;
            answer = new int[0][];
            result = solution.Construct2DArray(original, m, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 4. 
            original = new int[] { 3 }; m = 1; n = 2;
            answer = new int[0][];
            result = solution.Construct2DArray(original, m, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 5. 
            original = new int[] { 1, 1, 1, 1 }; m = 4; n = 1;
            answer = new int[4][] { new int[] { 1 }, new int[] { 1 }, new int[] { 1 }, new int[] { 1 } };
            result = solution.Construct2DArray(original, m, n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");
        }
    }
}

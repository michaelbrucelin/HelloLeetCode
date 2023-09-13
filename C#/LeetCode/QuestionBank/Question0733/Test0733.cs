using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0733
{
    public class Test0733
    {
        public void Test()
        {
            Interface0733 solution = new Solution0733_2();
            int[][] image; int sr, sc, color;
            int[][] result, answer;
            int id = 0;

            // 1. 
            image = new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 } }; sr = 1; sc = 1; color = 2;
            answer = new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 0 }, new int[] { 2, 0, 1 } };
            result = solution.FloodFill(image, sr, sc, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            image = new int[][] { new int[] { 1, 3, 3 }, new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 } }; sr = 1; sc = 1; color = 2;
            answer = new int[][] { new int[] { 2, 3, 3 }, new int[] { 2, 2, 0 }, new int[] { 2, 0, 1 } };
            result = solution.FloodFill(image, sr, sc, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            image = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } }; sr = 0; sc = 0; color = 2;
            answer = new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 } };
            result = solution.FloodFill(image, sr, sc, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            image = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } }; sr = 0; sc = 0; color = 0;
            answer = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
            result = solution.FloodFill(image, sr, sc, color);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

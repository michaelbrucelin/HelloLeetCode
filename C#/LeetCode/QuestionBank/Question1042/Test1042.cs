using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1042
{
    public class Test1042
    {
        public void Test()
        {
            Interface1042 solution = new Solution1042();
            int n; int[][] paths;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 3; paths = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 1 } };
            answer = new int[] { 1, 2, 3 };
            result = solution.GardenNoAdj(n, paths);
            Console.WriteLine($"{++id,2}: {IsNoAdj(result, paths) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            n = 4; paths = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
            answer = new int[] { 1, 2, 1, 2 };
            result = solution.GardenNoAdj(n, paths);
            Console.WriteLine($"{++id,2}: {IsNoAdj(result, paths) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            n = 4; paths = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 1 }, new int[] { 1, 3 }, new int[] { 2, 4 } };
            answer = new int[] { 1, 2, 3, 4 };
            result = solution.GardenNoAdj(n, paths);
            Console.WriteLine($"{++id,2}: {IsNoAdj(result, paths) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }

        private bool IsNoAdj(int[] garden, int[][] paths)
        {
            foreach (var arr in paths)
                if (garden[arr[0] - 1] == garden[arr[1] - 1]) return false;
            return true;
        }
    }
}

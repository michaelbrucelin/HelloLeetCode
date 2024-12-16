using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1847
{
    public class Test1847
    {
        public void Test()
        {
            Interface1847 solution = new Solution1847_err();
            int[][] rooms, queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            rooms = [[2, 2], [1, 2], [3, 2]]; queries = [[3, 1], [3, 3], [5, 2]];
            answer = [3, -1, 3];
            result = solution.ClosestRoom(rooms, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            rooms = [[1, 4], [2, 3], [3, 5], [4, 1], [5, 2]]; queries = [[2, 3], [2, 4], [2, 5]];
            answer = [2, 1, 3];
            result = solution.ClosestRoom(rooms, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            rooms = [[23, 22], [6, 20], [15, 6], [22, 19], [2, 10], [21, 4], [10, 18], [16, 1], [12, 7], [5, 22]];
            queries = [[12, 5], [15, 15], [21, 6], [15, 1], [23, 4], [15, 11], [1, 24], [3, 19], [25, 8], [18, 6]];
            answer = [12, 10, 22, 15, 23, 10, -1, 5, 23, 15];
            result = solution.ClosestRoom(rooms, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

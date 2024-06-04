using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3067
{
    public class Test3067
    {
        public void Test()
        {
            Interface3067 solution = new Solution3067();
            int[][] edges; int signalSpeed;
            int[] result, answer;
            int id = 0;

            // 1. 
            edges = [[0, 1, 1], [1, 2, 5], [2, 3, 13], [3, 4, 9], [4, 5, 2]]; signalSpeed = 1;
            answer = [0, 4, 6, 6, 4, 0];
            result = solution.CountPairsOfConnectableServers(edges, signalSpeed);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            edges = [[0, 6, 3], [6, 5, 3], [0, 3, 1], [3, 2, 7], [3, 1, 6], [3, 4, 2]]; signalSpeed = 3;
            answer = [2, 0, 0, 0, 0, 0, 2];
            result = solution.CountPairsOfConnectableServers(edges, signalSpeed);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2477
{
    public class Test2477
    {
        public void Test()
        {
            Interface2477 solution = new Solution2477();
            int[][] roads; int seats;
            long result, answer;
            int id = 0;

            // 1. 
            roads = Utils.Str2NumArray_2d<int>("[[0,1],[0,2],[0,3]]"); seats = 5;
            answer = 3;
            result = solution.MinimumFuelCost(roads, seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            roads = Utils.Str2NumArray_2d<int>("[[3,1],[3,2],[1,0],[0,4],[0,5],[4,6]]"); seats = 2;
            answer = 7;
            result = solution.MinimumFuelCost(roads, seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            roads = new int[][] { }; seats = 1;
            answer = 0;
            result = solution.MinimumFuelCost(roads, seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            roads = Utils.Str2NumArray_2d<int>("[[0,1],[0,2],[1,3],[1,4]]"); seats = 5;
            answer = 4;
            result = solution.MinimumFuelCost(roads, seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            roads = Utils.Str2NumArray_2d<int>("[[0,1],[1,2]]"); seats = 3;
            answer = 2;
            result = solution.MinimumFuelCost(roads, seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

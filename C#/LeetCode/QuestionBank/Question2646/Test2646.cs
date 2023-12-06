using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2646
{
    public class Test2646
    {
        public void Test()
        {
            Interface2646 solution = new Solution2646();
            int n; int[][] edges; int[] price; int[][] trips;
            int result, answer;
            int id = 0;

            // 1. 
            n = 4;
            edges = Utils.Str2NumArray_2d<int>("[[0,1],[1,2],[1,3]]");
            price = new int[] { 2, 2, 10, 6 };
            trips = Utils.Str2NumArray_2d<int>("[[0,3],[2,1],[2,3]]");
            answer = 23;
            result = solution.MinimumTotalPrice(n, edges, price, trips);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 2;
            edges = Utils.Str2NumArray_2d<int>("[[0,1]]");
            price = new int[] { 2, 2 };
            trips = Utils.Str2NumArray_2d<int>("[[0,0]]");
            answer = 1;
            result = solution.MinimumTotalPrice(n, edges, price, trips);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            //n =;
            //edges = Utils.Str2NumArray_2d<int>("");
            //price = new int[] { };
            //trips = Utils.Str2NumArray_2d<int>("");
            //answer = ;
            //result = solution.MinimumTotalPrice(n, edges, price, trips);
            //Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

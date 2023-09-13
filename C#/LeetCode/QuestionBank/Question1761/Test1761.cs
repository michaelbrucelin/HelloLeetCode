using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1761
{
    public class Test1761
    {
        public void Test()
        {
            Interface1761 solution = new Solution1761();
            int n; int[][] edges;
            int result, answer;
            int id = 0;

            // 1. 
            n = 6; edges = Utils.Str2NumArray_2d<int>("[[1,2],[1,3],[3,2],[4,1],[5,2],[3,6]]");
            answer = 3;
            result = solution.MinTrioDegree(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 7; edges = Utils.Str2NumArray_2d<int>("[[1,3],[4,1],[4,3],[2,5],[5,6],[6,7],[7,5],[2,6]]");
            answer = 0;
            result = solution.MinTrioDegree(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3; edges = Utils.Str2NumArray_2d<int>("[[3,2],[2,1]]");
            answer = -1;
            result = solution.MinTrioDegree(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 15; edges = Utils.Str2NumArray_2d<int>("[[6,15],[12,10],[14,7],[4,6],[14,10],[3,10],[5,1],[4,15],[14,13],[8,3],[8,6],[10,9],[2,5],[1,3],[15,2],[2,14],[15,5],[7,4],[6,2],[10,15],[15,8],[15,14],[1,15],[6,14],[4,5],[3,9],[5,6],[3,6],[4,14],[5,9],[8,2],[3,12],[3,15],[8,5],[11,4],[9,4],[5,12],[11,7],[2,4],[1,2],[9,13],[10,11],[2,7],[10,8],[1,11],[2,10],[15,7],[1,14],[2,13],[7,9],[6,13],[7,6],[6,10],[8,11],[3,2],[14,5],[3,14],[5,11],[4,13],[8,1],[10,4],[11,9],[10,7],[10,13],[1,4],[8,13],[11,6],[1,7],[1,13],[2,9],[2,12],[13,12],[15,9],[14,12]]");
            answer = 20;
            result = solution.MinTrioDegree(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

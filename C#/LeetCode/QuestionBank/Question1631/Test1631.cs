using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1631
{
    public class Test1631
    {
        public void Test()
        {
            Interface1631 solution = new Solution1631_3();
            int[][] heights;
            int result, answer;
            int id = 0;

            // 1. 
            heights = Utils.Str2NumArray_2d<int>("[[1,2,2],[3,8,2],[5,3,5]]");
            answer = 2;
            result = solution.MinimumEffortPath(heights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            heights = Utils.Str2NumArray_2d<int>("[[1,2,3],[3,8,4],[5,3,5]]");
            answer = 1;
            result = solution.MinimumEffortPath(heights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            heights = Utils.Str2NumArray_2d<int>("[[1,2,1,1,1],[1,2,1,2,1],[1,2,1,2,1],[1,2,1,2,1],[1,1,1,2,1]]");
            answer = 0;
            result = solution.MinimumEffortPath(heights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            heights = Utils.Str2NumArray_2d<int>("[[4,3,4,10,5,5,9,2],[10,8,2,10,9,7,5,6],[5,8,10,10,10,7,4,2],[5,1,3,1,1,3,1,9],[6,4,10,6,10,9,4,6]]");
            answer = 5;
            result = solution.MinimumEffortPath(heights);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

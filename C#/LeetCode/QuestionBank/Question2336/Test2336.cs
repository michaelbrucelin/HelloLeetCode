using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2336
{
    public class Test2336
    {
        public void Test()
        {
            Interface2336 solution;
            int result, answer;
            int id1, id2;

            // 1. 
            id1 = 1; id2 = 0;
            solution = new SmallestInfiniteSet_2();
            solution.AddBack(2);
            answer = 1; result = solution.PopSmallest(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 2; result = solution.PopSmallest(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 3; result = solution.PopSmallest(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.AddBack(1);
            answer = 1; result = solution.PopSmallest(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 4; result = solution.PopSmallest(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 5; result = solution.PopSmallest(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

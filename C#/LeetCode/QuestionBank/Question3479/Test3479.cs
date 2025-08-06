using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3479
{
    public class Test3479
    {
        public void Test()
        {
            Interface3479 solution = new Solution3479();
            int[] fruits, baskets;
            int result, answer;
            int id = 0;

            // 1. 
            fruits = [4, 2, 5]; baskets = [3, 5, 4];
            answer = 1;
            result = solution.NumOfUnplacedFruits(fruits, baskets);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            fruits = [3, 6, 1]; baskets = [6, 4, 7];
            answer = 0;
            result = solution.NumOfUnplacedFruits(fruits, baskets);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

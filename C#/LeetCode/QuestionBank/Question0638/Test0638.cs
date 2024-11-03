using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0638
{
    public class Test0638
    {
        public void Test()
        {
            Interface0638 solution = new Solution0638();
            IList<int> price; IList<IList<int>> special; IList<int> needs;
            int result, answer;
            int id = 0;

            // 1. 
            price = [2, 5]; special = [[3, 0, 5], [1, 2, 10]]; needs = [3, 2];
            answer = 14;
            result = solution.ShoppingOffers(price, special, needs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            price = [2, 3, 4]; special = [[1, 1, 0, 4], [2, 2, 1, 9]]; needs = [1, 2, 1];
            answer = 11;
            result = solution.ShoppingOffers(price, special, needs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

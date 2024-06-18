using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2288
{
    public class Test2288
    {
        public void Test()
        {
            Interface2288 solution = new Solution2288_2();
            string sentence; int discount;
            string result, answer;
            int id = 0;

            // 1. 
            sentence = "there are $1 $2 and 5$ candies in the shop"; discount = 50;
            answer = "there are $0.50 $1.00 and 5$ candies in the shop";
            result = solution.DiscountPrices(sentence, discount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            sentence = "1 2 $3 4 $5 $6 7 8$ $9 $10$"; discount = 100;
            answer = "1 2 $0.00 4 $0.00 $0.00 7 8$ $0.00 $10$";
            result = solution.DiscountPrices(sentence, discount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            sentence = "$7383692 5q $5870426"; discount = 64;
            answer = "$2658129.12 5q $2113353.36";
            result = solution.DiscountPrices(sentence, discount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

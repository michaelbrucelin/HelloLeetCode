using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0605
{
    public class Test0605
    {
        public void Test()
        {
            Interface0605 solution = new Solution0605();
            int[] flowerbed; int n;
            bool result, answer;
            int id = 0;

            // 1. 
            flowerbed = new int[] { 1, 0, 0, 0, 1 }; n = 1; answer = true;
            result = solution.CanPlaceFlowers(flowerbed, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            flowerbed = new int[] { 1, 0, 0, 0, 1 }; n = 2; answer = false;
            result = solution.CanPlaceFlowers(flowerbed, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            flowerbed = new int[] { 0 }; n = 1; answer = true;
            result = solution.CanPlaceFlowers(flowerbed, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

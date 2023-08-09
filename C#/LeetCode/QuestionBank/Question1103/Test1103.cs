using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1103
{
    public class Test1103
    {
        public void Test()
        {
            Interface1103 solution = new Solution1103_2();
            int candies, num_people;
            int[] result, answer;
            int id = 0;

            // 1. 
            candies = 7; num_people = 4;
            answer = new int[] { 1, 2, 3, 1 };
            result = solution.DistributeCandies(candies, num_people);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            candies = 10; num_people = 3;
            answer = new int[] { 5, 2, 3 };
            result = solution.DistributeCandies(candies, num_people);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            candies = 60; num_people = 4;
            answer = new int[] { 15, 18, 15, 12 };
            result = solution.DistributeCandies(candies, num_people);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1090
{
    public class Test1090
    {
        public void Test()
        {
            Interface1090 solution = new Solution1090_2();
            int[] values, labels; int numWanted, useLimit;
            int result, answer;
            int id = 0;

            // 1. 
            values = new int[] { 5, 4, 3, 2, 1 }; labels = new int[] { 1, 1, 2, 2, 3 };
            numWanted = 3; useLimit = 1; answer = 9;
            result = solution.LargestValsFromLabels(values, labels, numWanted, useLimit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            values = new int[] { 5, 4, 3, 2, 1 }; labels = new int[] { 1, 3, 3, 3, 2 };
            numWanted = 3; useLimit = 2; answer = 12;
            result = solution.LargestValsFromLabels(values, labels, numWanted, useLimit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            values = new int[] { 9, 8, 8, 7, 6 }; labels = new int[] { 0, 0, 0, 1, 1 };
            numWanted = 3; useLimit = 1; answer = 16;
            result = solution.LargestValsFromLabels(values, labels, numWanted, useLimit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            values = new int[] { 2, 6, 1, 2, 6 }; labels = new int[] { 2, 2, 2, 1, 1 };
            numWanted = 1; useLimit = 1; answer = 6;
            result = solution.LargestValsFromLabels(values, labels, numWanted, useLimit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

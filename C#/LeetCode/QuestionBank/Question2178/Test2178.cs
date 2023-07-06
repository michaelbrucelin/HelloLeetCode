using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2178
{
    public class Test2178
    {
        public void Test()
        {
            Interface2178 solution = new Solution2178_2();
            long finalSum;
            IList<long> result, answer;
            int id = 0;

            // 1. 
            finalSum = 12;
            answer = new List<long>() { 2, 4, 6 };
            result = solution.MaximumEvenSplit(finalSum);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            finalSum = 7;
            answer = new List<long>() { };
            result = solution.MaximumEvenSplit(finalSum);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            finalSum = 28;
            answer = new List<long>() { 2, 4, 6, 16 };
            result = solution.MaximumEvenSplit(finalSum);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

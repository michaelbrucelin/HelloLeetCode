using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1291
{
    public class Test1291
    {
        public void Test()
        {
            Interface1291 solution = new Solution1291();
            int low, high;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            low = 100; high = 300;
            answer = [123, 234];
            result = solution.SequentialDigits(low, high);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            low = 1000; high = 13000;
            answer = [1234, 2345, 3456, 4567, 5678, 6789, 12345];
            result = solution.SequentialDigits(low, high);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            low = 234; high = 2314;
            answer = [234, 345, 456, 567, 678, 789, 1234];
            result = solution.SequentialDigits(low, high);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

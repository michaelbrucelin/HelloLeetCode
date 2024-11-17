using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0825
{
    public class Test0825
    {
        public void Test()
        {
            Interface0825 solution = new Solution0825();
            int[] ages;
            int result, answer;
            int id = 0;

            // 1. 
            ages = [16, 16];
            answer = 2;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            ages = [16, 17, 18];
            answer = 2;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            ages = [20, 30, 100, 110, 120];
            answer = 3;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            ages = [101, 56, 69, 48, 30];
            answer = 4;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            ages = [8, 85, 24, 85, 69];
            answer = 4;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            ages = [54, 23, 102, 90, 40, 74, 112, 74, 76, 21];
            answer = 22;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            ages = [73, 106, 39, 6, 26, 15, 30, 100, 71, 35, 46, 112, 6, 60, 110];
            answer = 29;
            result = solution.NumFriendRequests(ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

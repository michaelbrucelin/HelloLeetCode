using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2076
{
    public class Test2076
    {
        public void Test()
        {
            Interface2076 solution = new Solution2076_2();
            int n; int[][] restrictions, requests;
            bool[] result, answer;
            int id = 0;

            // 1. 
            n = 3; restrictions = [[0, 1]]; requests = [[0, 2], [2, 1]];
            answer = [true, false];
            result = solution.FriendRequests(n, restrictions, requests);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 3; restrictions = [[0, 1]]; requests = [[1, 2], [0, 2]];
            answer = [true, false];
            result = solution.FriendRequests(n, restrictions, requests);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 5; restrictions = [[0, 1], [1, 2], [2, 3]]; requests = [[0, 4], [1, 2], [3, 1], [3, 4]];
            answer = [true, false, true, false];
            result = solution.FriendRequests(n, restrictions, requests);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

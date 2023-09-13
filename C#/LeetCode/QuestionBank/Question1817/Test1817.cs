using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1817
{
    public class Test1817
    {
        public void Test()
        {
            Interface1817 solution = new Solution1817();
            int[][] logs; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            logs = new int[][] { new int[] { 0, 5 }, new int[] { 1, 2 }, new int[] { 0, 2 }, new int[] { 0, 5 }, new int[] { 1, 3 } };
            k = 5; answer = new int[] { 0, 2, 0, 0, 0 };
            result = solution.FindingUsersActiveMinutes(logs, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            logs = new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 2, 3 } };
            k = 4; answer = new int[] { 1, 1, 0, 0 };
            result = solution.FindingUsersActiveMinutes(logs, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            // [[283268890,14532],[283268891,14530],[283268889,14530],[283268892,14530],[283268890,14531]]
            logs = new int[][] { new int[] { 283268890, 14532 }, new int[] { 283268891, 14530 }, new int[] { 283268889, 14530 }, new int[] { 283268892, 14530 }, new int[] { 283268890, 14531 } };
            k = 2; answer = new int[] { 3, 1 };
            result = solution.FindingUsersActiveMinutes(logs, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

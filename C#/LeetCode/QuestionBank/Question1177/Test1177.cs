using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1177
{
    public class Test1177
    {
        public void Test()
        {
            Interface1177 solution = new Solution1177();
            string s; int[][] queries;
            IList<bool> result, answer;
            int id = 0;

            // 1. 
            s = "abcda"; queries = new int[][] { new int[] { 3, 3, 0 }, new int[] { 1, 2, 0 }, new int[] { 0, 3, 1 }, new int[] { 0, 3, 2 }, new int[] { 0, 4, 1 } };
            answer = new List<bool>() { true, false, false, true, true };
            result = solution.CanMakePaliQueries(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            s = "lyb"; queries = new int[][] { new int[] { 0, 1, 0 }, new int[] { 2, 2, 1 } };
            answer = new List<bool>() { false, true };
            result = solution.CanMakePaliQueries(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

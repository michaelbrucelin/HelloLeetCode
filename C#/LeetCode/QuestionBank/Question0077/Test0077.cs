using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0077
{
    public class Test0077
    {
        public void Test()
        {
            Interface0077 solution = new Solution0077();
            int n, k;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            n = 4; k = 2;
            answer = Utils.Str2NumArray_2d<int>("[[2,4],[3,4],[2,3],[1,2],[1,3],[1,4]]");
            result = solution.Combine(n, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            n = 1; k = 1;
            answer = Utils.Str2NumArray_2d<int>("[[1]]");
            result = solution.Combine(n, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0089
{
    public class Test0089
    {
        public void Test()
        {
            Interface0089 solution = new Solution0089_err();
            int n;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            n = 2;
            answer = [0, 1, 3, 2];
            result = solution.GrayCode(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}"); ;

            // 2. 
            n = 1;
            answer = [0, 1];
            result = solution.GrayCode(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 3;
            answer = [0, 1, 3, 2, 6, 7, 5, 4];
            result = solution.GrayCode(n);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

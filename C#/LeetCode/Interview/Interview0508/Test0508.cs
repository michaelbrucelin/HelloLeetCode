using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0508
{
    public class Test0508
    {
        public void Test()
        {
            Interface0508 solution = new Solution0508();
            int length; int w, x1, x2, y;
            int[] result, answer;
            int id = 0;

            // 1. 
            length = 1; w = 32; x1 = 30; x2 = 31; y = 0;
            answer = [3];
            result = solution.DrawLine(length, w, x1, x2, y);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            length = 3; w = 96; x1 = 0; x2 = 95; y = 0;
            answer = [-1, -1, -1];
            result = solution.DrawLine(length, w, x1, x2, y);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

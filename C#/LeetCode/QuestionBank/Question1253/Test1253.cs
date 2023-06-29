using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1253
{
    public class Test1253
    {
        public void Test()
        {
            Interface1253 solution = new Solution1253();
            int upper, lower; int[] colsum;
            IList<IList<int>> result; bool flag;
            int id = 0;

            // 1. 
            upper = 2; lower = 1; colsum = new int[] { 1, 1, 1 };
            flag = false;
            result = solution.ReconstructMatrix(upper, lower, colsum);
            flag = flag ? result.Count == 0 : result[0].Sum() == upper && result[1].Sum() == lower && Utils.CompareArray(result[0].Zip(result[1], (i, j) => i + j).ToArray(), colsum);
            Console.WriteLine($"{++id,2}: {flag + ",",-6} result: {Utils.ArrayToString(result, false)}");

            // 2. 
            upper = 2; lower = 3; colsum = new int[] { 2, 2, 1, 1 };
            flag = true;
            result = solution.ReconstructMatrix(upper, lower, colsum);
            flag = flag ? result.Count == 0 : result[0].Sum() == upper && result[1].Sum() == lower && Utils.CompareArray(result[0].Zip(result[1], (i, j) => i + j).ToArray(), colsum);
            Console.WriteLine($"{++id,2}: {flag + ",",-6} result: {Utils.ArrayToString(result, false)}");

            // 3. 
            upper = 5; lower = 5; colsum = new int[] { 2, 1, 2, 0, 1, 0, 1, 2, 0, 1 };
            flag = false;
            result = solution.ReconstructMatrix(upper, lower, colsum);
            flag = flag ? result.Count == 0 : result[0].Sum() == upper && result[1].Sum() == lower && Utils.CompareArray(result[0].Zip(result[1], (i, j) => i + j).ToArray(), colsum);
            Console.WriteLine($"{++id,2}: {flag + ",",-6} result: {Utils.ArrayToString(result, false)}");
        }
    }
}

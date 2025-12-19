using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0636
{
    public class Test0636
    {
        public void Test()
        {
            Interface0636 solution = new Solution0636();
            int n; IList<string> logs;
            int[] result, answer;
            int id = 0;

            // 1.
            n = 2; logs = ["0:start:0", "1:start:2", "1:end:5", "0:end:6"];
            answer = [3, 4];
            result = solution.ExclusiveTime(n, logs);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 1; logs = ["0:start:0", "0:start:2", "0:end:5", "0:start:6", "0:end:6", "0:end:7"];
            answer = [8];
            result = solution.ExclusiveTime(n, logs);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 2; logs = ["0:start:0", "0:start:2", "0:end:5", "1:start:6", "1:end:6", "0:end:7"];
            answer = [7, 1];
            result = solution.ExclusiveTime(n, logs);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

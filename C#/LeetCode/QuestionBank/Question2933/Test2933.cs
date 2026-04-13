using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2933
{
    public class Test2933
    {
        public void Test()
        {
            Interface2933 solution = new Solution2933();
            IList<IList<string>> access_times;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            access_times = [["a", "0549"], ["b", "0457"], ["a", "0532"], ["a", "0621"], ["b", "0540"]];
            answer = ["a"];
            result = solution.FindHighAccessEmployees(access_times);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            access_times = [["d", "0002"], ["c", "0808"], ["c", "0829"], ["e", "0215"], ["d", "1508"], ["d", "1444"], ["d", "1410"], ["c", "0809"]];
            answer = ["c", "d"];
            result = solution.FindHighAccessEmployees(access_times);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            access_times = [["cd", "1025"], ["ab", "1025"], ["cd", "1046"], ["cd", "1055"], ["ab", "1124"], ["ab", "1120"]];
            answer = ["ab", "cd"];
            result = solution.FindHighAccessEmployees(access_times);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

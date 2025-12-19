using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2092
{
    public class Test2092
    {
        public void Test()
        {
            Interface2092 solution = new Solution2092();
            int n; int[][] meetings; int firstPerson;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            n = 6; meetings = [[1, 2, 5], [2, 3, 8], [1, 5, 10]]; firstPerson = 1;
            answer = [0, 1, 2, 3, 5];
            result = solution.FindAllPeople(n, meetings, firstPerson);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 4; meetings = [[3, 1, 3], [1, 2, 2], [0, 3, 3]]; firstPerson = 3;
            answer = [0, 1, 3];
            result = solution.FindAllPeople(n, meetings, firstPerson);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 5; meetings = [[3, 4, 2], [1, 2, 1], [2, 3, 1]]; firstPerson = 1;
            answer = [0, 1, 2, 3, 4];
            result = solution.FindAllPeople(n, meetings, firstPerson);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

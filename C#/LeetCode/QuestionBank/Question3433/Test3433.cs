using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3433
{
    public class Test3433
    {
        public void Test()
        {
            Interface3433 solution = new Solution3433();
            int numberOfUsers; IList<IList<string>> events;
            int[] result, answer;
            int id = 0;

            // 1. 
            numberOfUsers = 2; events = [["MESSAGE", "10", "id1 id0"], ["OFFLINE", "11", "0"], ["MESSAGE", "71", "HERE"]];
            answer = [2, 2];
            result = solution.CountMentions(numberOfUsers, events);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            numberOfUsers = 2; events = [["MESSAGE", "10", "id1 id0"], ["OFFLINE", "11", "0"], ["MESSAGE", "12", "ALL"]];
            answer = [2, 2];
            result = solution.CountMentions(numberOfUsers, events);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            numberOfUsers = 2; events = [["OFFLINE", "10", "0"], ["MESSAGE", "12", "HERE"]];
            answer = [0, 1];
            result = solution.CountMentions(numberOfUsers, events);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            numberOfUsers = 3; events = [["MESSAGE", "5", "HERE"], ["OFFLINE", "10", "0"], ["MESSAGE", "15", "HERE"], ["OFFLINE", "18", "2"], ["MESSAGE", "20", "HERE"]];
            answer = [1, 3, 2];
            result = solution.CountMentions(numberOfUsers, events);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

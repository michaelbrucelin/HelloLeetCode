using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1604
{
    public class Test1604
    {
        public void Test()
        {
            Interface1604 solution = new Solution1604();
            string[] keyName, keyTime;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            keyName = new string[] { "daniel", "daniel", "daniel", "luis", "luis", "luis", "luis" };
            keyTime = new string[] { "10:00", "10:40", "11:00", "09:00", "11:00", "13:00", "15:00" };
            answer = new string[] { "daniel" };
            result = solution.AlertNames(keyName, keyTime);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            keyName = new string[] { "alice", "alice", "alice", "bob", "bob", "bob", "bob" };
            keyTime = new string[] { "12:01", "12:00", "18:00", "21:00", "21:20", "21:30", "23:00" };
            answer = new string[] { "bob" };
            result = solution.AlertNames(keyName, keyTime);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            keyName = new string[] { "john", "john", "john" };
            keyTime = new string[] { "23:58", "23:59", "00:01" };
            answer = new string[] { };
            result = solution.AlertNames(keyName, keyTime);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            keyName = new string[] { "leslie", "leslie", "leslie", "clare", "clare", "clare", "clare" };
            keyTime = new string[] { "13:00", "13:20", "14:00", "18:00", "18:51", "19:30", "19:49" };
            answer = new string[] { "clare", "leslie" };
            result = solution.AlertNames(keyName, keyTime);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}

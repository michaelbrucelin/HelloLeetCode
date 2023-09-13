using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0401
{
    public class Test0401
    {
        public void Test()
        {
            Interface0401 solution = new Solution0401_2();
            int turnedOn;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            turnedOn = 1; answer = new List<string>() { "0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00", "2:00", "4:00", "8:00" };
            result = solution.ReadBinaryWatch(turnedOn);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            turnedOn = 9; answer = new List<string>();
            result = solution.ReadBinaryWatch(turnedOn);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            turnedOn = 0; answer = new List<string>() { "0:00" };
            result = solution.ReadBinaryWatch(turnedOn);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

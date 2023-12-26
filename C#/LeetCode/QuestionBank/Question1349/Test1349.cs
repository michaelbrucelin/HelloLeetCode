using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1349
{
    public class Test1349
    {
        public void Test()
        {
            Interface1349 solution = new Solution1349();
            char[][] seats;
            int result, answer;
            int id = 0;

            // 1. 
            seats = Utils.Str2CharArray_2d("[[\"#\",\".\",\"#\",\"#\",\".\",\"#\"],[\".\",\"#\",\"#\",\"#\",\"#\",\".\"],[\"#\",\".\",\"#\",\"#\",\".\",\"#\"]]");
            answer = 4;
            result = solution.MaxStudents(seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            seats = Utils.Str2CharArray_2d("[[\".\",\"#\"],[\"#\",\"#\"],[\"#\",\".\"],[\"#\",\"#\"],[\".\",\"#\"]]");
            answer = 3;
            result = solution.MaxStudents(seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            seats = Utils.Str2CharArray_2d("[[\"#\",\".\",\".\",\".\",\"#\"],[\".\",\"#\",\".\",\"#\",\".\"],[\".\",\".\",\"#\",\".\",\".\"],[\".\",\"#\",\".\",\"#\",\".\"],[\"#\",\".\",\".\",\".\",\"#\"]]");
            answer = 10;
            result = solution.MaxStudents(seats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1301
{
    public class Test1301
    {
        public void Test()
        {
            Interface1301 solution = new Solution1301();
            IList<string> board;
            int[] result, answer;
            int id = 0;

            // 1. 
            board = ["E23", "2X2", "12S"];
            answer = [7, 1];
            result = solution.PathsWithMaxScore(board);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            board = ["E12", "1X1", "21S"];
            answer = [4, 2];
            result = solution.PathsWithMaxScore(board);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            board = ["E11", "XXX", "11S"];
            answer = [0, 0];
            result = solution.PathsWithMaxScore(board);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            board = ["EX", "XS"];
            answer = [0, 1];
            result = solution.PathsWithMaxScore(board);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}

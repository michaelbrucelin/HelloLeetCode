using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1366
{
    public class Test1366
    {
        public void Test()
        {
            Interface1366 solution = new Solution1366_2();
            string[] votes;
            string result, answer;
            int id = 0;

            // 1.
            votes = ["ABC", "ACB", "ABC", "ACB", "ACB"];
            answer = "ACB";
            result = solution.RankTeams(votes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            votes = ["WXYZ", "XYZW"];
            answer = "XWYZ";
            result = solution.RankTeams(votes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            votes = ["ZMNAGUEDSJYLBOPHRQICWFXTVK"];
            answer = "ZMNAGUEDSJYLBOPHRQICWFXTVK";
            result = solution.RankTeams(votes);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2056
{
    public class Test2056
    {
        public void Test()
        {
            Interface2056 solution = new Solution2056_err();
            string[] pieces; int[][] positions;
            int result, answer;
            int id = 0;

            // 1. 
            pieces = ["rook"]; positions = [[1, 1]];
            answer = 15;
            result = solution.CountCombinations(pieces, positions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            pieces = ["queen"]; positions = [[1, 1]];
            answer = 22;
            result = solution.CountCombinations(pieces, positions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            pieces = ["bishop"]; positions = [[4, 3]];
            answer = 12;
            result = solution.CountCombinations(pieces, positions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            pieces = ["rook", "rook"]; positions = [[1, 1], [8, 8]];
            answer = 223;
            result = solution.CountCombinations(pieces, positions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            pieces = ["queen", "bishop"]; positions = [[5, 7], [3, 4]];
            answer = 281;
            result = solution.CountCombinations(pieces, positions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

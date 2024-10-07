using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0999
{
    public class Test0999
    {
        public void Test()
        {
            Interface0999 solution = new Solution0999();
            char[][] board;
            int result, answer;
            int id = 0;

            // 1. 
            board = [['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', 'p', '.', '.', '.', '.'], ['.', '.', '.', 'R', '.', '.', '.', 'p'], ['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', 'p', '.', '.', '.', '.'], ['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', '.', '.', '.', '.', '.']];
            answer = 3;
            result = solution.NumRookCaptures(board);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            board = [['.', '.', '.', '.', '.', '.', '.', '.'], ['.', 'p', 'p', 'p', 'p', 'p', '.', '.'], ['.', 'p', 'p', 'B', 'p', 'p', '.', '.'], ['.', 'p', 'B', 'R', 'B', 'p', '.', '.'], ['.', 'p', 'p', 'B', 'p', 'p', '.', '.'], ['.', 'p', 'p', 'p', 'p', 'p', '.', '.'], ['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', '.', '.', '.', '.', '.']];
            answer = 0;
            result = solution.NumRookCaptures(board);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            board = [['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', 'p', '.', '.', '.', '.'], ['.', '.', '.', 'p', '.', '.', '.', '.'], ['p', 'p', '.', 'R', '.', 'p', 'B', '.'], ['.', '.', '.', '.', '.', '.', '.', '.'], ['.', '.', '.', 'B', '.', '.', '.', '.'], ['.', '.', '.', 'p', '.', '.', '.', '.'], ['.', '.', '.', '.', '.', '.', '.', '.']];
            answer = 3;
            result = solution.NumRookCaptures(board);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

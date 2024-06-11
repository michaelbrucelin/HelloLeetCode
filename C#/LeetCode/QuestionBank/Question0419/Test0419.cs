using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0419
{
    public class Test0419
    {
        public void Test()
        {
            Interface0419 solution = new Solution0419_2();
            char[][] board;
            int result, answer;
            int id = 0;

            // 1. 
            board = [['X', '.', '.', 'X'], ['.', '.', '.', 'X'], ['.', '.', '.', 'X']];
            answer = 2;
            result = solution.CountBattleships(board);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            board = [['.']];
            answer = 0;
            result = solution.CountBattleships(board);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

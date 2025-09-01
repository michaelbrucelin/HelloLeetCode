using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0037
{
    public class Test0037
    {
        public void Test()
        {
            Interface0037 solution = new Solution0037_3();
            char[][] board;
            char[][] result, answer;
            int id = 0;

            // 1. 
            board = [['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                     ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                     ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                     ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                     ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                     ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                     ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                     ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                     ['.', '.', '.', '.', '8', '.', '.', '7', '9']];
            solution.SolveSudoku(board);
            result = board;
            answer = [['5', '3', '4', '6', '7', '8', '9', '1', '2'],
                      ['6', '7', '2', '1', '9', '5', '3', '4', '8'],
                      ['1', '9', '8', '3', '4', '2', '5', '6', '7'],
                      ['8', '5', '9', '7', '6', '1', '4', '2', '3'],
                      ['4', '2', '6', '8', '5', '3', '7', '9', '1'],
                      ['7', '1', '3', '9', '2', '4', '8', '5', '6'],
                      ['9', '6', '1', '5', '3', '7', '2', '8', '4'],
                      ['2', '8', '7', '4', '1', '9', '6', '3', '5'],
                      ['3', '4', '5', '2', '8', '6', '1', '7', '9']];
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0041
{
    public class Test0041
    {
        public void Test()
        {
            Interface0041 solution = new Solution0041();
            string[] chessboard;
            int result, answer;
            int id = 0;

            // 1. 
            chessboard = new string[] { "....X.", "....X.", "XOOO..", "......", "......" };
            answer = 3;
            result = solution.FlipChess(chessboard);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            chessboard = new string[] { ".X.", ".O.", "XO." };
            answer = 2;
            result = solution.FlipChess(chessboard);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            chessboard = new string[] { ".......", ".......", ".......", "X......", ".O.....", "..O....", "....OOX" };
            answer = 4;
            result = solution.FlipChess(chessboard);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}

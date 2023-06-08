using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1240
{
    public class Solution1240_dial : Interface1240
    {
        public int TilingRectangle(int n, int m)
        {
            int[,] answers = new int[,] {
                {  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                {  2, 1, 3, 2, 4, 3, 5, 4, 6,  5,  7,  6,  8 },
                {  3, 3, 1, 4, 4, 2, 5, 5, 3,  6,  6,  4,  7 },
                {  4, 2, 4, 1, 5, 3, 5, 2, 6,  4,  6,  3,  7 },
                {  5, 4, 4, 5, 1, 5, 5, 5, 6,  2,  6,  6,  6 },
                {  6, 3, 2, 3, 5, 1, 5, 4, 3,  4,  6,  2,  6 },
                {  7, 5, 5, 5, 5, 5, 1, 7, 6,  6,  6,  6,  6 },
                {  8, 4, 5, 2, 5, 4, 7, 1, 7,  5,  6,  3,  6 },
                {  9, 6, 3, 6, 6, 3, 6, 7, 1,  6,  7,  4,  7 },
                { 10, 5, 6, 4, 2, 4, 6, 5, 6,  1,  6,  5,  7 },
                { 11, 7, 6, 6, 6, 6, 6, 6, 7,  6,  1,  7,  6 },
                { 12, 6, 4, 3, 6, 2, 6, 3, 4,  5,  7,  1,  7 },
                { 13, 8, 7, 7, 6, 6, 6, 6, 7,  7,  6,  7,  1 }
            };
            return answers[n - 1, m - 1];
        }
    }
}

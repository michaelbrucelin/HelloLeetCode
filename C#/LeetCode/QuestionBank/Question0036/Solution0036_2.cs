using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0036
{
    public class Solution0036_2 : Interface0036
    {
        /// <summary>
        /// 模拟
        /// 逻辑本质上同Solution0036
        /// Solution0036是遍历3次，使用1个mask记录，这里是遍历1次，使用27个mask记录
        /// Solution0036是逐行，逐列，逐块去检查，这里是逐个单元格去检查
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            int[,] masks = new int[3, 9];  // 1维 行，2维 列， 3维 块
            int val, mask, p;
            for (int r = 0; r < 9; r++) for (int c = 0; c < 9; c++) if (board[r][c] != '.')
                    {
                        val = board[r][c] & 15;
                        mask = 1 << val;
                        if (((masks[0, r] >> val) & 1) != 0) return false; else masks[0, r] |= mask;
                        if (((masks[1, c] >> val) & 1) != 0) return false; else masks[1, c] |= mask;
                        p = r / 3 * 3 + c / 3;
                        if (((masks[2, p] >> val) & 1) != 0) return false; else masks[2, p] |= mask;
                    }

            return true;
        }
    }
}

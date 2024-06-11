using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0419
{
    public class Solution0419_2 : Interface0419
    {
        /// <summary>
        /// 遍历
        /// 进阶提示后才想到的，由于“战舰”只能横着或者竖着放，所以只需要遍历一次“甲板”
        ///     如果是战舰，检查左侧或者上侧是不是战舰即可，是，忽略，不是，结果+1
        ///     即只有战舰的最左上侧进行了计算
        /// 反思，其实这个进阶解法并没有多难想，但是为什么没有进阶提示自己就没想到，而是直接掉进了BFS的思维定势中了？
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int CountBattleships(char[][] board)
        {
            int result = 0, rcnt = board.Length, ccnt = board[0].Length;
            if (board[0][0] != '.') result++;
            for (int c = 1; c < ccnt; c++) if (board[0][c] != '.' && board[0][c - 1] == '.') result++;
            for (int r = 1; r < rcnt; r++) if (board[r][0] != '.' && board[r - 1][0] == '.') result++;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    if (board[r][c] != '.' && board[r - 1][c] == '.' && board[r][c - 1] == '.') result++;
                }

            return result;
        }
    }
}

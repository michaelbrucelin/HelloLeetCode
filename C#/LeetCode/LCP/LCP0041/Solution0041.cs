using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0041
{
    public class Solution0041 : Interface0041
    {
        /// <summary>
        /// 暴力
        /// 1. 枚举每一个位置
        ///     验证水平方向
        ///     验证垂直方向
        ///     验证左斜方向
        ///     验证右斜方向
        /// 2. 封装一个方法，检查棋盘中所有可以翻转的白棋，将其翻转并计数，用于执完黑棋后调用
        /// 
        /// 未完成，感觉写起来好恶心，没心情写了，以后再说
        /// </summary>
        /// <param name="chessboard"></param>
        /// <returns></returns>
        public int FlipChess(string[] chessboard)
        {
            int rcnt = chessboard.Length, ccnt = chessboard[0].Length;
            int[,] _chess = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    _chess[r, c] = chessboard[r][c] & 3;  // 黑棋：X -> 0, 白棋：O -> 3, 空白：. -> 2, 分别为其ASCII码的后两位
                }

            throw new NotImplementedException();
        }

        private int FlipWhite(int[,] chess, int rcnt, int ccnt)
        {
            throw new NotImplementedException();
        }
    }
}

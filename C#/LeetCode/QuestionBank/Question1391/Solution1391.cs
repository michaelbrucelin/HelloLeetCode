using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1391
{
    public class Solution1391 : Interface1391
    {
        /// <summary>
        /// 状态机
        /// 逻辑完全同Solution1391_err，修正了题目理解错误的部分
        /// 整理出 Street类型 + 入口方向 --> 出口方向，就可以模拟了
        /// grid[0][0]=4 可以作为起点，题目就稍微复杂了一些，是有可能形成环路的
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool HasValidPath(int[][] grid)
        {
            if (grid.Length == 1 && grid[0].Length == 1) return true;
            if (grid[0][0] == 5) return false;

            int[] dirs = [-1, 0, 1, 0, -1];  // 0:up, 1:right, 2:down, 3:left, (x+2)%4 可实现 左右 上下 方向互转
            Dictionary<(int, int), int> map = new Dictionary<(int, int), int>()
            {
                {(1,3),1},{(1,1),3},{(2,0),2},{(2,2),0},{(3,3),2},{(3,2),3},{(4,1),2},{(4,2),1},{(5,0),3},{(5,3),0},{(6,0),1},{(6,1),0}
            };

            int from, rcnt = grid.Length, ccnt = grid[0].Length;
            from = grid[0][0] switch { 1 => 3, 2 => 0, 3 => 3, 6 => 0, 4 => 4, _ => -1 };  // 4作为起点，单独处理

            return from != 4 ? HasValidPath(from) : (HasValidPath(1) || HasValidPath(2));

            bool HasValidPath(int from)
            {
                int r = 0, c = 0;
                bool[,] visited = new bool[rcnt, ccnt];
                while (true)
                {
                    if (!map.TryGetValue((grid[r][c], from), out int dir)) return false;
                    if (r == rcnt - 1 && c == ccnt - 1) return true;
                    if (visited[r, c]) return false;
                    visited[r, c] = true;
                    from = (dir + 2) % 4; r += dirs[dir]; c += dirs[dir + 1];
                    if (r < 0 || r >= rcnt || c < 0 || c >= ccnt) return false;
                }
                throw new Exception("logic error");
            }
        }
    }
}

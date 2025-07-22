using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0427
{
    public class Solution0427_2 : Interface0427
    {
        /// <summary>
        /// 分治 + 前缀和
        /// 逻辑同Solution0427，使用前缀和优化，按照题目的数据量，使用前缀和不一定能有效果，甚至可能会反优化
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Node Construct(int[][] grid)
        {
            int n = grid.Length;
            int[,] pre = new int[n + 1, n + 1];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) pre[r + 1, c + 1] = pre[r, c + 1] + pre[r + 1, c] + grid[r][c] - pre[r, c];

            return _Construct(0, n - 1, 0, n - 1);

            Node _Construct(int top, int bottom, int left, int right)
            {
                if (check(top, bottom, left, right)) return new Node() { isLeaf = true, val = grid[top][left] == 1 };

                Node node = new Node();
                node.isLeaf = false;
                node.topLeft = _Construct(top, top + ((bottom - top) >> 1), left, left + ((right - left) >> 1));
                node.topRight = _Construct(top, top + ((bottom - top) >> 1), left + ((right - left) >> 1) + 1, right);
                node.bottomLeft = _Construct(top + ((bottom - top) >> 1) + 1, bottom, left, left + ((right - left) >> 1));
                node.bottomRight = _Construct(top + ((bottom - top) >> 1) + 1, bottom, left + ((right - left) >> 1) + 1, right);
                return node;
            }

            bool check(int top, int bottom, int left, int right)
            {
                int sum = pre[bottom + 1, right + 1] - pre[top, right + 1] - pre[bottom + 1, left] + pre[top, left];
                return sum == 0 || sum == (bottom - top + 1) * (right - left + 1);
            }
        }
    }
}

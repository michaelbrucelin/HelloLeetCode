using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0427
{
    public class Solution0427 : Interface0427
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Node Construct(int[][] grid)
        {
            int n = grid.Length;
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
                for (int r = top; r <= bottom; r++) for (int c = left; c <= right; c++) if (grid[r][c] != grid[top][left]) return false;
                return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1483
{
    public class Solution1483_3
    {
    }

    /// <summary>
    /// 倍增(binary lifting)，二进制预处理（即跳表）
    /// Solution1483是没有预处理，TLE，Solution1483_2相当于（惰性）预处理的所有的可能，MLE
    /// 所以这里采用倍增的方式预处理（折中TLE与MLE），即预处理出 y = 1, 2, 4, 8, 16 ... 2^x 的值
    ///     当计算 k 的结果时，一定可以通过预处理出来的结果计算出来（二进制）
    /// </summary>
    public class TreeAncestor_3 : Interface1483
    {
        public TreeAncestor_3(int n, int[] parent)
        {
            int len = (int)Math.Ceiling(Math.Log2(n)) + 1;
            parents = new int[n, len];
            InitParents(parent, n, len);
        }

        private int[,] parents;

        public int GetKthAncestor(int node, int k)
        {
            int pos = 0;
            while (k > 0)
            {
                if ((k & 1) == 1)
                {
                    node = parents[node, pos];
                    if (node == -1) break;
                }
                pos++; k >>= 1;
            }

            return node;
        }

        private void InitParents(int[] parent, int n, int len)
        {
            for (int i = 0; i < n; i++) for (int j = 0; j < len; j++) parents[i, j] = -2;
            for (int i = 0; i < n; i++) for (int j = 0; j < len; j++) _InitParents(parent, i, j);
        }

        private void _InitParents(int[] parent, int i, int j)
        {
            if (parents[i, j] != -2) return;
            if (j == 0)
            {
                parents[i, j] = parent[i];
            }
            else
            {
                int _i = i, _j = j;
                while (_j > 0)
                {
                    _j--;
                    if (parents[_i, _j] == -2) _InitParents(parent, _i, _j);
                    _i = parents[_i, _j];
                    if (_i == -1) break;
                }

                if (_i == -1)
                {
                    parents[i, j] = -1;
                }
                else
                {
                    if (parents[_i, _j] == -2) _InitParents(parent, _i, _j);
                    parents[i, j] = parents[_i, _j];
                }
            }
        }
    }
}

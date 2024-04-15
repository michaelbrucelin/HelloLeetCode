using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1483
{
    public class Solution1483_4
    {
    }

    /// <summary>
    /// 倍增(binary lifting)
    /// 逻辑同Solution1483_3，只是将递归1:1翻译为了迭代
    /// </summary>
    public class TreeAncestor_4 : Interface1483
    {
        public TreeAncestor_4(int n, int[] parent)
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
            Stack<(int i, int j)> stack = new Stack<(int i, int j)>();
            (int i, int j) item; int _i, _j;
            for (int i = 0; i < n; i++) for (int j = 0; j < len; j++)
                {
                    stack.Push((i, j));
                    while (stack.Count > 0)
                    {
                        item = stack.Pop();
                        if (parents[item.i, item.j] != -2) continue;
                        if (item.j == 0)
                        {
                            parents[item.i, item.j] = parent[item.i];
                        }
                        else
                        {
                            _i = item.i; _j = item.j;
                            while (_j > 0)
                            {
                                _j--;
                                if (parents[_i, _j] == -2) { stack.Push(item); stack.Push((_i, _j)); goto CONTINUE; }
                                _i = parents[_i, _j];
                                if (_i == -1) break;
                            }

                            if (_i == -1)
                            {
                                parents[item.i, item.j] = -1;
                            }
                            else
                            {
                                if (parents[_i, _j] == -2) { stack.Push(item); stack.Push((_i, _j)); goto CONTINUE; }
                                parents[item.i, item.j] = parents[_i, _j];
                            }
                        }
                        CONTINUE:;
                    }
                }
        }
    }
}

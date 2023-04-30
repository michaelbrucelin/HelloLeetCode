using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2331
{
    public class Solution2331_3 : Interface2331
    {
        /// <summary>
        /// BFS
        /// 1. 将树的节点逐层全部入List<List<int>>
        /// 2. 从最后一层逐层向上层计算结果
        /// 
        /// 预计效果不一定会比递归好，递归可能提前“短路”，而BFS必然计算了全部
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool EvaluateTree(TreeNode root)
        {
            if (root.left == null) return root.val == 1;

            List<List<int>> bfs = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                List<int> _list = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode _node = queue.Dequeue();
                    _list.Add(_node.val);
                    if (_node.left != null)
                    {
                        queue.Enqueue(_node.left); queue.Enqueue(_node.right);
                    }
                }
                bfs.Add(_list);
            }

            for (int i = bfs.Count - 2; i >= 0; i--)
            {
                for (int j = 0, k = 0; j < bfs[i].Count; j++)
                {
                    if (bfs[i][j] > 1)
                    {
                        bool _left = bfs[i + 1][k << 1] != 0, _right = bfs[i + 1][(k << 1) + 1] != 0;
                        bfs[i][j] = (bfs[i][j] == 2 ? _left || _right : _left && _right) ? 1 : 0;
                        k++;
                    }
                }
            }

            return bfs[0][0] == 1;
        }
    }
}

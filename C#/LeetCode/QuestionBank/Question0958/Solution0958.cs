using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0958
{
    public class Solution0958 : Interface0958
    {
        /// <summary>
        /// BFS
        /// 第 k+1 层，如果有 2^k 个节点，那么从左至右所有子节点必须连续
        ///            如果不足 2^k 个节点，那么所有节点不能有子节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsCompleteTree(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt = 1; bool flag; TreeNode node;
            while (queue.Count > 0)
            {
                if (queue.Count == cnt)
                {
                    flag = true;
                    for (int i = queue.Count; i > 0; i--)
                    {
                        node = queue.Dequeue();
                        switch ((flag, node.left))
                        {
                            case (true, null): flag = false; break;
                            case (true, _): queue.Enqueue(node.left); break;
                            case (false, null): break;
                            case (false, _): return false;
                        }
                        switch ((flag, node.right))
                        {
                            case (true, null): flag = false; break;
                            case (true, _): queue.Enqueue(node.right); break;
                            case (false, null): break;
                            case (false, _): return false;
                        }
                    }
                }
                else
                {
                    for (int i = queue.Count; i > 0; i--)
                    {
                        node = queue.Dequeue();
                        if (node.left != null || node.right != null) return false;
                    }
                }
                cnt <<= 1;
            }

            return true;
        }
    }
}

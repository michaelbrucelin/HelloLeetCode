using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1379
{
    public class Solution1379_4_2 : Interface1379
    {
        /// <summary>
        /// BFS
        /// 进阶的解法，先在original树中遍历查找target，记录下其“路径”，然后按照这个“路径”到cloned树中取查找对应的结点
        ///     所谓“路径”，就是从树的根开始，第几层的第几个结点
        /// </summary>
        /// <param name="original"></param>
        /// <param name="cloned"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == target) return cloned;
            int level = 1, id = 0;  // 结果在第level层的第id个位置
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(original);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                level++; id = 0; for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null)
                    {
                        id++; if (node.left == target) goto Found;
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        id++; if (node.right == target) goto Found;
                        queue.Enqueue(node.right);
                    }
                }
            }
            Found:

            queue.Clear(); queue.Enqueue(cloned);
            while (--level > 1)
            {
                cnt = queue.Count; for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            cnt = queue.Count; for (int i = 0; i < cnt; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null && --id == 0) return node.left;
                if (node.right != null && --id == 0) return node.right;
            }

            throw new Exception("logic error!");
        }
    }
}

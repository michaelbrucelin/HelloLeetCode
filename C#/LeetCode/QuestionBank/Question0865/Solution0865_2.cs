using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0865
{
    public class Solution0865_2 : Interface0865
    {
        /// <summary>
        /// 两轮BFS
        /// BFS遍历，记录每个节点的深度与父节点，然后反向查找
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;

            Dictionary<TreeNode, TreeNode> map = new Dictionary<TreeNode, TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; TreeNode item; Queue<TreeNode> level = new Queue<TreeNode>();
            while ((cnt = queue.Count) > 0)
            {
                level.Clear();
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    level.Enqueue(item);
                    if (item.left != null) { queue.Enqueue(item.left); map.Add(item.left, item); }
                    if (item.right != null) { queue.Enqueue(item.right); map.Add(item.right, item); }
                }
            }
            // 自底向上BFS
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            while ((cnt = level.Count) > 1)
            {
                visited.Clear();
                for (int i = 0; i < cnt; i++)
                {
                    item = level.Dequeue();
                    if (!visited.Contains(map[item])) { level.Enqueue(map[item]); visited.Add(map[item]); }
                }
            }

            return level.Dequeue();
        }

        /// <summary>
        /// 逻辑与SubtreeWithAllDeepest()完全相同，少了几次Hash计算
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode SubtreeWithAllDeepest2(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;

            Dictionary<TreeNode, TreeNode> map = new Dictionary<TreeNode, TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; TreeNode item; Queue<TreeNode> level = new Queue<TreeNode>();
            while ((cnt = queue.Count) > 0)
            {
                level.Clear();
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    level.Enqueue(item);
                    if (item.left != null) { queue.Enqueue(item.left); map.Add(item.left, item); }
                    if (item.right != null) { queue.Enqueue(item.right); map.Add(item.right, item); }
                }
            }
            // 自底向上BFS
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            TreeNode father;
            while ((cnt = level.Count) > 1)
            {
                visited.Clear();
                for (int i = 0; i < cnt; i++)
                {
                    item = level.Dequeue();
                    father = map[item];
                    if (!visited.Contains(father)) { level.Enqueue(father); visited.Add(father); }
                }
            }

            return level.Dequeue();
        }
    }
}

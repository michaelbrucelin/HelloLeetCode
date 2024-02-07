using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2641
{
    public class Solution2641 : Interface2641
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            TreeNode dummy = new TreeNode();
            Queue<(TreeNode node, TreeNode pnode)> queue = new Queue<(TreeNode node, TreeNode pnode)>(); queue.Enqueue((root, dummy));
            Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>() { { dummy, root.val } };
            int cnt, level_sum = root.val; (TreeNode node, TreeNode pnode) item;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    item.node.val = level_sum - map[item.pnode];
                    queue.Enqueue(item);
                }

                map.Clear(); level_sum = 0;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    map.Add(item.node, 0);
                    if (item.node.left != null)
                    {
                        map[item.node] += item.node.left.val; level_sum += item.node.left.val;
                        queue.Enqueue((item.node.left, item.node));
                    }
                    if (item.node.right != null)
                    {
                        map[item.node] += item.node.right.val; level_sum += item.node.right.val;
                        queue.Enqueue((item.node.right, item.node));
                    }
                }
            }

            return root;
        }

        /// <summary>
        /// BFS
        /// 逻辑同ReplaceValueInTree()，只是将两次循环合并为一次循环
        /// 这样写字典不能及时释放没用的数据，空间复杂度更大，写着玩的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ReplaceValueInTree2(TreeNode root)
        {
            TreeNode dummy = new TreeNode();
            Queue<(TreeNode node, TreeNode pnode)> queue = new Queue<(TreeNode node, TreeNode pnode)>(); queue.Enqueue((root, dummy));
            Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>() { { dummy, root.val } };
            int cnt, level_sum = root.val, _level_sum; (TreeNode node, TreeNode pnode) item;
            while ((cnt = queue.Count) > 0)
            {
                _level_sum = 0;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    item.node.val = level_sum - map[item.pnode];
                    map.Add(item.node, 0);
                    if (item.node.left != null)
                    {
                        map[item.node] += item.node.left.val; _level_sum += item.node.left.val;
                        queue.Enqueue((item.node.left, item.node));
                    }
                    if (item.node.right != null)
                    {
                        map[item.node] += item.node.right.val; _level_sum += item.node.right.val;
                        queue.Enqueue((item.node.right, item.node));
                    }
                }
                level_sum = _level_sum;
            }

            return root;
        }
    }
}

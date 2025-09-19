using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0113
{
    public class Solution0113_2 : Interface0113
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<(TreeNode, List<int>, int)> queue = new Queue<(TreeNode, List<int>, int)>();
            queue.Enqueue((root, [], 0));
            (TreeNode node, List<int> list, int sum) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                item.list.Add(item.node.val);
                item.sum += item.node.val;
                if (item.node.left == null && item.node.right == null)
                {
                    if (item.sum == targetSum) result.Add(item.list);
                }
                else
                {
                    switch (item.node.left, item.node.right)
                    {
                        case (_, null):
                            queue.Enqueue((item.node.left, item.list, item.sum));
                            break;
                        case (null, _):
                            queue.Enqueue((item.node.right, item.list, item.sum));
                            break;
                        default:
                            queue.Enqueue((item.node.left, [.. item.list], item.sum));
                            queue.Enqueue((item.node.right, item.list, item.sum));
                            break;
                    }
                }
            }

            return result;
        }
    }
}

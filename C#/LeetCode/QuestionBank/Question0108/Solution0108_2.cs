using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0108
{
    public class Solution0108_2 : Interface0108
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 1) return new TreeNode(nums[0]);

            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<(int left, int right)> queue2 = new Queue<(int left, int right)>();
            int left = 0, right = nums.Length - 1;
            int mid = right >> 1;
            TreeNode root = new TreeNode(nums[mid]);
            queue1.Enqueue(root);
            queue2.Enqueue((left, mid - 1)); queue2.Enqueue((mid + 1, right));
            int cnt; while ((cnt = queue1.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue1.Dequeue();
                    var range = queue2.Dequeue();
                    if (range.left <= range.right)
                    {
                        int _mid = range.left + ((range.right - range.left) >> 1);
                        TreeNode _node = new TreeNode(nums[_mid]);
                        node.left = _node;
                        queue1.Enqueue(_node);
                        queue2.Enqueue((range.left, _mid - 1)); queue2.Enqueue((_mid + 1, range.right));
                    }
                    range = queue2.Dequeue();
                    if (range.left <= range.right)
                    {
                        int _mid = range.left + ((range.right - range.left) >> 1);
                        TreeNode _node = new TreeNode(nums[_mid]);
                        node.right = _node;
                        queue1.Enqueue(_node);
                        queue2.Enqueue((range.left, _mid - 1)); queue2.Enqueue((_mid + 1, range.right));
                    }
                }
            }

            return root;
        }
    }
}

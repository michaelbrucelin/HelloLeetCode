using LeetCode.QuestionBank.Question0116;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2415
{
    public class Solution2415_2 : Interface2415
    {
        /// <summary>
        /// BFS
        /// 逻辑与Solution2415一样，改为直接在树上操作
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ReverseOddLevels(TreeNode root)
        {
            if (root == null || root.left == null) return root;

            List<TreeNode> list = new List<TreeNode>() { root };
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            bool isOdd = false; TreeNode node; int cnt, left, right, temp;
            while ((cnt = queue.Count) > 0)
            {
                if (isOdd)
                {
                    left = 0; right = list.Count - 1;
                    while (left < right)
                    {
                        temp = list[left].val; list[left].val = list[right].val; list[right].val = temp;
                        left++; right--;
                    }

                    for (int i = 0; i < cnt; i++)
                    {
                        node = queue.Dequeue();
                        if (node.left != null)
                        {
                            queue.Enqueue(node.left); queue.Enqueue(node.right);
                        }
                    }
                }
                else
                {
                    list.Clear();
                    for (int i = 0; i < cnt; i++)
                    {
                        node = queue.Dequeue();
                        if (node.left != null)
                        {
                            queue.Enqueue(node.left); list.Add(node.left);
                            queue.Enqueue(node.right); list.Add(node.right);
                        }
                    }
                }
                isOdd = !isOdd;
            }

            return root;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2415
{
    public class Solution2415 : Interface2415
    {
        /// <summary>
        /// BFS + 数组操作
        /// 1. BFS将树每个节点的值序列化到数组中
        /// 2. 在数组中反转每一层的值，奇数层的位置在[2^i - 1, 2^(i+1) - 2], i为奇数
        /// 3. BFS将数组中的值反写回树中
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ReverseOddLevels(TreeNode root)
        {
            if (root == null || root.left == null) return root;

            // 树中的值序列化到数组
            List<int> list = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            TreeNode node;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                list.Add(node.val);
                if (node.left != null)
                {
                    queue.Enqueue(node.left); queue.Enqueue(node.right);
                }
            }

            // 在数组中翻转奇数行
            for (int i = 1, left = 0, right = 0, temp = 0; ; i += 2)
            {
                if ((left = (1 << i) - 1) >= list.Count) break;
                right = (1 << (i + 1)) - 2;
                while (left < right)
                {
                    temp = list[left]; list[left] = list[right]; list[right] = temp;
                    left++; right--;
                }
            }

            // 将数组中的值写回树中
            queue.Enqueue(root); int id = 0;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                node.val = list[id++];
                if (node.left != null)
                {
                    queue.Enqueue(node.left); queue.Enqueue(node.right);
                }
            }

            return root;
        }

        /// <summary>
        /// BFS + 数组操作
        /// 与ReverseOddLevels()逻辑一样，只是数组中不在存储树节点的值，而是直接存储树的节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ReverseOddLevels2(TreeNode root)
        {
            if (root == null || root.left == null) return root;

            // 树中的节点序列化到数组
            List<TreeNode> list = new List<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            TreeNode node;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                list.Add(node);
                if (node.left != null)
                {
                    queue.Enqueue(node.left); queue.Enqueue(node.right);
                }
            }

            // 在数组中翻转奇数行
            for (int i = 1, left = 0, right = 0; ; i += 2)
            {
                if ((left = (1 << i) - 1) >= list.Count) break;
                right = (1 << (i + 1)) - 2;
                while (left < right)
                {
                    node = list[left]; list[left] = list[right]; list[right] = node;
                    left++; right--;
                }
            }

            // 利用数组中的节点重构树
            for (int i = 0, j = 0, cnt = list.Count; i < cnt; i++) if ((j = (i << 1) + 1) < cnt)
                {
                    list[i].left = list[j]; list[i].right = list[j + 1];
                }

            return root;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.QuestionBank.Question0653
{
    public class Solution0653 : Interface0653
    {
        /// <summary>
        /// 遍历 + 二叉树查找
        /// 遍历树中的每一个元素i，然后在二叉查找树中查找k-i，O(nlogn)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            return FindTarget(root, root, k);
        }

        private bool FindTarget(TreeNode root, TreeNode node, int k)
        {
            if (node == null) return false;
            if (node.val + node.val != k && BinarySearch(root, k - node.val)) return true;
            if (FindTarget(root, node.left, k) || FindTarget(root, node.right, k)) return true;

            return false;
        }

        private bool BinarySearch(TreeNode root, int target)
        {
            TreeNode ptr = root;
            while (ptr != null)
            {
                if (ptr.val == target) return true;
                ptr = ptr.val < target ? ptr.right : ptr.left;
            }

            return false;
        }
    }
}

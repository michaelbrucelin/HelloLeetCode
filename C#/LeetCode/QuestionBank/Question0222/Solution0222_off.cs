using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0222
{
    public class Solution0222_off : Interface0222
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;

            int level = 0; TreeNode ptr = root;
            while (ptr != null) { level++; ptr = ptr.left; }

            int result = -1, left = 1 << (level - 1), right = (1 << level) - 1, mid, mask = 1 << (level - 2);
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (Exists(root, mask, mid))
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        private bool Exists(TreeNode node, int mask, int x)
        {
            TreeNode ptr = node;
            while (mask > 0)
            {
                if ((x & mask) != 0) ptr = ptr.right; else ptr = ptr.left;
                mask >>= 1;
            }

            return ptr != null;
        }
    }
}

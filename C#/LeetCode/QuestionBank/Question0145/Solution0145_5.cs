using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0145
{
    public class Solution0145_5 : Interface0145
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            TreeNode ptr = root, pre;
            while (ptr != null)
            {
                if (ptr.left == null) ptr = ptr.right;
                else
                {
                    pre = ptr.left; while (pre.right != null && pre.right != ptr) pre = pre.right;
                    if (pre.right == null)
                    {
                        pre.right = ptr; ptr = ptr.left;
                    }
                    else
                    {
                        pre.right = null; AddPath(result, ptr.left); ptr = ptr.right;
                    }
                }
            }
            AddPath(result, root);

            return result;
        }

        private void AddPath(List<int> list, TreeNode node)
        {
            int cnt = 0;
            while (node != null)
            {
                list.Add(node.val); cnt++; node = node.right;
            }

            int left = list.Count - cnt, right = list.Count - 1;
            while (left < right)
            {
                int t = list[left]; list[left] = list[right]; list[right] = t;
                left++; right--;
            }
        }
    }
}

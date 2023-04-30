using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0606
{
    public class Solution0606 : Interface0606
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Tree2str(TreeNode root)
        {
            if (root == null) return string.Empty;
            if (root.left != null && root.right != null)
            {
                return $"{root.val}({Tree2str(root.left)})({Tree2str(root.right)})";
            }
            else if (root.left != null && root.right == null)
            {
                return $"{root.val}({Tree2str(root.left)})";
            }
            else if (root.left == null && root.right != null)
            {
                return $"{root.val}()({Tree2str(root.right)})";
            }
            else  // if (root.left == null && root.right == null)
            {
                return $"{root.val}";
            }
        }
    }
}

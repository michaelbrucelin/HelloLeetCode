﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0144
{
    /// <summary>
    /// 递归
    /// </summary>
    public class Solution0144 : Interface0144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            result.Add(root.val);
            if (root.left != null) result.AddRange(PreorderTraversal(root.left));
            if (root.right != null) result.AddRange(PreorderTraversal(root.right));

            return result;
        }
    }
}

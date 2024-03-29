﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1379
{
    public class Solution1379 : Interface1379
    {
        /// <summary>
        /// DFS
        /// 前序遍历
        /// </summary>
        /// <param name="original"></param>
        /// <param name="cloned"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (cloned == null || cloned.val == target.val) return cloned;
            TreeNode result;
            result = GetTargetCopy(original, cloned.left, target);
            if (result != null) return result;
            result = GetTargetCopy(original, cloned.right, target);
            return result;
        }
    }
}

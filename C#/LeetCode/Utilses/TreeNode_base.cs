using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public class TreeNode_base
    {
        public int val;
        public TreeNode_base left;
        public TreeNode_base right;
        public TreeNode_base(int val = 0, TreeNode_base left = null, TreeNode_base right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

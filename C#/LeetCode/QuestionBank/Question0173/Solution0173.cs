using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0173
{
    public class Solution0173
    {
    }

    /// <summary>
    /// 将树初始化为列表
    /// </summary>
    public class BSTIterator : Interface0173
    {
        public BSTIterator(TreeNode root)
        {
            ptr = 0;
            list = [];
            dfs(root);
        }

        private List<int> list;
        private int ptr;

        public bool HasNext()
        {
            return ptr < list.Count();
        }

        public int Next()
        {
            return list[ptr++];
        }

        private void dfs(TreeNode node)
        {
            if (node == null) return;
            dfs(node.left);
            list.Add(node.val);
            dfs(node.right);
        }
    }
}

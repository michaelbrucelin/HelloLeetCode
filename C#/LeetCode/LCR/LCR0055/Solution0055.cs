using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0055
{
    public class Solution0055
    {
    }

    // 中序遍历出列表，遍历列表
    public class BSTIterator : Interface0055
    {
        public BSTIterator(TreeNode root)
        {
            list = [];
            dfs(root);
            ptr = 0;
            count = list.Count;
        }

        private List<int> list;
        private int count;
        private int ptr;

        public int Next()
        {
            return list[ptr++];
        }

        public bool HasNext()
        {
            return ptr < count;
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

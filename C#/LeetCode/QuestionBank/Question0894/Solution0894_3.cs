using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0894
{
    public class Solution0894_3 : Interface0894
    {
        /// <summary>
        /// 递归 + 记忆化（深拷贝）
        /// 逻辑同Solution0894，添加了记忆化（深拷贝）来优化时间复杂度
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            if ((n & 1) != 1) return new List<TreeNode>();
            if (n == 1) return new List<TreeNode>() { new TreeNode() };
            if (n == 3) return new List<TreeNode>() {
                new TreeNode() { left = new TreeNode(), right = new TreeNode() } };  // 多一层判断，少一层递归，此行可以删除

            List<TreeNode>[] memory = new List<TreeNode>[n + 1];
            memory[1] = new List<TreeNode>() { new TreeNode() };
            memory[3] = new List<TreeNode>() { new TreeNode() { left = new TreeNode(), right = new TreeNode() } };

            dfs(n, memory);

            return memory[n];
        }

        private void dfs(int n, List<TreeNode>[] memory)
        {
            memory[n] = new List<TreeNode>();
            for (int i = 1, j = n - 2; i < n; i += 2, j -= 2)
            {
                if (memory[i] == null) dfs(i, memory);
                if (memory[j] == null) dfs(j, memory);
                foreach (TreeNode lchild in memory[i]) foreach (TreeNode rchild in memory[j])
                    {
                        memory[n].Add(new TreeNode() { left = DeepClone(lchild), right = DeepClone(rchild) });
                    }
            }
        }

        private TreeNode DeepClone(TreeNode node)
        {
            if (node == null) return null;

            TreeNode root = new TreeNode(node.val);
            root.left = DeepClone(node.left);
            root.right = DeepClone(node.right);

            return root;
        }
    }
}

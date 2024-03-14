using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1712
{
    public class Solution1712_3 : Interface1712
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution1712，但是不使用额外的列表记录中序遍历的顺序，在中序遍历的同时直接操作
        /// 
        /// 提交竟然TLE且OLE，参考测试用例01，原则上Solution1712能过，这个也一定可以过的，没想明白是为什么
        /// 可以参考测试用例02，测试用例02是由测试用例01精简而来，少一个节点可以通过
        /// 
        /// 暂时不研究具体原因了
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBiNode(TreeNode root)
        {
            TreeNode dummy = new TreeNode(-1);
            TreeNode parent = dummy;            // parent就相当于Solution1712中list中的最后一项的指针
            dfs(root, ref parent);

            return dummy.right;
        }

        private void dfs(TreeNode node, ref TreeNode parent)
        {
            if (node == null) return;
            dfs(node.left, ref parent);
            parent.left = null; parent.right = node; parent = node;
            dfs(node.right, ref parent);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1379
{
    public class Solution1379_3_2 : Interface1379
    {
        /// <summary>
        /// DFS
        /// 进阶的解法，先在original树中遍历查找target，记录下其“路径”，然后按照这个“路径”到cloned树中取查找对应的结点
        ///     所谓“路径”，就是从树的根开始，每次选择“左”还是“右”
        /// </summary>
        /// <param name="original"></param>
        /// <param name="cloned"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == target) return cloned;
            List<bool> path = dfs(original, target, new List<bool>());  // true表示左孩子，false表示右孩子

            TreeNode ptr = cloned;
            for (int i = 0; i < path.Count; i++) ptr = path[i] ? ptr.left : ptr.right;

            return ptr;
        }

        private List<bool> dfs(TreeNode node, TreeNode target, List<bool> path)
        {
            if (node == null) return null;

            if (node == target) return path;
            List<bool> path_l = new List<bool>(path) { true };
            List<bool> result;
            result = dfs(node.left, target, path_l);
            if (result != null) return result;
            List<bool> path_r = new List<bool>(path) { false };
            result = dfs(node.right, target, path_r);
            return result;
        }
    }
}

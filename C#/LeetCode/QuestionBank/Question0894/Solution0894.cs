using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0894
{
    public class Solution0894 : Interface0894
    {
        /// <summary>
        /// 递归
        /// 1. 真二叉树的节点数一定是奇数，因为除了根节点外，其余节点都是成对出现
        /// 2. 真二叉树的子树也一定是真二叉树
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            if ((n & 1) != 1) return new List<TreeNode>();
            if (n == 1) return new List<TreeNode>() { new TreeNode() };
            if (n == 3) return new List<TreeNode>() {
                new TreeNode() { left = new TreeNode(), right = new TreeNode() } };  // 多一层判断，少一层递归，此行可以删除

            List<TreeNode> result = new List<TreeNode>();
            for (int i = 1, j = n - 2; i < n; i += 2, j -= 2)
            {
                IList<TreeNode> lchilds = AllPossibleFBT(i);
                IList<TreeNode> rchilds = AllPossibleFBT(j);
                foreach (TreeNode lchild in lchilds) foreach (TreeNode rchild in rchilds)
                    {
                        result.Add(new TreeNode() { left = lchild, right = rchild });
                    }
            }

            return result;
        }
    }
}

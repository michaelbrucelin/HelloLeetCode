using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0993
{
    public class Solution0993 : Interface0993
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (x == y || x == root.val || y == root.val) return false;

            var tx = GetLevelAndFather(root, 0, x);
            var ty = GetLevelAndFather(root, 0, y);

            return tx.level == ty.level && tx.father != ty.father;
        }

        private (int level, TreeNode father) GetLevelAndFather(TreeNode root, int level, int x)
        {
            level++;
            (int level, TreeNode father) result = (-1, null);
            if (root.left != null)
            {
                if (root.left.val == x) return (level, root);
                result = GetLevelAndFather(root.left, level, x);
                if (result.father != null) return result;
            }
            if (root.right != null)
            {
                if (root.right.val == x) return (level, root);
                result = GetLevelAndFather(root.right, level, x);
                if (result.father != null) return result;
            }

            return result;
        }
    }
}

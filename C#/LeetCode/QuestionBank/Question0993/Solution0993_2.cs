using LeetCode.QuestionBank.Question0001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0993
{
    public class Solution0993_2 : Interface0993
    {
        /// <summary>
        /// DFS
        /// 同Solution0993，一次DFS找出两个节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (x == y || x == root.val || y == root.val) return false;

            (int level, TreeNode father)[] t = new (int level, TreeNode father)[] { (-1, null), (-1, null) };
            GetLevelAndFather(root, 0, x, y, t);

            return t[0].level == t[1].level && t[0].father != t[1].father;
        }

        private void GetLevelAndFather(TreeNode root, int level, int x, int y, (int level, TreeNode father)[] t)
        {
            level++;

            if (t[0].father != null && t[1].father != null) return;
            if (root.left != null)
            {
                if (root.left.val == x) t[0] = (level, root);
                else if (root.left.val == y) t[1] = (level, root);
                else GetLevelAndFather(root.left, level, x, y, t);
            }
            if (t[0].father != null && t[1].father != null) return;
            if (root.right != null)
            {
                if (root.right.val == x) t[0] = (level, root);
                else if (root.right.val == y) t[1] = (level, root);
                else GetLevelAndFather(root.right, level, x, y, t);
            }
        }
    }
}

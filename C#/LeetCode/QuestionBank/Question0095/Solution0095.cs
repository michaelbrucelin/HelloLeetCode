using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0095
{
    public class Solution0095 : Interface0095
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> GenerateTrees(int n)
        {
            return _GenerateTrees(1, n);

            List<TreeNode> _GenerateTrees(int x, int y)
            {
                if (x > y) return [null];
                if (x == y) return [new TreeNode(x)];

                List<TreeNode> result = [];
                for (int i = x; i <= y; i++)
                {
                    List<TreeNode> ltree = _GenerateTrees(x, i - 1);
                    List<TreeNode> rtree = _GenerateTrees(i + 1, y);
                    foreach (TreeNode lchild in ltree) foreach (TreeNode rchild in rtree)
                        {
                            result.Add(new TreeNode(i, lchild, rchild));
                        }
                }

                return result;
            }
        }
    }
}

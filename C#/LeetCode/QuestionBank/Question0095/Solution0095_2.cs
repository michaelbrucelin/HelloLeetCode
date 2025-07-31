using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0095
{
    public class Solution0095_2 : Interface0095
    {
        /// <summary>
        /// 分治（DFS） + 记忆化
        /// 逻辑同Solution0095，前者是自顶向下分治，有个弊端就是会有大量的重复运算，可以使用记忆化搜索的方式优化
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> GenerateTrees(int n)
        {
            List<TreeNode>[,] memory = new List<TreeNode>[n + 2, n + 2];
            _GenerateTrees(1, n);
            return memory[1, n];

            void _GenerateTrees(int x, int y)
            {
                if (memory[x, y] != null) return;
                if (x > y) { memory[x, y] = [null]; return; }
                if (x == y) { memory[x, y] = [new TreeNode(x)]; return; }

                List<TreeNode> result = [];
                for (int i = x; i <= y; i++)
                {
                    if (memory[x, i - 1] == null) _GenerateTrees(x, i - 1);
                    List<TreeNode> ltree = memory[x, i - 1];
                    if (memory[i + 1, y] == null) _GenerateTrees(i + 1, y);
                    List<TreeNode> rtree = memory[i + 1, y];
                    foreach (TreeNode lchild in ltree) foreach (TreeNode rchild in rtree)
                        {
                            result.Add(new TreeNode(i, lchild, rchild));
                        }
                }
                memory[x, y] = result;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0095
{
    public class Solution0095_3 : Interface0095
    {
        /// <summary>
        /// DP
        /// 逻辑完全同Solution0095_2，改为自底向上的DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> GenerateTrees(int n)
        {
            List<TreeNode>[,] memory = new List<TreeNode>[n + 2, n + 2];
            for (int i = 1; i < n + 2; i++) for (int j = 0; j < i; j++) memory[i, j] = [null];
            for (int k = 0; k < n; k++) for (int l = 1, r = l + k; r <= n; l++, r++)
                {
                    List<TreeNode> item = [];
                    for (int i = l; i <= r; i++)
                    {
                        foreach (TreeNode lchild in memory[l, i - 1]) foreach (TreeNode rchild in memory[i + 1, r])
                            {
                                item.Add(new TreeNode(i, lchild, rchild));
                            }
                    }
                    memory[l, r] = item;
                }

            return memory[1, n];
        }
    }
}

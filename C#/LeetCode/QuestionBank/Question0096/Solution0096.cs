using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0096
{
    public class Solution0096 : Interface0096
    {
        /// <summary>
        /// 分治，递归
        /// n = 0，1
        /// n = 1，1
        /// n = 2，2
        ///     1 为根，左子树0个节点 1，右子树1个节点 1，共 1
        ///     2 为根，左子树1个节点 1，右子树0个节点 1，共 1
        /// n = 3，4
        ///     1 为根，左子树0个节点 1，右子树2个节点 2，共 2
        ///     2 为根，左子树1个节点 1，右子树1个节点 1，共 1
        ///     3 为根，左子树2个节点 2，右子树0个节点 1，共 2
        /// 
        /// 测试，TLE
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTrees(int n)
        {
            if (n < 2) return 1;

            int result = 0;
            for (int i = 1; i <= n; i++) result += NumTrees(i - 1) * NumTrees(n - i);

            return result;
        }
    }
}

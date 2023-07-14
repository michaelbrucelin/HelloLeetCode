using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0979
{
    public class Solution0979 : Interface0979
    {
        /// <summary>
        /// 策略
        /// 1. 找出所有叶子节点到主节点的路径
        ///         A      A B D
        ///        / \     A B E
        ///       B   C    A C F
        ///      / \ / \   A C G
        ///     D  E F  G
        /// 2. 倒序遍历每条路径
        ///     如果一个节点的值大于0，优先将值向值为0的后代节点中转移，再想值为0的父结点中转移，最后把余下的全部放在根节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DistributeCoins(TreeNode root)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0894
{
    public class Solution0894_2 : Interface0894
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0894，只是将递归1:1翻译为迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            if ((n & 1) != 1) return new List<TreeNode>();
            if (n == 1) return new List<TreeNode>() { new TreeNode() };
            if (n == 3) return new List<TreeNode>() {
                new TreeNode() { left = new TreeNode(), right = new TreeNode() } };  // 多一层判断，少一层迭代，此行可以删除

            List<TreeNode> result = new List<TreeNode>();
            Stack<(int cnt, List<TreeNode> node, List<TreeNode> lsub, List<TreeNode> rsub)> stack
                = new Stack<(int cnt, List<TreeNode> node, List<TreeNode> lsub, List<TreeNode> rsub)>();
            stack.Push((n, new List<TreeNode>(), null, null));
            (int cnt, List<TreeNode> node, List<TreeNode> lsub, List<TreeNode> rsub) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.lsub != null)  // <==> if (item.lsub != null && item.rsub != null)
                {
                    List<TreeNode> _node = item.cnt != n ? item.node : result;
                    foreach (TreeNode lchild in item.lsub) foreach (TreeNode rchild in item.rsub)
                        {
                            _node.Add(new TreeNode() { left = lchild, right = rchild });
                        }
                }
                else                    // <==> if (item.lsub == null && item.rsub == null)
                {
                    if (item.cnt == 1) item.node.Add(new TreeNode());
                    else for (int i = 1, j = item.cnt - 2; i < item.cnt; i += 2, j -= 2)
                        {
                            List<TreeNode> lsub = new List<TreeNode>();
                            List<TreeNode> rsub = new List<TreeNode>();
                            stack.Push((item.cnt, item.node, lsub, rsub));
                            stack.Push((i, lsub, null, null)); stack.Push((j, rsub, null, null));
                        }
                }
            }

            return result;
        }
    }
}

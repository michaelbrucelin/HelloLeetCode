using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0145
{
    public class Solution0145 : Interface0145
    {
        /// <summary>
        /// BFS
        /// BFS，验证每一层是否回文
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool CheckSymmetricTree(TreeNode root)
        {
            if (root == null) return true;
            List<TreeNode> list = new List<TreeNode>(), _list;
            list.Add(root.left); list.Add(root.right);
            int cnt, pl, pr;
            while ((cnt = list.Count) > 0)
            {
                if ((cnt & 1) != 0) return false;
                pl = -1; pr = cnt; while (++pl < --pr)
                {
                    if (list[pl] == null && list[pr] == null) continue;
                    if (list[pl] == null || list[pr] == null || list[pl].val != list[pr].val) return false;
                }

                _list = new List<TreeNode>();
                pl = -1; while (++pl < cnt) if (list[pl] != null)
                    {
                        _list.Add(list[pl].left); _list.Add(list[pl].right);
                    }
                list = _list;
            }

            return true;
        }
    }
}

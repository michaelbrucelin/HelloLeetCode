using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1123
{
    public class Solution1123 : Interface1123
    {
        /// <summary>
        /// BFS + Hash
        /// 1. BFS找出最深的叶子节点，并用hash表记录每个节点的父结点
        /// 2. 从最深的叶子节点向上找公共的父结点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            Dictionary<TreeNode, TreeNode> map = new Dictionary<TreeNode, TreeNode>() { { root, root } };
            List<TreeNode> list = new List<TreeNode>() { root }, _list = new List<TreeNode>();
            while (true)
            {
                _list.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].left != null) { _list.Add(list[i].left); map.Add(list[i].left, list[i]); }
                    if (list[i].right != null) { _list.Add(list[i].right); map.Add(list[i].right, list[i]); }
                }
                if (_list.Count > 0) { list.Clear(); list.AddRange(_list); } else break;
            }
            if (list.Count == 1) return list[0];

            HashSet<TreeNode> set = new HashSet<TreeNode>();
            while (set.Count != 1)
            {
                set.Clear();
                for (int i = 0; i < list.Count; i++) set.Add(map[list[i]]);
                if (set.Count > 1) { list.Clear(); list.AddRange(set); } else break;
            }

            return set.First();
        }
    }
}

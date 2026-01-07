using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public static class UtilsBuilder
    {
        /// <summary>
        /// [1,null,2,3,4,null,null,5,6]
        ///     1
        ///      \
        ///       2
        ///      / \
        ///     3   4
        ///        / \
        ///       5   6
        /// 方法有逻辑错误，但是没找出来，反例见Test1339.05
        /// </summary>
        /// <returns></returns>
        public static TreeNode TreeBuilder(string input)
        {
            int?[] _nodes = input[1..^1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => x.Replace(" ", "").ToLower())
                                        .Select(x => (int?)(x != "null" ? int.Parse(x) : null))
                                        .ToArray();
            if (_nodes[0] == null) return null;

            int p1 = 0, p2 = 1, n = _nodes.Length;
            TreeNode[] nodes = new TreeNode[n];
            for (int i = 0; i < n; i++) if (_nodes[i] != null) nodes[i] = new TreeNode(_nodes[i].Value);
            while (p2 < n)
            {
                while (nodes[p1] == null) p1++;
                if (nodes[p2] != null) nodes[p1].left = nodes[p2];
                if (++p2 >= n) break;
                if (nodes[p2] != null) nodes[p1].right = nodes[p2];
                ++p2;
                ++p1;
            }

            return nodes[0];
        }
    }
}

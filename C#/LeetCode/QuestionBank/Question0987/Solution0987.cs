using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0987
{
    public class Solution0987 : Interface0987
    {
        /// <summary>
        /// DFS，前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            SortedDictionary<int, List<(int val, int rid)>> map = new SortedDictionary<int, List<(int val, int rid)>>();
            dfs(root, 0, 0, map);

            IList<IList<int>> result = new List<IList<int>>();
            foreach (List<(int val, int rid)> list in map.Values)
                result.Add(list.OrderBy(t => t.rid).ThenBy(t => t.val).Select(t => t.val).ToArray());
            return result;
        }

        private void dfs(TreeNode root, int rid, int cid, SortedDictionary<int, List<(int val, int rid)>> map)
        {
            if (!map.ContainsKey(cid)) map.Add(cid, new List<(int val, int rid)>());
            map[cid].Add((root.val, rid));
            if (root.left != null) dfs(root.left, rid + 1, cid - 1, map);
            if (root.right != null) dfs(root.right, rid + 1, cid + 1, map);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0987
{
    public class Solution0987_2 : Interface0987
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            SortedDictionary<int, List<(int val, int rid)>> map = new SortedDictionary<int, List<(int val, int rid)>>();
            Queue<(TreeNode node, int rid, int cid)> queue = new Queue<(TreeNode node, int rid, int cid)>();
            queue.Enqueue((root, 0, 0));
            (TreeNode node, int rid, int cid) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                map.TryAdd(item.cid, new List<(int val, int rid)>());
                map[item.cid].Add((item.node.val, item.rid));
                if (item.node.left != null) queue.Enqueue((item.node.left, item.rid + 1, item.cid - 1));
                if (item.node.right != null) queue.Enqueue((item.node.right, item.rid + 1, item.cid + 1));
            }

            IList<IList<int>> result = new List<IList<int>>();
            foreach (List<(int val, int rid)> list in map.Values)
                result.Add(list.OrderBy(t => t.rid).ThenBy(t => t.val).Select(t => t.val).ToArray());
            return result;
        }

        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalTraversal2(TreeNode root)
        {
            SortedDictionary<int, List<(int val, int rid)>> map = new SortedDictionary<int, List<(int val, int rid)>>();
            Queue<(TreeNode node, int cid)> queue = new Queue<(TreeNode node, int cid)>();
            queue.Enqueue((root, 0));
            int rid = 0, cnt; (TreeNode node, int cid) item;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    map.TryAdd(item.cid, new List<(int val, int rid)>());
                    map[item.cid].Add((item.node.val, rid));
                    if (item.node.left != null) queue.Enqueue((item.node.left, item.cid - 1));
                    if (item.node.right != null) queue.Enqueue((item.node.right, item.cid + 1));
                }
                rid++;
            }

            IList<IList<int>> result = new List<IList<int>>();
            foreach (List<(int val, int rid)> list in map.Values)
                result.Add(list.OrderBy(t => t.rid).ThenBy(t => t.val).Select(t => t.val).ToArray());
            return result;
        }
    }
}

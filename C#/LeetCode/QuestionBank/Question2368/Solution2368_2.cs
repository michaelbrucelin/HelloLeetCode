using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2368
{
    public class Solution2368_2 : Interface2368
    {
        /// <summary>
        /// DFS
        /// 逻辑与Solution2368完全相同，只是将递归1:1翻译为显示的栈迭代
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="restricted"></param>
        /// <returns></returns>
        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            HashSet<int> set = new HashSet<int>(restricted);
            if (set.Contains(0)) return 0;

            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            int result = 0;
            Stack<(int id, int pre)> stack = new Stack<(int id, int pre)>();
            stack.Push((0, -1)); (int id, int pre) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (set.Contains(item.id)) continue;
                result++;
                foreach (int _id in tree[item.id]) if (_id != item.pre) stack.Push((_id, item.id));
            }

            return result;
        }
    }
}

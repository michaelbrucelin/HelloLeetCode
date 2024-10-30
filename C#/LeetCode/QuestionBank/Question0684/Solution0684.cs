using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0684
{
    public class Solution0684 : Interface0684
    {
        /// <summary>
        /// 分析
        /// 树增了加一条边后，必然产生一个环，删除环中任意一条边即可，所以解此题就是在找环
        /// 任选一个节点作为根，BFS，当出现同一层两节点相连，即找到了环的相交的点
        ///         / \      / \
        ///         | |  或  | |  两种可能
        ///         \ /      |_|
        /// 然后从环相交的点再来一次BFS，即可找出环全部的点
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            List<int>[] tree = new List<int>[n + 1];
            for (int i = 1; i <= n; i++) tree[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            bool[] mask = new bool[n + 1];
            HashSet<int> queue = new HashSet<int>(),_queue= new HashSet<int>();

            throw new NotImplementedException();
        }
    }
}

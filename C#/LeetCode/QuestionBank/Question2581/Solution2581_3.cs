using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2581
{
    public class Solution2581_3 : Interface2581
    {
        /// <summary>
        /// 逻辑完全与Solution2581_2相同，只是将其中的BFS换为了DFS
        /// 
        /// 逻辑没有问题，但是递归超出了CLR默认的递归层数，参考测试用例04
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="guesses"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int RootCount(int[][] edges, int[][] guesses, int k)
        {
            int n = edges.Length + 1;
            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }
            HashSet<int>[] guess = new HashSet<int>[n];
            for (int i = 0; i < n; i++) guess[i] = new HashSet<int>();
            foreach (var edge in guesses)
            {
                guess[edge[0]].Add(edge[1]);
            }

            int result, cnt0 = RootCount(tree, -1, 0, guess);
            result = cnt0 >= k ? 1 : 0;
            foreach (int child in tree[0]) result += RootCountDFS(tree, 0, child, cnt0, guess, k);

            return result;
        }

        private int RootCountDFS(List<int>[] tree, int parent, int child, int cnt, HashSet<int>[] guess, int k)
        {
            int result, _cnt;
            _cnt = cnt + ((guess[parent].Contains(child), guess[child].Contains(parent)) switch
            {
                (true, true) => 0,
                (true, false) => -1,
                (false, true) => 1,
                (false, false) => 0
            });
            result = _cnt >= k ? 1 : 0;

            foreach (int _child in tree[child]) if (_child != parent)
                {
                    result += RootCountDFS(tree, child, _child, _cnt, guess, k);
                }

            return result;
        }

        /// <summary>
        /// 计算以root为根，guess猜对的结果数量
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        private int RootCount(List<int>[] tree, int parent, int child, HashSet<int>[] guess)
        {
            int result = 0;
            foreach (int _child in tree[child]) if (_child != parent)
                {
                    result += guess[child].Contains(_child) ? 1 : 0;
                    result += RootCount(tree, child, _child, guess);
                }

            return result;
        }
    }
}

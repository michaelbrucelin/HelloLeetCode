using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2581
{
    public class Solution2581_3_2 : Interface2581
    {
        /// <summary>
        /// 逻辑完全与Solution2581_3相同，只是将递归 1:1 改为显式的栈迭代，来避免超出了CLR默认的递归层数
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
            int result = 0;
            Stack<(int parent, int child, int cnt)> stack = new Stack<(int parent, int child, int cnt)>();
            stack.Push((parent, child, cnt));
            (int parent, int child, int cnt) item; int _cnt;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                _cnt = item.cnt + ((guess[item.parent].Contains(item.child), guess[item.child].Contains(item.parent)) switch
                {
                    (true, true) => 0,
                    (true, false) => -1,
                    (false, true) => 1,
                    (false, false) => 0
                });
                result += _cnt >= k ? 1 : 0;

                foreach (int _child in tree[item.child]) if (_child != item.parent)
                    {
                        stack.Push((item.child, _child, _cnt));
                    }
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
            Stack<(int parent, int child)> stack = new Stack<(int parent, int child)>();
            stack.Push((parent, child));
            (int parent, int child) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                foreach (int _child in tree[item.child]) if (_child != item.parent)
                    {
                        result += guess[item.child].Contains(_child) ? 1 : 0;
                        stack.Push((item.child, _child));
                    }
            }

            return result;
        }
    }
}

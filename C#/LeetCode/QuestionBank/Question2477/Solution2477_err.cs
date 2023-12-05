using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2477
{
    public class Solution2477_err : Interface2477
    {
        /// <summary>
        /// 模拟，dfs
        /// dfs找出根节点到每个叶子节点的路径（栈），然后就可以模拟计算出这条路径上的“耗油量”
        ///     也可以直接将无向图改为有向图，这样就不需要dfs全部路径了，空间复杂度更优
        /// 所有叶子节点到达根节点，就一定覆盖了所有节点
        /// 
        /// 思路是错误的，忽略了可以半路换车，参考测试用例04
        /// </summary>
        /// <param name="roads"></param>
        /// <param name="seats"></param>
        /// <returns></returns>
        public long MinimumFuelCost(int[][] roads, int seats)
        {
            if (roads.Length == 0) return 0;
            if (roads.Length == 1) return 1;

            // 构造图/树
            int n = roads.Length + 1;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                graph[roads[i][0]].Add(roads[i][1]); graph[roads[i][1]].Add(roads[i][0]);
            }

            // 找出所有路径
            List<Stack<int>> paths = new List<Stack<int>>();
            for (int i = 0; i < graph[0].Count; i++) GetPaths(graph, 0, graph[0][i], new Stack<int>(), paths);

            // 模拟从叶子节点向根前进，只有一个相邻节点（非0）的节点是叶子节点
            long result = 0;
            int ptr, _seats, _cars;
            bool[] visited = new bool[n];
            Stack<int> stack;
            for (int i = 0; i < paths.Count; i++)
            {
                stack = paths[i]; _seats = seats; _cars = 1;
                while (stack.Count > 0)
                {
                    ptr = stack.Pop();
                    if (!visited[ptr])
                    {
                        visited[ptr] = true;
                        if (--_seats < 0) { _cars++; _seats = seats - 1; }
                    }
                    result += _cars;
                }
            }

            return result;
        }

        private void GetPaths(List<int>[] graph, int last, int curr, Stack<int> path, List<Stack<int>> paths)
        {
            path.Push(curr);
            if (graph[curr].Count == 1)
            {
                paths.Add(path);
            }
            else
            {
                for (int i = 0; i < graph[curr].Count; i++) if (graph[curr][i] != last)
                    {
                        GetPaths(graph, curr, graph[curr][i], new Stack<int>(path.Reverse()), paths);
                    }
            }
        }
    }
}

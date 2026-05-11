using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0401
{
    public class Solution0401 : Interface0401
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindWhetherExistsPath(int n, int[][] graph, int start, int target)
        {
            if (start == target) return true;

            HashSet<int>[] paths = new HashSet<int>[n];
            for (int i = 0; i < n; i++) paths[i] = [];
            foreach (int[] path in graph) paths[path[0]].Add(path[1]);
            bool[] visited = new bool[n];

            return dfs(start);

            bool dfs(int x)
            {
                if (x == target || paths[x].Contains(target)) return true;
                if (visited[x]) return false;
                visited[x] = true;

                foreach (int _x in paths[x]) if (dfs(_x)) return true;
                return false;
            }
        }
    }
}

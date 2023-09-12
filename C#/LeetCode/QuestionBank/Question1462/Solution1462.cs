using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1462
{
    public class Solution1462 : Interface1462
    {
        /// <summary>
        /// 预处理
        /// 1. 题目限定有向图中没有环，那么把途中任意顶点看作根的话，都有一颗树
        /// 2. 对于图中的每一颗树，树中的每一个节点都是所有孩子节点的祖先，即先修课程
        ///     问题就变成了预处理树中每个节点的全部后代节点了
        /// 3. 使用visited数组做记录，如果一个顶点已经被处理过了，那么就不需要二次处理了
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            List<int>[] grpah = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++) grpah[i] = new List<int>();
            foreach (var arr in prerequisites) grpah[arr[0]].Add(arr[1]);
            bool[,] map = new bool[numCourses, numCourses];
            bool[] visited = new bool[numCourses];
            for (int i = 0; i < numCourses; i++) dfs(grpah, map, numCourses, visited, i);

            int len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0; i < len; i++) result[i] = map[queries[i][0], queries[i][1]];

            return result;
        }

        private void dfs(List<int>[] grpah, bool[,] map, int len, bool[] visited, int vid)
        {
            if (visited[vid]) return;
            foreach (int _vid in grpah[vid])
            {
                map[vid, _vid] = true;
                dfs(grpah, map, len, visited, _vid);
                for (int i = 0; i < len; i++) if (map[_vid, i]) map[vid, i] = true;
            }

            visited[vid] = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1462
{
    public class Solution1462_3 : Interface1462
    {
        /// <summary>
        /// 同Solution1462，但是不一次性全部预处理，只有在查询时才预处理，但是只会预处理依次，类记忆化搜索
        /// 这样对图很大，但是查询较少的场景运行更快
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

            int len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0; i < len; i++)
            {
                if (!visited[queries[i][0]]) dfs(grpah, map, numCourses, visited, queries[i][0]);
                result[i] = map[queries[i][0], queries[i][1]];
            }

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

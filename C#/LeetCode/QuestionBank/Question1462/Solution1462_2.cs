using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1462
{
    public class Solution1462_2 : Interface1462
    {
        /// <summary>
        /// 同Solution1462，只是将预处理的结果集由二维数组，改为了字典，这样对稀疏图更好一些
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
            HashSet<int>[] map = new HashSet<int>[numCourses];
            for (int i = 0; i < numCourses; i++) map[i] = new HashSet<int>();
            bool[] visited = new bool[numCourses];
            for (int i = 0; i < numCourses; i++) dfs(grpah, map, numCourses, visited, i);

            int len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0; i < len; i++) result[i] = map[queries[i][0]].Contains(queries[i][1]);

            return result;
        }

        private void dfs(List<int>[] grpah, HashSet<int>[] map, int len, bool[] visited, int vid)
        {
            if (visited[vid]) return;
            foreach (int _vid in grpah[vid])
            {
                map[vid].Add(_vid);
                dfs(grpah, map, len, visited, _vid);
                map[vid].UnionWith(map[_vid]);
            }

            visited[vid] = true;
        }
    }
}

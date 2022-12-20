using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1971
{
    public class Solution1971_2 : Interface1971
    {
        /// <summary>
        /// DFS
        /// 提交会内存溢出，参考测试用例4
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;

            Dictionary<int, HashSet<int>> emap = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                int a = edges[i][0], b = edges[i][1];
                if (emap.ContainsKey(a)) emap[a].Add(b); else emap[a] = new HashSet<int>() { b };
                if (emap.ContainsKey(b)) emap[b].Add(a); else emap[b] = new HashSet<int>() { a };
            }

            return dfs(source, destination, emap);
        }

        private bool dfs(int source, int destination, Dictionary<int, HashSet<int>> emap)
        {
            if (!emap.ContainsKey(source)) return false;
            HashSet<int> dests = emap[source];
            foreach (int _destination in dests)
            {
                if (_destination == destination) return true;
                Dictionary<int, HashSet<int>> _emap = new Dictionary<int, HashSet<int>>(emap);
                foreach (HashSet<int> item in _emap.Values) item.Remove(source);
                if (dfs(_destination, destination, _emap)) return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1971
{
    public class Solution1971 : Interface1971
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;

            HashSet<int> mask = new HashSet<int>();
            Dictionary<int, List<int>> emap = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                int a = edges[i][0], b = edges[i][1];
                if (emap.ContainsKey(a)) emap[a].Add(b); else emap[a] = new List<int>() { b };
                if (emap.ContainsKey(b)) emap[b].Add(a); else emap[b] = new List<int>() { a };
            }

            Queue<int> queue = new Queue<int>(); queue.Enqueue(source);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int _source = queue.Dequeue();
                    if (!emap.ContainsKey(_source)) continue;
                    for (int j = 0; j < emap[_source].Count; j++)
                    {
                        int _destination = emap[_source][j];
                        if (_destination == destination) return true;
                        if (!mask.Contains(_destination))
                        {
                            mask.Add(_destination);
                            queue.Enqueue(_destination);
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 与上面完全一致，但是将HashMap与Dictionary合成数组试一下
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool ValidPath2(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;

            bool[] mask = new bool[n];
            List<int>[] emap = new List<int>[n];
            for (int i = 0; i < n; i++) emap[i] = new List<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                emap[edges[i][0]].Add(edges[i][1]);
                emap[edges[i][1]].Add(edges[i][0]);
            }

            Queue<int> queue = new Queue<int>(); queue.Enqueue(source);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int _source = queue.Dequeue();
                    for (int j = 0; j < emap[_source].Count; j++)
                    {
                        int _destination = emap[_source][j];
                        if (_destination == destination) return true;
                        if (!mask[_destination])
                        {
                            mask[_destination] = true;
                            queue.Enqueue(_destination);
                        }
                    }
                }
            }

            return false;
        }
    }
}

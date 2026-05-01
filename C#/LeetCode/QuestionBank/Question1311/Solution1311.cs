using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1311
{
    public class Solution1311 : Interface1311
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="watchedVideos"></param>
        /// <param name="friends"></param>
        /// <param name="id"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            int n = friends.Length;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id); visited[id] = true;
            int cnt, x;
            while (level-- > 0 && (cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    x = queue.Dequeue();
                    foreach (int y in friends[x]) if (!visited[y])
                        {
                            queue.Enqueue(y); visited[y] = true;
                        }
                }
            }

            Dictionary<string, int> freq = new Dictionary<string, int>();
            while (queue.Count > 0)
            {
                x = queue.Dequeue();
                foreach (string vedio in watchedVideos[x])
                {
                    freq.TryAdd(vedio, 0); freq[vedio]++;
                }
            }
            List<(int, string)> list = new List<(int, string)>();
            foreach (string vedio in freq.Keys) list.Add((freq[vedio], vedio));
            list.Sort((x, y) => x.Item1 != y.Item1 ? x.Item1 - y.Item1 : string.CompareOrdinal(x.Item2, y.Item2));

            IList<string> result = new List<string>();
            foreach (var item in list) result.Add(item.Item2);
            return result;
        }
    }
}

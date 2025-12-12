using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3433
{
    public class Solution3433 : Interface3433
    {
        /// <summary>
        /// 模拟
        /// 可以考虑使用差分数组优化，对用户总数很大而离线用户较少的情况优化明显，这里先不写了
        /// </summary>
        /// <param name="numberOfUsers"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
        {
            int[] result = new int[numberOfUsers];
            events = [.. events.OrderBy(x => int.Parse(x[1])).ThenByDescending(x => x[0][0])];
            Dictionary<int, int> offline = new Dictionary<int, int>();
            int ts, id, all_cnt = 0;
            string[] ids;
            foreach (IList<string> e in events)
            {
                ts = int.Parse(e[1]);
                if (e[0][0] == 'O')
                {
                    id = int.Parse(e[2]);
                    if (offline.ContainsKey(id)) offline[id] = ts + 60; else offline.Add(id, ts + 60);
                }
                else
                {
                    switch (e[2])
                    {
                        case "ALL": all_cnt++; break;
                        case "HERE":
                            foreach (int key in offline.Keys) if (offline[key] <= ts) offline.Remove(key);
                            if (offline.Count == 0) all_cnt++;
                            else
                            {
                                for (int i = 0; i < numberOfUsers; i++) if (!offline.ContainsKey(i)) result[i]++;
                            }
                            break;
                        default:
                            ids = e[2].Split(' ');
                            foreach (string _id in ids) result[int.Parse(_id[2..])]++;
                            break;
                    }
                }
            }
            for (int i = 0; i < numberOfUsers; i++) result[i] += all_cnt;

            return result;
        }
    }
}

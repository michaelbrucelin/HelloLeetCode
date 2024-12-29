using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1366
{
    public class Solution1366 : Interface1366
    {
        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <param name="votes"></param>
        /// <returns></returns>
        public string RankTeams(string[] votes)
        {
            if (votes.Length == 1 || votes[0].Length == 1) return votes[0];

            int cnt = votes[0].Length;
            int[,] dist = new int[26, cnt];
            foreach (string vote in votes) for (int i = 0; i < cnt; i++) dist[vote[i] - 'A', i]++;

            Comparer<char> comparer = Comparer<char>.Create((c1, c2) =>
            {
                for (int i = 0; i < cnt; i++) if (dist[c1 - 'A', i] != dist[c2 - 'A', i]) return dist[c2 - 'A', i] - dist[c1 - 'A', i];
                return c1 - c2;
            });

            char[] teams = votes[0].ToCharArray();
            Array.Sort(teams, comparer);

            return new string(teams);
        }
    }
}

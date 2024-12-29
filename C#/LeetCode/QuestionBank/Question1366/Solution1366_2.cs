using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1366
{
    public class Solution1366_2 : Interface1366
    {
        /// <summary>
        /// 自定义排序
        /// 玩点花活，可以将每支队伍的得票情况映射为一个数字，但是26支队伍，1000个人投票，需要长度为26的1000进制数值来表示，这里使用Unicode来操作
        /// </summary>
        /// <param name="votes"></param>
        /// <returns></returns>
        public string RankTeams(string[] votes)
        {
            if (votes.Length == 1 || votes[0].Length == 1) return votes[0];

            int cnt = votes[0].Length;
            int[,] dist = new int[26, cnt];
            foreach (string vote in votes) for (int i = 0; i < cnt; i++) dist[vote[i] - 'A', i]++;
            string[] weight = new string[26];
            char[] buffer = new char[cnt + 1];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < cnt; j++) buffer[j] = (char)(dist[i, j] + 19968);
                buffer[cnt] = (char)(26 - i + 19968);
                weight[i] = new string(buffer);
            }

            Comparer<char> comparer = Comparer<char>.Create((c1, c2) => string.CompareOrdinal(weight[c2 - 'A'], weight[c1 - 'A']));
            char[] teams = votes[0].ToCharArray();
            Array.Sort(teams, comparer);

            return new string(teams);
        }
    }
}

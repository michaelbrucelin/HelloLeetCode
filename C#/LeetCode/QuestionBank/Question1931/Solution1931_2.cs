using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1931
{
    public class Solution1931_2 : Interface1931
    {
        /// <summary>
        /// DP
        /// 逻辑与Solution1931完全相同，只是将状态（0，1，2组成的字符串）改成了3进制整型
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ColorTheGrid(int m, int n)
        {
            long result;
            const int MOD = (int)1e9 + 7;
            if (n < m) (m, n) = (n, m);
            if (m == 1)
            {
                result = 3;
                for (int i = 1; i < n; i++) result = (result << 1) % MOD;
                return (int)result;
            }
            if (m == 2)
            {
                result = 6;
                for (int i = 1; i < n; i++) result = result * 3 % MOD;
                return (int)result;
            }

            // 第一列的所有可能性
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); queue.Enqueue(1); queue.Enqueue(2);
            int item;
            for (int i = 1, cnt; i < m; i++)
            {
                cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    item = queue.Dequeue();
                    int c = item % 3;
                    queue.Enqueue(item * 3 + (c + 1) % 3);
                    queue.Enqueue(item * 3 + (c + 2) % 3);
                }
            }
            // 每一列对应下一列的所有可能性
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            while (queue.Count > 0) map.Add(item = queue.Dequeue(), NextColumn(item));

            // DP
            Dictionary<string, long> curr = [], next = [];
            foreach (string key in map.Keys) curr.Add(key, 1);
            for (int i = 1; i < n; i++)
            {
                next = [];
                foreach (var kv in curr) foreach (string key in map[kv.Key])
                    {
                        if (!next.ContainsKey(key)) next.Add(key, 0);
                        next[key] = next[key] + kv.Value;
                    }
                curr = next;
                foreach (string key in curr.Keys) curr[key] %= MOD;
            }

            result = 0;
            foreach (long cnt in curr.Values) result += cnt;
            return (int)(result % MOD);

            List<string> NextColumn(string curr)
            {
                Queue<string> queue = new Queue<string>();
                int c = curr[0] - '0';
                queue.Enqueue($"{(char)('0' + (c + 1) % 3)}");
                queue.Enqueue($"{(char)('0' + (c + 2) % 3)}");
                string item;
                for (int i = 1, cnt; i < curr.Length; i++)
                {
                    cnt = queue.Count;
                    for (int j = 0; j < cnt; j++)
                    {
                        item = queue.Dequeue();
                        if (item[^1] != curr[i])
                        {
                            queue.Enqueue($"{item}{(char)('0' + 3 - (item[^1] - '0') - (curr[i] - '0'))}");
                        }
                        else
                        {
                            c = item[^1] - '0';
                            queue.Enqueue($"{item}{(char)('0' + (c + 1) % 3)}");
                            queue.Enqueue($"{item}{(char)('0' + (c + 2) % 3)}");
                        }
                    }
                }

                return queue.ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1931
{
    public class Solution1931 : Interface1931
    {
        /// <summary>
        /// DP
        /// 1. 如果m=1，则结果为3*2^(n-1)
        /// 2. 如果m=2，则结果为6*3^(n-1)
        /// 3. 如果m>2，先计算出如果n=1一共有多少种可能，然后回溯每一种可能对应的下一次的可能性，然后DP就可以了
        ///    例如m=3，那么第一列有GB中可能：R  R  R  R  G  G  G  G  B  B  B  B
        ///                                   G  G  B  B  R  R  B  B  R  R  G  G
        ///                                   R  B  R  G  G  B  R  G  G  B  R  B
        ///    对于每一种可能，下一列的可能性都是固定的，所以记录第n列的所有可能性，就可以推出第n+1列的所有可能性
        /// 技巧：这里用0 1 2表示R G B，这样做有两点好处，方便计算
        /// 1. (x+1)%3 与 (x+2)%3 就是与自身不同的另外两种颜色
        /// 2. 3-x-y,x != y 就是与 x 和 y 不相同的另外一种颜色
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
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("0"); queue.Enqueue("1"); queue.Enqueue("2");
            string item;
            for (int i = 1, cnt; i < m; i++)
            {
                cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    item = queue.Dequeue();
                    int c = item[^1] - '0';
                    queue.Enqueue($"{item}{(char)('0' + (c + 1) % 3)}");
                    queue.Enqueue($"{item}{(char)('0' + (c + 2) % 3)}");
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

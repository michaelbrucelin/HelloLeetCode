using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0514
{
    public class Solution0514_3_2 : Interface0514
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution0514_3，DP的过程中只计算需要的状态，而不是计算全部状态
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int FindRotateSteps(string ring, string key)
        {
            int len = ring.Length;
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = new List<int>();
            for (int i = 0; i < len; i++) dist[ring[i] - 'a'].Add(i);

            int[] dp = new int[len], _dp = new int[len];
            for (int i = key.Length - 1, _step; i > 0; i--)
            {
                Array.Fill(_dp, 5000);  // 题目的数据范围，结果不会大于5000
                foreach (int sid in dist[key[i - 1] - 'a']) foreach (int did in dist[key[i] - 'a'])
                    {
                        _step = (did - sid) switch { > 0 => Math.Min(did - sid, len - did + sid), < 0 => Math.Min(sid - did, len - sid + did), _ => 0 };
                        _dp[sid] = Math.Min(_dp[sid], _step + 1 + dp[did]);
                    }
                Array.Copy(_dp, dp, len);
            }

            int result = 5000, step;    // 题目的数据范围，结果不会大于5000
            foreach (int id in dist[key[0] - 'a'])
            {
                step = (id == 0) ? 0 : Math.Min(id - 0, len - id);
                result = Math.Min(result, step + 1 + dp[id]);
            }

            return result;
        }

        /// <summary>
        /// 与FindRotateSteps()逻辑一样，只是优化了复制数组的部分，没有太大的意义，写着玩的
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int FindRotateSteps2(string ring, string key)
        {
            int len = ring.Length;
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = new List<int>();
            for (int i = 0; i < len; i++) dist[ring[i] - 'a'].Add(i);

            int[] dp = new int[len], _dp = new int[len];
            for (int i = key.Length - 1, _step; i > 0; i--)
            {
                foreach (int sid in dist[key[i - 1] - 'a'])
                {
                    _dp[sid] = 5000;  // 题目的数据范围，结果不会大于5000
                    foreach (int did in dist[key[i] - 'a'])
                    {
                        _step = (did - sid) switch { > 0 => Math.Min(did - sid, len - did + sid), < 0 => Math.Min(sid - did, len - sid + did), _ => 0 };
                        _dp[sid] = Math.Min(_dp[sid], _step + 1 + dp[did]);
                    }
                }
                foreach (int id in dist[key[i - 1] - 'a']) dp[id] = _dp[id];
            }

            int result = 5000, step;  // 题目的数据范围，结果不会大于5000
            foreach (int id in dist[key[0] - 'a'])
            {
                step = (id == 0) ? 0 : Math.Min(id - 0, len - id);
                result = Math.Min(result, step + 1 + dp[id]);
            }

            return result;
        }
    }
}

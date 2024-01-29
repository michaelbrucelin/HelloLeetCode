using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0514
{
    public class Solution0514_2 : Interface0514
    {
        /// <summary>
        /// 逻辑同Solution0514，增加了记忆化搜索，Dictionary<(ringId, keyId), result>
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int FindRotateSteps(string ring, string key)
        {
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = new List<int>();
            for (int i = 0; i < ring.Length; i++) dist[ring[i] - 'a'].Add(i);

            Dictionary<(int ringId, int keyId), int> memory = new Dictionary<(int ringId, int keyId), int>();
            return dfs(dist, ring, 0, key, 0, memory);
        }

        /// <summary>
        /// dfs, 递归
        /// </summary>
        /// <param name="dist">ring中字符的分布</param>
        /// <param name="ring">ring</param>
        /// <param name="ringId">当前ring的位置</param>
        /// <param name="key">key</param>
        /// <param name="keyId">下一个要找的key中的字符</param>
        /// <param name="memory">记忆化搜索</param>
        /// <returns></returns>
        private int dfs(List<int>[] dist, string ring, int ringId, string key, int keyId, Dictionary<(int ringId, int keyId), int> memory)
        {
            if (keyId == key.Length) return 0;

            if (!memory.ContainsKey((ringId, keyId)))
            {
                if (ring[ringId] == key[keyId])
                {
                    memory.Add((ringId, keyId), dfs(dist, ring, ringId, key, keyId + 1, memory) + 1);
                }
                else
                {
                    int result = 5000, step;  // 题目的数据范围，结果不会大于5000
                    foreach (int id in dist[key[keyId] - 'a'])
                    {
                        step = id > ringId ? Math.Min(id - ringId, ring.Length - id + ringId) : Math.Min(ringId - id, ring.Length - ringId + id);
                        result = Math.Min(result, dfs(dist, ring, id, key, keyId + 1, memory) + step + 1);
                    }
                    memory.Add((ringId, keyId), result);
                }
            }

            return memory[(ringId, keyId)];
        }
    }
}

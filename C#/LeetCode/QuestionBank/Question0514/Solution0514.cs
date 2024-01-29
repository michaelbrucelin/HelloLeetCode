using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0514
{
    public class Solution0514 : Interface0514
    {
        /// <summary>
        /// 模拟，DFS，递归
        /// 
        /// 假定ring与key长度都是100，且都含有10个不同的字符，ring中每个字符出现10次，那么时间复杂度为10^100，显然比会TLE
        /// 逻辑没有问题，但是意料中的TLE，参考测试用例03
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int FindRotateSteps(string ring, string key)
        {
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = new List<int>();
            for (int i = 0; i < ring.Length; i++) dist[ring[i] - 'a'].Add(i);

            return dfs(dist, ring, 0, key, 0, 0);
        }

        /// <summary>
        /// dfs, 递归
        /// </summary>
        /// <param name="dist">ring中字符的分布</param>
        /// <param name="ring">ring</param>
        /// <param name="ringId">当前ring的位置</param>
        /// <param name="key">key</param>
        /// <param name="keyId">下一个要找的key中的字符</param>
        /// <param name="curr">当前累计的步数</param>
        /// <returns></returns>
        private int dfs(List<int>[] dist, string ring, int ringId, string key, int keyId, int curr)
        {
            if (keyId == key.Length) return curr;

            if (ring[ringId] == key[keyId])
            {
                return dfs(dist, ring, ringId, key, keyId + 1, curr + 1);
            }
            else
            {
                int result = 5000, step;  // 题目的数据范围，结果不会大于5000
                foreach (int id in dist[key[keyId] - 'a'])
                {
                    step = id > ringId ? Math.Min(id - ringId, ring.Length - id + ringId) : Math.Min(ringId - id, ring.Length - ringId + id);
                    result = Math.Min(result, dfs(dist, ring, id, key, keyId + 1, curr + step + 1));
                }
                return result;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0997
{
    public class Solution0997 : Interface0997
    {
        /// <summary>
        /// 遍历
        /// 由题意知，trust.length = n -1 是有法官的必要条件
        /// 用一个Dictionary<int, List<int>>记录每一个人都被哪些人信任
        /// </summary>
        /// <param name="n"></param>
        /// <param name="trust"></param>
        /// <returns></returns>
        public int FindJudge(int n, int[][] trust)
        {
            if (trust.Length < n - 1) return -1;
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; i++) dic.Add(i, new List<int>());
            foreach (var arr in trust)
            {
                if (dic.ContainsKey(arr[0])) dic.Remove(arr[0]);
                if (dic.Count == 0) return -1;
                if (dic.ContainsKey(arr[1])) dic[arr[1]].Add(arr[0]);
            }
            foreach (int key in dic.Keys) if (dic[key].Count != n - 1) dic.Remove(key);

            return dic.Count == 1 ? dic.First().Key : -1;
        }
    }
}

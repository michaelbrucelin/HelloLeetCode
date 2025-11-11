using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0474
{
    public class Solution0474 : Interface0474
    {
        /// <summary>
        /// DFS
        /// 使用DFS找全部的组合，注意剪枝，感觉会TLE
        /// 
        /// 意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindMaxForm(string[] strs, int m, int n)
        {
            int len = strs.Length;
            int[,] cnts = new int[len, 2];
            for (int i = 0; i < len; i++) foreach (char c in strs[i]) cnts[i, c & 15]++;

            int result = 0;
            dfs(-1, 0, 0, 0);
            return result;

            void dfs(int id, int _m, int _n, int cnt)
            {
                if (_m > m || _n > n) return;
                result = Math.Max(result, cnt);

                if (++id == len) return;
                dfs(id, _m, _n, cnt);
                dfs(id, _m + cnts[id, 0], _n + cnts[id, 1], cnt + 1);
            }
        }
    }
}

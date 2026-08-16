using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2029
{
    public class Solution2029 : Interface2029
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 逻辑没问题，栈溢出 + TLE，参考测试用例04
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public bool StoneGameIX(int[] stones)
        {
            int[] cnts = new int[3];
            foreach (int stone in stones) cnts[stone % 3]++;
            Dictionary<(bool, int, int, int, int), bool> memory = new Dictionary<(bool, int, int, int, int), bool>();
            return dfs(true, 0, cnts[0], cnts[1], cnts[2], memory);

            static bool dfs(bool isAlice, int total, int cnt0, int cnt1, int cnt2, Dictionary<(bool, int, int, int, int), bool> memory)
            {
                if (cnt0 == 0 && cnt1 == 0 && cnt2 == 0) return false;
                if (memory.ContainsKey((isAlice, total, cnt0, cnt1, cnt2))) return memory[(isAlice, total, cnt0, cnt1, cnt2)];

                bool result;
                if (isAlice)
                {
                    result = false;
                    switch (total % 3)
                    {
                        case 0:
                            if (!result && cnt1 > 0 && dfs(false, 1, cnt0, cnt1 - 1, cnt2, memory)) result = true;
                            if (!result && cnt2 > 0 && dfs(false, 2, cnt0, cnt1, cnt2 - 1, memory)) result = true;
                            break;
                        case 1:
                            if (!result && cnt0 > 0 && dfs(false, 1, cnt0 - 1, cnt1, cnt2, memory)) result = true;
                            if (!result && cnt1 > 0 && dfs(false, 2, cnt0, cnt1 - 1, cnt2, memory)) result = true;
                            break;
                        case 2:
                            if (!result && cnt0 > 0 && dfs(false, 2, cnt0 - 1, cnt1, cnt2, memory)) result = true;
                            if (!result && cnt2 > 0 && dfs(false, 1, cnt0, cnt1, cnt2 - 1, memory)) result = true;
                            break;
                    }
                }
                else
                {
                    result = true;
                    switch (total % 3)
                    {
                        case 0:
                            if (result && cnt1 > 0 && !dfs(true, 1, cnt0, cnt1 - 1, cnt2, memory)) result = false;
                            if (result && cnt2 > 0 && !dfs(true, 2, cnt0, cnt1, cnt2 - 1, memory)) result = false;
                            break;
                        case 1:
                            if (result && cnt0 > 0 && !dfs(true, 1, cnt0 - 1, cnt1, cnt2, memory)) result = false;
                            if (result && cnt1 > 0 && !dfs(true, 2, cnt0, cnt1 - 1, cnt2, memory)) result = false;
                            break;
                        case 2:
                            if (result && cnt0 > 0 && !dfs(true, 2, cnt0 - 1, cnt1, cnt2, memory)) result = false;
                            if (result && cnt2 > 0 && !dfs(true, 1, cnt0, cnt1, cnt2 - 1, memory)) result = false;
                            break;
                    }
                }

                memory.Add((isAlice, total, cnt0, cnt1, cnt2), result);
                return result;
            }
        }
    }
}

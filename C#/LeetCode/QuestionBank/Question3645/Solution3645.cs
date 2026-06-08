using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3645
{
    public class Solution3645 : Interface3645
    {
        /// <summary>
        /// 贪心 + 自定义排序 + 状态机
        /// 阅读理解题，题意是3个状态：未激活，已激活，永久非活跃（未激活，但不可被激活）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public long MaxTotal(int[] value, int[] limit)
        {
            int len = value.Length;
            int[] order = new int[len], state = new int[len];  // 0 未激活，1 已激活，2 永久非活跃
            for (int i = 0; i < len; i++) order[i] = i;
            Array.Sort(order, (x, y) => limit[x] != limit[y] ? limit[x] - limit[y] : value[y] - value[x]);

            long result = 0; int cnt = 0;
            for (int i = 0, j = 0, _cnt; i < len; i++)
            {
                if (cnt >= limit[order[i]] || state[order[i]] == 2) continue;
                result += value[order[i]];
                state[order[i]] = 1;
                cnt++;
                _cnt = cnt;
                while (j < len && limit[order[j]] <= _cnt)
                {
                    if (state[order[j]] == 1) cnt--;
                    state[order[j]] = 2;
                    j++;
                }
            }

            return result;
        }
    }
}

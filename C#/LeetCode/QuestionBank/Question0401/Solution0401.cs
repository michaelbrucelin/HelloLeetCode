using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0401
{
    public class Solution0401 : Interface0401
    {
        private static readonly List<int> HH = new List<int>() { 1, 2, 4, 8 };
        private static readonly List<int> MI = new List<int>() { 1, 2, 4, 8, 16, 32 };

        /// <summary>
        /// 组合
        /// 小时是由1, 2, 4, 8这4个数字中的几个组合而来，4次背包
        /// 分钟是由1, 2, 4, 8, 16, 32这6个数字中的几个组合而来，6次背包
        /// 简化
        /// 把小时与分钟连在一起分析，10次背包
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            List<string> result = new List<string>();
            for (int hh = 0, mi; hh <= turnedOn && hh <= 4; hh++)
            {
                if ((mi = turnedOn - hh) > 6) continue;
                List<string> hour = new List<string>(), minute = new List<string>();
                dfs_hour(0, hh, 0, hour); dfs_minute(0, mi, 0, minute);
                for (int i = 0; i < hour.Count; i++) for (int j = 0; j < minute.Count; j++)
                    {
                        result.Add($"{hour[i]}:{minute[j]}");
                    }
            }

            return result;
        }

        private void dfs_hour(int id, int cnt, int val, List<string> result)
        {
            if (cnt == 0 && val < 12) { result.Add(val.ToString()); return; }
            if (id >= HH.Count) return;
            dfs_hour(id + 1, cnt - 1, val + HH[id], result);  // 选
            dfs_hour(id + 1, cnt, val, result);               // 不选
        }

        private void dfs_minute(int id, int cnt, int val, List<string> result)
        {
            if (cnt == 0 && val < 60) { result.Add($"{val:D2}"); return; }
            if (id >= MI.Count) return;
            dfs_minute(id + 1, cnt - 1, val + MI[id], result);  // 选
            dfs_minute(id + 1, cnt, val, result);               // 不选
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0554
{
    public class Solution0554 : Interface0554
    {
        /// <summary>
        /// Hash
        /// 枚举，使用Hash表记录每个位置有多少个“缝”
        /// </summary>
        /// <param name="wall"></param>
        /// <returns></returns>
        public int LeastBricks(IList<IList<int>> wall)
        {
            int len = wall.Count;
            Dictionary<long, int> map = new Dictionary<long, int>();
            long pos; int cnt;
            foreach (List<int> list in wall)
            {
                pos = 0; cnt = list.Count - 1;
                for (int i = 0; i < cnt; i++)
                {
                    pos += list[i];
                    if (map.TryGetValue(pos, out int val)) map[pos] = ++val; else map.Add(pos, 1);
                }
            }

            int result = len;
            foreach (int val in map.Values) if (val == len) return 0; else result = Math.Min(result, len - val);
            return result;
        }
    }
}

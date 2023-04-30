using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1125
{
    public class Solution1125_2 : Interface1125
    {
        /// <summary>
        /// 与Solution1125一样，这里使用二进制枚举代替回溯
        /// </summary>
        /// <param name="req_skills"></param>
        /// <param name="people"></param>
        /// <returns></returns>
        public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
        {
            Dictionary<string, int> skmap = new Dictionary<string, int>();
            for (int i = 0; i < req_skills.Length; i++) skmap.Add(req_skills[i], i);
            Dictionary<int, int> skills = new Dictionary<int, int>();      // key是技能掩码，value是people的id
            for (int i = 0, mask; i < people.Count; i++)
            {
                if (people[i].Count == 0) continue;
                if (people[i].Count == req_skills.Length) return new int[] { i };
                mask = 0; for (int j = 0; j < people[i].Count; j++) mask |= 1 << skmap[people[i][j]];
                bool keep = true; Queue<int> remove = new Queue<int>();
                foreach (int key in skills.Keys)
                {
                    if ((key | mask) == key) { keep = false; break; }
                    else if ((key | mask) == mask) remove.Enqueue(key);
                }
                if (keep)
                {
                    skills.Add(mask, i);
                    while (remove.Count > 0) skills.Remove(remove.Dequeue());
                }
            }

            int all = (1 << req_skills.Length) - 1;                        // 全部技能的掩码
            int[] sk = new int[skills.Count], pp = new int[skills.Count];  // 将精简后的技能与人员转为数组，准备二进制枚举
            int id = 0; foreach (var kv in skills)
            {
                sk[id] = kv.Key; pp[id] = kv.Value; id++;
            }

            int[] result;
            for (int cnt = 2; cnt < sk.Length; cnt++)                      // 二进制枚举
            {
                result = BinaryEnum(sk, pp, sk.Length, cnt, all);
                if (result != null) return result;
            }

            return pp;
        }

        private int[] BinaryEnum(int[] sk, int[] pp, int n, int k, int all)
        {
            int[] result = new int[k];

            long kset = (1L << k) - 1, mask = 1L << n;
            while (kset < mask)
            {
                long _kset = kset; int skill = 0, i = 0, j = 0;
                while (_kset > 0)
                {
                    if ((_kset & 1) != 0)
                    {
                        skill |= sk[i]; result[j++] = pp[i];
                    }
                    _kset >>= 1; i++;
                }
                if (skill == all) return result;

                long x = kset & -kset, y = kset + x;
                kset = ((kset & ~y) / x >> 1) | y;
            }

            return null;
        }
    }
}

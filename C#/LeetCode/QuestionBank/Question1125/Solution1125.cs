using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1125
{
    public class Solution1125 : Interface1125
    {
        /// <summary>
        /// 分析
        /// 1. 最多有16种技能，所以每个人的技能表可以用一个整型掩码来表示
        /// 2. 假定其中两个人的技能掩码是m与n
        ///     如果m|n==m，那么只保留m，因为n是m的子集
        ///     如果m|n==n，那么只保留n，因为m是n的子集
        /// 3. 前两步处理完后，可以尝试1个人，2个人，... n个人，依次去尝试
        ///     当尝试k个人的时候，可以使用回溯的方式去遍历所有的可能
        ///     由于k<=60，所以也可以使用二进制枚举去遍历所有的可能
        /// 这里使用回溯的方式去遍历
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
            int[] sk = new int[skills.Count], pp = new int[skills.Count];  // 将精简后的技能与人员转为数组，准备回溯
            int id = 0; foreach (var kv in skills)
            {
                sk[id] = kv.Key; pp[id] = kv.Value; id++;
            }

            int[] result;
            for (int cnt = 2; cnt < sk.Length; cnt++)                      // 回溯
            {
                result = backtracking(sk, pp, 0, new List<int>(), cnt, 0, all);
                if (result != null) return result;
            }

            return pp;
        }

        private int[] backtracking(int[] sk, int[] pp, int skill, List<int> people, int cnt, int left, int all)
        {
            if (skill == all) return people.ToArray();
            if (cnt == 0 || left > sk.Length - cnt) return null;
            cnt--;
            for (int i = left, _skill; i < sk.Length; i++)
            {
                if ((_skill = skill | sk[i]) == skill) continue;

                List<int> _people = new List<int>(people) { pp[i] };
                int[] _result = backtracking(sk, pp, _skill, _people, cnt, i + 1, all);
                if (_result != null) return _result;
            }

            return null;
        }
    }
}

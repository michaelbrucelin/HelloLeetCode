using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0721
{
    public class Solution0721 : Interface0721
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            // 分组
            Dictionary<string, List<HashSet<string>>> map = new Dictionary<string, List<HashSet<string>>>();
            foreach (List<string> account in accounts)
            {
                string key = account[0];
                HashSet<string> set = new HashSet<string>(account[1..]);
                if (map.ContainsKey(key)) map[key].Add(set); else map.Add(key, new List<HashSet<string>>() { set });
            }

            // 合并
            foreach (string key in map.Keys)
            {
                for (int i = map[key].Count - 1; i >= 0; i--) for (int j = i - 1; j >= 0; j--) if (map[key][j].Overlaps(map[key][i]))
                        {
                            map[key][j].UnionWith(map[key][i]); map[key].RemoveAt(i); break;
                        }
            }

            // 排序，生成结果
            IList<IList<string>> result = new List<IList<string>>();
            Comparer<string> comparer = Comparer<string>.Create((x, y) => string.Compare(x, y, StringComparison.Ordinal));
            foreach (string key in map.Keys) foreach (HashSet<string> set in map[key])
                {
                    List<string> list = new List<string>(set);
                    list.Sort(comparer); list.Insert(0, key); result.Add(list);
                }

            return result;
        }
    }
}

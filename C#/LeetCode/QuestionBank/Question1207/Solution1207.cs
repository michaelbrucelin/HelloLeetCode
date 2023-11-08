using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1207
{
    public class Solution1207 : Interface1207
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in arr) if (map.ContainsKey(num)) map[num]++; else map.Add(num, 0);

            HashSet<int> set = new HashSet<int>();
            foreach (int cnt in map.Values) if (set.Contains(cnt)) return false; else set.Add(cnt);

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1157
{
    public class Solution1157_3
    {
    }

    /// <summary>
    /// “前缀和”
    /// 与Solution1157相同，额外增加了一个预处理的“前缀和”，以数字出现的次数作为key，value是出现key次的数字集合
    /// 
    /// 内存占用更高，没有提交测试
    /// </summary>
    public class MajorityChecker_3 : Interface1157
    {
        public MajorityChecker_3(int[] arr)
        {
            Comparer<int> comparer = Comparer<int>.Create((i1, i2) => i2 - i1);
            pre = new SortedDictionary<int, HashSet<int>>[arr.Length + 1];
            pre[0] = new SortedDictionary<int, HashSet<int>>(comparer);
            freq = new Dictionary<int, int>[arr.Length + 1];
            freq[0] = new Dictionary<int, int>();
            Dictionary<int, HashSet<int>> _pre = new Dictionary<int, HashSet<int>>();
            Dictionary<int, int> _freq = new Dictionary<int, int>();
            for (int i = 0, num; i < arr.Length; i++)
            {
                num = arr[i];
                if (_freq.ContainsKey(num))
                {
                    _pre[_freq[num]].Remove(num); if (_pre[_freq[num]].Count == 0) _pre.Remove(_freq[num]);
                    if (!_pre.ContainsKey(_freq[num] + 1)) _pre.Add(_freq[num] + 1, new HashSet<int>());
                    _pre[_freq[num] + 1].Add(num);
                    _freq[num]++;
                }
                else
                {
                    if (!_pre.ContainsKey(1)) _pre.Add(1, new HashSet<int>());
                    _pre[1].Add(num);
                    _freq.Add(num, 1);
                }

                freq[i + 1] = new Dictionary<int, int>(_freq);
                SortedDictionary<int, HashSet<int>> buf = new SortedDictionary<int, HashSet<int>>(comparer);
                foreach (var key in _pre.Keys) buf.Add(key, new HashSet<int>(_pre[key]));
                pre[i + 1] = buf;
            }
        }

        private Dictionary<int, int>[] freq;
        private SortedDictionary<int, HashSet<int>>[] pre;

        public int Query(int left, int right, int threshold)
        {
            foreach (int key in pre[right + 1].Keys)
            {
                if (key < threshold) break;
                foreach (int num in pre[right + 1][key])
                {
                    int cnt = key - (freq[left].ContainsKey(num) ? freq[left][num] : 0);
                    if (cnt >= threshold) return num;
                }
            }

            return -1;
        }
    }
}
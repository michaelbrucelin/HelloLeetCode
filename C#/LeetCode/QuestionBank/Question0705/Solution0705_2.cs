using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0705
{
    public class Solution0705_2
    {
    }

    /// 设计一个简单的hash表
    /// 由于题目的条件是
    ///     1. 0 <= key <= 10^6
    ///     2. 最多调用 10^4 次 add、remove 和 contains
    /// 那么就用一个dic = List<bool>[10001]来模拟，key的储存位置为dic[key/100][key%100]
    /// 至于更高级的，例如扩容，hash冲突时用红黑树之类的替代List<bool>这里就不展开了
    public class MyHashSet_2 : Interface0705
    {
        public MyHashSet_2()
        {
            set = new List<bool>[10001];
        }

        private List<bool>[] set;
        private const int MOD = 100;

        public void Add(int key)
        {
            var info = GetKey(key);
            int key1 = info.key1, key2 = info.key2;
            if (set[key1] == null) set[key1] = new List<bool>();
            int cnt = set[key1].Count;
            if (key2 < cnt)
            {
                set[key1][key2] = true;
            }
            else
            {
                for (int i = 0; i < key2 - cnt; i++) set[key1].Add(false);
                set[key1].Add(true);
            }
        }

        public bool Contains(int key)
        {
            var info = GetKey(key);
            int key1 = info.key1, key2 = info.key2;
            if (set[key1] == null || key2 > set[key1].Count - 1) return false;
            return set[key1][key2];
        }

        public void Remove(int key)
        {
            var info = GetKey(key);
            int key1 = info.key1, key2 = info.key2;
            if (set[key1] != null && key2 < set[key1].Count)
            {
                set[key1][key2] = false;
                int cnt = set[key1].Count;
                for (int i = cnt - 1; i >= 0; i--) if (!set[key1][i]) set[key1].RemoveAt(i); else break;
                if (set[key1].Count == 0) set[key1] = null;
            }
        }

        private (int key1, int key2) GetKey(int key)
        {
            var info = Math.DivRem(key, MOD);
            return (info.Quotient, info.Remainder);
        }
    }
}

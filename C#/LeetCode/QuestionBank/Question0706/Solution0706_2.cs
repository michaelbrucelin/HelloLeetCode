using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0706
{
    public class Solution0706_2
    {
    }

    /// <summary>
    /// 设计一个简单的hash表
    /// 由于题目的条件是
    ///     1. 0 <= key, value <= 10^6
    ///     2. 最多调用 10^4 次 put、get 和 remove 方法
    /// 那么就用一个dic = List<int>[10001]来模拟，key的储存位置为dic[key/100][key%100]
    /// 至于更高级的，例如扩容，hash冲突时用红黑树之类的替代List<int>这里就不展开了
    /// </summary>
    public class MyHashMap_2 : Interface0706
    {
        public MyHashMap_2()
        {
            dic = new List<int>[10001];
        }

        private List<int>[] dic;
        private const int MOD = 100;

        public int Get(int key)
        {
            var info = GetKey(key);
            int key1 = info.key1, key2 = info.key2;
            if (dic[key1] == null || key2 > dic[key1].Count - 1) return -1;
            return dic[key1][key2];
        }

        public void Put(int key, int value)
        {
            var info = GetKey(key);
            int key1 = info.key1, key2 = info.key2;
            if (dic[key1] == null) dic[key1] = new List<int>();
            int cnt = dic[key1].Count;
            if (key2 < cnt)
            {
                dic[key1][key2] = value;
            }
            else
            {
                for (int i = 0; i < key2 - cnt; i++) dic[key1].Add(-1);
                dic[key1].Add(value);
            }
        }

        public void Remove(int key)
        {
            var info = GetKey(key);
            int key1 = info.key1, key2 = info.key2;
            if (dic[key1] != null && key2 < dic[key1].Count)
            {
                dic[key1][key2] = -1;
                int cnt = dic[key1].Count;
                for (int i = cnt - 1; i >= 0; i--) if (dic[key1][i] == -1) dic[key1].RemoveAt(i); else break;
                if (dic[key1].Count == 0) dic[key1] = null;
            }
        }

        private (int key1, int key2) GetKey(int key)
        {
            var info = Math.DivRem(key, MOD);
            return (info.Quotient, info.Remainder);
        }
    }
}

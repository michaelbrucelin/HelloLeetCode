using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    public class Solution1825_2
    {
    }

    /// <summary>
    /// 用数组存储最后添加的m个元素
    /// 用SortedDictionary存储m个排列的元素（可以尝试使用SortedList或SkipList来实现）
    /// </summary>
    public class MKAverage_2 : Interface1825
    {
        public MKAverage_2(int m, int k)
        {
            this.m = m;
            this.k = k;
            this.id = 0;
            this.isfull = false;
            nums = new int[m];
            dic = new SortedDictionary<int, int>();
        }

        private int m, k, id;
        private bool isfull;
        private int[] nums;
        private SortedDictionary<int, int> dic;

        public void AddElement(int num)
        {
            if (isfull)
            {
                int rm = nums[id];
                nums[id] = num;
                if (dic[rm] > 1) dic[rm]--; else dic.Remove(rm);
                if (dic.ContainsKey(num)) dic[num]++; else dic.Add(num, 1);

                id = (id + 1) % m;
            }
            else
            {
                nums[id] = num;
                if (dic.ContainsKey(num)) dic[num]++; else dic.Add(num, 1);

                if (++id == m) { isfull = true; id = 0; }
            }
        }

        public int CalculateMKAverage()
        {
            if (isfull)
            {
                long sum = 0;
                int skip = k, need = m - (k << 1); int cnt = need;
                foreach (var kv in dic)
                {
                    int _key = kv.Key, _cnt = kv.Value;
                    if (skip > 0)
                    {
                        if (skip >= _cnt) skip -= _cnt;
                        else
                        {
                            _cnt -= skip; skip = 0;
                            if (_cnt >= need) return _key;
                            else
                            {
                                sum += _key * _cnt; need -= _cnt;
                            }
                        }
                    }
                    else
                    {
                        if (_cnt >= need)
                        {
                            sum += _key * need; break;
                        }
                        else
                        {
                            sum += _key * _cnt; need -= _cnt;
                        }
                    }
                }
                return (int)(sum / cnt);
            }
            else
            {
                return -1;
            }
        }
    }
}

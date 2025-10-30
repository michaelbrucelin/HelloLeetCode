using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1526
{
    public class Solution1526_2_wait : Interface1526
    {
        /// <summary>
        /// 分治
        /// 逻辑同Solution1526，Solution1526慢在每一次递归都需要重新遍历子数组来查找其最小值以及最小值的位置，产生了大量的重复运算
        /// 使用线段树思想和差分的思想是第一反应，但是貌似不好应用，这里只要先预处理出来数据的分布就可以了
        /// 
        /// 未完成，以后再说
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinNumberOperations(int[] target)
        {
            Dictionary<int, List<int>> map1 = new Dictionary<int, List<int>>() { { 0, [] } };  // 记录数组中每个值的分布
            Dictionary<int, int> map2 = new Dictionary<int, int>();                            // 记录数组中每个值的下一个最小值
            for (int i = 0; i < target.Length; i++) if (map1.TryGetValue(target[i], out List<int> value)) value.Add(i); else map1.Add(target[i], [i]);
            int id = 0, cnt = map1.Count;
            int[] keys = new int[cnt];
            foreach (int key in map1.Keys) keys[id++] = key;
            Array.Sort(keys);
            for (int i = 1; i < cnt; i++) map2.Add(keys[i - 1], keys[i]);

            return rec(0, target.Length - 1, 0, keys[1]);

            int rec(int left, int right, int lastmin, int min)
            {
                if (left > right) return 0;
                // if (left == right) return min - lastmin;
                if (map1[min][0] > right || map1[min][^1] < left) return 0;
                if (!map2.ContainsKey(min)) return min - lastmin;

                int result, nextmin = map2[min];
                int _l = UpperBound(map1[min], left);
                int _r = LowerBound(map1[min], right);

                result = min - lastmin;
                result += rec(left, map1[min][_l] - 1, min, nextmin);
                for (int i = _l + 1; i <= _r; i++) result += rec(map1[min][i - 1] + 1, map1[min][i] - 1, min, nextmin);
                result += rec(map1[min][_r] + 1, right, min, nextmin);

                return result;
            }

            int LowerBound(IList<int> list, int target)
            {
                int result = list.Count, low = 0, high = list.Count - 1, mid;
                while (low <= high)
                {
                    mid = low + ((high - low) >> 1);
                    if (list[mid] <= target)
                    {
                        result = mid; low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                return result;
            }

            int UpperBound(IList<int> list, int target)
            {
                int result = -1, low = 0, high = list.Count - 1, mid;
                while (low <= high)
                {
                    mid = low + ((high - low) >> 1);
                    if (list[mid] >= target)
                    {
                        result = mid; high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                return result;
            }
        }
    }
}

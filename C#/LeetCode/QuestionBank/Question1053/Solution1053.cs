using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1053
{
    public class Solution1053 : Interface1053
    {
        /// <summary>
        /// 贪心
        /// 1. 交换的两个元素，后面的元素必须比前面的元素小（交换后比原数组小，反证法即可证明）
        /// 2. 前面的元素无所谓大小，位置尽可能靠后就好（交换后比原数组小，位置越靠后，减少的越小）
        /// 3. 后边的元素无所谓位置，大小尽可能大就好，大小相同的情况下，选择靠前的
        /// 代码实现
        /// 1. 两层循环
        ///     1.1. 外层从后向前遍历每一个元素
        ///     1.2. 内层从外层当前元素向后遍历每一个元素，找到比内层元素小的最大元素
        ///     1.3. 找到的第一个就是答案
        /// 如果两层循环，O(n^2），如果将原数组预处理为有序字典，O(nlogn)
        /// 
        /// 暴力，两层循环
        /// 提交后竟然不超时
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] PrevPermOpt1(int[] arr)
        {
            int len = arr.Length, num, max, maxid;
            for (int i = len - 2; i >= 0; i--)
            {
                num = arr[i]; max = -1; maxid = -1;
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j] < num && arr[j] > max)
                    {
                        max = arr[j]; maxid = j;
                    }
                }
                if (max != -1)
                {
                    arr[i] = max; arr[maxid] = num;
                    return arr;
                }
            }

            return arr;
        }

        /// <summary>
        /// 与PrevPermOpt1()一样，将数组预处理为有序字典来优化
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] PrevPermOpt12(int[] arr)
        {
            int len = arr.Length;
            SortedDictionary<int, int> map = new SortedDictionary<int, int>(Comparer<int>.Create((i1, i2) => i2 - i1));
            for (int i = len - 2; i >= 0; i--)
            {
                if (map.ContainsKey(arr[i + 1])) map[arr[i + 1]] = i + 1; else map.Add(arr[i + 1], i + 1);
                foreach (var kv in map)
                {
                    if (kv.Key < arr[i])
                    {
                        arr[kv.Value] = arr[i]; arr[i] = kv.Key;
                        return arr;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// 与PrevPermOpt1()一样，将数组预处理为有序列表来优化
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] PrevPermOpt13(int[] arr)
        {
            int len = arr.Length;
            SortedList<int, int> list = new SortedList<int, int>();
            for (int i = len - 2, id; i >= 0; i--)
            {
                if (list.ContainsKey(arr[i + 1])) list[arr[i + 1]] = i + 1; else list.Add(arr[i + 1], i + 1);
                if ((id = BinarySearch(list, arr[i])) != -1)
                {
                    arr[list.Values[id]] = arr[i]; arr[i] = list.Keys[id];
                    return arr;
                }
            }

            return arr;
        }

        private int BinarySearch(SortedList<int, int> list, int target)
        {
            int result = -1, left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list.Keys[mid] < target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}

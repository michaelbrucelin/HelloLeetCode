using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3072
{
    public class Solution3072 : Interface3072
    {
        /// <summary>
        /// 暴力解
        /// 思路是维护4个数组，题目要求的 arr1, arr2 与 arr1, arr2 的有序版本
        /// 这样可以二分快速计算出 GreaterCount(arr, val) 的值，但是插入新值的复杂度太高
        /// 如果有一种数据结构可以快速插入新值且保持有序可以替换这里的有序数组
        ///     二叉搜索树应该不行，因为不能快速计算 GreaterCount(arr, val) 的值
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例05
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ResultArray(int[] nums)
        {
            int cnt1, cnt2, len = nums.Length;
            List<int> list1 = new List<int>() { nums[0] }, _list1 = new List<int>() { nums[0] };
            List<int> list2 = new List<int>() { nums[1] }, _list2 = new List<int>() { nums[1] };
            for (int i = 2, num; i < len; i++)
            {
                num = nums[i];
                cnt1 = GreaterCount(_list1, num); cnt2 = GreaterCount(_list2, num);
                switch (cnt1 - cnt2)
                {
                    case > 0: list1.Add(num); Insert(_list1, num, _list1.Count - cnt1); break;
                    case < 0: list2.Add(num); Insert(_list2, num, _list2.Count - cnt2); break;
                    default:
                        switch (list1.Count - list2.Count)
                        {
                            case > 0: list2.Add(num); Insert(_list2, num, _list2.Count - cnt2); break;
                            case < 0: list1.Add(num); Insert(_list1, num, _list1.Count - cnt1); break;
                            default: list1.Add(num); Insert(_list1, num, _list1.Count - cnt1); break;
                        }
                        break;
                }
            }

            int[] result = new int[len];
            int id = 0;
            for (int i = 0; i < list1.Count; i++) result[id++] = list1[i];
            for (int i = 0; i < list2.Count; i++) result[id++] = list2[i];

            return result;
        }

        private int GreaterCount(List<int> list, int val)
        {
            int gid = list.Count, left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid] > val)
                {
                    gid = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return list.Count - gid;
        }

        private void Insert(List<int> list, int val, int pos)
        {
            list.Add(val);
            int id = list.Count - 1;
            while (pos < id)
            {
                list[id] = list[id - 1];
                id--;
            }
            list[pos] = val;
        }

        private void Swap(List<int> list, int i, int j)
        {
            int temp = list[i]; list[i] = list[j]; list[j] = temp;
        }
    }
}

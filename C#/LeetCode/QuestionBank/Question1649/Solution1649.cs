using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1649
{
    public class Solution1649 : Interface1649
    {
        /// <summary>
        /// 插入排序 + 二分查找
        /// 感觉会TLE，先写出来试试
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例05
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public int CreateSortedArray(int[] instructions)
        {
            if (instructions.Length < 3) return 0;

            const int MOD = (int)1e9 + 7;
            int result = 0, len = instructions.Length;
            Dictionary<int, int> cnts = new Dictionary<int, int>() { { instructions[0], 1 } };
            int[] order = new int[len];
            order[0] = instructions[0];
            for (int i = 1, pos, num; i < len; i++)
            {
                num = instructions[i];
                pos = binary_search(0, i - 1, num);
                if (cnts.TryGetValue(num, out int cnt)) cnts[num] = cnt + 1; else cnts.Add(num, 1);
                result = (result + Math.Min(pos - cnt, i - pos)) % MOD;
                for (int j = i; j > pos; j--) order[j] = order[j - 1];
                order[pos] = num;
            }

            return result;

            int binary_search(int left, int right, int target)
            {
                int pos = -1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (order[mid] <= target)
                    {
                        pos = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return pos + 1;
            }
        }

        /// <summary>
        /// 逻辑同CreateSortedArray()，略加优化，对有大量重复值的情况有提高，但是如果没有重复值，相当于负优化了
        /// 优化：
        /// 插入排序时，每个值的数量已知，所以只需要最后一个向后移动一个位置即可
        /// 
        /// 逻辑没问题，提交依然TLE
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public int CreateSortedArray2(int[] instructions)
        {
            if (instructions.Length < 3) return 0;

            const int MOD = (int)1e9 + 7;
            int result = 0, len = instructions.Length;
            Dictionary<int, int> cnts = new Dictionary<int, int>() { { instructions[0], 1 } };
            int[] order = new int[len];
            order[0] = instructions[0];
            for (int i = 1, pos, num; i < len; i++)
            {
                num = instructions[i];
                pos = binary_search(0, i - 1, num);
                if (cnts.TryGetValue(num, out int cnt)) cnts[num] = cnt + 1; else cnts.Add(num, 1);
                result = (result + Math.Min(pos - cnt, i - pos)) % MOD;
                for (int j = i; j > pos; j -= cnt)
                {
                    cnt = cnts[order[j - 1]];
                    order[j] = order[j - 1];
                }
                order[pos] = num;
            }

            return result;

            int binary_search(int left, int right, int target)
            {
                int pos = -1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (order[mid] <= target)
                    {
                        pos = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return pos + 1;
            }
        }
    }
}

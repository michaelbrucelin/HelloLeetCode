using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1764
{
    public class Solution1764_3 : Interface1764
    {
        /// <summary>
        /// KMP解
        /// 理论上就是查找字符串的字串问题，所以字符串查找的算法都可以拿到这里来用
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanChoose(int[][] groups, int[] nums)
        {
            int start = 0;
            foreach (int[] arr in groups)
            {
                start = KMP(nums, start, arr);
                if (start == -1) return false;
                start += arr.Length;
            }

            return true;
        }

        private int KMP(int[] nums, int start, int[] arr)
        {
            int len_nums = nums.Length - start, len_arr = arr.Length;
            if (len_nums < len_arr) return -1;
            if (len_nums == len_arr)
            {
                for (int id = 0; id < len_arr; id++) if (nums[start + id] != arr[id]) return -1;
                return start;
            }

            int[] next = GetNext(arr);
            int i = start, j = 0, len = nums.Length;  // i是nums的索引，j是arr的索引
            while (len - i >= len_arr - j)
            {
                while (i < len && j < len_arr && nums[i] == arr[j]) { i++; j++; };

                if (j == len_arr) return i - len_arr;
                j = next[j];
                if (j == -1) { i++; j++; }
            }

            return -1;
        }

        private int[] GetNext(int[] arr)
        {
            if (arr.Length == 0) return new int[0];
            if (arr.Length == 1) return new int[1] { -1 };
            if (arr.Length == 2) return new int[2] { -1, 0 };

            int[] next = new int[arr.Length]; next[0] = -1; next[1] = 0;
            int i = 2, j = 0;
            while (i < arr.Length)
            {
                while (j >= 0 && arr[i - 1] != arr[j]) j = next[j];
                if (j == -1)
                {
                    if (arr[i] != arr[0]) next[i] = 0; else next[i] = -1;
                }
                else
                {
                    if (arr[i] != arr[j]) next[i] = j + 1; else next[i] = next[j];
                }
                i++; j++;
            }

            return next;
        }
    }
}

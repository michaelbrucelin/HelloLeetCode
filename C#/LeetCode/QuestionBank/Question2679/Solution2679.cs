using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2679
{
    public class Solution2679 : Interface2679
    {
        /// <summary>
        /// 排序
        /// 1. 每一行倒序排序，O(nmlogm)
        /// 2. 每一列遍历取最大值O(nm)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MatrixSum(int[][] nums)
        {
            int result = 0, _result, rcnt = nums.Length, ccnt = nums[0].Length;
            for (int r = 0; r < rcnt; r++) Array.Sort(nums[r], (i, j) => j - i);
            for (int c = 0; c < ccnt; c++)
            {
                _result = 0;
                for (int r = 0; r < rcnt; r++) _result = Math.Max(_result, nums[r][c]);
                result += _result;
            }

            return result;
        }

        /// <summary>
        /// 与MatrixSum()一样，只不过将使用API排序改为了计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MatrixSum2(int[][] nums)
        {
            int result = 0, _result, rcnt = nums.Length, ccnt = nums[0].Length;
            for (int r = 0; r < rcnt; r++) CountSort(nums[r]);
            for (int c = 0; c < ccnt; c++)
            {
                _result = 0;
                for (int r = 0; r < rcnt; r++) _result = Math.Max(_result, nums[r][c]);
                result += _result;
            }

            return result;
        }

        private void CountSort(int[] arr)
        {
            int[] cache = new int[1001];
            for (int i = 0; i < arr.Length; i++) cache[arr[i]]++;
            for (int i = 1000, j = 0; i >= 0; i--)
            {
                if (cache[i] > 0) for (int _i = 0; _i < cache[i]; _i++)
                    {
                        arr[j++] = i;
                    }
            }
        }

        /// <summary>
        /// 与MatrixSum3()一样，只不过将计数排序的缓冲区固化，节省内存
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MatrixSum3(int[][] nums)
        {
            int result = 0, _result, rcnt = nums.Length, ccnt = nums[0].Length;
            int[] cache = new int[1001];
            for (int r = 0; r < rcnt; r++) CountSort(nums[r], cache);
            for (int c = 0; c < ccnt; c++)
            {
                _result = 0;
                for (int r = 0; r < rcnt; r++) _result = Math.Max(_result, nums[r][c]);
                result += _result;
            }

            return result;
        }

        private void CountSort(int[] arr, int[] cache)
        {
            Array.Fill(cache, 0);
            for (int i = 0; i < arr.Length; i++) cache[arr[i]]++;
            for (int i = 1000, j = 0; i >= 0; i--)
            {
                if (cache[i] > 0) for (int _i = 0; _i < cache[i]; _i++)
                    {
                        arr[j++] = i;
                    }
            }
        }
    }
}

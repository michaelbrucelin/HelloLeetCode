using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1799
{
    public class Solution1799 : Interface1799
    {
        /// <summary>
        /// 暴力解
        /// 由于题目中n <= 7，所以这里使用暴力解
        /// 第1轮，使用数组中的第一个元素一次与后边的每一个元素做一个组合
        /// 第2轮，使用数组中剩余元素中第一个元素与后边的每一个元素做一个组合
        /// ... ...
        /// 
        /// 也可以数字来遍历，例如当n=3时，采用3进制遍历，遍历3进制的001122到221100，只要0 1 2各两次，就是一个合法的分组
        /// 所以当n=7时，遍历7进制的00112233445566到66554433221100，遍历次数太多（核心是无用的遍历比例太大），所以就不用了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxScore(int[] nums)
        {
            int result = 0;
            dfs(nums, new int[nums.Length >> 1], ref result);

            return result;
        }

        private void dfs(int[] nums, int[] buffer, ref int result)
        {
            int len = nums.Length;
            if (len > 2)
            {
                for (int i = 1; i < len; i++)
                {
                    int[] _buffer = buffer.ToArray();
                    _buffer[_buffer.Length - (len >> 1)] = GetGCD(nums[0], nums[i]);
                    dfs(nums.Where((_i, id) => id != 0 && id != i).ToArray(), _buffer, ref result);
                }
            }
            else  // if(len == 2)
            {
                buffer[buffer.Length - 1] = GetGCD(nums[0], nums[1]);
                Array.Sort(buffer);
                int _result = 0;
                for (int i = 0; i < buffer.Length; i++)
                {
                    _result += buffer[i] * (i + 1);
                }
                if (_result > result) result = _result;
            }
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            if ((x & 1) == 0 && (y & 1) == 0)
                return GetGCD(x >> 1, y >> 1) << 1;
            else if ((x & 1) == 0 && (y & 1) == 1)
                return GetGCD(x >> 1, y);
            else if ((x & 1) == 1 && (y & 1) == 0)
                return GetGCD(x, y >> 1);
            else
            {
                if (x > y)
                    return GetGCD(x - y, y);
                else
                    return GetGCD(x, y - x);
            }
        }
    }
}

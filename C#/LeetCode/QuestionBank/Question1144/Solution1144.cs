using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1144
{
    public class Solution1144 : Interface1144
    {
        /// <summary>
        /// 暴力解
        /// 1. 只有两种可能：/\/\/\或\/\/\/
        /// 2. 操作只能是将一个元素减小1，而不能将另一个元素增加1
        /// 那这道题难度是中等的理由是？
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MovesToMakeZigzag(int[] nums)
        {
            int result1 = 0, result2 = 0, len = nums.Length;

            // 第1种可能：/\/\/\
            int[] adjust = nums.ToArray(); bool up = true;
            for (int i = 1; i < len; i++, up = !up)
            {
                switch ((up, adjust[i] - adjust[i - 1]))
                {
                    case (true, <= 0):
                        result1 += adjust[i - 1] - adjust[i] + 1;
                        break;
                    case (false, >= 0):
                        result1 += adjust[i] - adjust[i - 1] + 1;
                        adjust[i] = adjust[i - 1] - 1;
                        break;
                }
            }

            // 第2种可能：\/\/\/
            Array.Copy(nums, adjust, len); up = false;
            for (int i = 1; i < len; i++, up = !up)
            {
                switch ((up, adjust[i] - adjust[i - 1]))
                {
                    case (true, <= 0):
                        result2 += adjust[i - 1] - adjust[i] + 1;
                        break;
                    case (false, >= 0):
                        result2 += adjust[i] - adjust[i - 1] + 1;
                        adjust[i] = adjust[i - 1] - 1;
                        break;
                }
                if (result2 > result1) break;
            }

            return Math.Min(result1, result2);
        }

        /// <summary>
        /// 与MovesToMakeZigzag()一样，使用编码手段精简代码
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MovesToMakeZigzag2(int[] nums)
        {
            int result = int.MaxValue, len = nums.Length;  // 由题意知，int.MaxValue是个合理的边界

            // 第1种可能：/\/\/\
            int[] adjust = nums.ToArray(); int _result = 0; bool up = true, repeat = true;
            Repeat:
            for (int i = 1; i < len; i++, up = !up)
            {
                switch ((up, adjust[i] - adjust[i - 1]))
                {
                    case (true, <= 0):
                        _result += adjust[i - 1] - adjust[i] + 1;
                        break;
                    case (false, >= 0):
                        _result += adjust[i] - adjust[i - 1] + 1;
                        adjust[i] = adjust[i - 1] - 1;
                        break;
                }
                if (_result > result) break;
            }
            result = Math.Min(result, _result);

            // 第2种可能：\/\/\/
            if (repeat)
            {
                Array.Copy(nums, adjust, len); _result = 0; up = false; repeat = false;
                goto Repeat;
            }

            return result;
        }
    }
}

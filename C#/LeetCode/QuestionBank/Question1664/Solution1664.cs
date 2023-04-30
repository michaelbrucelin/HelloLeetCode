using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace LeetCode.QuestionBank.Question1664
{
    public class Solution1664 : Interface1664
    {
        /// <summary>
        /// 预处理
        /// 具体见Solution1664.md
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WaysToMakeFair(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return 1; else if (len == 2) return 0;

            int result = 0;
            int[,] dp = new int[2, len + 1];
            for (int i = len - 1; i >= 0; i--)
            {
                dp[0, i] = dp[1, i + 1] + nums[i];
                dp[1, i] = dp[0, i + 1];
            }

            for (int i = 0; i < len; i++)
            {
                int odd, even;
                if ((i & 1) != 1)
                {
                    odd = dp[0, 0] - dp[0, i] + dp[0, i + 1];
                    even = dp[1, 0] - dp[1, i] + dp[1, i + 1];
                }
                else
                {
                    odd = dp[0, 0] - dp[0, i + 1] + dp[1, i + 1];
                    even = dp[1, 0] - dp[1, i + 1] - nums[i] + dp[0, i + 1];
                }
                if (odd == even) result++;
            }

            return result;
        }

        /// <summary>
        /// 逻辑与WaysToMakeFair()一样，使用滚动数组优化空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WaysToMakeFair2(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return 1; else if (len == 2) return 0;

            int odd = 0, even = 0, dp_odd = 0, dp_even = 0;
            for (int i = 0; i < len; i++) if ((i & 1) != 1) odd += nums[i]; else even += nums[i];

            int result = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                int _dp_odd = dp_even + nums[i], _dp_even = dp_odd;
                int _odd, _even;
                if ((i & 1) != 1)
                {
                    _odd = odd - _dp_odd + dp_odd;
                    _even = even - _dp_even + dp_even;
                }
                else
                {
                    _odd = odd - dp_odd + dp_even;
                    _even = even - dp_even - nums[i] + dp_odd;
                }
                if (_odd == _even) result++;
                dp_odd = _dp_odd; dp_even = _dp_even;
            }

            return result;
        }
    }
}

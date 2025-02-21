using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1016
{
    public class Solution1016 : Interface1016
    {
        /// <summary>
        /// 暴力枚举
        /// 1. 从n向1进行验证，因为更大的十进制拥有更长的二进制，不存在的可能性更大，更容易被剪枝
        /// 2. 如果n存在，那么n>>1, n>>2, ... 1 就一定都存在，使用一个mask做标记
        /// 
        /// 逻辑没问题，提交会内存溢出，参考测试用例03（本地测试挺快的）
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool QueryString(string s, int n)
        {
            bool[] mask = new bool[n + 1];  // 可以使用无符号整型数组优化空间复杂度，每个无符号整型记录32个值
            string _str;
            for (int i = n, j; i > 0; i--)
            {
                if (mask[i]) continue;
                _str = Convert.ToString(i, 2);
                if (s.Contains(_str))       // 由于s是固定的，可以一次性生成好next数组，然后自己写KMP来优化时间复杂度
                {
                    j = i; while (j >= 1) { mask[j] = true; j >>= 1; }
                }
                else return false;
            }

            return true;
        }

        /// <summary>
        /// 暴力枚举
        /// 与QueryString()一样，将mask数组改为无符号整型数组，每个无符号整型记录32个值
        /// 1. n的mask在mask[n>>32]（mask[n/32]）的第n&32-1（n%32-1）位，如果n&32==0，是第32位
        /// 2. mask[i]的第j位，表示((i-1)<<5)+j+1（(i-1)*32+j+1）
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool QueryString2(string s, int n)
        {
            uint[] mask = new uint[(n >> 5) + 1]; const int _m = 31;
            string _str;
            for (int _n = n, __n = 0, i = 0, j = 0; _n > 0; _n--)
            {
                i = _n >> 5; j = _n & _m; j = j != 0 ? j - 1 : _m;
                if (((mask[i] >> j) & 1) == 1) continue;

                _str = Convert.ToString(_n, 2);
                if (s.Contains(_str))            // 由于s是固定的，可以一次性生成好next数组，然后自己写KMP来优化时间复杂度
                {
                    mask[i] |= 1u << j;
                    __n = _n >> 1; while (__n >= 1)
                    {
                        i = __n >> 5; j = __n & _m; j = j != 0 ? j - 1 : _m;
                        mask[i] |= 1u << j;
                        __n >>= 1;
                    }
                }
                else return false;
            }

            return true;
        }
    }
}

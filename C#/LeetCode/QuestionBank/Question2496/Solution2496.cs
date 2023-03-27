using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2496
{
    public class Solution2496 : Interface2496
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MaximumValue(string[] strs)
        {
            int result = 0;
            for (int i = 0, _r; i < strs.Length; i++)
            {
                _r = 0;
                for (int j = 0; j < strs[i].Length; j++)
                {
                    if (char.IsDigit(strs[i][j]))
                    {
                        _r = _r * 10 + (strs[i][j] & 15);
                    }
                    else
                    {
                        _r = strs[i].Length; break;
                    }
                }
                result = Math.Max(result, _r);
            }

            return result;
        }

        /// <summary>
        /// 模拟
        /// 更多的用API
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MaximumValue2(string[] strs)
        {
            int result = 0, _r;
            foreach (string str in strs)
            {
                _r = str.All(c => char.IsDigit(c)) ? int.Parse(str) : str.Length;
                result = Math.Max(result, _r);
            }

            return result;
        }

        /// <summary>
        /// 模拟
        /// 更多的用API
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MaximumValue3(string[] strs)
        {
            int result = 0, _r;
            foreach (string str in strs)
            {
                if (!int.TryParse(str, out _r)) _r = str.Length;
                result = Math.Max(result, _r);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2516
{
    public class Solution2516 : Interface2516
    {
        /// <summary>
        /// 分别记录从前向后，从后向前1个 2个 ... k个 a b c 的数量，然后双指针即可
        /// 
        /// 未完成，没时间，不写了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int TakeCharacters(string s, int k)
        {
            int len = s.Length;
            if (len < k * 3) return -1;

            int[,] prefix = new int[3, k + 1], suffix = new int[3, k + 1];
            int[] ptr = new int[3];
            for (int i = 0, _ptr; i < len && (ptr[0] < k || ptr[1] < k || ptr[2] < k); i++)
            {
                _ptr = s[i] - 'a';
                if (++ptr[_ptr] <= k) prefix[_ptr, ptr[_ptr]] = i + 1;
            }
            if (prefix[0, k] == 0 || prefix[1, k] == 0 || prefix[2, k] == 0) return -1;

            Array.Fill(ptr, 0);
            for (int i = len - 1, _ptr; i >= 0 && (ptr[0] < k || ptr[1] < k || ptr[2] < k); i--)
            {
                _ptr = s[i] - 'a';
                if (++ptr[_ptr] <= k) suffix[_ptr, ptr[_ptr]] = i + 1;
            }
            if (suffix[0, k] == 0 || suffix[1, k] == 0 || suffix[2, k] == 0) return -1;

            throw new NotImplementedException();
        }
    }
}

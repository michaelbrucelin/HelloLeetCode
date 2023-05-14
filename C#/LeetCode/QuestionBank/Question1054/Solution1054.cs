using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1054
{
    public class Solution1054 : Interface1054
    {
        /// <summary>
        /// 贪心 + 构造
        /// 1. 将数组元素计数，按照数量由多到少排列
        ///     [1,2,1,1,2,1,3,3] -> [1,1,1,1,2,2,3,3]
        /// 2. 将元素按照0, 2, 4,...1, 3, 5...的顺序放到新的数组中
        /// 简要证明：
        /// 1. 首先题目保证了一定有解，那么
        ///     如果数组的长度是偶数，数组中数量最多的那个元素的数目一定小于等于len/2
        ///     如果数组的长度是奇数，数组中数量最多的那个元素的数目一定小于等于len/2+1
        /// 2. 类似于摩尔投票的机制，按照上面方法构造的新数组，一定不存在相邻相等的元素
        /// </summary>
        /// <param name="barcodes"></param>
        /// <returns></returns>
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            int len = barcodes.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int code in barcodes)
                if (dic.ContainsKey(code)) dic[code]++; else dic.Add(code, 1);
            (int code, int cnt)[] codes = new (int code, int cnt)[dic.Count];
            int _i = 0; foreach (var kv in dic) codes[_i++] = (kv.Key, kv.Value);
            Array.Sort(codes, (t1, t2) => t2.cnt - t1.cnt);

            int[] result = new int[len];
            _i = 0; for (int i = 0; i < codes.Length; i++) for (int j = 0; j < codes[i].cnt; j++)
                {
                    result[_i] = codes[i].code;
                    _i = _i >= len - 2 ? 1 : _i + 2;
                }

            return result;
        }
    }
}

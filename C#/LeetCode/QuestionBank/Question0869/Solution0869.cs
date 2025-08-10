using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0869
{
    public class Solution0869 : Interface0869
    {
        /// <summary>
        /// Hash
        /// 题目范围内的2的幂，一共有29个
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool ReorderedPowerOf2(int n)
        {
            HashSet<int> set = new HashSet<int>();
            int[] freq = new int[10];
            for (int i = 0; i < 30; i++) set.Add(gethashint(1 << i));
            return set.Contains(gethashint(n));

            int gethashint(int x)  // 这里使用最大的字典序整数做为hash值
            {
                Array.Fill(freq, 0);
                while (x > 0) { freq[x % 10]++; x /= 10; }
                int y = 0;
                for (int i = 9; i >= 0; i--) for (int j = 0; j < freq[i]; j++) y = y * 10 + i;
                return y;
            }
        }
    }
}

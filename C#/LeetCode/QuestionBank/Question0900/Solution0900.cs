using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0900
{
    public class Solution0900
    {
    }

    /// <summary>
    /// 模拟
    /// </summary>
    public class RLEIterator : Interface0900
    {
        public RLEIterator(int[] encoding)
        {
            this.encoding = encoding;
            idx = 0;
        }

        private int[] encoding;
        private int idx;

        public int Next(int n)
        {
            while (idx < encoding.Length && encoding[idx] < n) { n -= encoding[idx]; idx += 2; }
            if (idx >= encoding.Length) return -1;
            encoding[idx] -= n;
            return encoding[idx + 1];  // 题目限定encoding长度为偶数，所以idx+1一定有效
        }
    }
}

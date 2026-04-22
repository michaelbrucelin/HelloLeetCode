using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2526
{
    public class Solution2526
    {
    }

    /// <summary>
    /// 模拟
    /// </summary>
    public class DataStream
    {
        public DataStream(int value, int k)
        {
            this.value = value; this.k = k; cnt = 0;
        }

        private int value, k, cnt;

        public bool Consec(int num)
        {
            if (num == value) cnt++; else cnt = 0;
            return cnt >= k;
        }
    }
}

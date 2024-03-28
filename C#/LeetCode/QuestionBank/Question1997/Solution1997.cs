using LeetCode.QuestionBank.Question0895;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1997
{
    public class Solution1997 : Interface1997
    {
        /// <summary>
        /// 模拟
        /// 
        /// 逻辑没问题，TLE，参考测试用例04
        /// </summary>
        /// <param name="nextVisit"></param>
        /// <returns></returns>
        public int FirstDayBeenInAllRooms(int[] nextVisit)
        {
            const int MOD = (int)1e9 + 7;
            int result = -1, ptr = 0, len = nextVisit.Length, visitCnt = 0;
            bool[] visited = new bool[len];
            bool[] freq = new bool[len];
            while (visitCnt < len)
            {
                if (++result == MOD) result = 0;
                if (!visited[ptr]) { visitCnt++; visited[ptr] = true; }
                ptr = (freq[ptr] = !freq[ptr]) ? nextVisit[ptr] : (ptr + 1) % len;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0365
{
    public class Solution0365_2 : Interface0365
    {
        /// <summary>
        /// 逻辑与Solution0365一样，只是没有应用“ax + by = c 有整数解的充要条件是 gcd(a, b) | c”这一定理
        /// 而是自行使用代码去找整数解
        /// ax + by = c，x = (c - by)/a，枚举y即可，如果不存在整数解，最多枚举a-1次（余数从1至a-1），余数就会出现循环
        /// </summary>
        /// <param name="jug1Capacity"></param>
        /// <param name="jug2Capacity"></param>
        /// <param name="targetCapacity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (jug1Capacity + jug2Capacity < targetCapacity) return false;

            bool[] visited = new bool[jug1Capacity];
            for (long y = 0, r; ; y++)
            {
                r = (targetCapacity + jug2Capacity * y) % jug1Capacity;
                if (r == 0) return true;
                if (visited[r]) return false;
                visited[r] = true;
            }
        }
    }
}

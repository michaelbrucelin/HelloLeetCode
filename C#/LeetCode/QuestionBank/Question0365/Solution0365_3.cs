using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0365
{
    public class Solution0365_3 : Interface0365
    {
        /// <summary>
        /// 模拟
        /// 没有实际意义，但是这是一个绝好的联系代码模拟真实世界的案例，有点像代码模拟“汉诺塔”，写着玩一下
        /// 逻辑同官解中的描述，这里就不再赘述了
        /// 
        /// 实操栈溢出了，看着像是超过递归层数的限制（确实是超出clr默认的递归层数了，参考Solution0365_3_2）
        /// Stack overflow.
        ///    at System.Collections.Generic.HashSet`1[[System.ValueTuple`2[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e],[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].FindItemIndex(System.ValueTuple`2<Int32,Int32>)
        ///    at System.Collections.Generic.HashSet`1[[System.ValueTuple`2[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e],[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].Contains(System.ValueTuple`2<Int32,Int32>)
        ///    at LeetCode.QuestionBank.Question0365.Solution0365_3.dfs(Int32, Int32, Int32, System.ValueTuple`2<Int32,Int32>, System.Collections.Generic.HashSet`1<System.ValueTuple`2<Int32,Int32>>)
        ///    at LeetCode.QuestionBank.Question0365.Solution0365_3.dfs(Int32, Int32, Int32, System.ValueTuple`2<Int32,Int32>, System.Collections.Generic.HashSet`1<System.ValueTuple`2<Int32,Int32>>)
        /// </summary>
        /// <param name="jug1Capacity"></param>
        /// <param name="jug2Capacity"></param>
        /// <param name="targetCapacity"></param>
        /// <returns></returns>
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (jug1Capacity + jug2Capacity < targetCapacity) return false;

            HashSet<(int c1, int c2)> visited = new HashSet<(int c1, int c2)>();

            return dfs(jug1Capacity, jug2Capacity, targetCapacity, (0, 0), visited);
        }

        private bool dfs(int c1, int c2, int tar, (int c1, int c2) curr, HashSet<(int c1, int c2)> visited)
        {
            if (curr.c1 == tar || curr.c2 == tar || curr.c1 + curr.c2 == tar) return true;
            if (visited.Contains(curr)) return false;
            visited.Add(curr);

            (int c1, int c2) next;
            next = (0, curr.c2);
            if (next != curr && dfs(c1, c2, tar, next, visited)) return true;                 // A桶清空
            next = (curr.c1, 0);
            if (next != curr && dfs(c1, c2, tar, next, visited)) return true;                 // B桶清空
            next = (c1, curr.c2);
            if (next != curr && dfs(c1, c2, tar, next, visited)) return true;                 // A桶装满
            next = (curr.c1, c2);
            if (next != curr && dfs(c1, c2, tar, next, visited)) return true;                 // B桶装满
            next = (Math.Max(curr.c1 - (c2 - curr.c2), 0), Math.Min(curr.c2 + curr.c1, c2));
            if (next != curr && dfs(c1, c2, tar, next, visited)) return true;                 // A桶倒入B桶
            next = (Math.Min(curr.c1 + curr.c2, c1), Math.Max(curr.c2 - (c1 - curr.c1), 0));
            if (next != curr && dfs(c1, c2, tar, next, visited)) return true;                 // B桶倒入A桶

            return false;
        }
    }
}

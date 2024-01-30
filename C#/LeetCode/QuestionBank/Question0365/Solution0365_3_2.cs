using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0365
{
    public class Solution0365_3_2 : Interface0365
    {
        /// <summary>
        /// 模拟
        /// 逻辑同Solution0365_2，只是将递归改为了循环，这样就可以突破clr默认的递归层数的限制
        /// </summary>
        /// <param name="jug1Capacity"></param>
        /// <param name="jug2Capacity"></param>
        /// <param name="targetCapacity"></param>
        /// <returns></returns>
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (jug1Capacity + jug2Capacity < targetCapacity) return false;

            HashSet<(int c1, int c2)> visited = new HashSet<(int c1, int c2)>();
            Stack<(int c1, int c2)> stack = new Stack<(int c1, int c2)>();
            stack.Push((0, 0));
            (int c1, int c2) ptr, next;
            while (stack.Count > 0)
            {
                while (stack.Count > 0 && visited.Contains(stack.Peek())) stack.Pop();
                if (stack.Count == 0) break;
                ptr = stack.Pop();

                if (ptr.c1 == targetCapacity || ptr.c2 == targetCapacity || ptr.c1 + ptr.c2 == targetCapacity) return true;
                visited.Add(ptr);

                if ((next = (0, ptr.c2)) != ptr) stack.Push(next);                                                                               // A桶清空
                if ((next = (ptr.c1, 0)) != ptr) stack.Push(next);                                                                               // B桶清空
                if ((next = (jug1Capacity, ptr.c2)) != ptr) stack.Push(next);                                                                    // A桶装满
                if ((next = (ptr.c1, jug2Capacity)) != ptr) stack.Push(next);                                                                    // B桶装满
                if ((next = (Math.Max(ptr.c1 - (jug2Capacity - ptr.c2), 0), Math.Min(ptr.c2 + ptr.c1, jug2Capacity))) != ptr) stack.Push(next);  // A桶倒入B桶
                if ((next = (Math.Min(ptr.c1 + ptr.c2, jug1Capacity), Math.Max(ptr.c2 - (jug1Capacity - ptr.c1), 0))) != ptr) stack.Push(next);  // B桶倒入A桶
            }

            return false;
        }
    }
}

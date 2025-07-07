using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1353
{
    public class Solution1353_err : Interface1353
    {
        /// <summary>
        /// 贪心
        /// 1. 将events按 开始事件,结束时间 升序排序
        /// 2. 遍历每一个events，尽可能选择靠左的时间
        /// 
        /// 没有证明方法的正确性
        /// 
        /// 没经过证明的贪心就是不靠谱，参考测试用例03
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public int MaxEvents(int[][] events)
        {
            Array.Sort(events, (x, y) => x[0] != y[0] ? x[0] - y[0] : x[1] - y[1]);
            int result = 0, choose = 0;
            foreach (int[] _event in events) if (choose < _event[1])
                {
                    choose = choose < _event[0] ? _event[0] : choose + 1;
                    result++;
                }

            return result;
        }
    }
}

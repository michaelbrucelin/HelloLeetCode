using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0160
{
    public class Solution0160
    {
    }

    /// <summary>
    /// 无脑排序
    /// 
    /// 意料之中的TLE，参考测试用例03
    /// </summary>
    public class MedianFinder : Interface0160
    {
        public MedianFinder()
        {
            list = [];
            sort = false;
        }

        private List<int> list;
        private bool sort;

        public void AddNum(int num)
        {
            list.Add(num);
            sort = false;
        }

        public double FindMedian()
        {
            list.Sort();
            sort = true;

            int cnt = list.Count;
            return (cnt & 1) == 1 ? list[cnt >> 1] : (1D * list[cnt >> 1] + list[(cnt >> 1) - 1]) / 2;
        }
    }
}

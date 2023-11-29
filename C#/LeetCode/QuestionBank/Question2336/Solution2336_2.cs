using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2336
{
    public class Solution2336_2
    {
    }

    /// <summary>
    /// 逻辑与Solution2336一样，只是这里将记录缺失值，改为了记录缺失区间
    /// </summary>
    public class SmallestInfiniteSet_2 : Interface2336
    {
        public SmallestInfiniteSet_2()
        {
            lost = new List<(int l, int r)>() { (0, 0) };
        }

        private List<(int l, int r)> lost;

        public void AddBack(int num)
        {
            int id = -1, left = 0, right = lost.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (lost[mid].l <= num && num <= lost[mid].r)
                {
                    id = mid; break;
                }
                if (lost[mid].r < num) left = mid + 1; else right = mid - 1;
            }

            if (id != -1)
            {
                var rng = lost[id];
                if (rng.l == rng.r)
                {
                    lost.RemoveAt(id);
                }
                else
                {
                    if (rng.l == num) lost[id] = (num + 1, rng.r);
                    else if (rng.r == num) lost[id] = (rng.l, num - 1);
                    else
                    {
                        lost.Add((-1, -1));
                        for (int i = lost.Count - 1; i > id + 1; i--) lost[i] = lost[i - 1];
                        lost[id] = (rng.l, num - 1); lost[id + 1] = (num + 1, rng.r);
                    }
                }
            }
        }

        public int PopSmallest()
        {
            int result = lost[0].r + 1;
            lost[0] = (0, lost[0].r + 1);
            if (lost.Count > 1 && lost[0].r + 1 == lost[1].l)
            {
                lost[0] = (0, lost[1].r); lost.RemoveAt(1);
            }

            return result;
        }
    }
}

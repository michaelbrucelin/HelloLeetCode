using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1526
{
    public class Solution1526 : Interface1526
    {
        /// <summary>
        /// 分治
        /// 同样的逆操作把target中的元素全部变为0即可
        /// 1. 计算数组的最小值为min，操作min次，然后最小值变为0
        /// 2. 以0为分隔点，将数组分为若干子数组，对每个子数组重复第一步
        /// 
        /// 可能会很慢，可以考虑用线段树思想或差分数组的思想来优化，先写出来试试
        /// 逻辑没问题，意料之中的TLE，参考测试用例05
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinNumberOperations(int[] target)
        {
            return rec(0, target.Length - 1, 0);

            int rec(int left, int right, int donecnt)  // 使用donecnt记录已经执行过的操作，这样就不用真的去更改数组了
            {
                if (left > right) return 0;
                if (left == right) return target[left] - donecnt;

                int result, min = target[left];
                List<int> ids = [left];
                for (int i = left + 1; i <= right; i++) if (target[i] <= min)
                    {
                        if (target[i] < min)
                        {
                            min = target[i];
                            ids.Clear();
                        }
                        ids.Add(i);
                    }
                result = min - donecnt;
                result += rec(left, ids[0] - 1, min);
                for (int i = 1; i < ids.Count; i++) result += rec(ids[i - 1] + 1, ids[i] - 1, min);
                result += rec(ids[^1] + 1, right, min);

                return result;
            }
        }
    }
}

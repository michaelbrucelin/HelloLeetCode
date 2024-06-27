using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0448
{
    public class Solution0448_2 : Interface0448
    {
        /// <summary>
        /// 逐位判断
        /// 由题目提示才想到的O(1)空间，O(n)时间的解法
        /// 指针从前向后遍历，如果当前位的值大于0，则将对应位的值改为-1（先把这一位的值取出来）
        ///     如果取出来的值也是-1，指针继续向后移动
        ///     如果取出来的值大于0，沿着取出来的值继续往下替换
        /// 参考下面的例子
        /// index: [  0   1   2   3   4   5   6   7 ]
        /// value: [  4,  3,  2,  7,  8,  2,  3,  1 ]
        ///        [  4,  3,  2,  7,  8,  2,  3,  1 ]  指针在 0，值是  4
        ///        [  4,  3,  2, -1,  8,  2,  3,  1 ]  指针在 0，值是  7
        ///        [  4,  3,  2, -1,  8,  2, -1,  1 ]  指针在 0，值是  3
        ///        [  4,  3, -1, -1,  8,  2, -1,  1 ]  指针在 0，值是  2
        ///        [  4, -1, -1, -1,  8,  2, -1,  1 ]  指针在 0，值是  3
        ///        [  4, -1, -1, -1,  8,  2, -1,  1 ]  指针在 0，值是 -1
        ///        [  4, -1, -1, -1,  8,  2, -1,  1 ]  指针在 4，值是  8
        ///        [  4, -1, -1, -1,  8,  2, -1, -1 ]  指针在 4，值是  1
        ///        [ -1, -1, -1, -1,  8,  2, -1, -1 ]  指针在 4，值是  4
        ///        [ -1, -1, -1, -1,  8,  2, -1, -1 ]  指针在 4，值是 -1
        ///        [ -1, -1, -1, -1,  8,  2, -1, -1 ]  指针在 5，值是 -1
        ///        [ -1, -1, -1, -1,  8,  2, -1, -1 ]  指针越界
        /// 遍历一次数组，值不是-1的位置，就是缺少的值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            for (int i = 0, next, _next; i < nums.Length; i++)
            {
                if ((next = nums[i]) == -1) continue;
                while (next != -1)
                {
                    _next = nums[next - 1]; nums[next - 1] = -1; next = _next;
                }
            }

            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++) if (nums[i] != -1) result.Add(i + 1);

            return result;
        }

        /// <summary>
        /// 与FindDisappearedNumbers()类似，但是并不是将对应位置标记为-1来记录值存在，而是将值的第18位置为1
        /// 题目中n<=100000，15位整型就可以放得下
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers2(int[] nums)
        {
            const int flag = 1 << 16, mask = (1 << 16) - 1;
            int len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i] & mask;
                nums[num - 1] |= flag;
            }

            List<int> result = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if ((nums[i] & flag) != flag) result.Add(i + 1);
            }

            return result;
        }
    }
}

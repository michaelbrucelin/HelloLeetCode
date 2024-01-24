using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2865
{
    public class Solution2865 : Interface2865
    {
        /// <summary>
        /// 单调栈
        /// 枚举数组中的每一项，通过单调栈可以快速计算出以当前元素为峰值时，左右两边的“和”
        /// 两次单调栈，具体见Solution2865.png
        /// </summary>
        /// <param name="maxHeights"></param>
        /// <returns></returns>
        public long MaximumSumOfHeights(IList<int> maxHeights)
        {
            int len = maxHeights.Count;
            long[] l2r = new long[len], r2l = new long[len];
            Stack<(int val, int cnt, long sum)> stack = new Stack<(int val, int cnt, long sum)>();

            // 左至右
            stack.Push((0, 0, 0));
            for (int i = 0, _val, _cnt; i < len; i++)
            {
                _val = maxHeights[i];
                if (_val > stack.Peek().val)
                {
                    stack.Push((_val, 1, stack.Peek().sum + _val));
                }
                else  // if (_val <= stack.Peek().val)
                {
                    _cnt = 1;
                    while (stack.Peek().val >= _val)
                    {
                        _cnt += stack.Pop().cnt;
                    }
                    stack.Push((_val, _cnt, (long)_val * _cnt + stack.Peek().sum));
                }
                l2r[i] = stack.Peek().sum;
            }

            // 右至左
            stack.Clear(); stack.Push((0, 0, 0));
            for (int i = len - 1, _val, _cnt; i >= 0; i--)
            {
                _val = maxHeights[i];
                if (_val > stack.Peek().val)
                {
                    stack.Push((_val, 1, stack.Peek().sum + _val));
                }
                else  // if (_val <= stack.Peek().val)
                {
                    _cnt = 1;
                    while (stack.Peek().val >= _val)
                    {
                        _cnt += stack.Pop().cnt;
                    }
                    stack.Push((_val, _cnt, (long)_val * _cnt + stack.Peek().sum));
                }
                r2l[i] = stack.Peek().sum;
            }

            long result = 0;
            for (int i = 0; i < len; i++)
                result = Math.Max(result, l2r[i] + r2l[i] - maxHeights[i]);

            return result;
        }

        /// <summary>
        /// 逻辑与MaximumSumOfHeights()完全一样，只是从代码层面做了些优化
        /// </summary>
        /// <param name="maxHeights"></param>
        /// <returns></returns>
        public long MaximumSumOfHeights2(IList<int> maxHeights)
        {
            int len = maxHeights.Count;
            long[] l2r = new long[len];
            Stack<(int val, int cnt, long sum)> stack = new Stack<(int val, int cnt, long sum)>();

            // 左至右
            stack.Push((0, 0, 0));
            for (int i = 0, _val, _cnt; i < len; i++)
            {
                _val = maxHeights[i];
                if (_val > stack.Peek().val)
                {
                    stack.Push((_val, 1, stack.Peek().sum + _val));
                }
                else  // if (_val <= stack.Peek().val)
                {
                    _cnt = 1;
                    while (stack.Peek().val >= _val)
                    {
                        _cnt += stack.Pop().cnt;
                    }
                    stack.Push((_val, _cnt, (long)_val * _cnt + stack.Peek().sum));
                }
                l2r[i] = stack.Peek().sum;
            }

            // 右至左
            long result = 0;
            stack.Clear(); stack.Push((0, 0, 0));
            for (int i = len - 1, _val, _cnt; i >= 0; i--)
            {
                _val = maxHeights[i];
                if (_val > stack.Peek().val)
                {
                    stack.Push((_val, 1, stack.Peek().sum + _val));
                }
                else  // if (_val <= stack.Peek().val)
                {
                    _cnt = 1;
                    while (stack.Peek().val >= _val)
                    {
                        _cnt += stack.Pop().cnt;
                    }
                    stack.Push((_val, _cnt, (long)_val * _cnt + stack.Peek().sum));
                }
                result = Math.Max(result, l2r[i] + stack.Peek().sum - maxHeights[i]);
            }

            return result;
        }
    }
}

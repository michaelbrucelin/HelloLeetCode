using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1186
{
    public class Solution1186 : Interface1186
    {
        /// <summary>
        /// 分析
        /// 具体见Solution1186.md
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaximumSum(int[] arr)
        {
            if (arr.Length == 1) return arr[0];

            List<int> list = new List<int>() { arr[0] };
            for (int i = 1, num; i < arr.Length; i++)
            {
                num = arr[i];
                if (num < 0)
                {
                    list.Add(num);
                }
                else
                {
                    if (list[^1] < 0) list.Add(num); else list[^1] += num;
                }
            }
            int len = list.Count;
            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + list[i];
            Stack<int> stack = new Stack<int>(); stack.Push(len - 1);
            for (int i = len - 2; i >= 0; i--)
            {
                if (pre[i + 1] > pre[stack.Peek() + 1]) stack.Push(i);
            }

            int result = list[0], minid = 0, _result;
            for (int i = 0; i < len - 1; i++)
            {
                if (pre[i] < pre[minid]) minid = i;
                while (i >= stack.Peek()) stack.Pop();  // stack.Count > 0 一定成立，无需判断
                _result = pre[stack.Peek() + 1] - pre[minid] - (list[i] < 0 ? list[i] : 0);
                result = Math.Max(result, _result);
            }
            // 最后一项没有使用哨兵，单独判断
            if (pre[len - 1] < pre[minid])
            {
                result = Math.Max(result, list[len - 1]);  // minid = len - 1，至少选一项
            }
            else
            {
                _result = pre[len] - pre[minid] - (list[len - 1] < 0 ? list[len - 1] : 0);
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}

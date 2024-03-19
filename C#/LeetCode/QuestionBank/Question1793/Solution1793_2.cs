using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1793
{
    public class Solution1793_2 : Interface1793
    {
        /// <summary>
        /// 双指针
        /// 逻辑同Solution1793，只是将mins数据改为栈
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumScore(int[] nums, int k)
        {
            int len = nums.Length;
            Stack<(int num, int idx)> stack_l = new Stack<(int num, int idx)>();
            stack_l.Push((nums[k], k));
            for (int i = k - 1; i >= 0; i--)
                if (nums[i] < stack_l.Peek().num) stack_l.Push((nums[i], i)); else stack_l.Push((stack_l.Pop().num, i));
            Stack<(int num, int idx)> stack_r = new Stack<(int num, int idx)>();
            stack_r.Push((nums[k], k));
            for (int i = k + 1; i < len; i++)
                if (nums[i] < stack_r.Peek().num) stack_r.Push((nums[i], i)); else stack_r.Push((stack_r.Pop().num, i));

            int result = nums[k], _result;
            (int num, int idx) pl, pr;
            while (stack_l.Count > 1 || stack_r.Count > 1)
            {
                pl = stack_l.Peek(); pr = stack_r.Peek();
                _result = Math.Min(pl.num, pr.num) * (pr.idx - pl.idx + 1);
                result = Math.Max(result, _result);
                switch (pl.num - pr.num)
                {
                    case > 0:
                        stack_r.Pop(); break;
                    case < 0:
                        stack_l.Pop(); break;
                    default:  // == 0
                        if (pl.num == nums[k])
                        {
                            stack_l.Clear();
                        }
                        else
                        {
                            stack_l.Pop(); stack_r.Pop();
                        }
                        break;
                }
            }
            if (stack_l.Count > 0 && stack_r.Count > 0)
            {
                pl = stack_l.Peek(); pr = stack_r.Peek();
                _result = Math.Min(pl.num, pr.num) * (pr.idx - pl.idx + 1);
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}

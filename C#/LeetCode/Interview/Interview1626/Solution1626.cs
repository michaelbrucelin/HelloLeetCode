using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1626
{
    public class Solution1626 : Interface1626
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            List<int> nums = new List<int>();
            List<char> opts = new List<char>();

            int num = 0;
            foreach (char c in s) switch (c)
                {
                    case ' ': break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        nums.Add(num); num = 0; opts.Add(c);
                        break;
                    default:
                        num = num * 10 + c - '0';
                        break;
                }
            nums.Add(num);

            for (int i = 0; i < opts.Count; i++) switch (opts[i])
                {
                    case '*':
                        nums[i] *= nums[i + 1]; nums.RemoveAt(i + 1); opts.RemoveAt(i); i--;
                        break;
                    case '/':
                        nums[i] /= nums[i + 1]; nums.RemoveAt(i + 1); opts.RemoveAt(i); i--;
                        break;
                    default: break;
                }

            for (int i = 0; i < opts.Count; i++) switch (opts[i])
                {
                    case '+': nums[0] += nums[i + 1]; break;
                    case '-': nums[0] -= nums[i + 1]; break;
                    default: break;
                }

            return nums[0];
        }
    }
}
